using Salary.Forms;
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
    public partial class InsertStatementForm : ChildForm
    {
        public InsertStatementForm(ThemeColor themeColor, MainForm parentForm)
            : base(parentForm, themeColor)
        {
            InitializeComponent();

            StatementDAO statementDAO = new StatementDAO();
            PositionsBox.DataSource = statementDAO.GetPositions().Select(position => position.Name).ToList();
        }

        private void InsertForm_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(System.Windows.Forms.Button))
                {
                    System.Windows.Forms.Button button = (System.Windows.Forms.Button)control;
                    button.BackColor = _themeColor.GetPrimaryColor();
                    button.ForeColor = Color.White;
                    button.FlatAppearance.BorderColor = _themeColor.GetSecondaryColor();
                }
                else if (control.GetType() == typeof(System.Windows.Forms.Label))
                {
                    System.Windows.Forms.Label label = (System.Windows.Forms.Label)control;
                    label.ForeColor = Color.White;
                }
            }
            BackColor = _themeColor.GetLighterColor();
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            StatementDAO statementDAO = new StatementDAO();

            statementDAO.AddEmployee(Name_txt.Text, PositionsBox.Text);
            MessageBox.Show("1 row edited");

            SwitchForm(new StatementForm(_themeColor, _parentForm));
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            SwitchForm(new StatementForm(_themeColor, _parentForm));
            this.Close();
        }
    }
}
