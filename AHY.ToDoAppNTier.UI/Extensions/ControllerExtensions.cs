using AHY.ToDoAppNTier.Common.ResponseObjects;
using Microsoft.AspNetCore.Mvc;

namespace AHY.ToDoAppNTier.UI.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResponseRedirectToAction<T>(this Controller controller, IResponse<T> response, string actionName, string controllerName = "Home")
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var item in response.ValidationErrors)
                {
                    controller.ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return controller.View(response.Data);
            }
            //RedirectToAction'ı overload olarak kullandım. Controller adı paramaetre olarak verilirse, verilmezse diye 2'ye ayırdım.
            if (controllerName != "Home")
            {
                return controller.RedirectToAction(actionName, controllerName);
            }
            return controller.RedirectToAction(actionName);
        }

        public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response, string actionName)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.RedirectToAction(actionName);
        }

        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.View(response.Data);
        }
    }
}
