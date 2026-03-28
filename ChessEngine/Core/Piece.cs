namespace ChessEngine.Core;
public static class Piece
{
    public const int WhitePawn = 0; 
    public const int WhiteKnight = 1; 
    public const int WhiteBishop = 2;
    public const int WhiteRook = 3; 
    public const int WhiteQueen = 4; 
    public const int WhiteKing = 5;
    public const int BlackPawn = 6;
    public const int BlackKnight = 7;
    public const int BlackBishop = 8;
    public const int BlackRook = 9;
    public const int BlackQueen = 10;
    public const int BlackKing = 11;
    public const int None = 12;

    public const int White = 0;
    public const int Black = 1;

    public static int ColorOf(int piece) => piece >= 6 ? Black : White;
    public static int TypeOf(int piece)  => piece % 6;
    public static int Make(int color, int type) => color * 6 + type;
    private static readonly char[] Glyphs = { 'P','N','B','R','Q','K','p','n','b','r','q','k','.' };
    public static char ToChar(int piece) => Glyphs[piece];
    }
