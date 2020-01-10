namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct IssueType :
        System.IEquatable<IssueType>
    {
        /// <summary>FIXME: Field AgentStopped is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType AgentStopped = @"AgentStopped";

        /// <summary>FIXME: Field DnsResolution is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType DnsResolution = @"DnsResolution";

        /// <summary>FIXME: Field GuestFirewall is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType GuestFirewall = @"GuestFirewall";

        /// <summary>FIXME: Field NetworkSecurityRule is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType NetworkSecurityRule = @"NetworkSecurityRule";

        /// <summary>FIXME: Field Platform is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType Platform = @"Platform";

        /// <summary>FIXME: Field PortThrottled is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType PortThrottled = @"PortThrottled";

        /// <summary>FIXME: Field SocketBind is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType SocketBind = @"SocketBind";

        /// <summary>FIXME: Field Unknown is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType Unknown = @"Unknown";

        /// <summary>FIXME: Field UserDefinedRoute is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType UserDefinedRoute = @"UserDefinedRoute";

        /// <summary>the value for an instance of the <see cref="IssueType" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to IssueType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="IssueType" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new IssueType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type IssueType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type IssueType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is IssueType && Equals((IssueType)obj);
        }

        /// <summary>Returns hashCode for enum IssueType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="IssueType" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private IssueType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for IssueType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to IssueType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="IssueType" />.</param>

        public static implicit operator IssueType(string value)
        {
            return new IssueType(value);
        }

        /// <summary>Implicit operator to convert IssueType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="IssueType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum IssueType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum IssueType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType e2)
        {
            return e2.Equals(e1);
        }
    }
}