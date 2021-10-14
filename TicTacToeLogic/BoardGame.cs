using System.Collections.Generic;
using System.Linq;

namespace TicTacToeLogic
{
    public class BoardGame
    {
        private readonly Cell[,] r_Board;
        private readonly int r_SizeOfBoard;
        private List<Cell> m_FreeCells;

        public BoardGame(int i_SizeOfBoard)
        {
            r_SizeOfBoard = i_SizeOfBoard;
            m_FreeCells = new List<Cell>();
            r_Board = new Cell[r_SizeOfBoard, r_SizeOfBoard];
            initializeBoard();
        }

        public int BoardSize
        {
            get { return r_SizeOfBoard; }
        }

        public Cell[,] Matrix
        {
            get { return r_Board; }
        }

        private void initializeBoard()
        {
            for(int row = 0; row < r_SizeOfBoard; row++)
            {
                for(int col = 0; col < r_SizeOfBoard; col++)
                {
                    Cell newCell = new Cell(row, col, Cell.eSign.E);
                    r_Board[row, col] = newCell;
                    m_FreeCells.Add(newCell);
                }
            }
        }

        public void AddSignToBoard(int i_Row, int i_Col, Cell.eSign i_SignToAdd)
        {
            r_Board[i_Row, i_Col].CellSign = i_SignToAdd;
            m_FreeCells.Remove(r_Board[i_Row, i_Col]);
        }

        private bool checkIfValidPlace(int i_NumToCheck)
        {
            bool flag = false;

            if((i_NumToCheck > 0) && (i_NumToCheck <= r_SizeOfBoard))
            {
                flag = true;
            }

            return flag;
        }

        public bool CheckIfBoardIsFull()
        {
            return !m_FreeCells.Any();
        }

        public void ClearBoard()
        {
            m_FreeCells = new List<Cell>();
            initializeBoard();
        }

        public bool CheckIfLose()
        {
            bool flag = false;

            if(checkIfMainDiagonalIsSameSign() || checkIfSecondaryDiagonalIsSameSign())
            {
                flag = true;
            }

            if(!flag)
            {
                for(int i = 0; i < r_SizeOfBoard; i++)
                {
                    if(checkIfRowIsSameSign(i) || checkIfColIsSameSign(i))
                    {
                        flag = true;
                        break;
                    }
                }
            }

            return flag;
        }

        private bool checkIfRowIsSameSign(int i_RowIndex)
        {
            bool flag = true;

            for(int i = 1; i < r_SizeOfBoard; i++)
            {
                if(r_Board[i_RowIndex, i - 1] != r_Board[i_RowIndex, i])
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        private bool checkIfColIsSameSign(int i_ColIndex)
        {
            bool flag = true;

            for(int i = 1; i < r_SizeOfBoard; i++)
            {
                if(r_Board[i - 1, i_ColIndex] != r_Board[i, i_ColIndex])
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        private bool checkIfMainDiagonalIsSameSign()
        {
            bool flag = true;

            for(int i = 1; i < r_SizeOfBoard; i++)
            {
                if(r_Board[i - 1, i - 1] != r_Board[i, i])
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        private bool checkIfSecondaryDiagonalIsSameSign()
        {
            bool flag = true;
            int boardLength = r_SizeOfBoard;

            for(int i = 1; i < boardLength; i++)
            {
                if(r_Board[boardLength - (i - 1) - 1, i - 1] != r_Board[boardLength - i - 1, i])
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        public Cell AIAddComputerSignToBoard(Cell.eSign i_SignToAdd)
        {
            int maxRank = int.MinValue;
            int[] rowCol = new int[2];
            Cell bestCell = m_FreeCells[0];
            int currentRank = 0;

            foreach(Cell cellTocheck in m_FreeCells)
            {
                currentRank = 0;
                cellTocheck.CellSign = i_SignToAdd;
                if(CheckIfLose())
                {
                    currentRank = int.MinValue;
                }
                else
                {
                    cellTocheck.CellSign = Cell.eSign.X;
                    if(CheckIfLose())
                    {
                        currentRank = int.MinValue + 1;
                    }
                    else
                    {
                        cellTocheck.CellSign = Cell.eSign.E;
                        currentRank += checkRowRank(cellTocheck.Row) +
                                       checkColRank(cellTocheck.Col) +
                                       checkDiagonals(cellTocheck.Row, cellTocheck.Col);
                    }
                }

                if(currentRank > maxRank)
                {
                    maxRank = currentRank;
                    bestCell = cellTocheck;
                }

                cellTocheck.CellSign = Cell.eSign.E;
                }

                bestCell.CellSign = i_SignToAdd;
                m_FreeCells.Remove(bestCell);

                return bestCell;
            }
        
            private int checkDiagonals(int i_Row, int i_Col)
            {
                int rank = 0;

                if(i_Row == i_Col)
                {
                    rank += computeRankOfMainDiagonal();
                }

                if((i_Row + i_Col) == (r_SizeOfBoard - 1))
                {
                    rank += computeRankOfSecondaryDiagonal();
                }

                return rank;
            }

            private int computeRankOfMainDiagonal()
            {
                int rank = 0;

                for(int i = 0; i < r_SizeOfBoard; i++)
                {
                    if(r_Board[i, i].CellSign != Cell.eSign.E)
                    {
                        rank -= 100;
                    }
                }

                return rank;
            }

            private int computeRankOfSecondaryDiagonal()
            {
                int rank = 0;

                for(int i = 0; i < r_SizeOfBoard; i++)
                {
                    if(r_Board[r_SizeOfBoard - i - 1, i].CellSign != Cell.eSign.E)
                    {
                        rank -= 100;
                    }
                }

                return rank;
            }

            private int checkColRank(int i_Col)
            {
                int rank = 0;

                for(int i = 0; i < r_SizeOfBoard; i++)
                {
                    if(r_Board[i, i_Col].CellSign != Cell.eSign.E)
                    {
                        rank -= 100;
                    }
                }

                return rank;
            }

            private int checkRowRank(int i_Row)
            {
                int rank = 0;

                for(int i = 0; i < r_SizeOfBoard; i++)
                {
                    if(r_Board[i_Row, i].CellSign != Cell.eSign.E)
                    {
                        rank -= 100;
                    }
                }

                return rank;
            }  
    }
}