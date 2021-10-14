using System.Windows.Forms;
using TicTacToeLogic;

namespace TicTacToeApp
{
    public static class Messages
    {
        private static bool playAgainAnswer(string i_Msg, string i_TypeOfEnd)
        {
            DialogResult answer;
            bool answerBool = false;

            answer = MessageBox.Show(i_Msg, i_TypeOfEnd, MessageBoxButtons.YesNo);
            if(answer == DialogResult.Yes)
            {
                answerBool = true;
            }

            return answerBool;
        }

        public static bool WinEndGame(Player i_WinnerPlayer)
        {
            string msg;
            string type = "A Win!";

            msg = string.Format(
@"
The winner is {0}!
Would you like to play another round",
i_WinnerPlayer.Name);

            return playAgainAnswer(msg, type);
        }

        public static bool TieEndGame()
        {
            string msg;
            string type = "A Tie!";

            msg = string.Format(@"
Tie!
Would you like to play another round");

            return playAgainAnswer(msg, type);
        }
    }
}
