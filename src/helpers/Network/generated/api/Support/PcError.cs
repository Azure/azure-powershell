namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct PcError :
        System.IEquatable<PcError>
    {
        /// <summary>FIXME: Field AgentStopped is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError AgentStopped = @"AgentStopped";

        /// <summary>FIXME: Field CaptureFailed is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError CaptureFailed = @"CaptureFailed";

        /// <summary>FIXME: Field InternalError is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError InternalError = @"InternalError";

        /// <summary>FIXME: Field LocalFileFailed is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError LocalFileFailed = @"LocalFileFailed";

        /// <summary>FIXME: Field StorageFailed is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError StorageFailed = @"StorageFailed";

        /// <summary>the value for an instance of the <see cref="PcError" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to PcError</summary>
        /// <param name="value">the value to convert to an instance of <see cref="PcError" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new PcError(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type PcError</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type PcError (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is PcError && Equals((PcError)obj);
        }

        /// <summary>Returns hashCode for enum PcError</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="PcError" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private PcError(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for PcError</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to PcError</summary>
        /// <param name="value">the value to convert to an instance of <see cref="PcError" />.</param>

        public static implicit operator PcError(string value)
        {
            return new PcError(value);
        }

        /// <summary>Implicit operator to convert PcError to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="PcError" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum PcError</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum PcError</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError e2)
        {
            return e2.Equals(e1);
        }
    }
}