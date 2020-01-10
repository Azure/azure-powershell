namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct WebApplicationFirewallMatchVariable :
        System.IEquatable<WebApplicationFirewallMatchVariable>
    {
        /// <summary>FIXME: Field PostArgs is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable PostArgs = @"PostArgs";

        /// <summary>FIXME: Field QueryString is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable QueryString = @"QueryString";

        /// <summary>FIXME: Field RemoteAddr is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable RemoteAddr = @"RemoteAddr";

        /// <summary>FIXME: Field RequestBody is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable RequestBody = @"RequestBody";

        /// <summary>FIXME: Field RequestCookies is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable RequestCookies = @"RequestCookies";

        /// <summary>FIXME: Field RequestHeaders is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable RequestHeaders = @"RequestHeaders";

        /// <summary>FIXME: Field RequestMethod is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable RequestMethod = @"RequestMethod";

        /// <summary>FIXME: Field RequestUri is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable RequestUri = @"RequestUri";

        /// <summary>
        /// the value for an instance of the <see cref="WebApplicationFirewallMatchVariable" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to WebApplicationFirewallMatchVariable</summary>
        /// <param name="value">the value to convert to an instance of <see cref="WebApplicationFirewallMatchVariable" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new WebApplicationFirewallMatchVariable(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type WebApplicationFirewallMatchVariable</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type WebApplicationFirewallMatchVariable (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is WebApplicationFirewallMatchVariable && Equals((WebApplicationFirewallMatchVariable)obj);
        }

        /// <summary>Returns hashCode for enum WebApplicationFirewallMatchVariable</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for WebApplicationFirewallMatchVariable</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Creates an instance of the <see cref="WebApplicationFirewallMatchVariable" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private WebApplicationFirewallMatchVariable(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to WebApplicationFirewallMatchVariable</summary>
        /// <param name="value">the value to convert to an instance of <see cref="WebApplicationFirewallMatchVariable" />.</param>

        public static implicit operator WebApplicationFirewallMatchVariable(string value)
        {
            return new WebApplicationFirewallMatchVariable(value);
        }

        /// <summary>Implicit operator to convert WebApplicationFirewallMatchVariable to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="WebApplicationFirewallMatchVariable" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum WebApplicationFirewallMatchVariable</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum WebApplicationFirewallMatchVariable</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable e2)
        {
            return e2.Equals(e1);
        }
    }
}