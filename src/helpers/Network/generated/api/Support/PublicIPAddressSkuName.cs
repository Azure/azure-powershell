namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct PublicIPAddressSkuName :
        System.IEquatable<PublicIPAddressSkuName>
    {
        /// <summary>FIXME: Field Basic is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName Basic = @"Basic";

        /// <summary>FIXME: Field Standard is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName Standard = @"Standard";

        /// <summary>the value for an instance of the <see cref="PublicIPAddressSkuName" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to PublicIPAddressSkuName</summary>
        /// <param name="value">the value to convert to an instance of <see cref="PublicIPAddressSkuName" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new PublicIPAddressSkuName(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type PublicIPAddressSkuName</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type PublicIPAddressSkuName (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is PublicIPAddressSkuName && Equals((PublicIPAddressSkuName)obj);
        }

        /// <summary>Returns hashCode for enum PublicIPAddressSkuName</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="PublicIPAddressSkuName" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private PublicIPAddressSkuName(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for PublicIPAddressSkuName</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to PublicIPAddressSkuName</summary>
        /// <param name="value">the value to convert to an instance of <see cref="PublicIPAddressSkuName" />.</param>

        public static implicit operator PublicIPAddressSkuName(string value)
        {
            return new PublicIPAddressSkuName(value);
        }

        /// <summary>Implicit operator to convert PublicIPAddressSkuName to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="PublicIPAddressSkuName" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum PublicIPAddressSkuName</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum PublicIPAddressSkuName</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName e2)
        {
            return e2.Equals(e1);
        }
    }
}