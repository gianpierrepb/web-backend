using Moments.Models;
using Moments.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Moments.Controllers
{
    [RoutePrefix("Moment")]
    public class MomentController : ApiController
    {
        [Route("Moments")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    List<MomentWebApi> moments = new List<MomentWebApi>();
                    foreach (Moment moment in context.Moment.ToList())
                    {
                        ApplicationUser user = context.Users.Find(moment.UserId);
                        moments.Add(new MomentWebApi
                        {
                            Nombre = user.NombreCompleto,
                            altitud = moment.altitud,
                            deleted = moment.deleted,
                            description = moment.description,
                            duration = moment.duration,
                            latitud = moment.latitud
                        });
                    }

                    return Ok(moments);
                }
            }
            catch
            {
                return InternalServerError();
            }
           
        }

        [Route("Moment")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Moment mom = context.Moment.Find(id);
                    ApplicationUser user = context.Users.Find(mom.UserId);
                    MomentWebApi moment = new MomentWebApi
                    {
                        Nombre = user.NombreCompleto,
                        altitud = mom.altitud,
                        deleted = mom.deleted,
                        description = mom.description,
                        duration = mom.duration,
                        latitud = mom.latitud
                    };

                    return Ok(moment);
                }
            }
            catch
            {
                return InternalServerError();
            }
        }

        [Route("Moment")]
        [HttpPost]
        public IHttpActionResult Post(string latitud, string altitud, string description, int duration)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Moment moment = new Moment();
                    moment.altitud = altitud;
                    moment.latitud = latitud;
                    moment.description = description;
                    moment.duration = duration;
                    context.Moment.Add(moment);
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }

        [Route("Moment")]
        [HttpPut]
        public IHttpActionResult Put(int id, string latitud, string altitud, string description, int duration)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Moment moment = context.Moment.Find(id);
                    moment.altitud = altitud;
                    moment.latitud = latitud;
                    moment.description = description;
                    moment.duration = duration;
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [Route("Moment")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Moment moment = context.Moment.Find(id);
                    context.Moment.Remove(moment);
                    return Ok();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            
        }
    }
    public class MomentWebApi
    {
        public string Nombre { get; set; }
        public string latitud { get; set; }
        public string altitud { get; set; }
        public string description { get; set; }
        public bool deleted { get; set; }
        public int duration { get; set; }
    }
}
