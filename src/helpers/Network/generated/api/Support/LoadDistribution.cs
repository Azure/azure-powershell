namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct LoadDistribution :
        System.IEquatable<LoadDistribution>
    {
        /// <summary>FIXME: Field Default is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution Default = @"Default";

        /// <summary>FIXME: Field SourceIP is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution SourceIP = @"SourceIP";

        /// <summary>FIXME: Field SourceIPProtocol is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution SourceIPProtocol = @"SourceIPProtocol";

        /// <summary>the value for an instance of the <see cref="LoadDistribution" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to LoadDistribution</summary>
        /// <param name="value">the value to convert to an instance of <see cref="LoadDistribution" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new LoadDistribution(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type LoadDistribution</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type LoadDistribution (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is LoadDistribution && Equals((LoadDistribution)obj);
        }

        /// <summary>Returns hashCode for enum LoadDistribution</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="LoadDistribution" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private LoadDistribution(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for LoadDistribution</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to LoadDistribution</summary>
        /// <param name="value">the value to convert to an instance of <see cref="LoadDistribution" />.</param>

        public static implicit operator LoadDistribution(string value)
        {
            return new LoadDistribution(value);
        }

        /// <summary>Implicit operator to convert LoadDistribution to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="LoadDistribution" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum LoadDistribution</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum LoadDistribution</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution e2)
        {
            return e2.Equals(e1);
        }
    }
}