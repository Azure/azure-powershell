namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct AzureFirewallApplicationRuleProtocolType :
        System.IEquatable<AzureFirewallApplicationRuleProtocolType>
    {
        /// <summary>FIXME: Field Http is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallApplicationRuleProtocolType Http = @"Http";

        /// <summary>FIXME: Field Https is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallApplicationRuleProtocolType Https = @"Https";

        /// <summary>
        /// the value for an instance of the <see cref="AzureFirewallApplicationRuleProtocolType" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="AzureFirewallApplicationRuleProtocolType" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private AzureFirewallApplicationRuleProtocolType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to AzureFirewallApplicationRuleProtocolType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AzureFirewallApplicationRuleProtocolType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new AzureFirewallApplicationRuleProtocolType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type AzureFirewallApplicationRuleProtocolType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallApplicationRuleProtocolType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type AzureFirewallApplicationRuleProtocolType (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is AzureFirewallApplicationRuleProtocolType && Equals((AzureFirewallApplicationRuleProtocolType)obj);
        }

        /// <summary>Returns hashCode for enum AzureFirewallApplicationRuleProtocolType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for AzureFirewallApplicationRuleProtocolType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to AzureFirewallApplicationRuleProtocolType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AzureFirewallApplicationRuleProtocolType" />.</param>

        public static implicit operator AzureFirewallApplicationRuleProtocolType(string value)
        {
            return new AzureFirewallApplicationRuleProtocolType(value);
        }

        /// <summary>Implicit operator to convert AzureFirewallApplicationRuleProtocolType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="AzureFirewallApplicationRuleProtocolType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallApplicationRuleProtocolType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum AzureFirewallApplicationRuleProtocolType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallApplicationRuleProtocolType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallApplicationRuleProtocolType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum AzureFirewallApplicationRuleProtocolType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallApplicationRuleProtocolType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallApplicationRuleProtocolType e2)
        {
            return e2.Equals(e1);
        }
    }
}