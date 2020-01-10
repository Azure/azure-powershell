namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ExpressRoutePeeringType :
        System.IEquatable<ExpressRoutePeeringType>
    {
        /// <summary>FIXME: Field AzurePrivatePeering is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType AzurePrivatePeering = @"AzurePrivatePeering";

        /// <summary>FIXME: Field AzurePublicPeering is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType AzurePublicPeering = @"AzurePublicPeering";

        /// <summary>FIXME: Field MicrosoftPeering is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType MicrosoftPeering = @"MicrosoftPeering";

        /// <summary>the value for an instance of the <see cref="ExpressRoutePeeringType" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to ExpressRoutePeeringType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ExpressRoutePeeringType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ExpressRoutePeeringType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ExpressRoutePeeringType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ExpressRoutePeeringType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ExpressRoutePeeringType && Equals((ExpressRoutePeeringType)obj);
        }

        /// <summary>Creates an instance of the <see cref="ExpressRoutePeeringType" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ExpressRoutePeeringType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns hashCode for enum ExpressRoutePeeringType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ExpressRoutePeeringType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ExpressRoutePeeringType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ExpressRoutePeeringType" />.</param>

        public static implicit operator ExpressRoutePeeringType(string value)
        {
            return new ExpressRoutePeeringType(value);
        }

        /// <summary>Implicit operator to convert ExpressRoutePeeringType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ExpressRoutePeeringType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ExpressRoutePeeringType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ExpressRoutePeeringType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType e2)
        {
            return e2.Equals(e1);
        }
    }
}