namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct VirtualWanSecurityProviderType :
        System.IEquatable<VirtualWanSecurityProviderType>
    {
        /// <summary>FIXME: Field External is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualWanSecurityProviderType External = @"External";

        /// <summary>FIXME: Field Native is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualWanSecurityProviderType Native = @"Native";

        /// <summary>
        /// the value for an instance of the <see cref="VirtualWanSecurityProviderType" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to VirtualWanSecurityProviderType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualWanSecurityProviderType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new VirtualWanSecurityProviderType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type VirtualWanSecurityProviderType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualWanSecurityProviderType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type VirtualWanSecurityProviderType (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is VirtualWanSecurityProviderType && Equals((VirtualWanSecurityProviderType)obj);
        }

        /// <summary>Returns hashCode for enum VirtualWanSecurityProviderType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for VirtualWanSecurityProviderType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Creates an instance of the <see cref="VirtualWanSecurityProviderType" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private VirtualWanSecurityProviderType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to VirtualWanSecurityProviderType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualWanSecurityProviderType" />.</param>

        public static implicit operator VirtualWanSecurityProviderType(string value)
        {
            return new VirtualWanSecurityProviderType(value);
        }

        /// <summary>Implicit operator to convert VirtualWanSecurityProviderType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="VirtualWanSecurityProviderType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualWanSecurityProviderType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum VirtualWanSecurityProviderType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualWanSecurityProviderType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualWanSecurityProviderType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum VirtualWanSecurityProviderType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualWanSecurityProviderType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualWanSecurityProviderType e2)
        {
            return e2.Equals(e1);
        }
    }
}