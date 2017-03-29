using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.ViewComponents
{
    public class SearchBoxViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
