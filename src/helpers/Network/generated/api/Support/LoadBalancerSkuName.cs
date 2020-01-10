namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct LoadBalancerSkuName :
        System.IEquatable<LoadBalancerSkuName>
    {
        /// <summary>FIXME: Field Basic is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName Basic = @"Basic";

        /// <summary>FIXME: Field Standard is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName Standard = @"Standard";

        /// <summary>the value for an instance of the <see cref="LoadBalancerSkuName" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to LoadBalancerSkuName</summary>
        /// <param name="value">the value to convert to an instance of <see cref="LoadBalancerSkuName" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new LoadBalancerSkuName(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type LoadBalancerSkuName</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type LoadBalancerSkuName (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is LoadBalancerSkuName && Equals((LoadBalancerSkuName)obj);
        }

        /// <summary>Returns hashCode for enum LoadBalancerSkuName</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="LoadBalancerSkuName" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private LoadBalancerSkuName(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for LoadBalancerSkuName</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to LoadBalancerSkuName</summary>
        /// <param name="value">the value to convert to an instance of <see cref="LoadBalancerSkuName" />.</param>

        public static implicit operator LoadBalancerSkuName(string value)
        {
            return new LoadBalancerSkuName(value);
        }

        /// <summary>Implicit operator to convert LoadBalancerSkuName to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="LoadBalancerSkuName" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum LoadBalancerSkuName</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum LoadBalancerSkuName</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName e2)
        {
            return e2.Equals(e1);
        }
    }
}