namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ApplicationGatewayProtocol :
        System.IEquatable<ApplicationGatewayProtocol>
    {
        /// <summary>FIXME: Field Http is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol Http = @"Http";

        /// <summary>FIXME: Field Https is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol Https = @"Https";

        /// <summary>
        /// the value for an instance of the <see cref="ApplicationGatewayProtocol" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="ApplicationGatewayProtocol" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ApplicationGatewayProtocol(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ApplicationGatewayProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayProtocol" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ApplicationGatewayProtocol(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ApplicationGatewayProtocol</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ApplicationGatewayProtocol (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ApplicationGatewayProtocol && Equals((ApplicationGatewayProtocol)obj);
        }

        /// <summary>Returns hashCode for enum ApplicationGatewayProtocol</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ApplicationGatewayProtocol</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ApplicationGatewayProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayProtocol" />.</param>

        public static implicit operator ApplicationGatewayProtocol(string value)
        {
            return new ApplicationGatewayProtocol(value);
        }

        /// <summary>Implicit operator to convert ApplicationGatewayProtocol to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ApplicationGatewayProtocol" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ApplicationGatewayProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ApplicationGatewayProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol e2)
        {
            return e2.Equals(e1);
        }
    }
}