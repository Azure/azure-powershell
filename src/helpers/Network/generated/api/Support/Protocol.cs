namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct Protocol :
        System.IEquatable<Protocol>
    {
        /// <summary>FIXME: Field Http is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol Http = @"Http";

        /// <summary>FIXME: Field Https is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol Https = @"Https";

        /// <summary>FIXME: Field Icmp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol Icmp = @"Icmp";

        /// <summary>FIXME: Field Tcp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol Tcp = @"Tcp";

        /// <summary>the value for an instance of the <see cref="Protocol" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to Protocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="Protocol" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new Protocol(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type Protocol</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type Protocol (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is Protocol && Equals((Protocol)obj);
        }

        /// <summary>Returns hashCode for enum Protocol</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="Protocol" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private Protocol(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for Protocol</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to Protocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="Protocol" />.</param>

        public static implicit operator Protocol(string value)
        {
            return new Protocol(value);
        }

        /// <summary>Implicit operator to convert Protocol to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="Protocol" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum Protocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum Protocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol e2)
        {
            return e2.Equals(e1);
        }
    }
}