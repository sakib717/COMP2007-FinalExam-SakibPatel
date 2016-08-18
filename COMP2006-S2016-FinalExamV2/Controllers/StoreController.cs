using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COMP2006_S2016_FinalExamV2.Models;


//FINAL EXAM BY SAKIB PATEL
//STUDENT #200307608  
//MODIFICATION DATE: 2016-08-18

//FILE DESCRIPTIION:This is a controller created for being able to view the lists

namespace COMP2007_S2016_Lesson12C.Controllers
{

    public class StoreController : Controller
    {

        MVCMusicStoreContext storeDB = new MVCMusicStoreContext();

        //
        // GET: /Store/
        public ActionResult Index()
        {
            List<Genre> genres = storeDB.Genres.ToList();

            return View(genres);
        }
        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string genre = "Rock")
        {
            // Retrieve Genre and its Associated Albums from database
            Genre genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);

            return View(genreModel);
        }
        //
        // GET: /Store/Details/5

        public ActionResult Details(int id = 1)
        {
            Album album = storeDB.Albums.Find(id);

            return View(album);
        }

        //
        // GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genres.ToList();
            return PartialView(genres);
        }
    }
}