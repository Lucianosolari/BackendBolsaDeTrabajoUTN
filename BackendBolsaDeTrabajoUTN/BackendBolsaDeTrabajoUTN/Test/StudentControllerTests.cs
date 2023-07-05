using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using BackendBolsaDeTrabajoUTN.Controllers;
using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Models;
using BackendBolsaDeTrabajoUTN.Entities;

namespace BackendBolsaDeTrabajoUTN.Tests
{ 
public class StudentControllerTests
{
    [Fact]
    public void CreateStudent_ValidData_ReturnsCreatedResult()
    {
        // Arrange
        var studentRepositoryMock = new Mock<IStudentRepository>();
        var companyRepositoryMock = new Mock<ICompanyRepository>();
        var studentOfferRepositoryMock = new Mock<IStudentOfferRepository>();
        var studentKnowledgeRepositoryMock = new Mock<IStudentKnowledgeRepository>();

        var controller = new StudentController(
            studentRepositoryMock.Object,
            companyRepositoryMock.Object,
            studentOfferRepositoryMock.Object,
            studentKnowledgeRepositoryMock.Object);

        var request = new AddStudentRequest
        {
            UserName = "john.doe",
            Password = "P@ssw0rd",
            ConfirmPassword = "P@ssw0rd",
            File = 1234,
            Name = "John",
            Surname = "Doe",
            UserEmail = "john.doe@example.com",
            AltEmail = "john.alt@example.com",
            DocumentType = "DNI",
            DocumentNumber = 12345678,
            CUIL_CUIT = 12345678901234,
            Birth = new DateTime(1990, 1, 1),
            Sex = "Male",
            CivilStatus = "Single"
        };

        studentRepositoryMock.Setup(repo => repo.GetUsers()).Returns(new List<User>());
        studentRepositoryMock.Setup(repo => repo.GetStudents()).Returns(new List<Student>());
        studentRepositoryMock.Setup(repo => repo.CreateStudent(It.IsAny<Student>())).Verifiable();

        // Act
        var result = controller.CreateStudent(request);

        // Assert
        var createdResult = Assert.IsType<CreatedResult>(result);
        Assert.Equal("Estudiante creado", createdResult.Value);
        studentRepositoryMock.Verify(repo => repo.CreateStudent(It.IsAny<Student>()), Times.Once);
    }

    [Fact]
    public void CreateStudent_InvalidData_ReturnsBadRequest()
    {
        // Arrange
        var studentRepositoryMock = new Mock<IStudentRepository>();
        var companyRepositoryMock = new Mock<ICompanyRepository>();
        var studentOfferRepositoryMock = new Mock<IStudentOfferRepository>();
        var studentKnowledgeRepositoryMock = new Mock<IStudentKnowledgeRepository>();

        var controller = new StudentController(
            studentRepositoryMock.Object,
            companyRepositoryMock.Object,
            studentOfferRepositoryMock.Object,
            studentKnowledgeRepositoryMock.Object);

        var request = new AddStudentRequest
        {
            // Set the request properties with invalid values for testing
            UserName = "john.doe",
            Password = "password",
            ConfirmPassword = "differentpassword",
            File = 0,
            Name = null,
            Surname = null,
            UserEmail = "invalidemail",
            AltEmail = "invalidemail",
            DocumentType = "InvalidType",
            DocumentNumber = 0,
            CUIL_CUIT = 0,
            Birth = DateTime.Now,
            Sex = "InvalidSex",
            CivilStatus = "InvalidStatus"
        };

        // Act
        var result = controller.CreateStudent(request);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }    
}
}

