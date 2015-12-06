namespace NonJSForm.Attributes
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class FillParamterFromActionName : ActionFilterAttribute
    {
        public string ParameterName { get; set; }

        public string SubmitButtonActionName { get; set; }

        public TypeCode ParameterType { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var value = filterContext.HttpContext.Request.Params[SubmitButtonActionName];
            var parameterValue = value.Split('-').Last();

            var realParameterValue = Convert.ChangeType(parameterValue, ParameterType);
            filterContext.ActionParameters[ParameterName] = realParameterValue;
        }
    }
}