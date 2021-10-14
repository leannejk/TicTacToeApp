namespace TicTacToeLogic
{
    public class Player
    {
        private readonly string r_Name;
        private readonly Cell.eSign r_Sign;
        private readonly bool r_IsComputer;
        private int m_Score = 0;

        public Player(string i_PlayerName, Cell.eSign i_PlayerSign)
        {
            r_Name = i_PlayerName;
            r_Sign = i_PlayerSign;
            r_IsComputer = false;
        }

        public Player(Cell.eSign i_PlayerSign)
        {
            r_Name = "Computer";
            r_Sign = i_PlayerSign;
            r_IsComputer = true;
        }

        public string Name
        {
            get { return r_Name; }
        }

        public Cell.eSign Sign
        {
            get { return r_Sign; }
        }

        public bool IsComputer
        {
            get { return r_IsComputer; }
        }

        public int Score
        {
            get { return m_Score; }

            set { m_Score = value; }
        }
    }
}