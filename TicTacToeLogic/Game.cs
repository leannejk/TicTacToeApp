using System;

namespace TicTacToeLogic
{   
    public class Game
    {
        public event EventHandler UpdateUIMoves;
        public event EventHandler UpdateUIIfGameEnds;
        private readonly BoardGame r_BoardGame;
        private readonly Player r_PlayerOne;
        private readonly Player r_PlayerTwo;
        private Player m_CurrentPlayer;

        public Game(int i_BoardSize, Player i_PlayerOne, Player i_PlayerTwo)
        {
            r_BoardGame = new BoardGame(i_BoardSize);
            r_PlayerOne = i_PlayerOne;
            r_PlayerTwo = i_PlayerTwo;
            m_CurrentPlayer = i_PlayerOne;
        }

        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
        }

        public Player PlayerOne
        {
            get { return r_PlayerOne; }
        }

        public Player PlayerTwo
        {
            get { return r_PlayerTwo; }
        }

        public void RunGame()
        {
            Cell chosenCell;
            EventArgs eventArgs = new EventArgs();

            if(m_CurrentPlayer.IsComputer)
            {                   
               chosenCell = makeComputerMove();
               UpdateUIMoves(chosenCell, eventArgs);
               afterMoveChecks();
            }           
        }

        public void MakeHumanMove(int[] i_RowCol)
        {
            EventArgs eventArgs = new EventArgs();
            int row = i_RowCol[0];
            int col = i_RowCol[1];

            r_BoardGame.AddSignToBoard(row, col, m_CurrentPlayer.Sign);
            UpdateUIMoves(this.r_BoardGame.Matrix[row, col], eventArgs);
            afterMoveChecks();
        }

        private Cell makeComputerMove()
        {
            Cell chosenCell;

            chosenCell = r_BoardGame.AIAddComputerSignToBoard(m_CurrentPlayer.Sign);

            return chosenCell;
        }

        private void afterMoveChecks()
        {
            bool flag = false;
            EventArgs eventArgs = new EventArgs();

            if(r_BoardGame.CheckIfLose())
            {
                switchPlayer();
                m_CurrentPlayer.Score += 1;
                flag = true;
                UpdateUIIfGameEnds("win", eventArgs);
            }

            if (!flag && r_BoardGame.CheckIfBoardIsFull())
            {
                flag = true;
                UpdateUIIfGameEnds("tie", eventArgs);
            }

            if (!flag)
            {
                switchPlayer();
            }
        }

        private void switchPlayer()
        {
            if (m_CurrentPlayer == r_PlayerOne)
            {
                m_CurrentPlayer = r_PlayerTwo;
            }
            else
            {
                m_CurrentPlayer = r_PlayerOne;
            }
        }

        public void EndGame(bool i_AnotherGameAnswer)
        {
            if (i_AnotherGameAnswer)
            {
                playAgainRestart();              
            }
            else
            {
                System.Environment.Exit(0);
            }
        }

        private void playAgainRestart()
        {
            r_BoardGame.ClearBoard();
            m_CurrentPlayer = r_PlayerOne;
            RunGame();
        }
    }
}