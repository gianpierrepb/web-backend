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
    [Authorize]
    [RoutePrefix("Plan")]
    public class PlanController : ApiController
    {
        [Route("Plans")]
        public IEnumerable<Plan> Get()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Plan.ToList();
            }
        }


        [Route("Plan")]
        public Plan Get(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Plan.Find(id);
            }
        }

        [Route("Plan")]
        public IHttpActionResult Post(string description)
        {
            using (var context = new ApplicationDbContext())
            {
                Plan Plan = new Plan();
                Plan.description = description;
                context.SaveChanges();
                return Ok();
            }
        }

        [Route("Plan")]
        public IHttpActionResult Put(int id, string description)
        {
            using (var context = new ApplicationDbContext())
            {
                Plan Plan = context.Plan.Find(id);
                Plan.description = description;
                context.SaveChanges();
                return Ok();
            }
        }

        [Route("Plan")]
        public IHttpActionResult Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                Plan Plan = context.Plan.Find(id);
                context.Plan.Remove(Plan);
                return Ok();
            }
        }
    }
}
