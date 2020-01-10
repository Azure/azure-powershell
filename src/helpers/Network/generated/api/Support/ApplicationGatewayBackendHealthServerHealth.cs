namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ApplicationGatewayBackendHealthServerHealth :
        System.IEquatable<ApplicationGatewayBackendHealthServerHealth>
    {
        /// <summary>FIXME: Field Down is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayBackendHealthServerHealth Down = @"Down";

        /// <summary>FIXME: Field Draining is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayBackendHealthServerHealth Draining = @"Draining";

        /// <summary>FIXME: Field Partial is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayBackendHealthServerHealth Partial = @"Partial";

        /// <summary>FIXME: Field Unknown is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayBackendHealthServerHealth Unknown = @"Unknown";

        /// <summary>FIXME: Field Up is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayBackendHealthServerHealth Up = @"Up";

        /// <summary>
        /// the value for an instance of the <see cref="ApplicationGatewayBackendHealthServerHealth" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="ApplicationGatewayBackendHealthServerHealth" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ApplicationGatewayBackendHealthServerHealth(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ApplicationGatewayBackendHealthServerHealth</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayBackendHealthServerHealth" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ApplicationGatewayBackendHealthServerHealth(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ApplicationGatewayBackendHealthServerHealth</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayBackendHealthServerHealth e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ApplicationGatewayBackendHealthServerHealth (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ApplicationGatewayBackendHealthServerHealth && Equals((ApplicationGatewayBackendHealthServerHealth)obj);
        }

        /// <summary>Returns hashCode for enum ApplicationGatewayBackendHealthServerHealth</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ApplicationGatewayBackendHealthServerHealth</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Implicit operator to convert string to ApplicationGatewayBackendHealthServerHealth
        /// </summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayBackendHealthServerHealth" />.</param>

        public static implicit operator ApplicationGatewayBackendHealthServerHealth(string value)
        {
            return new ApplicationGatewayBackendHealthServerHealth(value);
        }

        /// <summary>
        /// Implicit operator to convert ApplicationGatewayBackendHealthServerHealth to string
        /// </summary>
        /// <param name="e">the value to convert to an instance of <see cref="ApplicationGatewayBackendHealthServerHealth" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayBackendHealthServerHealth e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ApplicationGatewayBackendHealthServerHealth</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayBackendHealthServerHealth e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayBackendHealthServerHealth e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ApplicationGatewayBackendHealthServerHealth</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayBackendHealthServerHealth e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayBackendHealthServerHealth e2)
        {
            return e2.Equals(e1);
        }
    }
}