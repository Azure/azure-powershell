namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ConnectionState :
        System.IEquatable<ConnectionState>
    {
        /// <summary>FIXME: Field Reachable is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionState Reachable = @"Reachable";

        /// <summary>FIXME: Field Unknown is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionState Unknown = @"Unknown";

        /// <summary>FIXME: Field Unreachable is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionState Unreachable = @"Unreachable";

        /// <summary>the value for an instance of the <see cref="ConnectionState" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="ConnectionState" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ConnectionState(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ConnectionState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ConnectionState" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ConnectionState(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ConnectionState</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionState e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ConnectionState (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ConnectionState && Equals((ConnectionState)obj);
        }

        /// <summary>Returns hashCode for enum ConnectionState</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ConnectionState</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ConnectionState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ConnectionState" />.</param>

        public static implicit operator ConnectionState(string value)
        {
            return new ConnectionState(value);
        }

        /// <summary>Implicit operator to convert ConnectionState to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ConnectionState" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionState e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ConnectionState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionState e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ConnectionState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionState e2)
        {
            return e2.Equals(e1);
        }
    }
}