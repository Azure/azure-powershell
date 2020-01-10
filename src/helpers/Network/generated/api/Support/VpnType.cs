namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct VpnType :
        System.IEquatable<VpnType>
    {
        /// <summary>FIXME: Field PolicyBased is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType PolicyBased = @"PolicyBased";

        /// <summary>FIXME: Field RouteBased is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType RouteBased = @"RouteBased";

        /// <summary>the value for an instance of the <see cref="VpnType" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to VpnType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VpnType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new VpnType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type VpnType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type VpnType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is VpnType && Equals((VpnType)obj);
        }

        /// <summary>Returns hashCode for enum VpnType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for VpnType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Creates an instance of the <see cref="VpnType" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private VpnType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to VpnType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VpnType" />.</param>

        public static implicit operator VpnType(string value)
        {
            return new VpnType(value);
        }

        /// <summary>Implicit operator to convert VpnType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="VpnType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum VpnType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum VpnType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType e2)
        {
            return e2.Equals(e1);
        }
    }
}