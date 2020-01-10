namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct VirtualNetworkGatewaySkuTier :
        System.IEquatable<VirtualNetworkGatewaySkuTier>
    {
        /// <summary>FIXME: Field Basic is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier Basic = @"Basic";

        /// <summary>FIXME: Field ErGw1Az is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier ErGw1Az = @"ErGw1AZ";

        /// <summary>FIXME: Field ErGw2Az is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier ErGw2Az = @"ErGw2AZ";

        /// <summary>FIXME: Field ErGw3Az is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier ErGw3Az = @"ErGw3AZ";

        /// <summary>FIXME: Field HighPerformance is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier HighPerformance = @"HighPerformance";

        /// <summary>FIXME: Field Standard is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier Standard = @"Standard";

        /// <summary>FIXME: Field UltraPerformance is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier UltraPerformance = @"UltraPerformance";

        /// <summary>FIXME: Field VpnGw1 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier VpnGw1 = @"VpnGw1";

        /// <summary>FIXME: Field VpnGw1Az is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier VpnGw1Az = @"VpnGw1AZ";

        /// <summary>FIXME: Field VpnGw2 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier VpnGw2 = @"VpnGw2";

        /// <summary>FIXME: Field VpnGw2Az is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier VpnGw2Az = @"VpnGw2AZ";

        /// <summary>FIXME: Field VpnGw3 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier VpnGw3 = @"VpnGw3";

        /// <summary>FIXME: Field VpnGw3Az is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier VpnGw3Az = @"VpnGw3AZ";

        /// <summary>
        /// the value for an instance of the <see cref="VirtualNetworkGatewaySkuTier" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to VirtualNetworkGatewaySkuTier</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualNetworkGatewaySkuTier" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new VirtualNetworkGatewaySkuTier(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type VirtualNetworkGatewaySkuTier</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type VirtualNetworkGatewaySkuTier (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is VirtualNetworkGatewaySkuTier && Equals((VirtualNetworkGatewaySkuTier)obj);
        }

        /// <summary>Returns hashCode for enum VirtualNetworkGatewaySkuTier</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for VirtualNetworkGatewaySkuTier</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Creates an instance of the <see cref="VirtualNetworkGatewaySkuTier" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private VirtualNetworkGatewaySkuTier(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to VirtualNetworkGatewaySkuTier</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualNetworkGatewaySkuTier" />.</param>

        public static implicit operator VirtualNetworkGatewaySkuTier(string value)
        {
            return new VirtualNetworkGatewaySkuTier(value);
        }

        /// <summary>Implicit operator to convert VirtualNetworkGatewaySkuTier to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="VirtualNetworkGatewaySkuTier" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum VirtualNetworkGatewaySkuTier</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum VirtualNetworkGatewaySkuTier</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier e2)
        {
            return e2.Equals(e1);
        }
    }
}