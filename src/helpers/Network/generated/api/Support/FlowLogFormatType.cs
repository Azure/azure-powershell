namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct FlowLogFormatType :
        System.IEquatable<FlowLogFormatType>
    {
        /// <summary>FIXME: Field Json is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType Json = @"JSON";

        /// <summary>the value for an instance of the <see cref="FlowLogFormatType" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to FlowLogFormatType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="FlowLogFormatType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new FlowLogFormatType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type FlowLogFormatType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type FlowLogFormatType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is FlowLogFormatType && Equals((FlowLogFormatType)obj);
        }

        /// <summary>Creates an instance of the <see cref="FlowLogFormatType" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private FlowLogFormatType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns hashCode for enum FlowLogFormatType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for FlowLogFormatType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to FlowLogFormatType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="FlowLogFormatType" />.</param>

        public static implicit operator FlowLogFormatType(string value)
        {
            return new FlowLogFormatType(value);
        }

        /// <summary>Implicit operator to convert FlowLogFormatType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="FlowLogFormatType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum FlowLogFormatType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum FlowLogFormatType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType e2)
        {
            return e2.Equals(e1);
        }
    }
}