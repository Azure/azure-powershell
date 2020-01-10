namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct VpnConnectionStatus :
        System.IEquatable<VpnConnectionStatus>
    {
        /// <summary>FIXME: Field Connected is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus Connected = @"Connected";

        /// <summary>FIXME: Field Connecting is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus Connecting = @"Connecting";

        /// <summary>FIXME: Field NotConnected is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus NotConnected = @"NotConnected";

        /// <summary>FIXME: Field Unknown is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus Unknown = @"Unknown";

        /// <summary>the value for an instance of the <see cref="VpnConnectionStatus" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to VpnConnectionStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VpnConnectionStatus" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new VpnConnectionStatus(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type VpnConnectionStatus</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type VpnConnectionStatus (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is VpnConnectionStatus && Equals((VpnConnectionStatus)obj);
        }

        /// <summary>Returns hashCode for enum VpnConnectionStatus</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for VpnConnectionStatus</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Creates an instance of the <see cref="VpnConnectionStatus" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private VpnConnectionStatus(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to VpnConnectionStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VpnConnectionStatus" />.</param>

        public static implicit operator VpnConnectionStatus(string value)
        {
            return new VpnConnectionStatus(value);
        }

        /// <summary>Implicit operator to convert VpnConnectionStatus to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="VpnConnectionStatus" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum VpnConnectionStatus</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum VpnConnectionStatus</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus e2)
        {
            return e2.Equals(e1);
        }
    }
}