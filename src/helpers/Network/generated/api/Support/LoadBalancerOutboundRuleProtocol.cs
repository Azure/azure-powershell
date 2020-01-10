namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct LoadBalancerOutboundRuleProtocol :
        System.IEquatable<LoadBalancerOutboundRuleProtocol>
    {
        /// <summary>FIXME: Field All is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerOutboundRuleProtocol All = @"All";

        /// <summary>FIXME: Field Tcp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerOutboundRuleProtocol Tcp = @"Tcp";

        /// <summary>FIXME: Field Udp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerOutboundRuleProtocol Udp = @"Udp";

        /// <summary>
        /// the value for an instance of the <see cref="LoadBalancerOutboundRuleProtocol" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to LoadBalancerOutboundRuleProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="LoadBalancerOutboundRuleProtocol" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new LoadBalancerOutboundRuleProtocol(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type LoadBalancerOutboundRuleProtocol</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerOutboundRuleProtocol e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type LoadBalancerOutboundRuleProtocol (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is LoadBalancerOutboundRuleProtocol && Equals((LoadBalancerOutboundRuleProtocol)obj);
        }

        /// <summary>Returns hashCode for enum LoadBalancerOutboundRuleProtocol</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>
        /// Creates an instance of the <see cref="LoadBalancerOutboundRuleProtocol" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private LoadBalancerOutboundRuleProtocol(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for LoadBalancerOutboundRuleProtocol</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to LoadBalancerOutboundRuleProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="LoadBalancerOutboundRuleProtocol" />.</param>

        public static implicit operator LoadBalancerOutboundRuleProtocol(string value)
        {
            return new LoadBalancerOutboundRuleProtocol(value);
        }

        /// <summary>Implicit operator to convert LoadBalancerOutboundRuleProtocol to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="LoadBalancerOutboundRuleProtocol" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerOutboundRuleProtocol e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum LoadBalancerOutboundRuleProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerOutboundRuleProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerOutboundRuleProtocol e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum LoadBalancerOutboundRuleProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerOutboundRuleProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerOutboundRuleProtocol e2)
        {
            return e2.Equals(e1);
        }
    }
}