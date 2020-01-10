namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct IpsecEncryption :
        System.IEquatable<IpsecEncryption>
    {
        /// <summary>FIXME: Field Aes128 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption Aes128 = @"AES128";

        /// <summary>FIXME: Field Aes192 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption Aes192 = @"AES192";

        /// <summary>FIXME: Field Aes256 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption Aes256 = @"AES256";

        /// <summary>FIXME: Field Des is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption Des = @"DES";

        /// <summary>FIXME: Field Des3 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption Des3 = @"DES3";

        /// <summary>FIXME: Field Gcmaes128 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption Gcmaes128 = @"GCMAES128";

        /// <summary>FIXME: Field Gcmaes192 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption Gcmaes192 = @"GCMAES192";

        /// <summary>FIXME: Field Gcmaes256 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption Gcmaes256 = @"GCMAES256";

        /// <summary>FIXME: Field None is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption None = @"None";

        /// <summary>the value for an instance of the <see cref="IpsecEncryption" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to IpsecEncryption</summary>
        /// <param name="value">the value to convert to an instance of <see cref="IpsecEncryption" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new IpsecEncryption(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type IpsecEncryption</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type IpsecEncryption (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is IpsecEncryption && Equals((IpsecEncryption)obj);
        }

        /// <summary>Returns hashCode for enum IpsecEncryption</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="IpsecEncryption" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private IpsecEncryption(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for IpsecEncryption</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to IpsecEncryption</summary>
        /// <param name="value">the value to convert to an instance of <see cref="IpsecEncryption" />.</param>

        public static implicit operator IpsecEncryption(string value)
        {
            return new IpsecEncryption(value);
        }

        /// <summary>Implicit operator to convert IpsecEncryption to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="IpsecEncryption" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum IpsecEncryption</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum IpsecEncryption</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption e2)
        {
            return e2.Equals(e1);
        }
    }
}