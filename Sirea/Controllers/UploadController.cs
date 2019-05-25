using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sirea.Models.DataAccessPostgreSqlProvider;
using DoubleGisGidClasses;

namespace Sirea.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        // POST: Upload/Create
        [HttpPost]
        public ActionResult DoUpload(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var xs = new XmlSerializer(typeof(Places));
                var places = (Places)xs.Deserialize(stream);
                using (var db = new DoubleGisGidDbContext())
                {
                    foreach (var place in places.ListOfPlaces)
                    {
                        var dbp = new DbPlace()
                        {
                            Name = place.Name,
                            MainPhoto = place.MainPhoto,
                        };
                        dbp.Information = new DbInformation()
                        {
                            Discription = place.Information.Discription,
                            Address = new DbAddress()
                            {
                                City = place.Information.Address.City,
                                Region = place.Information.Address.Region,
                                Street = new DbStreet()
                                {
                                    Name = place.Information.Address.Street.Name,
                                    Number = place.Information.Address.Street.Number,
                                }

                            },
                            SpokesmanName = place.Information.SpokesmanName,

                        };
                        dbp.Rating = new DbRating()
                        {
                            Likes = place.Rating.Likes,
                            Dislikes = place.Rating.Dislikes,
                        };
                        dbp.RegistrationDate = new DateTime();
                        dbp.RegistrationDate = place.RegistrationDate;
                        dbp.Contacts = new DbContacts()
                        {
                            PhoneNumber = place.Contacts.PhoneNumber,
                            SocialContacts = place.Contacts.SocialContacts,
                        };
                        db.Places.Add(dbp);
                    }
                    db.SaveChanges();
                }
                return View(places);
            }
        }
      
        public ActionResult Image(int id)
        {
            using (var db = new DoubleGisGidDbContext())
            {
                return base.File(db.Places.Find(id).MainPhoto, "image/png");
            }
        }

        //public ActionResult List()
        //{
        //    List<DbPlace> list;
        //    using (var db = new DoubleGisGidDbContext())
        //    {
        //        list = db.Places.Include(p =>p.)
        //    }
        //}
    }
}