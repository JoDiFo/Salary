﻿using Org.BouncyCastle.Tls.Crypto;
using Salary.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Salary.Forms
{
    public partial class EditPositionForm : ChildForm
    {
        private int _selectedID;

        public EditPositionForm(int selectedID, ThemeColor themeColor, MainForm parentForm)
            : base(parentForm, themeColor)
        {
            InitializeComponent();
            _selectedID = selectedID;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            LoadTheme();

            StatementDAO statementDAO = new StatementDAO();
            Position position = statementDAO.GetPosition(_selectedID);

            Name_txt.Text = position.Name;
            SalaryTxt.Text = position.Salary.ToString();
            PositionTypeBox.DataSource = Enum.GetValues(typeof(Taxes.TaxType)).Cast<Taxes.TaxType>().ToList();
            PositionTypeBox.Text = position.TaxType.ToString();
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

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            StatementDAO statementDAO = new StatementDAO();

            Position position = new Position();
            position.Name = Name_txt.Text;
            position.Salary = double.Parse(SalaryTxt.Text);
            position.TaxType = PositionTypeBox.Text == "Income" ? Taxes.TaxType.Income : Taxes.TaxType.Contract;

            statementDAO.EditPosition(_selectedID, position);

            MessageBox.Show("1 row edited");
            SwitchForm(new PositionsForm(_themeColor, _parentForm));
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            SwitchForm(new PositionsForm(_themeColor, _parentForm));
            this.Close();
        }
    }
}
