namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ApplicationGatewayRedirectType :
        System.IEquatable<ApplicationGatewayRedirectType>
    {
        /// <summary>FIXME: Field Found is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType Found = @"Found";

        /// <summary>FIXME: Field Permanent is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType Permanent = @"Permanent";

        /// <summary>FIXME: Field SeeOther is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType SeeOther = @"SeeOther";

        /// <summary>FIXME: Field Temporary is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType Temporary = @"Temporary";

        /// <summary>
        /// the value for an instance of the <see cref="ApplicationGatewayRedirectType" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="ApplicationGatewayRedirectType" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ApplicationGatewayRedirectType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ApplicationGatewayRedirectType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayRedirectType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ApplicationGatewayRedirectType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ApplicationGatewayRedirectType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ApplicationGatewayRedirectType (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ApplicationGatewayRedirectType && Equals((ApplicationGatewayRedirectType)obj);
        }

        /// <summary>Returns hashCode for enum ApplicationGatewayRedirectType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ApplicationGatewayRedirectType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ApplicationGatewayRedirectType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayRedirectType" />.</param>

        public static implicit operator ApplicationGatewayRedirectType(string value)
        {
            return new ApplicationGatewayRedirectType(value);
        }

        /// <summary>Implicit operator to convert ApplicationGatewayRedirectType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ApplicationGatewayRedirectType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ApplicationGatewayRedirectType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ApplicationGatewayRedirectType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType e2)
        {
            return e2.Equals(e1);
        }
    }
}