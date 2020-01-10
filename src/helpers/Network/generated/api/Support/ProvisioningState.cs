namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ProvisioningState :
        System.IEquatable<ProvisioningState>
    {
        /// <summary>FIXME: Field Deleting is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState Deleting = @"Deleting";

        /// <summary>FIXME: Field Failed is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState Failed = @"Failed";

        /// <summary>FIXME: Field Succeeded is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState Succeeded = @"Succeeded";

        /// <summary>FIXME: Field Updating is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState Updating = @"Updating";

        /// <summary>the value for an instance of the <see cref="ProvisioningState" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to ProvisioningState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ProvisioningState" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ProvisioningState(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ProvisioningState</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ProvisioningState (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ProvisioningState && Equals((ProvisioningState)obj);
        }

        /// <summary>Returns hashCode for enum ProvisioningState</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="ProvisioningState" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ProvisioningState(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for ProvisioningState</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ProvisioningState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ProvisioningState" />.</param>

        public static implicit operator ProvisioningState(string value)
        {
            return new ProvisioningState(value);
        }

        /// <summary>Implicit operator to convert ProvisioningState to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ProvisioningState" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ProvisioningState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ProvisioningState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState e2)
        {
            return e2.Equals(e1);
        }
    }
}