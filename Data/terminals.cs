using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Data
{
    public class terminals
    {
        public DateTime activationDay { get; set; }
        public DateTime? deactivationDay { get; set; }

        [Key]
        public int Id { get; set; }

        public string compaynHash { get; set; }
        public string typeOfDevices { get; set; }
        public string appType { get; set; }
        public string description { get; set; }

    }
}
