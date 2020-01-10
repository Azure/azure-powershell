namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct IPVersion :
        System.IEquatable<IPVersion>
    {
        /// <summary>FIXME: Field IPv4 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion IPv4 = @"IPv4";

        /// <summary>FIXME: Field IPv6 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion IPv6 = @"IPv6";

        /// <summary>the value for an instance of the <see cref="IPVersion" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to IPVersion</summary>
        /// <param name="value">the value to convert to an instance of <see cref="IPVersion" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new IPVersion(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type IPVersion</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type IPVersion (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is IPVersion && Equals((IPVersion)obj);
        }

        /// <summary>Returns hashCode for enum IPVersion</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="IPVersion" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private IPVersion(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for IPVersion</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to IPVersion</summary>
        /// <param name="value">the value to convert to an instance of <see cref="IPVersion" />.</param>

        public static implicit operator IPVersion(string value)
        {
            return new IPVersion(value);
        }

        /// <summary>Implicit operator to convert IPVersion to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="IPVersion" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum IPVersion</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum IPVersion</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion e2)
        {
            return e2.Equals(e1);
        }
    }
}