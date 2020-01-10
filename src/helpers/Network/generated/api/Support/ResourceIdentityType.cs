namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ResourceIdentityType :
        System.IEquatable<ResourceIdentityType>
    {
        /// <summary>FIXME: Field None is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType None = @"None";

        /// <summary>FIXME: Field SystemAssigned is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType SystemAssigned = @"SystemAssigned";

        /// <summary>FIXME: Field SystemAssignedUserAssigned is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType SystemAssignedUserAssigned = @"SystemAssigned, UserAssigned";

        /// <summary>FIXME: Field UserAssigned is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType UserAssigned = @"UserAssigned";

        /// <summary>the value for an instance of the <see cref="ResourceIdentityType" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to ResourceIdentityType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ResourceIdentityType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ResourceIdentityType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ResourceIdentityType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ResourceIdentityType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ResourceIdentityType && Equals((ResourceIdentityType)obj);
        }

        /// <summary>Returns hashCode for enum ResourceIdentityType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="ResourceIdentityType" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ResourceIdentityType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for ResourceIdentityType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ResourceIdentityType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ResourceIdentityType" />.</param>

        public static implicit operator ResourceIdentityType(string value)
        {
            return new ResourceIdentityType(value);
        }

        /// <summary>Implicit operator to convert ResourceIdentityType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ResourceIdentityType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ResourceIdentityType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ResourceIdentityType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType e2)
        {
            return e2.Equals(e1);
        }
    }
}