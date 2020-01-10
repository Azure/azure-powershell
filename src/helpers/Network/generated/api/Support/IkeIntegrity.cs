namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct IkeIntegrity :
        System.IEquatable<IkeIntegrity>
    {
        /// <summary>FIXME: Field Gcmaes128 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity Gcmaes128 = @"GCMAES128";

        /// <summary>FIXME: Field Gcmaes256 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity Gcmaes256 = @"GCMAES256";

        /// <summary>FIXME: Field Md5 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity Md5 = @"MD5";

        /// <summary>FIXME: Field Sha1 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity Sha1 = @"SHA1";

        /// <summary>FIXME: Field Sha256 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity Sha256 = @"SHA256";

        /// <summary>FIXME: Field Sha384 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity Sha384 = @"SHA384";

        /// <summary>the value for an instance of the <see cref="IkeIntegrity" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to IkeIntegrity</summary>
        /// <param name="value">the value to convert to an instance of <see cref="IkeIntegrity" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new IkeIntegrity(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type IkeIntegrity</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type IkeIntegrity (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is IkeIntegrity && Equals((IkeIntegrity)obj);
        }

        /// <summary>Returns hashCode for enum IkeIntegrity</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="IkeIntegrity" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private IkeIntegrity(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for IkeIntegrity</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to IkeIntegrity</summary>
        /// <param name="value">the value to convert to an instance of <see cref="IkeIntegrity" />.</param>

        public static implicit operator IkeIntegrity(string value)
        {
            return new IkeIntegrity(value);
        }

        /// <summary>Implicit operator to convert IkeIntegrity to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="IkeIntegrity" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum IkeIntegrity</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum IkeIntegrity</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity e2)
        {
            return e2.Equals(e1);
        }
    }
}