namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ApplicationGatewaySkuName :
        System.IEquatable<ApplicationGatewaySkuName>
    {
        /// <summary>FIXME: Field StandardLarge is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName StandardLarge = @"Standard_Large";

        /// <summary>FIXME: Field StandardMedium is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName StandardMedium = @"Standard_Medium";

        /// <summary>FIXME: Field StandardSmall is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName StandardSmall = @"Standard_Small";

        /// <summary>FIXME: Field StandardV2 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName StandardV2 = @"Standard_v2";

        /// <summary>FIXME: Field WafLarge is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName WafLarge = @"WAF_Large";

        /// <summary>FIXME: Field WafMedium is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName WafMedium = @"WAF_Medium";

        /// <summary>FIXME: Field WafV2 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName WafV2 = @"WAF_v2";

        /// <summary>the value for an instance of the <see cref="ApplicationGatewaySkuName" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="ApplicationGatewaySkuName" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ApplicationGatewaySkuName(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ApplicationGatewaySkuName</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewaySkuName" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ApplicationGatewaySkuName(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ApplicationGatewaySkuName</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ApplicationGatewaySkuName (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ApplicationGatewaySkuName && Equals((ApplicationGatewaySkuName)obj);
        }

        /// <summary>Returns hashCode for enum ApplicationGatewaySkuName</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ApplicationGatewaySkuName</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ApplicationGatewaySkuName</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ApplicationGatewaySkuName" />.</param>

        public static implicit operator ApplicationGatewaySkuName(string value)
        {
            return new ApplicationGatewaySkuName(value);
        }

        /// <summary>Implicit operator to convert ApplicationGatewaySkuName to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ApplicationGatewaySkuName" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ApplicationGatewaySkuName</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ApplicationGatewaySkuName</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName e2)
        {
            return e2.Equals(e1);
        }
    }
}