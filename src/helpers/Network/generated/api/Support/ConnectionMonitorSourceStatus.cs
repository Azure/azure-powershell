namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ConnectionMonitorSourceStatus :
        System.IEquatable<ConnectionMonitorSourceStatus>
    {
        /// <summary>FIXME: Field Active is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus Active = @"Active";

        /// <summary>FIXME: Field Inactive is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus Inactive = @"Inactive";

        /// <summary>FIXME: Field Unknown is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus Unknown = @"Unknown";

        /// <summary>
        /// the value for an instance of the <see cref="ConnectionMonitorSourceStatus" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="ConnectionMonitorSourceStatus" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ConnectionMonitorSourceStatus(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ConnectionMonitorSourceStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ConnectionMonitorSourceStatus" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ConnectionMonitorSourceStatus(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ConnectionMonitorSourceStatus</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ConnectionMonitorSourceStatus (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ConnectionMonitorSourceStatus && Equals((ConnectionMonitorSourceStatus)obj);
        }

        /// <summary>Returns hashCode for enum ConnectionMonitorSourceStatus</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ConnectionMonitorSourceStatus</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ConnectionMonitorSourceStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ConnectionMonitorSourceStatus" />.</param>

        public static implicit operator ConnectionMonitorSourceStatus(string value)
        {
            return new ConnectionMonitorSourceStatus(value);
        }

        /// <summary>Implicit operator to convert ConnectionMonitorSourceStatus to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ConnectionMonitorSourceStatus" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ConnectionMonitorSourceStatus</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ConnectionMonitorSourceStatus</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus e2)
        {
            return e2.Equals(e1);
        }
    }
}