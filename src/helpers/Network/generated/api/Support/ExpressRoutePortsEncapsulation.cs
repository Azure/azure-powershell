namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ExpressRoutePortsEncapsulation :
        System.IEquatable<ExpressRoutePortsEncapsulation>
    {
        /// <summary>FIXME: Field Dot1Q is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation Dot1Q = @"Dot1Q";

        /// <summary>FIXME: Field QinQ is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation QinQ = @"QinQ";

        /// <summary>
        /// the value for an instance of the <see cref="ExpressRoutePortsEncapsulation" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to ExpressRoutePortsEncapsulation</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ExpressRoutePortsEncapsulation" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ExpressRoutePortsEncapsulation(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ExpressRoutePortsEncapsulation</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ExpressRoutePortsEncapsulation (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ExpressRoutePortsEncapsulation && Equals((ExpressRoutePortsEncapsulation)obj);
        }

        /// <summary>
        /// Creates an instance of the <see cref="ExpressRoutePortsEncapsulation" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ExpressRoutePortsEncapsulation(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns hashCode for enum ExpressRoutePortsEncapsulation</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ExpressRoutePortsEncapsulation</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ExpressRoutePortsEncapsulation</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ExpressRoutePortsEncapsulation" />.</param>

        public static implicit operator ExpressRoutePortsEncapsulation(string value)
        {
            return new ExpressRoutePortsEncapsulation(value);
        }

        /// <summary>Implicit operator to convert ExpressRoutePortsEncapsulation to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ExpressRoutePortsEncapsulation" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ExpressRoutePortsEncapsulation</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ExpressRoutePortsEncapsulation</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation e2)
        {
            return e2.Equals(e1);
        }
    }
}