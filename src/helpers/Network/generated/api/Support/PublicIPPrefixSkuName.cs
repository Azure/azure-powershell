namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct PublicIPPrefixSkuName :
        System.IEquatable<PublicIPPrefixSkuName>
    {
        /// <summary>FIXME: Field Standard is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName Standard = @"Standard";

        /// <summary>the value for an instance of the <see cref="PublicIPPrefixSkuName" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to PublicIPPrefixSkuName</summary>
        /// <param name="value">the value to convert to an instance of <see cref="PublicIPPrefixSkuName" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new PublicIPPrefixSkuName(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type PublicIPPrefixSkuName</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type PublicIPPrefixSkuName (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is PublicIPPrefixSkuName && Equals((PublicIPPrefixSkuName)obj);
        }

        /// <summary>Returns hashCode for enum PublicIPPrefixSkuName</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="PublicIPPrefixSkuName" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private PublicIPPrefixSkuName(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for PublicIPPrefixSkuName</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to PublicIPPrefixSkuName</summary>
        /// <param name="value">the value to convert to an instance of <see cref="PublicIPPrefixSkuName" />.</param>

        public static implicit operator PublicIPPrefixSkuName(string value)
        {
            return new PublicIPPrefixSkuName(value);
        }

        /// <summary>Implicit operator to convert PublicIPPrefixSkuName to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="PublicIPPrefixSkuName" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum PublicIPPrefixSkuName</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum PublicIPPrefixSkuName</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName e2)
        {
            return e2.Equals(e1);
        }
    }
}