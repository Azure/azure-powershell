namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct Origin :
        System.IEquatable<Origin>
    {
        /// <summary>FIXME: Field Inbound is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin Inbound = @"Inbound";

        /// <summary>FIXME: Field Local is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin Local = @"Local";

        /// <summary>FIXME: Field Outbound is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin Outbound = @"Outbound";

        /// <summary>the value for an instance of the <see cref="Origin" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to Origin</summary>
        /// <param name="value">the value to convert to an instance of <see cref="Origin" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new Origin(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type Origin</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type Origin (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is Origin && Equals((Origin)obj);
        }

        /// <summary>Returns hashCode for enum Origin</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="Origin" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private Origin(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for Origin</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to Origin</summary>
        /// <param name="value">the value to convert to an instance of <see cref="Origin" />.</param>

        public static implicit operator Origin(string value)
        {
            return new Origin(value);
        }

        /// <summary>Implicit operator to convert Origin to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="Origin" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum Origin</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum Origin</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin e2)
        {
            return e2.Equals(e1);
        }
    }
}