using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class DTOResult
    {
        public void DTOUpdateResult()
        {
            HasError = false;
            ErrorMessage = "";
        }

        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
