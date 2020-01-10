namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct RouteNextHopType :
        System.IEquatable<RouteNextHopType>
    {
        /// <summary>FIXME: Field Internet is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType Internet = @"Internet";

        /// <summary>FIXME: Field None is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType None = @"None";

        /// <summary>FIXME: Field VirtualAppliance is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType VirtualAppliance = @"VirtualAppliance";

        /// <summary>FIXME: Field VirtualNetworkGateway is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType VirtualNetworkGateway = @"VirtualNetworkGateway";

        /// <summary>FIXME: Field VnetLocal is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType VnetLocal = @"VnetLocal";

        /// <summary>the value for an instance of the <see cref="RouteNextHopType" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to RouteNextHopType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="RouteNextHopType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new RouteNextHopType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type RouteNextHopType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type RouteNextHopType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is RouteNextHopType && Equals((RouteNextHopType)obj);
        }

        /// <summary>Returns hashCode for enum RouteNextHopType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="RouteNextHopType" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private RouteNextHopType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for RouteNextHopType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to RouteNextHopType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="RouteNextHopType" />.</param>

        public static implicit operator RouteNextHopType(string value)
        {
            return new RouteNextHopType(value);
        }

        /// <summary>Implicit operator to convert RouteNextHopType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="RouteNextHopType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum RouteNextHopType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum RouteNextHopType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.RouteNextHopType e2)
        {
            return e2.Equals(e1);
        }
    }
}