using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Support
{
    public partial struct Count : IEquatable<Count>
    {
        public static Count One = 1;
        public static Count Three = 3;
        public static Count Five = 5;

        private int _value { get; set; }
        private Count(int underlyingValue)
        {
            _value = underlyingValue;
        }
        
        public static implicit operator Count(int value)
        {
            return new Count(value);
        }

        internal static object CreateFrom(object value)
        {
            return new Count(Convert.ToInt32(value));
        }

        public bool Equals(Count other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(object obj)
        {
            return obj is Count && Equals((Count)obj);
        }

        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        public override string ToString()
        {
            return this._value.ToString();
        }

        public static implicit operator string(Count e)
        {
            return e._value.ToString();
        }

        public static bool operator !=(Count e1, Count e2)
        {
            return !e2.Equals(e1);
        }

        public static bool operator ==(Count e1, Count e2)
        {
            return e2.Equals(e1);
        }
    }
}
