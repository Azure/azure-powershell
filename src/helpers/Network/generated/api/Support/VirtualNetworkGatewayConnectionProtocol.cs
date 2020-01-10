namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct VirtualNetworkGatewayConnectionProtocol :
        System.IEquatable<VirtualNetworkGatewayConnectionProtocol>
    {
        /// <summary>FIXME: Field IkEv1 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol IkEv1 = @"IKEv1";

        /// <summary>FIXME: Field IkEv2 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol IkEv2 = @"IKEv2";

        /// <summary>
        /// the value for an instance of the <see cref="VirtualNetworkGatewayConnectionProtocol" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to VirtualNetworkGatewayConnectionProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualNetworkGatewayConnectionProtocol" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new VirtualNetworkGatewayConnectionProtocol(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type VirtualNetworkGatewayConnectionProtocol</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type VirtualNetworkGatewayConnectionProtocol (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is VirtualNetworkGatewayConnectionProtocol && Equals((VirtualNetworkGatewayConnectionProtocol)obj);
        }

        /// <summary>Returns hashCode for enum VirtualNetworkGatewayConnectionProtocol</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for VirtualNetworkGatewayConnectionProtocol</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Creates an instance of the <see cref="VirtualNetworkGatewayConnectionProtocol" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private VirtualNetworkGatewayConnectionProtocol(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to VirtualNetworkGatewayConnectionProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualNetworkGatewayConnectionProtocol" />.</param>

        public static implicit operator VirtualNetworkGatewayConnectionProtocol(string value)
        {
            return new VirtualNetworkGatewayConnectionProtocol(value);
        }

        /// <summary>Implicit operator to convert VirtualNetworkGatewayConnectionProtocol to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="VirtualNetworkGatewayConnectionProtocol" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum VirtualNetworkGatewayConnectionProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum VirtualNetworkGatewayConnectionProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol e2)
        {
            return e2.Equals(e1);
        }
    }
}