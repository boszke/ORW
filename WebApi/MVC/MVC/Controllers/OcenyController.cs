using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC.Models;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Collections;
using MVC.Services;

namespace MVC.Controllers
{
    public class OcenyController : ApiController
    {
        private OcenyRepository ocenaRepository;

        public OcenyController()
        {
            this.ocenaRepository = new OcenyRepository();
        }

        public Oceny[] Get()
        {
            return ocenaRepository.GetAllOceny();
        }

        public HttpResponseMessage Post(Oceny ocena)
        {
            this.ocenaRepository.SaveOcena(ocena);

            var response = Request.CreateResponse<Oceny>(System.Net.HttpStatusCode.Created, ocena);

            return response;
        }
    }
}
