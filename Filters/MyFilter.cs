using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo.Filters
{
    public class MyFilter : Attribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
            Console.WriteLine("OnActionExecuted");
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            //throw new NotImplementedException();
            Console.WriteLine("OnActionExecuting");
        }
    }
}
