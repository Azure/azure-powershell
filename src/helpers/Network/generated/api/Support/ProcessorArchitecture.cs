namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ProcessorArchitecture :
        System.IEquatable<ProcessorArchitecture>
    {
        /// <summary>FIXME: Field Amd64 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture Amd64 = @"Amd64";

        /// <summary>FIXME: Field X86 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture X86 = @"X86";

        /// <summary>the value for an instance of the <see cref="ProcessorArchitecture" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to ProcessorArchitecture</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ProcessorArchitecture" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ProcessorArchitecture(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ProcessorArchitecture</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ProcessorArchitecture (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ProcessorArchitecture && Equals((ProcessorArchitecture)obj);
        }

        /// <summary>Returns hashCode for enum ProcessorArchitecture</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="ProcessorArchitecture" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ProcessorArchitecture(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for ProcessorArchitecture</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ProcessorArchitecture</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ProcessorArchitecture" />.</param>

        public static implicit operator ProcessorArchitecture(string value)
        {
            return new ProcessorArchitecture(value);
        }

        /// <summary>Implicit operator to convert ProcessorArchitecture to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ProcessorArchitecture" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ProcessorArchitecture</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ProcessorArchitecture</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture e2)
        {
            return e2.Equals(e1);
        }
    }
}