namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct IPFlowProtocol :
        System.IEquatable<IPFlowProtocol>
    {
        /// <summary>FIXME: Field Tcp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol Tcp = @"TCP";

        /// <summary>FIXME: Field Udp is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol Udp = @"UDP";

        /// <summary>the value for an instance of the <see cref="IPFlowProtocol" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to IPFlowProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="IPFlowProtocol" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new IPFlowProtocol(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type IPFlowProtocol</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type IPFlowProtocol (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is IPFlowProtocol && Equals((IPFlowProtocol)obj);
        }

        /// <summary>Returns hashCode for enum IPFlowProtocol</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="IPFlowProtocol" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private IPFlowProtocol(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for IPFlowProtocol</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to IPFlowProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="IPFlowProtocol" />.</param>

        public static implicit operator IPFlowProtocol(string value)
        {
            return new IPFlowProtocol(value);
        }

        /// <summary>Implicit operator to convert IPFlowProtocol to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="IPFlowProtocol" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum IPFlowProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum IPFlowProtocol</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol e2)
        {
            return e2.Equals(e1);
        }
    }
}