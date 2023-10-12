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
    public partial class Search : ChildForm
    {
        private BindingSource _bindingSource = new BindingSource();
        private ThemeColor _themeColor;

        public Search(ThemeColor themeColor, MainForm parentForm)
            : base(parentForm)
        {
            InitializeComponent();
            _themeColor = themeColor;
        }
        private void Search_Load(object sender, EventArgs e)
        {
            LoadTheme();
            FilterBox.DataSource = new List<string>{"Name", "Position"};
            FilterBox.Text = "Name";
            StatementDAO statementDAO = new StatementDAO();
            _bindingSource.DataSource = statementDAO.GetEntries();
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
            SearchGrid.GridColor = _themeColor.GetLighterColor();
            FilterBox.BackColor = _themeColor.GetSecondaryColor();
            FilterBox.ForeColor = Color.White;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            StatementDAO statementDAO = new StatementDAO();

            _bindingSource.DataSource = statementDAO.GetSearchResult(SearchTxt.Text, FilterBox.Text);
            SearchGrid.DataSource = _bindingSource.DataSource;
        }

        private void SearchTxt_KeyUp(object sender, KeyEventArgs e)
        {
            DoSearch();
        }

        private void DoSearch()
        {
            if (FilterBox.Text == "Name")
                DoNameSearch();
            else if (FilterBox.Text == "Position")
                DoPositionSearch();
        }

        private void DoPositionSearch()
        {
            if (SearchTxt.Text != "")
            {
                List<Entry> entries = new List<Entry>();
                foreach (Entry item in (List<Entry>)_bindingSource.DataSource)
                {
                    if (item.Position.ToUpper().Contains(SearchTxt.Text.ToUpper()))
                        entries.Add(item);
                }

                SearchGrid.DataSource = entries;
            }
            else
            {
                SearchGrid.DataSource = _bindingSource.DataSource;
            }
        }

        private void DoNameSearch()
        {
            if (SearchTxt.Text != "")
            {
                List<Entry> entries = new List<Entry>();
                foreach (Entry item in (List<Entry>)_bindingSource.DataSource)
                {
                    if (item.Name.ToUpper().Contains(SearchTxt.Text.ToUpper()))
                        entries.Add(item);
                }

                SearchGrid.DataSource = entries;
            }
            else
            {
                SearchGrid.DataSource = _bindingSource.DataSource;
            }
        }

        private void FilterBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (SearchTxt.Text == "") return;
            DoSearch();
        }
    }
}
