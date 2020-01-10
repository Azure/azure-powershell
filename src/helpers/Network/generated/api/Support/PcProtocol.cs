namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct PcProtocol :
        System.IEquatable<PcProtocol>
    {
        /// <summary>FIXME: Field Any is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcProtocol Any = @"Any";

        /// <summary>FIXME: Field Tcp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcProtocol Tcp = @"TCP";

        /// <summary>FIXME: Field Udp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcProtocol Udp = @"UDP";

        /// <summary>the value for an instance of the <see cref="PcProtocol" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to PcProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="PcProtocol" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new PcProtocol(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type PcProtocol</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcProtocol e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type PcProtocol (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is PcProtocol && Equals((PcProtocol)obj);
        }

        /// <summary>Returns hashCode for enum PcProtocol</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="PcProtocol" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private PcProtocol(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for PcProtocol</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to PcProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="PcProtocol" />.</param>

        public static implicit operator PcProtocol(string value)
        {
            return new PcProtocol(value);
        }

        /// <summary>Implicit operator to convert PcProtocol to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="PcProtocol" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcProtocol e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum PcProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcProtocol e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum PcProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcProtocol e2)
        {
            return e2.Equals(e1);
        }
    }
}