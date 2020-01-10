namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct VirtualNetworkGatewayConnectionType :
        System.IEquatable<VirtualNetworkGatewayConnectionType>
    {
        /// <summary>FIXME: Field ExpressRoute is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType ExpressRoute = @"ExpressRoute";

        /// <summary>FIXME: Field IPsec is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType IPsec = @"IPsec";

        /// <summary>FIXME: Field Vnet2Vnet is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType Vnet2Vnet = @"Vnet2Vnet";

        /// <summary>FIXME: Field VpnClient is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType VpnClient = @"VPNClient";

        /// <summary>
        /// the value for an instance of the <see cref="VirtualNetworkGatewayConnectionType" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to VirtualNetworkGatewayConnectionType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualNetworkGatewayConnectionType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new VirtualNetworkGatewayConnectionType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type VirtualNetworkGatewayConnectionType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type VirtualNetworkGatewayConnectionType (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is VirtualNetworkGatewayConnectionType && Equals((VirtualNetworkGatewayConnectionType)obj);
        }

        /// <summary>Returns hashCode for enum VirtualNetworkGatewayConnectionType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for VirtualNetworkGatewayConnectionType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Creates an instance of the <see cref="VirtualNetworkGatewayConnectionType" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private VirtualNetworkGatewayConnectionType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to VirtualNetworkGatewayConnectionType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualNetworkGatewayConnectionType" />.</param>

        public static implicit operator VirtualNetworkGatewayConnectionType(string value)
        {
            return new VirtualNetworkGatewayConnectionType(value);
        }

        /// <summary>Implicit operator to convert VirtualNetworkGatewayConnectionType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="VirtualNetworkGatewayConnectionType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum VirtualNetworkGatewayConnectionType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum VirtualNetworkGatewayConnectionType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType e2)
        {
            return e2.Equals(e1);
        }
    }
}