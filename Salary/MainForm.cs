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
    public partial class MainForm : Form
    {
        private Button _currentButton;
        private ChildForm _activeForm;
        private readonly ThemeColor _themeColor;

        public MainForm()
        {
            InitializeComponent();
            _themeColor = new ThemeColor();
            CloseChildBtn.Visible = false;
        }

        public void ChangeChildForm(ChildForm childForm)
        {
            OpenChildForm(childForm);
        }

        private void ActivateButton(object SenderBtn)
        {
            if (SenderBtn == null) { return; }

            if (_currentButton != (Button)SenderBtn)
            {
                DeactivateButton();
                _themeColor.SelectRandomColor();
                _currentButton = (Button)SenderBtn;
                _currentButton.BackColor = _themeColor.GetPrimaryColor();
                _currentButton.ForeColor = Color.White;
                _currentButton.Font = new Font("Microsoft Sans Serif", 12.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));

                TitleBarPanel.BackColor = _themeColor.GetPrimaryColor();
                LogoPanel.BackColor = _themeColor.GetSecondaryColor();
            }
        }

        private void DeactivateButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                }
            }
        }

        // Opens new child form and activates new button
        private void OpenChildForm(ChildForm childForm, object SenderBtn)
        {
            _activeForm?.Close();
            CloseChildBtn.Visible = true;
            TitleLbl.Text = childForm.Text;
            ActivateButton(SenderBtn);
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.ChildFormPanel.Controls.Add(childForm);
            this.ChildFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            _activeForm = childForm;
        }

        // Opens new child form but doesn't activate new button
        private void OpenChildForm(ChildForm childForm)
        {
            //_activeForm?.Close();
            //CloseChildBtn.Visible = true;
            //_activeForm = childForm;
            //TitleLbl.Text = childForm.Text;
            //childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            //childForm.Dock = DockStyle.Fill;
            //this.ChildFormPanel.Controls.Add(childForm);
            //this.ChildFormPanel.Tag = childForm;
            //childForm.BringToFront();
            //childForm.Show();

            _activeForm?.Close();
            CloseChildBtn.Visible = true;
            TitleLbl.Text = childForm.Text;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.ChildFormPanel.Controls.Add(childForm);
            this.ChildFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            _activeForm = childForm;
        }

        private void StatementBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StatementForm(_themeColor, this), sender);
        }

        private void PositionsBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PositionsForm(_themeColor, this), sender);
        }

        private void TaxesBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TaxesForm(_themeColor, this), sender);
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Search(_themeColor, this), sender);
        }

        private void CloseChildBtn_Click(object sender, EventArgs e)
        {
            _activeForm?.Close();
            Reset();
        }

        private void Reset()
        {
            DeactivateButton();
            TitleLbl.Text = "HOME";
            TitleBarPanel.BackColor = Color.FromArgb(0, 150, 136);
            LogoPanel.BackColor = Color.FromArgb(39, 39, 58);
            _currentButton = null;
            CloseChildBtn.Visible = false;
        }
    }
}
