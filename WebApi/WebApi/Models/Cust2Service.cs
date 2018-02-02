using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Cust2Service : ICustService
    {

        public string Para { get; set; }
        
        public string getCust1()
        {
            return "getCust1";
        }
        public string getCust2()
        {
            return "getCust2";
        }

        public string getCust3()
        {
            return Para;
        }

        public string getCust4()
        {
            return Para;
        }

        public string getCust5()
        {
            return Para;
        }
    }
}