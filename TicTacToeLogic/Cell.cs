namespace TicTacToeLogic
{
    public class Cell
    {
        public enum eSign
        {
            E = 0,
            X = 1,
            O = 2,
        }

        private readonly int r_Row;
        private readonly int r_Col;
        private eSign m_Sign;

        public static bool operator ==(Cell i_FirstCell, Cell i_SecondCell)
        {
            return (i_FirstCell.m_Sign == i_SecondCell.m_Sign) && (i_FirstCell.m_Sign != eSign.E);
        }

        public static bool operator !=(Cell i_FirstCell, Cell i_SecondCell)
        {
            return !(i_FirstCell == i_SecondCell);
        }

        public Cell(int i_Row, int i_Col, eSign i_Sign)
            : base()
        {
            r_Row = i_Row;
            r_Col = i_Col;
            m_Sign = i_Sign;
        }

        public eSign CellSign
        {
            get { return m_Sign; }
            set { m_Sign = value; }
        }

        public int Row
        {
            get { return r_Row; }
        }

        public int Col
        {
            get { return r_Col; }
        }

        public bool CheckIfEmpty()
        {
            return m_Sign == eSign.E;
        }
    }
}
