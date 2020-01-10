namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct AuthenticationMethod :
        System.IEquatable<AuthenticationMethod>
    {
        /// <summary>FIXME: Field EapmschaPv2 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod EapmschaPv2 = @"EAPMSCHAPv2";

        /// <summary>FIXME: Field Eaptls is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod Eaptls = @"EAPTLS";

        /// <summary>the value for an instance of the <see cref="AuthenticationMethod" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="AuthenticationMethod" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private AuthenticationMethod(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to AuthenticationMethod</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AuthenticationMethod" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new AuthenticationMethod(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type AuthenticationMethod</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type AuthenticationMethod (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is AuthenticationMethod && Equals((AuthenticationMethod)obj);
        }

        /// <summary>Returns hashCode for enum AuthenticationMethod</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for AuthenticationMethod</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to AuthenticationMethod</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AuthenticationMethod" />.</param>

        public static implicit operator AuthenticationMethod(string value)
        {
            return new AuthenticationMethod(value);
        }

        /// <summary>Implicit operator to convert AuthenticationMethod to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="AuthenticationMethod" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum AuthenticationMethod</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum AuthenticationMethod</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod e2)
        {
            return e2.Equals(e1);
        }
    }
}