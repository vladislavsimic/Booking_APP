using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookingApp.Models;
using BookingApp.Models.AppModel;

namespace BookingApp.Controllers.API
{
    [RoutePrefix("country")]
    public class CountriesController : ApiController
    {
        private BAContext db = new BAContext();

        [AllowAnonymous]
        [HttpGet]
        [Route("countries", Name = "CountryApi")]
        public IHttpActionResult GetCountries()
        {
            var l = this.db.Countries.ToList();
            
            if (l == null)
            {
                return NotFound();
            }

            return Ok(l);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("country/{id}")]
        [ResponseType(typeof(Country))]
        public IHttpActionResult GetCountry(int id)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [Authorize(Roles="Admin")]
        [HttpPut]
        [Route("country/{id}")]
        [ResponseType(typeof(Country))]
        public IHttpActionResult PutCountry(int id, Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.Id)
            {
                return BadRequest();
            }

            db.Entry(country).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(country);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("country")]
        [ResponseType(typeof(Country))]
        public IHttpActionResult PostCountry(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool countryExists = false;
            foreach (var item in db.Countries)
            {
                if (item.Name.Equals(country.Name) && item.Code.Equals(country.Code))
                {
                    countryExists = true;
                    break;
                }
            }

            if (countryExists == false)
            {
                db.Countries.Add(country);
                db.SaveChanges();

                return CreatedAtRoute("CountryApi", new { id = country.Id }, country);
            }
            else
            {
                return BadRequest();
            }

            
        }

        [Authorize(Roles="Admin")]
        [HttpDelete]
        [Route("country/{id}")]
        [ResponseType(typeof(Country))]
        public IHttpActionResult DeleteCountry(int id)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            db.Countries.Remove(country);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (db.Countries.Find(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryExists(int id)
        {
            return db.Countries.Count(e => e.Id == id) > 0;
        }
    }
}