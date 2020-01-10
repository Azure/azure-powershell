namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ApplicationGatewayCustomErrorStatusCode :
        System.IEquatable<ApplicationGatewayCustomErrorStatusCode>
    {
        /// <summary>FIXME: Field HttpStatus403 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCustomErrorStatusCode HttpStatus403 = @"HttpStatus403";

        /// <summary>FIXME: Field HttpStatus502 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCustomErrorStatusCode HttpStatus502 = @"HttpStatus502";

        /// <summary>
        /// the value for an instance of the <see cref="ApplicationGatewayCustomErrorStatusCode" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="ApplicationGatewayCustomErrorStatusCode" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ApplicationGatewayCustomErrorStatusCode(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ApplicationGatewayCustomErrorStatusCode</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayCustomErrorStatusCode" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ApplicationGatewayCustomErrorStatusCode(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ApplicationGatewayCustomErrorStatusCode</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCustomErrorStatusCode e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ApplicationGatewayCustomErrorStatusCode (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ApplicationGatewayCustomErrorStatusCode && Equals((ApplicationGatewayCustomErrorStatusCode)obj);
        }

        /// <summary>Returns hashCode for enum ApplicationGatewayCustomErrorStatusCode</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ApplicationGatewayCustomErrorStatusCode</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ApplicationGatewayCustomErrorStatusCode</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayCustomErrorStatusCode" />.</param>

        public static implicit operator ApplicationGatewayCustomErrorStatusCode(string value)
        {
            return new ApplicationGatewayCustomErrorStatusCode(value);
        }

        /// <summary>Implicit operator to convert ApplicationGatewayCustomErrorStatusCode to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ApplicationGatewayCustomErrorStatusCode" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCustomErrorStatusCode e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ApplicationGatewayCustomErrorStatusCode</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCustomErrorStatusCode e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCustomErrorStatusCode e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ApplicationGatewayCustomErrorStatusCode</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCustomErrorStatusCode e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCustomErrorStatusCode e2)
        {
            return e2.Equals(e1);
        }
    }
}