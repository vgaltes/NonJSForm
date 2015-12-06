namespace NonJSForm.ViewModels
{
    using System.Collections.Generic;

    public class IngredientViewModel
    {
        public string Name { get; set; }
        public int Ammount { get; set; }
    }

    public class RecipeViewModel
    {
        public string IngredientSearch { get; set; }
        public List<string> IngredientSearchResults { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }
    }
}