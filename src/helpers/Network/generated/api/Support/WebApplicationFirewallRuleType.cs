namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct WebApplicationFirewallRuleType :
        System.IEquatable<WebApplicationFirewallRuleType>
    {
        /// <summary>FIXME: Field Invalid is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallRuleType Invalid = @"Invalid";

        /// <summary>FIXME: Field MatchRule is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallRuleType MatchRule = @"MatchRule";

        /// <summary>
        /// the value for an instance of the <see cref="WebApplicationFirewallRuleType" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to WebApplicationFirewallRuleType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="WebApplicationFirewallRuleType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new WebApplicationFirewallRuleType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type WebApplicationFirewallRuleType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallRuleType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type WebApplicationFirewallRuleType (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is WebApplicationFirewallRuleType && Equals((WebApplicationFirewallRuleType)obj);
        }

        /// <summary>Returns hashCode for enum WebApplicationFirewallRuleType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for WebApplicationFirewallRuleType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Creates an instance of the <see cref="WebApplicationFirewallRuleType" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private WebApplicationFirewallRuleType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to WebApplicationFirewallRuleType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="WebApplicationFirewallRuleType" />.</param>

        public static implicit operator WebApplicationFirewallRuleType(string value)
        {
            return new WebApplicationFirewallRuleType(value);
        }

        /// <summary>Implicit operator to convert WebApplicationFirewallRuleType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="WebApplicationFirewallRuleType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallRuleType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum WebApplicationFirewallRuleType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallRuleType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallRuleType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum WebApplicationFirewallRuleType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallRuleType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallRuleType e2)
        {
            return e2.Equals(e1);
        }
    }
}