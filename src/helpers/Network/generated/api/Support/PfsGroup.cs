namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct PfsGroup :
        System.IEquatable<PfsGroup>
    {
        /// <summary>FIXME: Field Ecp256 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup Ecp256 = @"ECP256";

        /// <summary>FIXME: Field Ecp384 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup Ecp384 = @"ECP384";

        /// <summary>FIXME: Field None is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup None = @"None";

        /// <summary>FIXME: Field Pfs1 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup Pfs1 = @"PFS1";

        /// <summary>FIXME: Field Pfs14 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup Pfs14 = @"PFS14";

        /// <summary>FIXME: Field Pfs2 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup Pfs2 = @"PFS2";

        /// <summary>FIXME: Field Pfs2048 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup Pfs2048 = @"PFS2048";

        /// <summary>FIXME: Field Pfs24 is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup Pfs24 = @"PFS24";

        /// <summary>FIXME: Field Pfsmm is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup Pfsmm = @"PFSMM";

        /// <summary>the value for an instance of the <see cref="PfsGroup" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to PfsGroup</summary>
        /// <param name="value">the value to convert to an instance of <see cref="PfsGroup" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new PfsGroup(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type PfsGroup</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type PfsGroup (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is PfsGroup && Equals((PfsGroup)obj);
        }

        /// <summary>Returns hashCode for enum PfsGroup</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="PfsGroup" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private PfsGroup(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for PfsGroup</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to PfsGroup</summary>
        /// <param name="value">the value to convert to an instance of <see cref="PfsGroup" />.</param>

        public static implicit operator PfsGroup(string value)
        {
            return new PfsGroup(value);
        }

        /// <summary>Implicit operator to convert PfsGroup to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="PfsGroup" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum PfsGroup</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum PfsGroup</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup e2)
        {
            return e2.Equals(e1);
        }
    }
}