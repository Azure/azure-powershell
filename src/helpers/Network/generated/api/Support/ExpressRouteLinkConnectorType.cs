namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ExpressRouteLinkConnectorType :
        System.IEquatable<ExpressRouteLinkConnectorType>
    {
        /// <summary>FIXME: Field Lc is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType Lc = @"LC";

        /// <summary>FIXME: Field Sc is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType Sc = @"SC";

        /// <summary>
        /// the value for an instance of the <see cref="ExpressRouteLinkConnectorType" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to ExpressRouteLinkConnectorType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ExpressRouteLinkConnectorType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ExpressRouteLinkConnectorType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ExpressRouteLinkConnectorType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ExpressRouteLinkConnectorType (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ExpressRouteLinkConnectorType && Equals((ExpressRouteLinkConnectorType)obj);
        }

        /// <summary>
        /// Creates an instance of the <see cref="ExpressRouteLinkConnectorType" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ExpressRouteLinkConnectorType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns hashCode for enum ExpressRouteLinkConnectorType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ExpressRouteLinkConnectorType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ExpressRouteLinkConnectorType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ExpressRouteLinkConnectorType" />.</param>

        public static implicit operator ExpressRouteLinkConnectorType(string value)
        {
            return new ExpressRouteLinkConnectorType(value);
        }

        /// <summary>Implicit operator to convert ExpressRouteLinkConnectorType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ExpressRouteLinkConnectorType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ExpressRouteLinkConnectorType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ExpressRouteLinkConnectorType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType e2)
        {
            return e2.Equals(e1);
        }
    }
}