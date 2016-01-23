using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;
using System.Web.Http;
using System.Collections;
using System.Runtime;


namespace MVC.Services
{
    public class OcenyRepository
    {
        private const string CacheKey = "OcenaStore";


        public OcenyRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var oceny = new Oceny[]
                    {
                        new Oceny { Id = 1, Nazwisko = "Boszke", Ocena = 5 },
                        new Oceny { Id = 2, Nazwisko = "Adamiakowa", Ocena = 3.5F },
                        new Oceny { Id = 3, Nazwisko = "Kowalski",  Ocena = 2 }
                    };

                    ctx.Cache[CacheKey] = oceny;
                }
            }
        }        
        
        //Zwraca całą tablicę
        //URL: /api/books/
        public Oceny[] GetAllOceny()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Oceny[])ctx.Cache[CacheKey];
            }

            return new Oceny[]
            {
                new Oceny
                {
                    Id = 0,
                    Nazwisko = "",
                    Ocena = 0
                }
            };
        }

        

        public bool SaveOcena(Oceny ocena)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Oceny[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(ocena);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }

    }
}