using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace DevinDow.VisionBoard
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            string appName = Assembly.GetAssembly(this.GetType()).Location;
            AssemblyName assemblyName = AssemblyName.GetAssemblyName(appName);
            lblVersion.Text = string.Format("Version : {0}", assemblyName.Version);
        }
    }
}
