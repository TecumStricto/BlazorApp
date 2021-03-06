﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.sql
{
    public class AppSettingsService
    {
        private readonly IConfiguration _config;
        public AppSettingsService(IConfiguration config)
        {
            _config = config;
        }
        public string GetBaseUrl()
        {
            return _config.GetValue<string>("AppSettings:BaseUrl");
        }
    }
}
