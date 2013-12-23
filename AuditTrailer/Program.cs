using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using NLog;
using NLog.Config;
using NLog.Targets;

namespace AuditTrailer
{
    using AuditTrailer.Application.Model;
    using AuditTrailer.Authorisation;
    using AuditTrailer.StoreManagement;
    using AuditTrailer.TripManagement;

    using Application = System.Windows.Forms.Application;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
        	LoggingConfiguration configuration = new LoggingConfiguration();
        	FileTarget fileLog = new FileTarget();
        	fileLog.FileName = @"${basedir}\log.txt";
        	fileLog.Layout = "${date} ${message}";
        	configuration.AddTarget("file", fileLog);
        	configuration.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, fileLog));
        	LogManager.Configuration = configuration;
        	System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        	var logger = LogManager.GetLogger("Static logger");
        	AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs e) 
        	{
        		logger.Log(LogLevel.Fatal, ((Exception)e.ExceptionObject).ToString());
        	};
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new LoginForm());
        }
    }
}
