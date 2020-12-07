namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    public partial class StatusCodeCount :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IStatusCodeCount,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IStatusCodeCountInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>The instance view status code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Code { get => this._code; }

        /// <summary>Backing field for <see cref="Count" /> property.</summary>
        private int? _count;

        /// <summary>Number of instances having this status code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public int? Count { get => this._count; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IStatusCodeCountInternal.Code { get => this._code; set { {_code = value;} } }

        /// <summary>Internal Acessors for Count</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IStatusCodeCountInternal.Count { get => this._count; set { {_count = value;} } }

        /// <summary>Creates an new <see cref="StatusCodeCount" /> instance.</summary>
        public StatusCodeCount()
        {

        }
    }
    public partial interface IStatusCodeCount :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>The instance view status code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The instance view status code",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>Number of instances having this status code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Number of instances having this status code",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? Count { get;  }

    }
    internal partial interface IStatusCodeCountInternal

    {
        /// <summary>The instance view status code</summary>
        string Code { get; set; }
        /// <summary>Number of instances having this status code</summary>
        int? Count { get; set; }

    }
}