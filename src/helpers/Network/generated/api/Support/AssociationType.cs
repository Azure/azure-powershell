namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct AssociationType :
        System.IEquatable<AssociationType>
    {
        /// <summary>FIXME: Field Associated is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AssociationType Associated = @"Associated";

        /// <summary>FIXME: Field Contains is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AssociationType Contains = @"Contains";

        /// <summary>the value for an instance of the <see cref="AssociationType" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="AssociationType" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private AssociationType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to AssociationType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AssociationType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new AssociationType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type AssociationType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AssociationType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type AssociationType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is AssociationType && Equals((AssociationType)obj);
        }

        /// <summary>Returns hashCode for enum AssociationType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for AssociationType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to AssociationType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AssociationType" />.</param>

        public static implicit operator AssociationType(string value)
        {
            return new AssociationType(value);
        }

        /// <summary>Implicit operator to convert AssociationType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="AssociationType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AssociationType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum AssociationType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AssociationType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AssociationType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum AssociationType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AssociationType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AssociationType e2)
        {
            return e2.Equals(e1);
        }
    }
}