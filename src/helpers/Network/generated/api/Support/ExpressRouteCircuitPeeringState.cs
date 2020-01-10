namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ExpressRouteCircuitPeeringState :
        System.IEquatable<ExpressRouteCircuitPeeringState>
    {
        /// <summary>FIXME: Field Disabled is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState Disabled = @"Disabled";

        /// <summary>FIXME: Field Enabled is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState Enabled = @"Enabled";

        /// <summary>
        /// the value for an instance of the <see cref="ExpressRouteCircuitPeeringState" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to ExpressRouteCircuitPeeringState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ExpressRouteCircuitPeeringState" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ExpressRouteCircuitPeeringState(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ExpressRouteCircuitPeeringState</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ExpressRouteCircuitPeeringState (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ExpressRouteCircuitPeeringState && Equals((ExpressRouteCircuitPeeringState)obj);
        }

        /// <summary>
        /// Creates an instance of the <see cref="ExpressRouteCircuitPeeringState" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ExpressRouteCircuitPeeringState(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns hashCode for enum ExpressRouteCircuitPeeringState</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ExpressRouteCircuitPeeringState</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ExpressRouteCircuitPeeringState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ExpressRouteCircuitPeeringState" />.</param>

        public static implicit operator ExpressRouteCircuitPeeringState(string value)
        {
            return new ExpressRouteCircuitPeeringState(value);
        }

        /// <summary>Implicit operator to convert ExpressRouteCircuitPeeringState to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ExpressRouteCircuitPeeringState" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ExpressRouteCircuitPeeringState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ExpressRouteCircuitPeeringState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState e2)
        {
            return e2.Equals(e1);
        }
    }
}