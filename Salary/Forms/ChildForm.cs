using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salary.Forms
{
    public partial class ChildForm : Form
    {
        protected MainForm _parentForm;

        public ChildForm()
        {
            InitializeComponent();
            _parentForm = null;
        }        
        
        public ChildForm(MainForm parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
        }

        protected void SwitchForm(ChildForm newForm)
        {
            _parentForm.ChangeChildForm(newForm);
        }
    }
}
