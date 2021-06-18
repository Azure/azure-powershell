namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The name object of the resource</summary>
    public partial class UsageName :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageName,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageNameInternal
    {

        /// <summary>Backing field for <see cref="LocalizedValue" /> property.</summary>
        private string _localizedValue;

        /// <summary>The localized name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string LocalizedValue { get => this._localizedValue; }

        /// <summary>Internal Acessors for LocalizedValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageNameInternal.LocalizedValue { get => this._localizedValue; set { {_localizedValue = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageNameInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Value { get => this._value; }

        /// <summary>Creates an new <see cref="UsageName" /> instance.</summary>
        public UsageName()
        {

        }
    }
    /// The name object of the resource
    public partial interface IUsageName :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The localized name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The localized name of the resource",
        SerializedName = @"localizedValue",
        PossibleTypes = new [] { typeof(string) })]
        string LocalizedValue { get;  }
        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the resource",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get;  }

    }
    /// The name object of the resource
    internal partial interface IUsageNameInternal

    {
        /// <summary>The localized name of the resource</summary>
        string LocalizedValue { get; set; }
        /// <summary>The name of the resource</summary>
        string Value { get; set; }

    }
}