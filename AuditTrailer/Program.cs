using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace AuditTrailer
{
    using AuditTrailer.Application.Model;
    using AuditTrailer.Authorisation;
    using AuditTrailer.StoreManagement;
    using AuditTrailer.TripManagement;

    using Application = System.Windows.Forms.Application;
    using AuditTrailer.Application.Logging;
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			AppDomain.CurrentDomain.UnhandledException += (object sender, UnhandledExceptionEventArgs e) => Log.WriteException(((Exception)e.ExceptionObject), "Unhandled exception");
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new LoginForm());
        }
    }
}
