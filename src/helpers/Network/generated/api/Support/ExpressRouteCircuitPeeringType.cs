namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ExpressRouteCircuitPeeringType :
        System.IEquatable<ExpressRouteCircuitPeeringType>
    {
        /// <summary>FIXME: Field AzurePrivatePeering is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringType AzurePrivatePeering = @"AzurePrivatePeering";

        /// <summary>FIXME: Field AzurePublicPeering is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringType AzurePublicPeering = @"AzurePublicPeering";

        /// <summary>FIXME: Field MicrosoftPeering is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringType MicrosoftPeering = @"MicrosoftPeering";

        /// <summary>
        /// the value for an instance of the <see cref="ExpressRouteCircuitPeeringType" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to ExpressRouteCircuitPeeringType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ExpressRouteCircuitPeeringType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ExpressRouteCircuitPeeringType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ExpressRouteCircuitPeeringType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ExpressRouteCircuitPeeringType (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ExpressRouteCircuitPeeringType && Equals((ExpressRouteCircuitPeeringType)obj);
        }

        /// <summary>
        /// Creates an instance of the <see cref="ExpressRouteCircuitPeeringType" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ExpressRouteCircuitPeeringType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns hashCode for enum ExpressRouteCircuitPeeringType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ExpressRouteCircuitPeeringType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ExpressRouteCircuitPeeringType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ExpressRouteCircuitPeeringType" />.</param>

        public static implicit operator ExpressRouteCircuitPeeringType(string value)
        {
            return new ExpressRouteCircuitPeeringType(value);
        }

        /// <summary>Implicit operator to convert ExpressRouteCircuitPeeringType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ExpressRouteCircuitPeeringType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ExpressRouteCircuitPeeringType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ExpressRouteCircuitPeeringType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringType e2)
        {
            return e2.Equals(e1);
        }
    }
}