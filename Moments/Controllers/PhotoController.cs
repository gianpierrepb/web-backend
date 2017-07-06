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
    [RoutePrefix("Photo")]
    public class PhotoController : ApiController
    {
        [Route("Photos")]
        public IEnumerable<Photo> Get()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Photo.ToList();
            }
        }

        [Route("Photo")]
        public Photo Get(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Photo.Find(id);
            }
        }

        //[Route("Photo")]
        //public IHttpActionResult Post(int MomentId, string description)
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        Photo Photo = new Photo();
        //        Photo.url = description;
        //        context.SaveChanges();
        //        return Ok();
        //    }
        //}

        //[Route("Photo")]
        //public IHttpActionResult Put(int id, int MomentId, string description)
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        Photo Photo = context.Photo.Find(id);
        //        Photo.description = description;
        //        context.SaveChanges();
        //        return Ok();
        //    }
        //}

        //[Route("Photo")]
        //public IHttpActionResult Delete(int id)
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        Photo Photo = context.Photo.Find(id);
        //        context.Photo.Remove(Photo);
        //        return Ok();
        //    }
        //}
    }
}
