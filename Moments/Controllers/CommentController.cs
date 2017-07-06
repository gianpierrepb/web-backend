using Microsoft.AspNet.Identity;
using Moments.Models;
using Moments.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Comments.Controllers
{
    [RoutePrefix("Comment")]
    public class CommentController : ApiController
    {
        [Route("Comments")]
        public IHttpActionResult Get()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    List<CommentWebApi> moments = new List<CommentWebApi>();
                    foreach (Comment comment in context.Comment.ToList())
                    {
                        ApplicationUser user = context.Users.Find(comment.UserId);
                        moments.Add(new CommentWebApi
                        {
                            NombreCompleto = user.NombreCompleto,
                            description = comment.description,
                            id = comment.id
                        });
                    }

                    return Ok(moments);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            
        }

        [Route("Comment")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Comment comm = context.Comment.Find(id);
                    ApplicationUser user = context.Users.Find(comm.UserId);
                    CommentWebApi comment = new CommentWebApi
                    {
                        description = comm.description,
                        id = comm.id,
                        NombreCompleto = comm.User.NombreCompleto
                    };

                    return Ok(comment);
                }
            }
            catch (Exception)
            {

                return InternalServerError();
            }
            
        }

        [Route("Comment")]
        public IHttpActionResult Post(int MomentId, string description)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Comment Comment = new Comment();
                    Comment.UserId = User.Identity.GetUserId();
                    Comment.MomentId = MomentId;
                    Comment.description = description;
                    context.Comment.Add(Comment);
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("Comment")]
        public IHttpActionResult Put(int id, int MomentId, string description)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Comment Comment = context.Comment.Find(id);
                    Comment.UserId = User.Identity.GetUserId();
                    Comment.MomentId = MomentId;
                    Comment.description = description;
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("Comment")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Comment Comment = context.Comment.Find(id);
                    context.Comment.Remove(Comment);
                    return Ok();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }

    public class CommentWebApi
    {
        public string NombreCompleto { get; set; }
        public int MomentId { get; set; }
        public string description { get;  set; }
        public int id { get; set; }
    }
}
