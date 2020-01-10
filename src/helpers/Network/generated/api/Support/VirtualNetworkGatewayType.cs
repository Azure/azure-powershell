namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct VirtualNetworkGatewayType :
        System.IEquatable<VirtualNetworkGatewayType>
    {
        /// <summary>FIXME: Field ExpressRoute is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType ExpressRoute = @"ExpressRoute";

        /// <summary>FIXME: Field Vpn is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType Vpn = @"Vpn";

        /// <summary>the value for an instance of the <see cref="VirtualNetworkGatewayType" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to VirtualNetworkGatewayType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualNetworkGatewayType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new VirtualNetworkGatewayType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type VirtualNetworkGatewayType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type VirtualNetworkGatewayType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is VirtualNetworkGatewayType && Equals((VirtualNetworkGatewayType)obj);
        }

        /// <summary>Returns hashCode for enum VirtualNetworkGatewayType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for VirtualNetworkGatewayType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Creates an instance of the <see cref="VirtualNetworkGatewayType" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private VirtualNetworkGatewayType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to VirtualNetworkGatewayType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualNetworkGatewayType" />.</param>

        public static implicit operator VirtualNetworkGatewayType(string value)
        {
            return new VirtualNetworkGatewayType(value);
        }

        /// <summary>Implicit operator to convert VirtualNetworkGatewayType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="VirtualNetworkGatewayType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum VirtualNetworkGatewayType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum VirtualNetworkGatewayType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType e2)
        {
            return e2.Equals(e1);
        }
    }
}