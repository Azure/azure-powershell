namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ApplicationGatewayTier :
        System.IEquatable<ApplicationGatewayTier>
    {
        /// <summary>FIXME: Field Standard is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier Standard = @"Standard";

        /// <summary>FIXME: Field StandardV2 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier StandardV2 = @"Standard_v2";

        /// <summary>FIXME: Field Waf is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier Waf = @"WAF";

        /// <summary>FIXME: Field WafV2 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier WafV2 = @"WAF_v2";

        /// <summary>the value for an instance of the <see cref="ApplicationGatewayTier" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="ApplicationGatewayTier" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ApplicationGatewayTier(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ApplicationGatewayTier</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayTier" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ApplicationGatewayTier(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ApplicationGatewayTier</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ApplicationGatewayTier (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ApplicationGatewayTier && Equals((ApplicationGatewayTier)obj);
        }

        /// <summary>Returns hashCode for enum ApplicationGatewayTier</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ApplicationGatewayTier</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ApplicationGatewayTier</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewayTier" />.</param>

        public static implicit operator ApplicationGatewayTier(string value)
        {
            return new ApplicationGatewayTier(value);
        }

        /// <summary>Implicit operator to convert ApplicationGatewayTier to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ApplicationGatewayTier" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ApplicationGatewayTier</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ApplicationGatewayTier</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier e2)
        {
            return e2.Equals(e1);
        }
    }
}