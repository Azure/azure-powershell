namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ConnectionStatus :
        System.IEquatable<ConnectionStatus>
    {
        /// <summary>FIXME: Field Connected is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus Connected = @"Connected";

        /// <summary>FIXME: Field Degraded is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus Degraded = @"Degraded";

        /// <summary>FIXME: Field Disconnected is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus Disconnected = @"Disconnected";

        /// <summary>FIXME: Field Unknown is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus Unknown = @"Unknown";

        /// <summary>the value for an instance of the <see cref="ConnectionStatus" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="ConnectionStatus" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ConnectionStatus(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ConnectionStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ConnectionStatus" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ConnectionStatus(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ConnectionStatus</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ConnectionStatus (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ConnectionStatus && Equals((ConnectionStatus)obj);
        }

        /// <summary>Returns hashCode for enum ConnectionStatus</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ConnectionStatus</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ConnectionStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ConnectionStatus" />.</param>

        public static implicit operator ConnectionStatus(string value)
        {
            return new ConnectionStatus(value);
        }

        /// <summary>Implicit operator to convert ConnectionStatus to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ConnectionStatus" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ConnectionStatus</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ConnectionStatus</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus e2)
        {
            return e2.Equals(e1);
        }
    }
}