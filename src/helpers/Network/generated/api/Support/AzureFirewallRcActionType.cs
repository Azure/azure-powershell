namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct AzureFirewallRcActionType :
        System.IEquatable<AzureFirewallRcActionType>
    {
        /// <summary>FIXME: Field Allow is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallRcActionType Allow = @"Allow";

        /// <summary>FIXME: Field Deny is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallRcActionType Deny = @"Deny";

        /// <summary>the value for an instance of the <see cref="AzureFirewallRcActionType" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="AzureFirewallRcActionType" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private AzureFirewallRcActionType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to AzureFirewallRcActionType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AzureFirewallRcActionType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new AzureFirewallRcActionType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type AzureFirewallRcActionType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallRcActionType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type AzureFirewallRcActionType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is AzureFirewallRcActionType && Equals((AzureFirewallRcActionType)obj);
        }

        /// <summary>Returns hashCode for enum AzureFirewallRcActionType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for AzureFirewallRcActionType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to AzureFirewallRcActionType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AzureFirewallRcActionType" />.</param>

        public static implicit operator AzureFirewallRcActionType(string value)
        {
            return new AzureFirewallRcActionType(value);
        }

        /// <summary>Implicit operator to convert AzureFirewallRcActionType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="AzureFirewallRcActionType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallRcActionType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum AzureFirewallRcActionType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallRcActionType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallRcActionType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum AzureFirewallRcActionType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallRcActionType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallRcActionType e2)
        {
            return e2.Equals(e1);
        }
    }
}