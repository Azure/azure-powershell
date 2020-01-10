namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct WebApplicationFirewallOperator :
        System.IEquatable<WebApplicationFirewallOperator>
    {
        /// <summary>FIXME: Field BeginsWith is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator BeginsWith = @"BeginsWith";

        /// <summary>FIXME: Field Contains is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator Contains = @"Contains";

        /// <summary>FIXME: Field EndsWith is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator EndsWith = @"EndsWith";

        /// <summary>FIXME: Field Equal is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator Equal = @"Equal";

        /// <summary>FIXME: Field GreaterThan is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator GreaterThan = @"GreaterThan";

        /// <summary>FIXME: Field GreaterThanOrEqual is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator GreaterThanOrEqual = @"GreaterThanOrEqual";

        /// <summary>FIXME: Field IPMatch is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator IPMatch = @"IPMatch";

        /// <summary>FIXME: Field LessThan is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator LessThan = @"LessThan";

        /// <summary>FIXME: Field LessThanOrEqual is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator LessThanOrEqual = @"LessThanOrEqual";

        /// <summary>FIXME: Field Regex is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator Regex = @"Regex";

        /// <summary>
        /// the value for an instance of the <see cref="WebApplicationFirewallOperator" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to WebApplicationFirewallOperator</summary>
        /// <param name="value">the value to convert to an instance of <see cref="WebApplicationFirewallOperator" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new WebApplicationFirewallOperator(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type WebApplicationFirewallOperator</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type WebApplicationFirewallOperator (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is WebApplicationFirewallOperator && Equals((WebApplicationFirewallOperator)obj);
        }

        /// <summary>Returns hashCode for enum WebApplicationFirewallOperator</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for WebApplicationFirewallOperator</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Creates an instance of the <see cref="WebApplicationFirewallOperator" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private WebApplicationFirewallOperator(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to WebApplicationFirewallOperator</summary>
        /// <param name="value">the value to convert to an instance of <see cref="WebApplicationFirewallOperator" />.</param>

        public static implicit operator WebApplicationFirewallOperator(string value)
        {
            return new WebApplicationFirewallOperator(value);
        }

        /// <summary>Implicit operator to convert WebApplicationFirewallOperator to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="WebApplicationFirewallOperator" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum WebApplicationFirewallOperator</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum WebApplicationFirewallOperator</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator e2)
        {
            return e2.Equals(e1);
        }
    }
}