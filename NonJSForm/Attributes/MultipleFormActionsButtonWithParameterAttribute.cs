namespace NonJSForm.Attributes
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MultipleFormActionsButtonWithParameterAttribute : ActionNameSelectorAttribute
    {
        public string SubmitButtonActionName { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var value = controllerContext.Controller.ValueProvider.GetValue(SubmitButtonActionName);
            string realActionName;
            var isValid = false;

            if (value == null)
            {
                realActionName = actionName.Split('-').First();
                isValid = methodInfo.Name.Equals(realActionName, StringComparison.InvariantCultureIgnoreCase);
            }
            else
            {
                realActionName = value.AttemptedValue.Split('-').First();
                isValid = realActionName == methodInfo.Name;
            }


            return isValid;
        }
    }
}