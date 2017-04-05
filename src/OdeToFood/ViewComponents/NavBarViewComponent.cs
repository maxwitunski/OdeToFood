using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.ViewComponents
{
    public class NavBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
