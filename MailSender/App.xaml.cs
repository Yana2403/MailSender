﻿using MailSenderReports;
using Microsoft.Extensions.Configuration;
using System;
using System.Windows;

namespace MailSender
{
    public partial class App 
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder() //интеграция свойств
           .SetBasePath(Environment.CurrentDirectory)
           .AddJsonFile("appsettings.json")
           .Build();
       
    }
}
