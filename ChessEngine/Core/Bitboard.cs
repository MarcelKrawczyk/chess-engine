using System.Numerics;
using System.Runtime.CompilerServices;

namespace ChessEngine.Core
{
    public static class Bitboard
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LsbIndex(ulong bb) => BitOperations.TrailingZeroCount(bb);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int PopLsb(ref ulong bb)
        {
            int sq = LsbIndex(bb);
            bb &= bb - 1;
            return sq;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int PopCount(ulong bb) => BitOperations.PopCount(bb);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool MoreThanOne(ulong bb) => (bb & (bb - 1)) != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong LsbBit(ulong bb) => bb & (ulong)(-(long)bb);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong SquareBit(int sq) => 1UL << sq;
    }
}