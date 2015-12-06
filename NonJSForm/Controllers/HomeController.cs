namespace NonJSForm.Controllers
{
    using System;
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
        [MultipleFormActionsButton(SubmitButtonActionName = "SpecifyIngredients")]
        public ActionResult SearchIngredients()
        {
            var viewModel = new RecipeViewModel
            {
                Ingredients = new List<IngredientViewModel>(),
                IngredientSearchResults = GetSearchResults()
            };

            return View("Index", viewModel);
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "SpecifyIngredients")]
        public ActionResult ClearIngredients()
        {
            var viewModel = new RecipeViewModel
            {
                Ingredients = new List<IngredientViewModel>(),
                IngredientSearchResults = new List<string>()
            };

            return View("Index", viewModel);
        }

        [HttpPost]
        [MultipleFormActionsButtonWithParameter(SubmitButtonActionName = "SpecifyIngredients")]
        [FillParameterFromActionName(ParameterName = "ingredientIndex", ParameterType = TypeCode.Int32, SubmitButtonActionName = "SpecifyIngredients")]
        public ActionResult UseIngredient(RecipeViewModel viewModel, int ingredientIndex)
        {
            viewModel.IngredientSearchResults = GetSearchResults();
            if (viewModel.Ingredients == null) 
                viewModel.Ingredients = new List<IngredientViewModel>();

            viewModel.Ingredients.Add(new IngredientViewModel {Ammount = 0, Name = viewModel.IngredientSearchResults[ingredientIndex]});

            return View("Index", viewModel);
        }

        [HttpPost]
        [MultipleFormActionsButtonWithParameter(SubmitButtonActionName = "SpecifyIngredients")]
        [FillParameterFromActionName(ParameterName = "ingredientIndex", ParameterType = TypeCode.Int32, SubmitButtonActionName = "SpecifyIngredients")]
        public ActionResult RemoveIngredient(RecipeViewModel viewModel, int ingredientIndex)
        {
            viewModel.IngredientSearchResults = GetSearchResults();
            
            viewModel.Ingredients.RemoveAt(ingredientIndex);

            return View("Index", viewModel);
        }

        [HttpPost]
        [MultipleFormActionsButton(SubmitButtonActionName = "SpecifyIngredients")]
        public ActionResult AddIngredients(RecipeViewModel viewModel)
        {
            return View("Recipe", viewModel.Ingredients);
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
    }
}