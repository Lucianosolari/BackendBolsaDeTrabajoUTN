﻿using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using BackendBolsaDeTrabajoUTN.Models;
using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;

namespace BackendBolsaDeTrabajoUTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IConfiguration config, IUserRepository userRepository)
        {
            _config = config; //Hacemos la inyección para poder usar el appsettings.json
            this._userRepository = userRepository;

        }

        [HttpPost("authenticate")] //Vamos a usar un POST ya que debemos enviar los datos para hacer el login
        public ActionResult<string> Autenticar(AuthenticationRequestBody authenticationRequestBody) //Enviamos como parámetro la clase que creamos arriba
        {
            //Paso 1: Validamos las credenciales
            var user = _userRepository.ValidateUser(authenticationRequestBody); //Lo primero que hacemos es llamar a una función que valide los parámetros que enviamos.

            if (user is null) //Si el la función de arriba no devuelve nada es porque los datos son incorrectos, por lo que devolvemos un Unauthorized (un status code 401).
                return Unauthorized();

            //Paso 2: Crear el token
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            //Los claims son datos en clave->valor que nos permite guardar data del usuario.
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserId.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
            claimsForToken.Add(new Claim("given_name", user.UserName)); //cambiar todo a user y no student //Lo mismo para given_name y family_name, son las convenciones para nombre y apellido. Ustedes pueden usar lo que quieran, pero si alguien que no conoce la app //quiere usar la API por lo general lo que espera es que se estén usando estas keys //Debería venir del usuario
            if (user.UserType == "Company")
            {
                claimsForToken.Add(new Claim("role", "Company"));
            }
            else if (user.UserType == "Admin") // si el usuario es un Admin, agregar el claim de 'role' con el valor 'Admin'
            {
                claimsForToken.Add(new Claim("role", "Admin"));
            }
            else
            {
                claimsForToken.Add(new Claim("role", "Student"));
            }

            claimsForToken.Add(new Claim("userType", user.UserType));


            var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
                .WriteToken(jwtSecurityToken);

            return Ok(new { Token = tokenToReturn, UserType = user.UserType, UserId = user.UserId });
        }

        //[HttpPost("logout")]
        //public IActionResult Logout()
        //{
        //    // Eliminar el token estableciendo una fecha de expiración anterior a la actual
        //    var expirationDate = DateTime.UtcNow.AddMinutes(-1); // Establecer una fecha de expiración anterior a la actual

        //    var tokenDescriptor = new JwtSecurityTokenDescriptor
        //    {
        //        // Otros parámetros del token (issuer, audience, claims, etc.)
        //        NotBefore = DateTime.UtcNow, // La fecha a partir de la cual el token es válido
        //        Expires = expirationDate // La fecha de expiración del token
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var jwtSecurityToken = tokenHandler.CreateToken(tokenDescriptor);
        //    var tokenToReturn = tokenHandler.WriteToken(jwtSecurityToken);

        //    // Devolver una respuesta exitosa junto con el nuevo token que indica que el cierre de sesión fue exitoso
        //    return Ok(new { Message = "Logout successful", Token = tokenToReturn });
        //}

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Eliminar el token almacenado en el cliente
            // Esto podría implicar borrar el token del almacenamiento local, cookies, etc.
            // Aquí se proporciona un ejemplo utilizando el almacenamiento local (LocalStorage) en un navegador web
            HttpContext.Response.Cookies.Delete("token");

            // Devolver una respuesta exitosa (status code 200) o cualquier otra información relevante
            return Ok(new { Message = "Logout successful" });
        }

    }
}
