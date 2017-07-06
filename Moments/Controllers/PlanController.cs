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
        public IHttpActionResult Get()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    List<PlanWebApi> plans = (from plan in context.Plan
                                              select new PlanWebApi
                                              {
                                                  descripcion = plan.description,
                                                  id = plan.id,
                                                  price = plan.price
                                              }).ToList();

                    return Ok(plans);
                }
            }
            catch (Exception)
            {

                return InternalServerError();
            }
            
        }


        [Route("Plan")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                using(var context = new ApplicationDbContext())
                {
                    Plan plan = context.Plan.Find(id);
                    return Ok(new PlanWebApi
                    {
                        descripcion = plan.description,
                        id = plan.id,
                        price = plan.price
                    });
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("Plan")]
        public IHttpActionResult Post(string description, decimal price)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Plan Plan = new Plan();
                    Plan.description = description;
                    Plan.price = price;
                    context.Plan.Add(Plan);
                    context.SaveChanges();
                    return Ok();
                }

            }
            catch (Exception)
            {

                return InternalServerError();
            }
            
        }

        [Route("Plan")]
        public IHttpActionResult Put(int id, string description, decimal price)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Plan Plan = context.Plan.Find(id);
                    Plan.description = description;
                    Plan.price = price;
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {

                return InternalServerError();
            }
            
        }

        [Route("Plan")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Plan Plan = context.Plan.Find(id);
                    context.Plan.Remove(Plan);
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {

                return InternalServerError();
            }
            
        }

    }

    public class PlanWebApi
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public decimal price { get; set; }
    }
}
