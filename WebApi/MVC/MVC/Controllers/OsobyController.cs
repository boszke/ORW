using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC.Models;
using System.Web.Http;
using System.Net;
using System.Collections;
using System.Diagnostics;
using MVC.Services;

namespace MVC.Controllers
{
    public class OsobyController : ApiController
    {
        //
        // GET: /Osoby/
        private OcenyRepository ocenaRepository;
        
        Osoba[] Osoby = new Osoba[]
        {
            new Osoba { Id = 1, Nazwisko = "Boszke", Ocena = 5 },
            new Osoba { Id = 2, Nazwisko = "Adamiakowa", Ocena = 3.5F },
            new Osoba { Id = 3, Nazwisko = "Kowalski",  Ocena = 2 }
        };
        

        //cała tablica
        public IEnumerable GetAllOsoby()
        {
            return Osoby;
        }

        public IHttpActionResult GetOsoba(int id)
        {
            var osobnik = Osoby.FirstOrDefault((p) => p.Id == id);
            if (osobnik == null)
            {
                return NotFound();
            }
            return Ok(osobnik);
        }
    }
}
