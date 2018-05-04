namespace ProductsAssessment.Controllers
{
using DataLayer;
using DataLayer.Models;
using ProductsAssessment.Mapping;
using ProductsAssessment.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

    public class HomeController : Controller
    {
        public HomeController()
        {
            dataAccess = new ProductsDAO(connectionString);
        }

        //Dependencies
        private ProductsDAO dataAccess;
        private static string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        //Index

        public ActionResult Index()
        {
            List<ProductsPO> mappedItems = new List<ProductsPO>();
            try
            {
                //Gets a list of products from SQL database.                
                List<ProductsDO> dataObjects = dataAccess.ReadProducts();
                mappedItems = ProductsMapper.MapDoToPO(dataObjects);
            }
            catch (Exception ex)
            {
                
            }
            return View(mappedItems);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}