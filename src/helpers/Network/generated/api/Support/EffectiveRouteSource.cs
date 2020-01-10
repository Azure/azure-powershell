namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct EffectiveRouteSource :
        System.IEquatable<EffectiveRouteSource>
    {
        /// <summary>FIXME: Field Default is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource Default = @"Default";

        /// <summary>FIXME: Field Unknown is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource Unknown = @"Unknown";

        /// <summary>FIXME: Field User is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource User = @"User";

        /// <summary>FIXME: Field VirtualNetworkGateway is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource VirtualNetworkGateway = @"VirtualNetworkGateway";

        /// <summary>the value for an instance of the <see cref="EffectiveRouteSource" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to EffectiveRouteSource</summary>
        /// <param name="value">the value to convert to an instance of <see cref="EffectiveRouteSource" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new EffectiveRouteSource(System.Convert.ToString(value));
        }

        /// <summary>Creates an instance of the <see cref="EffectiveRouteSource" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private EffectiveRouteSource(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Compares values of enum type EffectiveRouteSource</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type EffectiveRouteSource (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is EffectiveRouteSource && Equals((EffectiveRouteSource)obj);
        }

        /// <summary>Returns hashCode for enum EffectiveRouteSource</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for EffectiveRouteSource</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to EffectiveRouteSource</summary>
        /// <param name="value">the value to convert to an instance of <see cref="EffectiveRouteSource" />.</param>

        public static implicit operator EffectiveRouteSource(string value)
        {
            return new EffectiveRouteSource(value);
        }

        /// <summary>Implicit operator to convert EffectiveRouteSource to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="EffectiveRouteSource" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum EffectiveRouteSource</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum EffectiveRouteSource</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteSource e2)
        {
            return e2.Equals(e1);
        }
    }
}