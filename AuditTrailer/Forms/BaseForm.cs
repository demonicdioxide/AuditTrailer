using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AuditTrailer.Forms
{
    using AuditTrailer.Application.Authorisation;
    using AuditTrailer.Application.Database;
    using AuditTrailer.Application.Model;

    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            LoadForm();
        }

        protected virtual void LoadForm() { }
    }
}
