﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
