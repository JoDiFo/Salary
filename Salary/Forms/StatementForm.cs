using Salary.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salary
{
    public partial class StatementForm : ChildForm
    {
        private BindingSource _bindingSource = new BindingSource();
        private ThemeColor _themeColor;
        
        public StatementForm(ThemeColor themeColor, MainForm parentForm)
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
                if (control.GetType() == typeof(Button))
                {
                    Button button = (Button)control;
                    button.BackColor = _themeColor.GetPrimaryColor();
                    button.ForeColor = Color.White;
                    button.FlatAppearance.BorderColor = _themeColor.GetSecondaryColor();
                }
            }
            StatementGrid.GridColor = _themeColor.GetLighterColor();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            int selectedRow = StatementGrid.CurrentRow.Index;
            int selectedID = (int)StatementGrid.Rows[selectedRow].Cells[0].Value;

            StatementDAO statementDAO = new StatementDAO();

            statementDAO.DeleteEmployee(selectedID);
            MessageBox.Show("1 row deleted");

            UpdateData();
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            SwitchForm(new InsertStatementForm(_themeColor, _parentForm));

            UpdateData();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            int selectedRow = StatementGrid.CurrentRow.Index;
            int selectedID = (int)StatementGrid.Rows[selectedRow].Cells[0].Value;

            SwitchForm(new EditStatementForm(selectedID, _themeColor, _parentForm));

            UpdateData();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            StatementDAO statementDAO = new StatementDAO();

            _bindingSource.DataSource = statementDAO.GetEntries();
            StatementGrid.DataSource = _bindingSource.DataSource;
        }

        private void DoDynamicSearch()
        {
            if (SearchTxt.Text != "")
            {
                List<Entry> entries = new List<Entry>();
                foreach (Entry item in (List<Entry>)_bindingSource.DataSource)
                {
                    if (item.Name.ToUpper().Contains(SearchTxt.Text.ToUpper()))
                        entries.Add(item);
                }

                StatementGrid.DataSource = entries;
            }
            else
            {
                UpdateData();
            }
        }

        private void SearchTxt_KeyUp(object sender, KeyEventArgs e)
        {
            DoDynamicSearch();
        }
    }
}
