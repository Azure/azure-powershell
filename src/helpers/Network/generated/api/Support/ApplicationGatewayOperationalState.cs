namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ApplicationGatewayOperationalState :
        System.IEquatable<ApplicationGatewayOperationalState>
    {
        /// <summary>FIXME: Field Running is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState Running = @"Running";

        /// <summary>FIXME: Field Starting is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState Starting = @"Starting";

        /// <summary>FIXME: Field Stopped is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState Stopped = @"Stopped";

        /// <summary>FIXME: Field Stopping is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState Stopping = @"Stopping";

        /// <summary>
        /// the value for an instance of the <see cref="ApplicationGatewayOperationalState" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="ApplicationGatewayOperationalState" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ApplicationGatewayOperationalState(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ApplicationGatewayOperationalState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayOperationalState" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ApplicationGatewayOperationalState(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ApplicationGatewayOperationalState</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ApplicationGatewayOperationalState (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ApplicationGatewayOperationalState && Equals((ApplicationGatewayOperationalState)obj);
        }

        /// <summary>Returns hashCode for enum ApplicationGatewayOperationalState</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ApplicationGatewayOperationalState</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ApplicationGatewayOperationalState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayOperationalState" />.</param>

        public static implicit operator ApplicationGatewayOperationalState(string value)
        {
            return new ApplicationGatewayOperationalState(value);
        }

        /// <summary>Implicit operator to convert ApplicationGatewayOperationalState to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ApplicationGatewayOperationalState" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ApplicationGatewayOperationalState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ApplicationGatewayOperationalState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState e2)
        {
            return e2.Equals(e1);
        }
    }
}