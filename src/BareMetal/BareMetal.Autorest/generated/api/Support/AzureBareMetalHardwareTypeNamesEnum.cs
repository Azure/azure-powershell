// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.BareMetal.Support
{

    /// <summary>Name of the hardware type (vendor and/or their product name)</summary>
    public partial struct AzureBareMetalHardwareTypeNamesEnum :
        System.IEquatable<AzureBareMetalHardwareTypeNamesEnum>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.BareMetal.Support.AzureBareMetalHardwareTypeNamesEnum CiscoUcs = @"Cisco_UCS";

        public static Microsoft.Azure.PowerShell.Cmdlets.BareMetal.Support.AzureBareMetalHardwareTypeNamesEnum Hpe = @"HPE";

        /// <summary>
        /// the value for an instance of the <see cref="AzureBareMetalHardwareTypeNamesEnum" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="AzureBareMetalHardwareTypeNamesEnum"/> Enum class.
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private AzureBareMetalHardwareTypeNamesEnum(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to AzureBareMetalHardwareTypeNamesEnum</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AzureBareMetalHardwareTypeNamesEnum" />.</param>
        internal static object CreateFrom(object value)
        {
            return new AzureBareMetalHardwareTypeNamesEnum(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type AzureBareMetalHardwareTypeNamesEnum</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.BareMetal.Support.AzureBareMetalHardwareTypeNamesEnum e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>
        /// Compares values of enum type AzureBareMetalHardwareTypeNamesEnum (override for Object)
        /// </summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is AzureBareMetalHardwareTypeNamesEnum && Equals((AzureBareMetalHardwareTypeNamesEnum)obj);
        }

        /// <summary>Returns hashCode for enum AzureBareMetalHardwareTypeNamesEnum</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for AzureBareMetalHardwareTypeNamesEnum</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to AzureBareMetalHardwareTypeNamesEnum</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AzureBareMetalHardwareTypeNamesEnum" />.</param>

        public static implicit operator AzureBareMetalHardwareTypeNamesEnum(string value)
        {
            return new AzureBareMetalHardwareTypeNamesEnum(value);
        }

        /// <summary>Implicit operator to convert AzureBareMetalHardwareTypeNamesEnum to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="AzureBareMetalHardwareTypeNamesEnum" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.BareMetal.Support.AzureBareMetalHardwareTypeNamesEnum e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum AzureBareMetalHardwareTypeNamesEnum</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.BareMetal.Support.AzureBareMetalHardwareTypeNamesEnum e1, Microsoft.Azure.PowerShell.Cmdlets.BareMetal.Support.AzureBareMetalHardwareTypeNamesEnum e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum AzureBareMetalHardwareTypeNamesEnum</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.BareMetal.Support.AzureBareMetalHardwareTypeNamesEnum e1, Microsoft.Azure.PowerShell.Cmdlets.BareMetal.Support.AzureBareMetalHardwareTypeNamesEnum e2)
        {
            return e2.Equals(e1);
        }
    }
}