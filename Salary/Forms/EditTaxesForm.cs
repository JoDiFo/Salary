﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Salary.Forms
{
    public partial class EditTaxesForm : ChildForm
    {
        public EditTaxesForm(ThemeColor themeColor, MainForm parentForm)
            : base(parentForm, themeColor)
        {
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            LoadTheme();

            StatementDAO statementDAO = new StatementDAO();
            List<Taxes> taxes = statementDAO.GetTaxes();

            IncomeTaxTxt.Text = taxes[1].Tax.ToString();
            IncomeFundTxt.Text = taxes[1].Fund.ToString();
            ContractTaxTxt.Text = taxes[0].Tax.ToString();
            ContractFundTxt.Text = taxes[0].Fund.ToString();
        }

        private void LoadTheme()
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button button = (Button)control;
                    button.BackColor = _themeColor.GetPrimaryColor();
                    button.ForeColor = Color.White;
                    button.FlatAppearance.BorderColor = _themeColor.GetSecondaryColor();
                }
                else if (control.GetType() == typeof(Label))
                {
                    Label label = (Label)control;
                    label.ForeColor = Color.White;
                }
            }
            BackColor = _themeColor.GetLighterColor();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            StatementDAO statementDAO = new StatementDAO();
            statementDAO.EditTaxes(GetNewTaxes());

            MessageBox.Show("1 row edited");
            SwitchForm(new TaxesForm(_themeColor, _parentForm));
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            SwitchForm(new TaxesForm(_themeColor, _parentForm));
            this.Close();
        }

        private List<Taxes> GetNewTaxes()
        {
            List<Taxes> taxes = new List<Taxes>();
            Taxes taxes1 = new Taxes();
            taxes1.Tax = double.Parse(IncomeTaxTxt.Text);
            taxes1.Fund = double.Parse(IncomeFundTxt.Text);
            Taxes taxes2 = new Taxes();
            taxes2.Tax = double.Parse(ContractTaxTxt.Text);
            taxes2.Fund = double.Parse(ContractFundTxt.Text);
            taxes.Add(taxes2);
            taxes.Add(taxes1);
            return taxes;
        }
    }
}
