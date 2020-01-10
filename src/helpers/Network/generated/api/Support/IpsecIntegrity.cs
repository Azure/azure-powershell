namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct IpsecIntegrity :
        System.IEquatable<IpsecIntegrity>
    {
        /// <summary>FIXME: Field Gcmaes128 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity Gcmaes128 = @"GCMAES128";

        /// <summary>FIXME: Field Gcmaes192 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity Gcmaes192 = @"GCMAES192";

        /// <summary>FIXME: Field Gcmaes256 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity Gcmaes256 = @"GCMAES256";

        /// <summary>FIXME: Field Md5 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity Md5 = @"MD5";

        /// <summary>FIXME: Field Sha1 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity Sha1 = @"SHA1";

        /// <summary>FIXME: Field Sha256 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity Sha256 = @"SHA256";

        /// <summary>the value for an instance of the <see cref="IpsecIntegrity" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to IpsecIntegrity</summary>
        /// <param name="value">the value to convert to an instance of <see cref="IpsecIntegrity" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new IpsecIntegrity(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type IpsecIntegrity</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type IpsecIntegrity (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is IpsecIntegrity && Equals((IpsecIntegrity)obj);
        }

        /// <summary>Returns hashCode for enum IpsecIntegrity</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="IpsecIntegrity" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private IpsecIntegrity(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for IpsecIntegrity</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to IpsecIntegrity</summary>
        /// <param name="value">the value to convert to an instance of <see cref="IpsecIntegrity" />.</param>

        public static implicit operator IpsecIntegrity(string value)
        {
            return new IpsecIntegrity(value);
        }

        /// <summary>Implicit operator to convert IpsecIntegrity to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="IpsecIntegrity" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum IpsecIntegrity</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum IpsecIntegrity</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity e2)
        {
            return e2.Equals(e1);
        }
    }
}