namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct EffectiveSecurityRuleProtocol :
        System.IEquatable<EffectiveSecurityRuleProtocol>
    {
        /// <summary>FIXME: Field All is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol All = @"All";

        /// <summary>FIXME: Field Tcp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol Tcp = @"Tcp";

        /// <summary>FIXME: Field Udp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol Udp = @"Udp";

        /// <summary>
        /// the value for an instance of the <see cref="EffectiveSecurityRuleProtocol" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to EffectiveSecurityRuleProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="EffectiveSecurityRuleProtocol" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new EffectiveSecurityRuleProtocol(System.Convert.ToString(value));
        }

        /// <summary>
        /// Creates an instance of the <see cref="EffectiveSecurityRuleProtocol" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private EffectiveSecurityRuleProtocol(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Compares values of enum type EffectiveSecurityRuleProtocol</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type EffectiveSecurityRuleProtocol (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is EffectiveSecurityRuleProtocol && Equals((EffectiveSecurityRuleProtocol)obj);
        }

        /// <summary>Returns hashCode for enum EffectiveSecurityRuleProtocol</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for EffectiveSecurityRuleProtocol</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to EffectiveSecurityRuleProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="EffectiveSecurityRuleProtocol" />.</param>

        public static implicit operator EffectiveSecurityRuleProtocol(string value)
        {
            return new EffectiveSecurityRuleProtocol(value);
        }

        /// <summary>Implicit operator to convert EffectiveSecurityRuleProtocol to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="EffectiveSecurityRuleProtocol" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum EffectiveSecurityRuleProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum EffectiveSecurityRuleProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol e2)
        {
            return e2.Equals(e1);
        }
    }
}