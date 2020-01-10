namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct Access :
        System.IEquatable<Access>
    {
        /// <summary>FIXME: Field Allow is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access Allow = @"Allow";

        /// <summary>FIXME: Field Deny is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access Deny = @"Deny";

        /// <summary>the value for an instance of the <see cref="Access" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="Access" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private Access(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to Access</summary>
        /// <param name="value">the value to convert to an instance of <see cref="Access" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new Access(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type Access</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type Access (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is Access && Equals((Access)obj);
        }

        /// <summary>Returns hashCode for enum Access</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for Access</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to Access</summary>
        /// <param name="value">the value to convert to an instance of <see cref="Access" />.</param>

        public static implicit operator Access(string value)
        {
            return new Access(value);
        }

        /// <summary>Implicit operator to convert Access to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="Access" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum Access</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum Access</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access e2)
        {
            return e2.Equals(e1);
        }
    }
}