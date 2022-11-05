using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.VisualBasic.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _1_LABA
{
    public partial class AuthenticationForm : Form
    {
        private string sSourseData;
        public AuthenticationForm()
        {
            InitializeComponent();
            this.sSourseData= "4a7d1ed414474e4033ac29ccb8653d9b";
        }
     
    }
}
