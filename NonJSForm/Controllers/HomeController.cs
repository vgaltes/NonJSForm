namespace NonJSForm.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using ViewModels;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new RecipieViewModel
            {
                Ingredients = new List<IngredientViewModel>(),
                IngredientSearchResults = new List<string>()
            };

            return View(viewModel);
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