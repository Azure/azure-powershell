namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ApplicationGatewaySslPolicyName :
        System.IEquatable<ApplicationGatewaySslPolicyName>
    {
        /// <summary>FIXME: Field AppGwSslPolicy20150501 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName AppGwSslPolicy20150501 = @"AppGwSslPolicy20150501";

        /// <summary>FIXME: Field AppGwSslPolicy20170401 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName AppGwSslPolicy20170401 = @"AppGwSslPolicy20170401";

        /// <summary>FIXME: Field AppGwSslPolicy20170401S is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName AppGwSslPolicy20170401S = @"AppGwSslPolicy20170401S";

        /// <summary>
        /// the value for an instance of the <see cref="ApplicationGatewaySslPolicyName" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="ApplicationGatewaySslPolicyName" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ApplicationGatewaySslPolicyName(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ApplicationGatewaySslPolicyName</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewaySslPolicyName" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ApplicationGatewaySslPolicyName(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ApplicationGatewaySslPolicyName</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ApplicationGatewaySslPolicyName (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ApplicationGatewaySslPolicyName && Equals((ApplicationGatewaySslPolicyName)obj);
        }

        /// <summary>Returns hashCode for enum ApplicationGatewaySslPolicyName</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ApplicationGatewaySslPolicyName</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ApplicationGatewaySslPolicyName</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewaySslPolicyName" />.</param>

        public static implicit operator ApplicationGatewaySslPolicyName(string value)
        {
            return new ApplicationGatewaySslPolicyName(value);
        }

        /// <summary>Implicit operator to convert ApplicationGatewaySslPolicyName to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ApplicationGatewaySslPolicyName" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ApplicationGatewaySslPolicyName</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ApplicationGatewaySslPolicyName</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName e2)
        {
            return e2.Equals(e1);
        }
    }
}