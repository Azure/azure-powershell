namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ApplicationGatewaySslPolicyType :
        System.IEquatable<ApplicationGatewaySslPolicyType>
    {
        /// <summary>FIXME: Field Custom is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType Custom = @"Custom";

        /// <summary>FIXME: Field Predefined is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType Predefined = @"Predefined";

        /// <summary>
        /// the value for an instance of the <see cref="ApplicationGatewaySslPolicyType" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="ApplicationGatewaySslPolicyType" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ApplicationGatewaySslPolicyType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ApplicationGatewaySslPolicyType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewaySslPolicyType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ApplicationGatewaySslPolicyType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ApplicationGatewaySslPolicyType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ApplicationGatewaySslPolicyType (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ApplicationGatewaySslPolicyType && Equals((ApplicationGatewaySslPolicyType)obj);
        }

        /// <summary>Returns hashCode for enum ApplicationGatewaySslPolicyType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ApplicationGatewaySslPolicyType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ApplicationGatewaySslPolicyType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewaySslPolicyType" />.</param>

        public static implicit operator ApplicationGatewaySslPolicyType(string value)
        {
            return new ApplicationGatewaySslPolicyType(value);
        }

        /// <summary>Implicit operator to convert ApplicationGatewaySslPolicyType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ApplicationGatewaySslPolicyType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ApplicationGatewaySslPolicyType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ApplicationGatewaySslPolicyType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType e2)
        {
            return e2.Equals(e1);
        }
    }
}