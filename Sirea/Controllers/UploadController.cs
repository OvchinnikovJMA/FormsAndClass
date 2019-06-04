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
using DoubleGisGidClasses.Web.Models.DataAccessPostgreSqlProvider;
using DoubleGisGidClasses;

namespace DoubleGisGidClasses.Web.Controllers
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
                        var dbp = new DbPlace(place);
                        dbp.PhoneNumber = new List<string>();
                        foreach(var phn in place.PhoneNumber)
                        {
                            if (place.PhoneNumber.Count == 0)
                                dbp.PhoneNumber.Add("Нет номера");
                            else dbp.PhoneNumber.Add(phn);
                        }
                        dbp.SocialContacts = new List<string>();
                        foreach (var sc in place.SocialContacts)
                        {
                            if (place.SocialContacts.Count == 0)
                                dbp.SocialContacts.Add("Нет контактов");
                            else dbp.SocialContacts.Add(sc);
                        }                        
                        dbp.DbInformation = new DbInformation(place.Information);
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

        public ActionResult ListPhone()
        {
            List<DbPlace> list;
            using (var db = new DoubleGisGidDbContext())
            {
                list = db.Places.Include(s => s.PhoneNumber).ToList();
                
            }
            return View(list);
        }

        public ActionResult ListSoc()
        {
            List<DbPlace> list;
            using (var db = new DoubleGisGidDbContext())
            {
                list = db.Places.Include(s => s.SocialContacts).ToList();
            }
            return View(list);
        }

    }
}

