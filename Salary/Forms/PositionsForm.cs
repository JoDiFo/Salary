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
    public partial class PositionsForm : ChildForm
    {
        private BindingSource _bindingSource = new BindingSource();
        private ThemeColor _themeColor;
        
        public PositionsForm(ThemeColor themeColor, MainForm parentForm)
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
            PositionsGrid.GridColor = _themeColor.GetLighterColor();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            int selectedRow = PositionsGrid.CurrentRow.Index;
            int selectedID = (int)PositionsGrid.Rows[selectedRow].Cells[0].Value;

            StatementDAO statementDAO = new StatementDAO();

            statementDAO.DeletePosition(selectedID);
            MessageBox.Show("1 row deleted");

            UpdateData();
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            SwitchForm(new InsertPositionForm(_themeColor, _parentForm));

            UpdateData();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            int selectedRow = PositionsGrid.CurrentRow.Index;
            int selectedID = (int)PositionsGrid.Rows[selectedRow].Cells[0].Value;

            SwitchForm(new EditPositionForm(selectedID, _themeColor, _parentForm));

            UpdateData();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            StatementDAO statementDAO = new StatementDAO();

            _bindingSource.DataSource = statementDAO.GetPositions();
            PositionsGrid.DataSource = _bindingSource.DataSource;
        }
    }
}
