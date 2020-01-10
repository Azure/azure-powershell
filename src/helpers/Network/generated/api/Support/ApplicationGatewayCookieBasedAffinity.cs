namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ApplicationGatewayCookieBasedAffinity :
        System.IEquatable<ApplicationGatewayCookieBasedAffinity>
    {
        /// <summary>FIXME: Field Disabled is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity Disabled = @"Disabled";

        /// <summary>FIXME: Field Enabled is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity Enabled = @"Enabled";

        /// <summary>
        /// the value for an instance of the <see cref="ApplicationGatewayCookieBasedAffinity" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="ApplicationGatewayCookieBasedAffinity" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ApplicationGatewayCookieBasedAffinity(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ApplicationGatewayCookieBasedAffinity</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayCookieBasedAffinity" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ApplicationGatewayCookieBasedAffinity(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ApplicationGatewayCookieBasedAffinity</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ApplicationGatewayCookieBasedAffinity (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ApplicationGatewayCookieBasedAffinity && Equals((ApplicationGatewayCookieBasedAffinity)obj);
        }

        /// <summary>Returns hashCode for enum ApplicationGatewayCookieBasedAffinity</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ApplicationGatewayCookieBasedAffinity</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ApplicationGatewayCookieBasedAffinity</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayCookieBasedAffinity" />.</param>

        public static implicit operator ApplicationGatewayCookieBasedAffinity(string value)
        {
            return new ApplicationGatewayCookieBasedAffinity(value);
        }

        /// <summary>Implicit operator to convert ApplicationGatewayCookieBasedAffinity to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ApplicationGatewayCookieBasedAffinity" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ApplicationGatewayCookieBasedAffinity</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ApplicationGatewayCookieBasedAffinity</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity e2)
        {
            return e2.Equals(e1);
        }
    }
}