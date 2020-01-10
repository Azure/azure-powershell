namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ApplicationGatewaySslProtocol :
        System.IEquatable<ApplicationGatewaySslProtocol>
    {
        /// <summary>FIXME: Field TlSv10 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol TlSv10 = @"TLSv1_0";

        /// <summary>FIXME: Field TlSv11 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol TlSv11 = @"TLSv1_1";

        /// <summary>FIXME: Field TlSv12 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol TlSv12 = @"TLSv1_2";

        /// <summary>
        /// the value for an instance of the <see cref="ApplicationGatewaySslProtocol" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="ApplicationGatewaySslProtocol" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ApplicationGatewaySslProtocol(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ApplicationGatewaySslProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewaySslProtocol" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ApplicationGatewaySslProtocol(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ApplicationGatewaySslProtocol</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ApplicationGatewaySslProtocol (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ApplicationGatewaySslProtocol && Equals((ApplicationGatewaySslProtocol)obj);
        }

        /// <summary>Returns hashCode for enum ApplicationGatewaySslProtocol</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ApplicationGatewaySslProtocol</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ApplicationGatewaySslProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewaySslProtocol" />.</param>

        public static implicit operator ApplicationGatewaySslProtocol(string value)
        {
            return new ApplicationGatewaySslProtocol(value);
        }

        /// <summary>Implicit operator to convert ApplicationGatewaySslProtocol to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ApplicationGatewaySslProtocol" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ApplicationGatewaySslProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ApplicationGatewaySslProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol e2)
        {
            return e2.Equals(e1);
        }
    }
}