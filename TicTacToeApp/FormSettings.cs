using System;
using System.Windows.Forms;

namespace TicTacToeApp
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.m_SecondPlayerCheckBox.Click += m_SecondPlayerCheckBox_Click;
            this.m_RowsScaler.Click += m_NumberOfRows_Click;
            this.m_ColsScaler.Click += m_NumberOfCols_Click;
            this.m_StartButton.Click += m_StartButton_Click;
        }

        public bool IsComputer
        {
            get { return !this.m_SecondPlayerCheckBox.Checked; }          
        }

        public string FirstPlayerName
        {
            get { return this.m_FirstPlayerTextBox.Text; }
            set { this.m_FirstPlayerTextBox.Text = value; }
        }

        public string SecondPlayerName
        {
            get { return this.m_SecondPlayerTextBox.Text; }
            set { this.m_SecondPlayerTextBox.Text = value; }
        }

        public int BoardSize
        {
            get { return (int)this.m_ColsScaler.Value; }
        }

        private void m_SecondPlayerCheckBox_Click(object sender, EventArgs e)
        {
            this.m_SecondPlayerTextBox.Enabled = !this.m_SecondPlayerTextBox.Enabled;
            if(this.m_SecondPlayerTextBox.Enabled)
            {
                this.m_SecondPlayerTextBox.Text = string.Empty;
            }
            else
            {
                this.m_SecondPlayerTextBox.Text = "[Computer]";
            }
        }

        private void m_NumberOfCols_Click(object sender, EventArgs e)
        {
            this.m_RowsScaler.Value = this.m_ColsScaler.Value;
        }

        private void m_NumberOfRows_Click(object sender, EventArgs e)
        {
            this.m_ColsScaler.Value = this.m_RowsScaler.Value;
        }

        private void m_StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm game = new GameForm(this);
            this.Close();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void m_SecondPlayerTextBox_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
