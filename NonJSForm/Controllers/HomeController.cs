namespace NonJSForm.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Attributes;
    using ViewModels;

    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new RecipeViewModel
            {
                Ingredients = new List<IngredientViewModel>(),
                IngredientSearchResults = new List<string>()
            };

            return View(viewModel);
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "Ingredients")]
        public ActionResult SearchIngredients()
        {
            var viewModel = new RecipeViewModel
            {
                Ingredients = new List<IngredientViewModel>(),
                IngredientSearchResults = GetSearchResults()
            };

            return View("Index", viewModel);
        }

        private List<string> GetSearchResults()
        {
            return new List<string>
            {
                "beef fillet",
                "chesnut mushroom",
                "butter",
                "fresh thyme",
                "white wine",
                "prosciutto",
                "flour",
                "egg"
            };
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