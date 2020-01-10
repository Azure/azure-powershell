namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct AuthorizationUseStatus :
        System.IEquatable<AuthorizationUseStatus>
    {
        /// <summary>FIXME: Field Available is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthorizationUseStatus Available = @"Available";

        /// <summary>FIXME: Field InUse is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthorizationUseStatus InUse = @"InUse";

        /// <summary>the value for an instance of the <see cref="AuthorizationUseStatus" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="AuthorizationUseStatus" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private AuthorizationUseStatus(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to AuthorizationUseStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AuthorizationUseStatus" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new AuthorizationUseStatus(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type AuthorizationUseStatus</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthorizationUseStatus e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type AuthorizationUseStatus (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is AuthorizationUseStatus && Equals((AuthorizationUseStatus)obj);
        }

        /// <summary>Returns hashCode for enum AuthorizationUseStatus</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for AuthorizationUseStatus</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to AuthorizationUseStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AuthorizationUseStatus" />.</param>

        public static implicit operator AuthorizationUseStatus(string value)
        {
            return new AuthorizationUseStatus(value);
        }

        /// <summary>Implicit operator to convert AuthorizationUseStatus to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="AuthorizationUseStatus" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthorizationUseStatus e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum AuthorizationUseStatus</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthorizationUseStatus e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthorizationUseStatus e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum AuthorizationUseStatus</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthorizationUseStatus e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthorizationUseStatus e2)
        {
            return e2.Equals(e1);
        }
    }
}