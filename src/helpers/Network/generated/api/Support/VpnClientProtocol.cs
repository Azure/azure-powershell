namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct VpnClientProtocol :
        System.IEquatable<VpnClientProtocol>
    {
        /// <summary>FIXME: Field IkeV2 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol IkeV2 = @"IkeV2";

        /// <summary>FIXME: Field OpenVpn is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol OpenVpn = @"OpenVPN";

        /// <summary>FIXME: Field Sstp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol Sstp = @"SSTP";

        /// <summary>the value for an instance of the <see cref="VpnClientProtocol" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to VpnClientProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VpnClientProtocol" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new VpnClientProtocol(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type VpnClientProtocol</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type VpnClientProtocol (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is VpnClientProtocol && Equals((VpnClientProtocol)obj);
        }

        /// <summary>Returns hashCode for enum VpnClientProtocol</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for VpnClientProtocol</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Creates an instance of the <see cref="VpnClientProtocol" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private VpnClientProtocol(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to VpnClientProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VpnClientProtocol" />.</param>

        public static implicit operator VpnClientProtocol(string value)
        {
            return new VpnClientProtocol(value);
        }

        /// <summary>Implicit operator to convert VpnClientProtocol to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="VpnClientProtocol" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum VpnClientProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum VpnClientProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol e2)
        {
            return e2.Equals(e1);
        }
    }
}