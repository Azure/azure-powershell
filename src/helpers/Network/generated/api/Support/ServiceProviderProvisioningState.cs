namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct ServiceProviderProvisioningState :
        System.IEquatable<ServiceProviderProvisioningState>
    {
        /// <summary>FIXME: Field Deprovisioning is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState Deprovisioning = @"Deprovisioning";

        /// <summary>FIXME: Field NotProvisioned is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState NotProvisioned = @"NotProvisioned";

        /// <summary>FIXME: Field Provisioned is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState Provisioned = @"Provisioned";

        /// <summary>FIXME: Field Provisioning is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState Provisioning = @"Provisioning";

        /// <summary>
        /// the value for an instance of the <see cref="ServiceProviderProvisioningState" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to ServiceProviderProvisioningState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ServiceProviderProvisioningState" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new ServiceProviderProvisioningState(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ServiceProviderProvisioningState</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type ServiceProviderProvisioningState (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ServiceProviderProvisioningState && Equals((ServiceProviderProvisioningState)obj);
        }

        /// <summary>Returns hashCode for enum ServiceProviderProvisioningState</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>
        /// Creates an instance of the <see cref="ServiceProviderProvisioningState" Enum class./>
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ServiceProviderProvisioningState(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for ServiceProviderProvisioningState</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ServiceProviderProvisioningState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ServiceProviderProvisioningState" />.</param>

        public static implicit operator ServiceProviderProvisioningState(string value)
        {
            return new ServiceProviderProvisioningState(value);
        }

        /// <summary>Implicit operator to convert ServiceProviderProvisioningState to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ServiceProviderProvisioningState" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ServiceProviderProvisioningState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ServiceProviderProvisioningState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState e2)
        {
            return e2.Equals(e1);
        }
    }
}