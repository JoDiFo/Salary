using Salary.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salary
{
    public partial class TaxesForm : ChildForm
    {
        private BindingSource _bindingSource = new BindingSource();
        private ThemeColor _themeColor;
        
        public TaxesForm(ThemeColor themeColor, MainForm parentForm)
            : base(parentForm)
        {
            InitializeComponent();
            _themeColor = themeColor;
        }

        private void StatementForm_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateData();
        }

        private void LoadTheme()
        {
            foreach (Control control in MenuPanel.Controls)
            {
                if (control.GetType() == typeof(System.Windows.Forms.Button))
                {
                    System.Windows.Forms.Button button = (System.Windows.Forms.Button)control;
                    button.BackColor = _themeColor.GetPrimaryColor();
                    button.ForeColor = Color.White;
                    button.FlatAppearance.BorderColor = _themeColor.GetSecondaryColor();
                }
            }
            StatementGrid.GridColor = _themeColor.GetLighterColor();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            int selectedRow = StatementGrid.CurrentRow.Index;
            int selectedID = (int)StatementGrid.Rows[selectedRow].Cells[0].Value;

            SwitchForm(new EditTaxesForm(selectedID, _themeColor, _parentForm));

            UpdateData();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            StatementDAO statementDAO = new StatementDAO();

            _bindingSource.DataSource = statementDAO.GetTaxes();
            StatementGrid.DataSource = _bindingSource.DataSource;
        }
    }
}
