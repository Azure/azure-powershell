namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct DdosCustomPolicyTriggerSensitivityOverride :
        System.IEquatable<DdosCustomPolicyTriggerSensitivityOverride>
    {
        /// <summary>FIXME: Field Default is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride Default = @"Default";

        /// <summary>FIXME: Field High is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride High = @"High";

        /// <summary>FIXME: Field Low is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride Low = @"Low";

        /// <summary>FIXME: Field Relaxed is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride Relaxed = @"Relaxed";

        /// <summary>
        /// the value for an instance of the <see cref="DdosCustomPolicyTriggerSensitivityOverride" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to DdosCustomPolicyTriggerSensitivityOverride</summary>
        /// <param name="value">the value to convert to an instance of <see cref="DdosCustomPolicyTriggerSensitivityOverride" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new DdosCustomPolicyTriggerSensitivityOverride(System.Convert.ToString(value));
        }

        /// <summary>
        /// Creates an instance of the <see cref="DdosCustomPolicyTriggerSensitivityOverride" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private DdosCustomPolicyTriggerSensitivityOverride(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Compares values of enum type DdosCustomPolicyTriggerSensitivityOverride</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type DdosCustomPolicyTriggerSensitivityOverride (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is DdosCustomPolicyTriggerSensitivityOverride && Equals((DdosCustomPolicyTriggerSensitivityOverride)obj);
        }

        /// <summary>Returns hashCode for enum DdosCustomPolicyTriggerSensitivityOverride</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for DdosCustomPolicyTriggerSensitivityOverride</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Implicit operator to convert string to DdosCustomPolicyTriggerSensitivityOverride
        /// </summary>
        /// <param name="value">the value to convert to an instance of <see cref="DdosCustomPolicyTriggerSensitivityOverride" />.</param>

        public static implicit operator DdosCustomPolicyTriggerSensitivityOverride(string value)
        {
            return new DdosCustomPolicyTriggerSensitivityOverride(value);
        }

        /// <summary>
        /// Implicit operator to convert DdosCustomPolicyTriggerSensitivityOverride to string
        /// </summary>
        /// <param name="e">the value to convert to an instance of <see cref="DdosCustomPolicyTriggerSensitivityOverride" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum DdosCustomPolicyTriggerSensitivityOverride</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum DdosCustomPolicyTriggerSensitivityOverride</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride e2)
        {
            return e2.Equals(e1);
        }
    }
}