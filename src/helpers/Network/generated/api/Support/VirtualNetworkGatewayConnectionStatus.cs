namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct VirtualNetworkGatewayConnectionStatus :
        System.IEquatable<VirtualNetworkGatewayConnectionStatus>
    {
        /// <summary>FIXME: Field Connected is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus Connected = @"Connected";

        /// <summary>FIXME: Field Connecting is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus Connecting = @"Connecting";

        /// <summary>FIXME: Field NotConnected is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus NotConnected = @"NotConnected";

        /// <summary>FIXME: Field Unknown is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus Unknown = @"Unknown";

        /// <summary>
        /// the value for an instance of the <see cref="VirtualNetworkGatewayConnectionStatus" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to VirtualNetworkGatewayConnectionStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualNetworkGatewayConnectionStatus" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new VirtualNetworkGatewayConnectionStatus(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type VirtualNetworkGatewayConnectionStatus</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type VirtualNetworkGatewayConnectionStatus (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is VirtualNetworkGatewayConnectionStatus && Equals((VirtualNetworkGatewayConnectionStatus)obj);
        }

        /// <summary>Returns hashCode for enum VirtualNetworkGatewayConnectionStatus</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for VirtualNetworkGatewayConnectionStatus</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Creates an instance of the <see cref="VirtualNetworkGatewayConnectionStatus" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private VirtualNetworkGatewayConnectionStatus(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to VirtualNetworkGatewayConnectionStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualNetworkGatewayConnectionStatus" />.</param>

        public static implicit operator VirtualNetworkGatewayConnectionStatus(string value)
        {
            return new VirtualNetworkGatewayConnectionStatus(value);
        }

        /// <summary>Implicit operator to convert VirtualNetworkGatewayConnectionStatus to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="VirtualNetworkGatewayConnectionStatus" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum VirtualNetworkGatewayConnectionStatus</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum VirtualNetworkGatewayConnectionStatus</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus e2)
        {
            return e2.Equals(e1);
        }
    }
}