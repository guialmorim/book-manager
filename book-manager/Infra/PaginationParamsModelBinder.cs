using book_manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace book_manager.infra
{
    public class PaginationParamsModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            var paginationParameters = new PaginationParameters(request.Form);

            return paginationParameters;
        }
    }
}