namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct PcStatus :
        System.IEquatable<PcStatus>
    {
        /// <summary>FIXME: Field Error is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus Error = @"Error";

        /// <summary>FIXME: Field NotStarted is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus NotStarted = @"NotStarted";

        /// <summary>FIXME: Field Running is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus Running = @"Running";

        /// <summary>FIXME: Field Stopped is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus Stopped = @"Stopped";

        /// <summary>FIXME: Field Unknown is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus Unknown = @"Unknown";

        /// <summary>the value for an instance of the <see cref="PcStatus" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to PcStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="PcStatus" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new PcStatus(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type PcStatus</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type PcStatus (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is PcStatus && Equals((PcStatus)obj);
        }

        /// <summary>Returns hashCode for enum PcStatus</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="PcStatus" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private PcStatus(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for PcStatus</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to PcStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="PcStatus" />.</param>

        public static implicit operator PcStatus(string value)
        {
            return new PcStatus(value);
        }

        /// <summary>Implicit operator to convert PcStatus to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="PcStatus" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum PcStatus</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum PcStatus</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus e2)
        {
            return e2.Equals(e1);
        }
    }
}