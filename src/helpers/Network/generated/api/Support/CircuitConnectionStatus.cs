namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct CircuitConnectionStatus :
        System.IEquatable<CircuitConnectionStatus>
    {
        /// <summary>FIXME: Field Connected is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus Connected = @"Connected";

        /// <summary>FIXME: Field Connecting is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus Connecting = @"Connecting";

        /// <summary>FIXME: Field Disconnected is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus Disconnected = @"Disconnected";

        /// <summary>the value for an instance of the <see cref="CircuitConnectionStatus" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="CircuitConnectionStatus" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private CircuitConnectionStatus(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to CircuitConnectionStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="CircuitConnectionStatus" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new CircuitConnectionStatus(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type CircuitConnectionStatus</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type CircuitConnectionStatus (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is CircuitConnectionStatus && Equals((CircuitConnectionStatus)obj);
        }

        /// <summary>Returns hashCode for enum CircuitConnectionStatus</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for CircuitConnectionStatus</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to CircuitConnectionStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="CircuitConnectionStatus" />.</param>

        public static implicit operator CircuitConnectionStatus(string value)
        {
            return new CircuitConnectionStatus(value);
        }

        /// <summary>Implicit operator to convert CircuitConnectionStatus to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="CircuitConnectionStatus" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum CircuitConnectionStatus</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum CircuitConnectionStatus</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus e2)
        {
            return e2.Equals(e1);
        }
    }
}