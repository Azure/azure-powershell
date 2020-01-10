namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct OfficeTrafficCategory :
        System.IEquatable<OfficeTrafficCategory>
    {
        /// <summary>FIXME: Field All is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory All = @"All";

        /// <summary>FIXME: Field None is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory None = @"None";

        /// <summary>FIXME: Field Optimize is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory Optimize = @"Optimize";

        /// <summary>FIXME: Field OptimizeAndAllow is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory OptimizeAndAllow = @"OptimizeAndAllow";

        /// <summary>the value for an instance of the <see cref="OfficeTrafficCategory" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to OfficeTrafficCategory</summary>
        /// <param name="value">the value to convert to an instance of <see cref="OfficeTrafficCategory" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new OfficeTrafficCategory(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type OfficeTrafficCategory</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type OfficeTrafficCategory (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is OfficeTrafficCategory && Equals((OfficeTrafficCategory)obj);
        }

        /// <summary>Returns hashCode for enum OfficeTrafficCategory</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="OfficeTrafficCategory" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private OfficeTrafficCategory(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for OfficeTrafficCategory</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to OfficeTrafficCategory</summary>
        /// <param name="value">the value to convert to an instance of <see cref="OfficeTrafficCategory" />.</param>

        public static implicit operator OfficeTrafficCategory(string value)
        {
            return new OfficeTrafficCategory(value);
        }

        /// <summary>Implicit operator to convert OfficeTrafficCategory to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="OfficeTrafficCategory" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum OfficeTrafficCategory</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum OfficeTrafficCategory</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory e2)
        {
            return e2.Equals(e1);
        }
    }
}