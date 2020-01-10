namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct WebApplicationFirewallPolicyResourceState :
        System.IEquatable<WebApplicationFirewallPolicyResourceState>
    {
        /// <summary>FIXME: Field Creating is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState Creating = @"Creating";

        /// <summary>FIXME: Field Deleting is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState Deleting = @"Deleting";

        /// <summary>FIXME: Field Disabled is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState Disabled = @"Disabled";

        /// <summary>FIXME: Field Disabling is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState Disabling = @"Disabling";

        /// <summary>FIXME: Field Enabled is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState Enabled = @"Enabled";

        /// <summary>FIXME: Field Enabling is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState Enabling = @"Enabling";

        /// <summary>
        /// the value for an instance of the <see cref="WebApplicationFirewallPolicyResourceState" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to WebApplicationFirewallPolicyResourceState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="WebApplicationFirewallPolicyResourceState" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new WebApplicationFirewallPolicyResourceState(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type WebApplicationFirewallPolicyResourceState</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type WebApplicationFirewallPolicyResourceState (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is WebApplicationFirewallPolicyResourceState && Equals((WebApplicationFirewallPolicyResourceState)obj);
        }

        /// <summary>Returns hashCode for enum WebApplicationFirewallPolicyResourceState</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for WebApplicationFirewallPolicyResourceState</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Creates an instance of the <see cref="WebApplicationFirewallPolicyResourceState" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private WebApplicationFirewallPolicyResourceState(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>
        /// Implicit operator to convert string to WebApplicationFirewallPolicyResourceState
        /// </summary>
        /// <param name="value">the value to convert to an instance of <see cref="WebApplicationFirewallPolicyResourceState" />.</param>

        public static implicit operator WebApplicationFirewallPolicyResourceState(string value)
        {
            return new WebApplicationFirewallPolicyResourceState(value);
        }

        /// <summary>
        /// Implicit operator to convert WebApplicationFirewallPolicyResourceState to string
        /// </summary>
        /// <param name="e">the value to convert to an instance of <see cref="WebApplicationFirewallPolicyResourceState" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum WebApplicationFirewallPolicyResourceState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum WebApplicationFirewallPolicyResourceState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState e2)
        {
            return e2.Equals(e1);
        }
    }
}