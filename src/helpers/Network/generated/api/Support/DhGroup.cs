namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct DhGroup :
        System.IEquatable<DhGroup>
    {
        /// <summary>FIXME: Field DhGroup1 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup DhGroup1 = @"DHGroup1";

        /// <summary>FIXME: Field DhGroup14 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup DhGroup14 = @"DHGroup14";

        /// <summary>FIXME: Field DhGroup2 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup DhGroup2 = @"DHGroup2";

        /// <summary>FIXME: Field DhGroup2048 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup DhGroup2048 = @"DHGroup2048";

        /// <summary>FIXME: Field DhGroup24 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup DhGroup24 = @"DHGroup24";

        /// <summary>FIXME: Field Ecp256 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup Ecp256 = @"ECP256";

        /// <summary>FIXME: Field Ecp384 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup Ecp384 = @"ECP384";

        /// <summary>FIXME: Field None is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup None = @"None";

        /// <summary>the value for an instance of the <see cref="DhGroup" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to DhGroup</summary>
        /// <param name="value">the value to convert to an instance of <see cref="DhGroup" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new DhGroup(System.Convert.ToString(value));
        }

        /// <summary>Creates an instance of the <see cref="DhGroup" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private DhGroup(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Compares values of enum type DhGroup</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type DhGroup (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is DhGroup && Equals((DhGroup)obj);
        }

        /// <summary>Returns hashCode for enum DhGroup</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for DhGroup</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to DhGroup</summary>
        /// <param name="value">the value to convert to an instance of <see cref="DhGroup" />.</param>

        public static implicit operator DhGroup(string value)
        {
            return new DhGroup(value);
        }

        /// <summary>Implicit operator to convert DhGroup to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="DhGroup" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum DhGroup</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum DhGroup</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup e2)
        {
            return e2.Equals(e1);
        }
    }
}