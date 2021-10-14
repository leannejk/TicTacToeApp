namespace TicTacToeApp
{
    public partial class FormSettings
    {
        private System.Windows.Forms.Label m_PlayersLabel;
        private System.Windows.Forms.Label m_FirstPlayerLabel;
        private System.Windows.Forms.Label m_BoardSizeLabel;
        private System.Windows.Forms.CheckBox m_SecondPlayerCheckBox;
        private System.Windows.Forms.NumericUpDown m_ColsScaler;
        private System.Windows.Forms.NumericUpDown m_RowsScaler;
        private System.Windows.Forms.Label m_ColsLabel;
        private System.Windows.Forms.Label m_RowsLabel;
        private System.Windows.Forms.TextBox m_SecondPlayerTextBox;
        private System.Windows.Forms.TextBox m_FirstPlayerTextBox;
        private System.Windows.Forms.Button m_StartButton;
        private System.ComponentModel.IContainer components = null;
     
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.m_PlayersLabel = new System.Windows.Forms.Label();
            this.m_FirstPlayerLabel = new System.Windows.Forms.Label();
            this.m_BoardSizeLabel = new System.Windows.Forms.Label();
            this.m_SecondPlayerCheckBox = new System.Windows.Forms.CheckBox();
            this.m_ColsScaler = new System.Windows.Forms.NumericUpDown();
            this.m_RowsScaler = new System.Windows.Forms.NumericUpDown();
            this.m_ColsLabel = new System.Windows.Forms.Label();
            this.m_RowsLabel = new System.Windows.Forms.Label();
            this.m_SecondPlayerTextBox = new System.Windows.Forms.TextBox();
            this.m_FirstPlayerTextBox = new System.Windows.Forms.TextBox();
            this.m_StartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_ColsScaler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_RowsScaler)).BeginInit();
            this.SuspendLayout();
            // 
            // m_PlayersLabel
            // 
            this.m_PlayersLabel.AutoSize = true;
            this.m_PlayersLabel.Location = new System.Drawing.Point(25, 40);
            this.m_PlayersLabel.Name = "m_PlayersLabel";
            this.m_PlayersLabel.Size = new System.Drawing.Size(64, 20);
            this.m_PlayersLabel.TabIndex = 0;
            this.m_PlayersLabel.Text = "Players:";
            this.m_PlayersLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // m_FirstPlayerLabel
            // 
            this.m_FirstPlayerLabel.AutoSize = true;
            this.m_FirstPlayerLabel.Location = new System.Drawing.Point(51, 85);
            this.m_FirstPlayerLabel.Name = "m_FirstPlayerLabel";
            this.m_FirstPlayerLabel.Size = new System.Drawing.Size(69, 20);
            this.m_FirstPlayerLabel.TabIndex = 1;
            this.m_FirstPlayerLabel.Text = "Player 1:";
            // 
            // m_BoardSizeLabel
            // 
            this.m_BoardSizeLabel.AutoSize = true;
            this.m_BoardSizeLabel.Location = new System.Drawing.Point(25, 210);
            this.m_BoardSizeLabel.Name = "m_BoardSizeLabel";
            this.m_BoardSizeLabel.Size = new System.Drawing.Size(91, 20);
            this.m_BoardSizeLabel.TabIndex = 3;
            this.m_BoardSizeLabel.Text = "Board Size:";
            // 
            // m_SecondPlayerCheckBox
            // 
            this.m_SecondPlayerCheckBox.AutoSize = true;
            this.m_SecondPlayerCheckBox.Location = new System.Drawing.Point(54, 130);
            this.m_SecondPlayerCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_SecondPlayerCheckBox.Name = "m_SecondPlayerCheckBox";
            this.m_SecondPlayerCheckBox.Size = new System.Drawing.Size(95, 24);
            this.m_SecondPlayerCheckBox.TabIndex = 4;
            this.m_SecondPlayerCheckBox.Text = "Player 2:";
            this.m_SecondPlayerCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_ColsScaler
            // 
            this.m_ColsScaler.Location = new System.Drawing.Point(237, 244);
            this.m_ColsScaler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_ColsScaler.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.m_ColsScaler.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_ColsScaler.Name = "m_ColsScaler";
            this.m_ColsScaler.Size = new System.Drawing.Size(47, 26);
            this.m_ColsScaler.TabIndex = 5;
            this.m_ColsScaler.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_ColsScaler.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // m_RowsScaler
            // 
            this.m_RowsScaler.Location = new System.Drawing.Point(115, 244);
            this.m_RowsScaler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_RowsScaler.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.m_RowsScaler.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_RowsScaler.Name = "m_RowsScaler";
            this.m_RowsScaler.Size = new System.Drawing.Size(47, 26);
            this.m_RowsScaler.TabIndex = 6;
            this.m_RowsScaler.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // m_ColsLabel
            // 
            this.m_ColsLabel.AutoSize = true;
            this.m_ColsLabel.Location = new System.Drawing.Point(187, 246);
            this.m_ColsLabel.Name = "m_ColsLabel";
            this.m_ColsLabel.Size = new System.Drawing.Size(44, 20);
            this.m_ColsLabel.TabIndex = 8;
            this.m_ColsLabel.Text = "Cols:";
            // 
            // m_RowsLabel
            // 
            this.m_RowsLabel.AutoSize = true;
            this.m_RowsLabel.Location = new System.Drawing.Point(39, 246);
            this.m_RowsLabel.Name = "m_RowsLabel";
            this.m_RowsLabel.Size = new System.Drawing.Size(53, 20);
            this.m_RowsLabel.TabIndex = 9;
            this.m_RowsLabel.Text = "Rows:";
            // 
            // m_SecondPlayerTextBox
            // 
            this.m_SecondPlayerTextBox.Enabled = false;
            this.m_SecondPlayerTextBox.Location = new System.Drawing.Point(158, 128);
            this.m_SecondPlayerTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_SecondPlayerTextBox.Name = "m_SecondPlayerTextBox";
            this.m_SecondPlayerTextBox.Size = new System.Drawing.Size(127, 26);
            this.m_SecondPlayerTextBox.TabIndex = 10;
            this.m_SecondPlayerTextBox.Text = "[Computer]";
            this.m_SecondPlayerTextBox.TextChanged += new System.EventHandler(this.m_SecondPlayerTextBox_TextChanged);
            // 
            // m_FirstPlayerTextBox
            // 
            this.m_FirstPlayerTextBox.Location = new System.Drawing.Point(158, 85);
            this.m_FirstPlayerTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_FirstPlayerTextBox.Name = "m_FirstPlayerTextBox";
            this.m_FirstPlayerTextBox.Size = new System.Drawing.Size(127, 26);
            this.m_FirstPlayerTextBox.TabIndex = 11;
            // 
            // m_StartButton
            // 
            this.m_StartButton.Location = new System.Drawing.Point(28, 320);
            this.m_StartButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_StartButton.Name = "m_StartButton";
            this.m_StartButton.Size = new System.Drawing.Size(256, 29);
            this.m_StartButton.TabIndex = 12;
            this.m_StartButton.Text = "Start !";
            this.m_StartButton.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 374);
            this.Controls.Add(this.m_StartButton);
            this.Controls.Add(this.m_FirstPlayerTextBox);
            this.Controls.Add(this.m_SecondPlayerTextBox);
            this.Controls.Add(this.m_RowsLabel);
            this.Controls.Add(this.m_ColsLabel);
            this.Controls.Add(this.m_RowsScaler);
            this.Controls.Add(this.m_ColsScaler);
            this.Controls.Add(this.m_SecondPlayerCheckBox);
            this.Controls.Add(this.m_BoardSizeLabel);
            this.Controls.Add(this.m_FirstPlayerLabel);
            this.Controls.Add(this.m_PlayersLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_ColsScaler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_RowsScaler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}