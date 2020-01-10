namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct Direction :
        System.IEquatable<Direction>
    {
        /// <summary>FIXME: Field Inbound is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction Inbound = @"Inbound";

        /// <summary>FIXME: Field Outbound is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction Outbound = @"Outbound";

        /// <summary>the value for an instance of the <see cref="Direction" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to Direction</summary>
        /// <param name="value">the value to convert to an instance of <see cref="Direction" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new Direction(System.Convert.ToString(value));
        }

        /// <summary>Creates an instance of the <see cref="Direction" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private Direction(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Compares values of enum type Direction</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type Direction (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is Direction && Equals((Direction)obj);
        }

        /// <summary>Returns hashCode for enum Direction</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for Direction</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to Direction</summary>
        /// <param name="value">the value to convert to an instance of <see cref="Direction" />.</param>

        public static implicit operator Direction(string value)
        {
            return new Direction(value);
        }

        /// <summary>Implicit operator to convert Direction to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="Direction" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum Direction</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum Direction</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction e2)
        {
            return e2.Equals(e1);
        }
    }
}