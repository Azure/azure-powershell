namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct VpnGatewayTunnelingProtocol :
        System.IEquatable<VpnGatewayTunnelingProtocol>
    {
        /// <summary>FIXME: Field IkeV2 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol IkeV2 = @"IkeV2";

        /// <summary>FIXME: Field OpenVpn is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol OpenVpn = @"OpenVPN";

        /// <summary>
        /// the value for an instance of the <see cref="VpnGatewayTunnelingProtocol" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to VpnGatewayTunnelingProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VpnGatewayTunnelingProtocol" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new VpnGatewayTunnelingProtocol(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type VpnGatewayTunnelingProtocol</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type VpnGatewayTunnelingProtocol (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is VpnGatewayTunnelingProtocol && Equals((VpnGatewayTunnelingProtocol)obj);
        }

        /// <summary>Returns hashCode for enum VpnGatewayTunnelingProtocol</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for VpnGatewayTunnelingProtocol</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Creates an instance of the <see cref="VpnGatewayTunnelingProtocol" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private VpnGatewayTunnelingProtocol(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to VpnGatewayTunnelingProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VpnGatewayTunnelingProtocol" />.</param>

        public static implicit operator VpnGatewayTunnelingProtocol(string value)
        {
            return new VpnGatewayTunnelingProtocol(value);
        }

        /// <summary>Implicit operator to convert VpnGatewayTunnelingProtocol to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="VpnGatewayTunnelingProtocol" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum VpnGatewayTunnelingProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum VpnGatewayTunnelingProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol e2)
        {
            return e2.Equals(e1);
        }
    }
}