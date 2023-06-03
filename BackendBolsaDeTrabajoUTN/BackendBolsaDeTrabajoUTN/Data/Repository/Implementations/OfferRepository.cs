﻿using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;
using BackendBolsaDeTrabajoUTN.DBContexts;
using BackendBolsaDeTrabajoUTN.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendBolsaDeTrabajoUTN.Data.Repository
{
    public class OfferRepository : IOfferRepository
    {
        
        private readonly TPContext _context;
        public OfferRepository(TPContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<Offer>> GetOffersByCompany(int companyId)
        {
            try
            {
                return _context.Offers.Where(o => o.CompanyId == companyId).ToList();
            }
            catch
            {
                throw new Exception("La empresa no tiene ofertas");
            }
        }


        public ActionResult<IEnumerable<Offer>> GetOffers()
        {
            try
            {
                return _context.Offers.Include(o => o.Company).ToList();
            }
            catch
            {
                throw new Exception("No se encontraron ofertas");
            }
        }
        //public List<Offer> GetTrials() 
        //{
        //    return _context.Trials.ToList();
        //}

        //public Offer? GetSingleTrial(int id)
        //{
        //    try
        //    {
        //        return _context.Trials.First(x => x.Id == id);
        //    }
        //    catch
        //    {
        //        throw new Exception("Trial no encontrado");
        //    }
        //}

        

        //public void RemoveTrial(int id)
        //{
        //    try
        //    {
        //        _context.Trials.Remove(_context.Trials.First(x => x.Id == id));
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw new Exception("Trial no encontrado, revisar si el Id es correcto.");
        //    }
        //}

        //public void EditTrialDistance(int id, int newDistance)
        //{
        //    try
        //    {
        //        _context.Trials.First(t => t.Id == id).Distance = newDistance;
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw new Exception("Trial no encontrado, revisar si el Id es correcto");
        //    }
        //}

        //public void EditTrialStyle(int id, string newStyle)
        //{
        //    try
        //    {
        //        _context.Trials.First(t => t.Id == id).Style = newStyle;
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw new Exception("Trial no encontrado, revisar si el Id es correcto");
        //    }
        //}

        //public List<Company> GetExistingMeets()
        //{
        //    return _context.Meets.ToList();
        //}

        //public List<Student> GetRegisteredSwimmers(int id)
        //{
        //    return _context.Swimmers.Where(s => s.TrialId == id).ToList();
        //}

        //public Company GetTrialMeet(int id)
        //{
        //    return _context.Meets.First(m => m.Id == id);
        //}

        //public string GetTrialMeetName(int id)
        //{
        //    return _context.Meets.First(m => m.Id == id).MeetName;
        //}
    }
}