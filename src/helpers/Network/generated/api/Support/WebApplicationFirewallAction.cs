namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct WebApplicationFirewallAction :
        System.IEquatable<WebApplicationFirewallAction>
    {
        /// <summary>FIXME: Field Allow is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallAction Allow = @"Allow";

        /// <summary>FIXME: Field Block is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallAction Block = @"Block";

        /// <summary>FIXME: Field Log is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallAction Log = @"Log";

        /// <summary>
        /// the value for an instance of the <see cref="WebApplicationFirewallAction" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to WebApplicationFirewallAction</summary>
        /// <param name="value">the value to convert to an instance of <see cref="WebApplicationFirewallAction" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new WebApplicationFirewallAction(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type WebApplicationFirewallAction</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallAction e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type WebApplicationFirewallAction (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is WebApplicationFirewallAction && Equals((WebApplicationFirewallAction)obj);
        }

        /// <summary>Returns hashCode for enum WebApplicationFirewallAction</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for WebApplicationFirewallAction</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Creates an instance of the <see cref="WebApplicationFirewallAction" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private WebApplicationFirewallAction(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to WebApplicationFirewallAction</summary>
        /// <param name="value">the value to convert to an instance of <see cref="WebApplicationFirewallAction" />.</param>

        public static implicit operator WebApplicationFirewallAction(string value)
        {
            return new WebApplicationFirewallAction(value);
        }

        /// <summary>Implicit operator to convert WebApplicationFirewallAction to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="WebApplicationFirewallAction" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallAction e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum WebApplicationFirewallAction</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallAction e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallAction e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum WebApplicationFirewallAction</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallAction e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallAction e2)
        {
            return e2.Equals(e1);
        }
    }
}