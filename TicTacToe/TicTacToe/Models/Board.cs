namespace TicTacToe.Models
{
    public class Board
    {
        public string[] chars = new string[9];
        public string winText = "";
        public bool player = true;
        private int[,] winLines = new int[8, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };

        public bool solve()
        {
            for (int i = 0; i < 8; ++i)
            {
                if (chars[winLines[i, 0]] != null && chars[winLines[i, 1]] != null && chars[winLines[i, 2]] != null)
                {
                    if (chars[winLines[i, 0]] == chars[winLines[i, 1]] && chars[winLines[i, 0]] == chars[winLines[i, 2]])
                    {
                        winText = chars[winLines[i, 0]] + " wins";
                        return true;
                    }
                }
            }
            return false;
        }
        public void fill()
        {
            for (int i = 0; i < 9; ++i)
            {
                if (chars[i] == null)
                    chars[i] = " ";
            }
        }

    }
}