namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct DdosCustomPolicyProtocol :
        System.IEquatable<DdosCustomPolicyProtocol>
    {
        /// <summary>FIXME: Field Syn is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyProtocol Syn = @"Syn";

        /// <summary>FIXME: Field Tcp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyProtocol Tcp = @"Tcp";

        /// <summary>FIXME: Field Udp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyProtocol Udp = @"Udp";

        /// <summary>the value for an instance of the <see cref="DdosCustomPolicyProtocol" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to DdosCustomPolicyProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="DdosCustomPolicyProtocol" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new DdosCustomPolicyProtocol(System.Convert.ToString(value));
        }

        /// <summary>Creates an instance of the <see cref="DdosCustomPolicyProtocol" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private DdosCustomPolicyProtocol(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Compares values of enum type DdosCustomPolicyProtocol</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyProtocol e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type DdosCustomPolicyProtocol (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is DdosCustomPolicyProtocol && Equals((DdosCustomPolicyProtocol)obj);
        }

        /// <summary>Returns hashCode for enum DdosCustomPolicyProtocol</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for DdosCustomPolicyProtocol</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to DdosCustomPolicyProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="DdosCustomPolicyProtocol" />.</param>

        public static implicit operator DdosCustomPolicyProtocol(string value)
        {
            return new DdosCustomPolicyProtocol(value);
        }

        /// <summary>Implicit operator to convert DdosCustomPolicyProtocol to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="DdosCustomPolicyProtocol" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyProtocol e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum DdosCustomPolicyProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyProtocol e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum DdosCustomPolicyProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyProtocol e2)
        {
            return e2.Equals(e1);
        }
    }
}