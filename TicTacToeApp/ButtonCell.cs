using System.Windows.Forms;

namespace TicTacToeApp
{
    public class ButtonCell : Button
    {
        private readonly int r_Row;
        private readonly int r_Col;

        public ButtonCell(int i_Row, int i_Col)
        {
            this.r_Row = i_Row;
            this.r_Col = i_Col;
        }

        public int Row
        {
            get { return this.r_Row; }
        }

        public int Col
        {
            get { return this.r_Col; }
        }
    }
}
