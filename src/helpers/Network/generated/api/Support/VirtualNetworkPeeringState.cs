namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct VirtualNetworkPeeringState :
        System.IEquatable<VirtualNetworkPeeringState>
    {
        /// <summary>FIXME: Field Connected is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState Connected = @"Connected";

        /// <summary>FIXME: Field Disconnected is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState Disconnected = @"Disconnected";

        /// <summary>FIXME: Field Initiated is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState Initiated = @"Initiated";

        /// <summary>
        /// the value for an instance of the <see cref="VirtualNetworkPeeringState" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to VirtualNetworkPeeringState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualNetworkPeeringState" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new VirtualNetworkPeeringState(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type VirtualNetworkPeeringState</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type VirtualNetworkPeeringState (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is VirtualNetworkPeeringState && Equals((VirtualNetworkPeeringState)obj);
        }

        /// <summary>Returns hashCode for enum VirtualNetworkPeeringState</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for VirtualNetworkPeeringState</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Creates an instance of the <see cref="VirtualNetworkPeeringState" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private VirtualNetworkPeeringState(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to VirtualNetworkPeeringState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualNetworkPeeringState" />.</param>

        public static implicit operator VirtualNetworkPeeringState(string value)
        {
            return new VirtualNetworkPeeringState(value);
        }

        /// <summary>Implicit operator to convert VirtualNetworkPeeringState to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="VirtualNetworkPeeringState" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum VirtualNetworkPeeringState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum VirtualNetworkPeeringState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState e2)
        {
            return e2.Equals(e1);
        }
    }
}