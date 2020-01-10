namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ApplicationGatewayRequestRoutingRuleType :
        System.IEquatable<ApplicationGatewayRequestRoutingRuleType>
    {
        /// <summary>FIXME: Field Basic is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRequestRoutingRuleType Basic = @"Basic";

        /// <summary>FIXME: Field PathBasedRouting is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRequestRoutingRuleType PathBasedRouting = @"PathBasedRouting";

        /// <summary>
        /// the value for an instance of the <see cref="ApplicationGatewayRequestRoutingRuleType" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="ApplicationGatewayRequestRoutingRuleType" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ApplicationGatewayRequestRoutingRuleType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ApplicationGatewayRequestRoutingRuleType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayRequestRoutingRuleType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ApplicationGatewayRequestRoutingRuleType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ApplicationGatewayRequestRoutingRuleType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRequestRoutingRuleType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ApplicationGatewayRequestRoutingRuleType (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ApplicationGatewayRequestRoutingRuleType && Equals((ApplicationGatewayRequestRoutingRuleType)obj);
        }

        /// <summary>Returns hashCode for enum ApplicationGatewayRequestRoutingRuleType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ApplicationGatewayRequestRoutingRuleType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ApplicationGatewayRequestRoutingRuleType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayRequestRoutingRuleType" />.</param>

        public static implicit operator ApplicationGatewayRequestRoutingRuleType(string value)
        {
            return new ApplicationGatewayRequestRoutingRuleType(value);
        }

        /// <summary>Implicit operator to convert ApplicationGatewayRequestRoutingRuleType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ApplicationGatewayRequestRoutingRuleType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRequestRoutingRuleType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ApplicationGatewayRequestRoutingRuleType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRequestRoutingRuleType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRequestRoutingRuleType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ApplicationGatewayRequestRoutingRuleType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRequestRoutingRuleType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRequestRoutingRuleType e2)
        {
            return e2.Equals(e1);
        }
    }
}