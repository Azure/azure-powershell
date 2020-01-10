namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct EffectiveRouteState :
        System.IEquatable<EffectiveRouteState>
    {
        /// <summary>FIXME: Field Active is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteState Active = @"Active";

        /// <summary>FIXME: Field Invalid is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteState Invalid = @"Invalid";

        /// <summary>the value for an instance of the <see cref="EffectiveRouteState" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to EffectiveRouteState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="EffectiveRouteState" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new EffectiveRouteState(System.Convert.ToString(value));
        }

        /// <summary>Creates an instance of the <see cref="EffectiveRouteState" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private EffectiveRouteState(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Compares values of enum type EffectiveRouteState</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteState e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type EffectiveRouteState (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is EffectiveRouteState && Equals((EffectiveRouteState)obj);
        }

        /// <summary>Returns hashCode for enum EffectiveRouteState</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for EffectiveRouteState</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to EffectiveRouteState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="EffectiveRouteState" />.</param>

        public static implicit operator EffectiveRouteState(string value)
        {
            return new EffectiveRouteState(value);
        }

        /// <summary>Implicit operator to convert EffectiveRouteState to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="EffectiveRouteState" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteState e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum EffectiveRouteState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteState e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum EffectiveRouteState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveRouteState e2)
        {
            return e2.Equals(e1);
        }
    }
}