namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct SecurityRuleProtocol :
        System.IEquatable<SecurityRuleProtocol>
    {
        /// <summary>FIXME: Field All is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol All = @"*";

        /// <summary>FIXME: Field Esp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol Esp = @"Esp";

        /// <summary>FIXME: Field Icmp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol Icmp = @"Icmp";

        /// <summary>FIXME: Field Tcp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol Tcp = @"Tcp";

        /// <summary>FIXME: Field Udp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol Udp = @"Udp";

        /// <summary>the value for an instance of the <see cref="SecurityRuleProtocol" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to SecurityRuleProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="SecurityRuleProtocol" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new SecurityRuleProtocol(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type SecurityRuleProtocol</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type SecurityRuleProtocol (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is SecurityRuleProtocol && Equals((SecurityRuleProtocol)obj);
        }

        /// <summary>Returns hashCode for enum SecurityRuleProtocol</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="SecurityRuleProtocol" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private SecurityRuleProtocol(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for SecurityRuleProtocol</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to SecurityRuleProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="SecurityRuleProtocol" />.</param>

        public static implicit operator SecurityRuleProtocol(string value)
        {
            return new SecurityRuleProtocol(value);
        }

        /// <summary>Implicit operator to convert SecurityRuleProtocol to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="SecurityRuleProtocol" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum SecurityRuleProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum SecurityRuleProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol e2)
        {
            return e2.Equals(e1);
        }
    }
}