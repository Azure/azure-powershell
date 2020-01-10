namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct Severity :
        System.IEquatable<Severity>
    {
        /// <summary>FIXME: Field Error is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity Error = @"Error";

        /// <summary>FIXME: Field Warning is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity Warning = @"Warning";

        /// <summary>the value for an instance of the <see cref="Severity" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to Severity</summary>
        /// <param name="value">the value to convert to an instance of <see cref="Severity" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new Severity(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type Severity</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type Severity (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is Severity && Equals((Severity)obj);
        }

        /// <summary>Returns hashCode for enum Severity</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="Severity" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private Severity(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for Severity</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to Severity</summary>
        /// <param name="value">the value to convert to an instance of <see cref="Severity" />.</param>

        public static implicit operator Severity(string value)
        {
            return new Severity(value);
        }

        /// <summary>Implicit operator to convert Severity to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="Severity" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum Severity</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum Severity</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity e2)
        {
            return e2.Equals(e1);
        }
    }
}