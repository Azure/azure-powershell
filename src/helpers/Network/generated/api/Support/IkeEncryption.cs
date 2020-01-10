namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct IkeEncryption :
        System.IEquatable<IkeEncryption>
    {
        /// <summary>FIXME: Field Aes128 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption Aes128 = @"AES128";

        /// <summary>FIXME: Field Aes192 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption Aes192 = @"AES192";

        /// <summary>FIXME: Field Aes256 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption Aes256 = @"AES256";

        /// <summary>FIXME: Field Des is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption Des = @"DES";

        /// <summary>FIXME: Field Des3 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption Des3 = @"DES3";

        /// <summary>FIXME: Field Gcmaes128 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption Gcmaes128 = @"GCMAES128";

        /// <summary>FIXME: Field Gcmaes256 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption Gcmaes256 = @"GCMAES256";

        /// <summary>the value for an instance of the <see cref="IkeEncryption" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to IkeEncryption</summary>
        /// <param name="value">the value to convert to an instance of <see cref="IkeEncryption" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new IkeEncryption(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type IkeEncryption</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type IkeEncryption (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is IkeEncryption && Equals((IkeEncryption)obj);
        }

        /// <summary>Returns hashCode for enum IkeEncryption</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="IkeEncryption" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private IkeEncryption(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for IkeEncryption</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to IkeEncryption</summary>
        /// <param name="value">the value to convert to an instance of <see cref="IkeEncryption" />.</param>

        public static implicit operator IkeEncryption(string value)
        {
            return new IkeEncryption(value);
        }

        /// <summary>Implicit operator to convert IkeEncryption to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="IkeEncryption" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum IkeEncryption</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum IkeEncryption</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption e2)
        {
            return e2.Equals(e1);
        }
    }
}