using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    [Route("company/[controller]/[action]")]
    public class AboutController
    {
        public string Phone()
        {
            return "123-123-1234";
        }

        public string Address()
        {
            return "USA";
        }
    }
}
