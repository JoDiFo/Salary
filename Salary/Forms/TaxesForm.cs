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

namespace Salary.Forms
{
    public partial class TaxesForm : ChildForm
    {
        private BindingSource _bindingSource = new BindingSource();
        
        public TaxesForm(ThemeColor themeColor, MainForm parentForm)
            : base(parentForm, themeColor)
        {
            InitializeComponent();
        }

        private async void StatementForm_Load(object sender, EventArgs e)
        {
            LoadTheme();
            await UpdateData();
            StatementGrid.DataSource = _bindingSource.DataSource;
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

        private async void EditBtn_Click(object sender, EventArgs e)
        {
            SwitchForm(new EditTaxesForm(_themeColor, _parentForm));

            await UpdateData();
            StatementGrid.DataSource = _bindingSource.DataSource;
        }

        private async void UpdateBtn_Click(object sender, EventArgs e)
        {
            await UpdateData();
            StatementGrid.DataSource = _bindingSource.DataSource;
        }

        private async Task UpdateData()
        {
            StatementDAO statementDAO = new StatementDAO();
            _bindingSource.DataSource = await Task.Run(() => statementDAO.GetTaxes());
        }
    }
}
