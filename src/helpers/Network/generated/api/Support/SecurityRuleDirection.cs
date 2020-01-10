namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct SecurityRuleDirection :
        System.IEquatable<SecurityRuleDirection>
    {
        /// <summary>FIXME: Field Inbound is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection Inbound = @"Inbound";

        /// <summary>FIXME: Field Outbound is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection Outbound = @"Outbound";

        /// <summary>the value for an instance of the <see cref="SecurityRuleDirection" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to SecurityRuleDirection</summary>
        /// <param name="value">the value to convert to an instance of <see cref="SecurityRuleDirection" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new SecurityRuleDirection(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type SecurityRuleDirection</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type SecurityRuleDirection (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is SecurityRuleDirection && Equals((SecurityRuleDirection)obj);
        }

        /// <summary>Returns hashCode for enum SecurityRuleDirection</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="SecurityRuleDirection" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private SecurityRuleDirection(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for SecurityRuleDirection</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to SecurityRuleDirection</summary>
        /// <param name="value">the value to convert to an instance of <see cref="SecurityRuleDirection" />.</param>

        public static implicit operator SecurityRuleDirection(string value)
        {
            return new SecurityRuleDirection(value);
        }

        /// <summary>Implicit operator to convert SecurityRuleDirection to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="SecurityRuleDirection" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum SecurityRuleDirection</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum SecurityRuleDirection</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection e2)
        {
            return e2.Equals(e1);
        }
    }
}