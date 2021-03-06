﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace Alba.CsConsoleFormat
{
    [Flags]
    [SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames", Justification = "Enumeration represents options of a single character through extension methods.")]
    public enum LineChar
    {
        None = 0,

        Horizontal = 1 << 0,
        HorizontalWide = 1 << 1,
        Vertical = 1 << 2,
        VerticalWide = 1 << 3,

        MaskHorizontal = Horizontal | HorizontalWide,
        MaskVertical = Vertical | VerticalWide,
    }

    internal static class LineCharExts
    {
        [Pure]
        public static bool IsEmpty(this LineChar @this) => @this.IsNone() || !@this.IsHorizontal() && !@this.IsVertical();

        [Pure]
        public static bool IsNone(this LineChar @this) => @this == LineChar.None;

        [Pure]
        public static bool IsHorizontal(this LineChar @this) => (@this & LineChar.Horizontal) != 0;

        [Pure]
        public static bool IsHorizontalWide(this LineChar @this) => (@this & LineChar.HorizontalWide) != 0;

        [Pure]
        public static bool IsVertical(this LineChar @this) => (@this & LineChar.Vertical) != 0;

        [Pure]
        public static bool IsVerticalWide(this LineChar @this) => (@this & LineChar.VerticalWide) != 0;
    }
}