namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ApplicationGatewayFirewallMode :
        System.IEquatable<ApplicationGatewayFirewallMode>
    {
        /// <summary>FIXME: Field Detection is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode Detection = @"Detection";

        /// <summary>FIXME: Field Prevention is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode Prevention = @"Prevention";

        /// <summary>
        /// the value for an instance of the <see cref="ApplicationGatewayFirewallMode" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="ApplicationGatewayFirewallMode" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ApplicationGatewayFirewallMode(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ApplicationGatewayFirewallMode</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayFirewallMode" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ApplicationGatewayFirewallMode(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ApplicationGatewayFirewallMode</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ApplicationGatewayFirewallMode (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ApplicationGatewayFirewallMode && Equals((ApplicationGatewayFirewallMode)obj);
        }

        /// <summary>Returns hashCode for enum ApplicationGatewayFirewallMode</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ApplicationGatewayFirewallMode</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ApplicationGatewayFirewallMode</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayFirewallMode" />.</param>

        public static implicit operator ApplicationGatewayFirewallMode(string value)
        {
            return new ApplicationGatewayFirewallMode(value);
        }

        /// <summary>Implicit operator to convert ApplicationGatewayFirewallMode to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ApplicationGatewayFirewallMode" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ApplicationGatewayFirewallMode</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ApplicationGatewayFirewallMode</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode e2)
        {
            return e2.Equals(e1);
        }
    }
}