using System.Globalization;
using System;

public readonly struct ShortFloat : IComparable, IFormattable
{
    public const short MaxValue = 10000;
    public const short MinValue = -10000;

    public int CompareTo(object obj)
    {
        throw new NotImplementedException();
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        throw new NotImplementedException();
    }

    /*public static Int16 Parse(string s, IFormatProvider provider);
    public static Int16 Parse(string s, NumberStyles style, IFormatProvider provider);
    public static Int16 Parse(string s);
    public static Int16 Parse(ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider provider = null);
    public static Int16 Parse(string s, NumberStyles style);
    public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out Int16 result);
    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, out Int16 result);
    public static bool TryParse(ReadOnlySpan<char> s, out Int16 result);
    public static bool TryParse(string s, out Int16 result);
    public int CompareTo(object value);
    public int CompareTo(Int16 value);
    public override bool Equals(object obj);
    public bool Equals(Int16 obj);
    public override int GetHashCode();
    public TypeCode GetTypeCode();
    public override string ToString();
    public string ToString(IFormatProvider provider);
    public string ToString(string format);
    public string ToString(string format, IFormatProvider provider);
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null);*/
}