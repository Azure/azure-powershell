namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ProbeProtocol :
        System.IEquatable<ProbeProtocol>
    {
        /// <summary>FIXME: Field Http is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol Http = @"Http";

        /// <summary>FIXME: Field Https is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol Https = @"Https";

        /// <summary>FIXME: Field Tcp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol Tcp = @"Tcp";

        /// <summary>the value for an instance of the <see cref="ProbeProtocol" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to ProbeProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ProbeProtocol" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ProbeProtocol(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ProbeProtocol</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ProbeProtocol (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ProbeProtocol && Equals((ProbeProtocol)obj);
        }

        /// <summary>Returns hashCode for enum ProbeProtocol</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="ProbeProtocol" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ProbeProtocol(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for ProbeProtocol</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ProbeProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ProbeProtocol" />.</param>

        public static implicit operator ProbeProtocol(string value)
        {
            return new ProbeProtocol(value);
        }

        /// <summary>Implicit operator to convert ProbeProtocol to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ProbeProtocol" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ProbeProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ProbeProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol e2)
        {
            return e2.Equals(e1);
        }
    }
}