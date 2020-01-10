namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct AzureFirewallThreatIntelMode :
        System.IEquatable<AzureFirewallThreatIntelMode>
    {
        /// <summary>FIXME: Field Alert is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode Alert = @"Alert";

        /// <summary>FIXME: Field Deny is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode Deny = @"Deny";

        /// <summary>FIXME: Field Off is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode Off = @"Off";

        /// <summary>
        /// the value for an instance of the <see cref="AzureFirewallThreatIntelMode" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="AzureFirewallThreatIntelMode" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private AzureFirewallThreatIntelMode(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to AzureFirewallThreatIntelMode</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AzureFirewallThreatIntelMode" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new AzureFirewallThreatIntelMode(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type AzureFirewallThreatIntelMode</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type AzureFirewallThreatIntelMode (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is AzureFirewallThreatIntelMode && Equals((AzureFirewallThreatIntelMode)obj);
        }

        /// <summary>Returns hashCode for enum AzureFirewallThreatIntelMode</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for AzureFirewallThreatIntelMode</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to AzureFirewallThreatIntelMode</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AzureFirewallThreatIntelMode" />.</param>

        public static implicit operator AzureFirewallThreatIntelMode(string value)
        {
            return new AzureFirewallThreatIntelMode(value);
        }

        /// <summary>Implicit operator to convert AzureFirewallThreatIntelMode to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="AzureFirewallThreatIntelMode" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum AzureFirewallThreatIntelMode</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum AzureFirewallThreatIntelMode</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode e2)
        {
            return e2.Equals(e1);
        }
    }
}