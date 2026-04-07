namespace ChessEngine.Core
{
    public static class Castling
    {
        public const int None           = 0;
        public const int WhiteKingside  = 1;
        public const int WhiteQueenside = 2;
        public const int BlackKingside  = 4;
        public const int BlackQueenside = 8;
        public const int All            = 15;

        public static string ToString(int rights)
        {
            if (rights == None) return "-";
            string s = "";
            if ((rights & WhiteKingside)  != 0) s += "K";
            if ((rights & WhiteQueenside) != 0) s += "Q";
            if ((rights & BlackKingside)  != 0) s += "k";
            if ((rights & BlackQueenside) != 0) s += "q";
            return s;
        }
    }
}