using System.Runtime.CompilerServices;

namespace ChessEngine.Core;

public static class Move {
    public const int None = 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Encode(int from, int to, int piece, int captured = 12, int promoted = 12, int flags = 0) 
        => from | (to << 6) | (piece << 12) | (captured << 16) | (promoted << 20) | (flags << 24);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int From(int move) => move & 0x3F;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int To(int move) => (move >> 6) & 0x3F;
    [MethodImpl(MethodImplOptions.AggressiveInlining)] 
    public static int MovedPiece(int move) => (move >> 12) & 0xF;
    [MethodImpl(MethodImplOptions.AggressiveInlining)] 
    public static int Captured(int move) => (move >> 16) & 0xF;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Promoted(int move) => (move >> 20) & 0xF;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Flags(int move) => (move >> 24) & 0xF;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsCapture(int move) => Captured(move) != Piece.None;

    [MethodImpl(MethodImplOptions.AggressiveInlining)] 
    public static bool IsPromotion(int move) => Flags(move) == MoveFlags.Promotion;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsCastle(int move)
    { 
        int f = Flags(move);
        return f == MoveFlags.CastleKingside || f == MoveFlags.CastleQueenside;
    }
    public static string SquareName(int sq) => $"{(char)('a' + sq % 8)}{sq / 8 + 1}";
    public static int SquareFromName(string s) => (s[0] - 'a') + (s[1] - '1') * 8;
    public static string ToUci(int move)
    { 
        string s = SquareName(From(move)) + SquareName(To(move));
        if (IsPromotion(move)) { 
            char[] promChars = { 'p', 'n', 'b', 'r', 'q', 'k' };
            s += promChars[Piece.TypeOf(Promoted(move))];
        }
        return s;
    }
}