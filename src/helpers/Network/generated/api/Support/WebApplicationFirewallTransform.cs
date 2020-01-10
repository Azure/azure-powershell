namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct WebApplicationFirewallTransform :
        System.IEquatable<WebApplicationFirewallTransform>
    {
        /// <summary>FIXME: Field HtmlEntityDecode is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform HtmlEntityDecode = @"HtmlEntityDecode";

        /// <summary>FIXME: Field Lowercase is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform Lowercase = @"Lowercase";

        /// <summary>FIXME: Field RemoveNulls is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform RemoveNulls = @"RemoveNulls";

        /// <summary>FIXME: Field Trim is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform Trim = @"Trim";

        /// <summary>FIXME: Field UrlDecode is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform UrlDecode = @"UrlDecode";

        /// <summary>FIXME: Field UrlEncode is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform UrlEncode = @"UrlEncode";

        /// <summary>
        /// the value for an instance of the <see cref="WebApplicationFirewallTransform" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to WebApplicationFirewallTransform</summary>
        /// <param name="value">the value to convert to an instance of <see cref="WebApplicationFirewallTransform" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new WebApplicationFirewallTransform(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type WebApplicationFirewallTransform</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type WebApplicationFirewallTransform (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is WebApplicationFirewallTransform && Equals((WebApplicationFirewallTransform)obj);
        }

        /// <summary>Returns hashCode for enum WebApplicationFirewallTransform</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for WebApplicationFirewallTransform</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Creates an instance of the <see cref="WebApplicationFirewallTransform" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private WebApplicationFirewallTransform(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to WebApplicationFirewallTransform</summary>
        /// <param name="value">the value to convert to an instance of <see cref="WebApplicationFirewallTransform" />.</param>

        public static implicit operator WebApplicationFirewallTransform(string value)
        {
            return new WebApplicationFirewallTransform(value);
        }

        /// <summary>Implicit operator to convert WebApplicationFirewallTransform to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="WebApplicationFirewallTransform" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum WebApplicationFirewallTransform</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum WebApplicationFirewallTransform</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform e2)
        {
            return e2.Equals(e1);
        }
    }
}