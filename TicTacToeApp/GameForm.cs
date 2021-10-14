using System;
using System.Drawing;
using System.Windows.Forms;
using TicTacToeLogic;

namespace TicTacToeApp
{
    public class GameForm : Form
    {
        private const int k_RowLocation = 10;
        private const int k_ColLocation = 10;
        private const int k_ButtonSize = 60;
        private const int k_Margin = 2;
        private readonly Label r_PlayerOneName = new Label();
        private readonly Label r_PlayerTwoName = new Label();
        private readonly Label r_PlayerOneScore = new Label();
        private readonly Label r_PlayerTwoScore = new Label();
        private readonly FormSettings r_Settings;
        private readonly Game r_Game;
        private readonly ButtonCell[,] r_ButtonsBoard;
        private readonly TableLayoutPanel r_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();

        public GameForm(FormSettings i_Settings)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.r_Settings = i_Settings;
            this.r_ButtonsBoard = new ButtonCell[this.r_Settings.BoardSize, this.r_Settings.BoardSize];
            initializeBoard();
            this.r_Game = createGame();
            initializeScoreBoard();
            this.r_Game.UpdateUIMoves += makeMove;
            this.r_Game.UpdateUIIfGameEnds += finishGame;
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowDialog();
            runGame();
        }

        private void initializeScoreBoard()
        {
            this.r_TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();

            this.r_PlayerOneName.Text = $"{this.r_Settings.FirstPlayerName}:";
            this.r_PlayerOneScore.Text = $"{this.r_Game.PlayerOne.Score}";

            this.r_PlayerTwoName.Text = $"{this.r_Settings.SecondPlayerName}:";
            this.r_PlayerTwoScore.Text = $"{this.r_Game.PlayerTwo.Score}";

            this.r_TableLayoutPanel.AutoSize = true;
            this.r_TableLayoutPanel.ColumnCount = 4;
            for(int i = 0; i < r_TableLayoutPanel.ColumnCount; i++)
            {
                this.r_TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }

            this.r_TableLayoutPanel.Controls.Add(this.r_PlayerOneName, 0, 0);
            this.r_TableLayoutPanel.Controls.Add(this.r_PlayerOneScore, 1, 0);
            this.r_TableLayoutPanel.Controls.Add(this.r_PlayerTwoName, 2, 0);
            this.r_TableLayoutPanel.Controls.Add(this.r_PlayerTwoScore, 3, 0);
            this.r_TableLayoutPanel.Dock = DockStyle.Bottom;
            this.r_TableLayoutPanel.Location = new Point(0, ClientSize.Height);
            this.r_TableLayoutPanel.RowCount = 1;
            this.r_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.r_PlayerOneName.AutoSize = true;
            this.r_PlayerTwoName.AutoSize = true;
            this.r_PlayerOneScore.AutoSize = true;
            this.r_PlayerTwoScore.AutoSize = true;

            this.Controls.Add(this.r_TableLayoutPanel);
            this.r_TableLayoutPanel.ResumeLayout(false);
            this.r_TableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.r_PlayerOneName.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            this.r_PlayerOneScore.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private Game createGame()
        {
            Player playerOne;
            Player playerTwo;
            int sizeOfBoard;
            bool vsComputer;
           
            sizeOfBoard = this.r_Settings.BoardSize;
            vsComputer = this.r_Settings.IsComputer;
            playerOne = new Player(this.r_Settings.FirstPlayerName, Cell.eSign.X);
            if(!vsComputer)
            {
                playerTwo = new Player(this.r_Settings.SecondPlayerName, Cell.eSign.O);
            }
            else
            {
                playerTwo = new Player(Cell.eSign.O);
            }

            Game game = new Game(sizeOfBoard, playerOne, playerTwo);

            return game;
        }

        private void initializeBoard()
        {
            int rowLocation = GameForm.k_RowLocation;
            int colLocation = GameForm.k_ColLocation;
            ButtonCell cell;

            for(int row = 0; row < this.r_Settings.BoardSize; row++)
            {
                for(int col = 0; col < this.r_Settings.BoardSize; col++)
                {
                    cell = new ButtonCell(row, col);
                    cell.Width = k_ButtonSize;
                    cell.Height = k_ButtonSize;
                    cell.Text = string.Empty;
                    cell.Location = new Point(rowLocation, colLocation);
                    rowLocation += GameForm.k_ButtonSize + GameForm.k_Margin;
                    this.r_ButtonsBoard[row, col] = cell;
                    cell.Click += cell_Click;
                    this.Controls.Add(cell);
                }

                rowLocation = k_RowLocation;
                colLocation += k_ButtonSize + k_Margin;
            }

            this.Width = (this.r_Settings.BoardSize * k_ButtonSize) + ((this.r_Settings.BoardSize) * k_Margin) + (k_ButtonSize / 2);
            this.Height = colLocation + k_ButtonSize + (k_ButtonSize / 2);
            this.Text = "TicTacToeMisere";
        }

        private void runGame()
        {
            this.r_Game.RunGame();
        }

        private void makeMove(object sender, EventArgs e)
        {
            Cell cell = sender as Cell;

            this.r_ButtonsBoard[cell.Row, cell.Col].Enabled = false;
            this.r_ButtonsBoard[cell.Row, cell.Col].Text = cell.CellSign.ToString();
            if(this.r_PlayerOneName.Font.Bold)
            {
                takeOffBold(this.r_PlayerOneName, this.r_PlayerOneScore);
                makeBold(this.r_PlayerTwoName, this.r_PlayerTwoScore);
            }
            else
            {
                takeOffBold(this.r_PlayerTwoName, this.r_PlayerTwoScore);
                makeBold(this.r_PlayerOneName, this.r_PlayerOneScore);
            }
        }

        private void cell_Click(object sender, EventArgs e)
        {
            int[] rowCol = new int[2];
            ButtonCell currentButton = sender as ButtonCell;
         
            rowCol[0] = currentButton.Row;
            rowCol[1] = currentButton.Col;
            r_Game.MakeHumanMove(rowCol);
            runGame();
        }

        private void makeBold(Label i_PlayerName, Label i_PlayerScore)
        {
            i_PlayerName.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            i_PlayerScore.Font = new Font(Label.DefaultFont, FontStyle.Bold);
        }

        private void takeOffBold(Label i_PlayerName, Label i_PlayerScore)
        {
            i_PlayerName.Font = new Font(Label.DefaultFont, FontStyle.Regular);
            i_PlayerScore.Font = new Font(Label.DefaultFont, FontStyle.Regular);
        }

        private void finishGame(object sender, EventArgs e)
        {
            string winOrTie = sender as string;
            bool answer = false;

            if(winOrTie.Equals("win"))
            {
                answer = Messages.WinEndGame(this.r_Game.CurrentPlayer);
            }

            if(winOrTie.Equals("tie"))
            {
                answer = Messages.TieEndGame();
            }

            this.r_Game.EndGame(answer);
            if(answer)
            {
                restartGame();
            }        
        }

        private void restartGame()
        {
            foreach(ButtonCell cell in this.r_ButtonsBoard)
            {
                cell.Enabled = true;
                cell.Text = string.Empty;
            }

            this.r_PlayerOneScore.Text = $"{this.r_Game.PlayerOne.Score}";
            this.r_PlayerTwoScore.Text = $"{this.r_Game.PlayerTwo.Score}";            
            takeOffBold(this.r_PlayerTwoName, this.r_PlayerTwoScore);
            makeBold(this.r_PlayerOneName, this.r_PlayerOneScore);
        }
    }
}
