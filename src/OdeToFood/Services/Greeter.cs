using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{
    public interface IGreeter
    {
        string GetGreeting();
    }
    public class Greeter : IGreeter
    {
        private string _greeting;

        public Greeter(IConfiguration configuation)
        {
            _greeting = configuation["Greeting"];
        }
        public string GetGreeting()
        {
            return "Hello from greeter!";
        }
    }
}
