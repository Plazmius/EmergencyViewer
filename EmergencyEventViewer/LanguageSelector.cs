using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmergencyEventViewer
{
    public partial class LanguageSelector : Form
    {
        public string SelectedCulture { get; set; }

        public LanguageSelector()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedCulture = selectedLanguageComboBox.SelectedItem?.ToString() ?? "";
        }
    }
}
