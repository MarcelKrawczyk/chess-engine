namespace ChessEngine.Core;
public static class MoveFlags
{ 
    public const int None = 0;
    public const int DoublePush = 1;
    public const int EnPassant = 2; 
    public const int CastleKingside = 3; 
    public const int CastleQueenside = 4; 
    public const int Promotion = 5;
}
