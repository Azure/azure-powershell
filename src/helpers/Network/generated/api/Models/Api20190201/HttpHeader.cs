namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Describes the HTTP header.</summary>
    public partial class HttpHeader :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeaderInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name in HTTP header.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>The value in HTTP header.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="HttpHeader" /> instance.</summary>
        public HttpHeader()
        {

        }
    }
    /// Describes the HTTP header.
    public partial interface IHttpHeader :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The name in HTTP header.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name in HTTP header.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The value in HTTP header.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value in HTTP header.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Describes the HTTP header.
    internal partial interface IHttpHeaderInternal

    {
        /// <summary>The name in HTTP header.</summary>
        string Name { get; set; }
        /// <summary>The value in HTTP header.</summary>
        string Value { get; set; }

    }
}