namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The list of bot service operation response.</summary>
    public partial class OperationEntityListResult :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationEntityListResult,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationEntityListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link used to get the next page of operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationEntity[] _value;

        /// <summary>The list of operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationEntity[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="OperationEntityListResult" /> instance.</summary>
        public OperationEntityListResult()
        {

        }
    }
    /// The list of bot service operation response.
    public partial interface IOperationEntityListResult :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>The link used to get the next page of operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The link used to get the next page of operations.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The list of operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of operations.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationEntity) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationEntity[] Value { get; set; }

    }
    /// The list of bot service operation response.
    internal partial interface IOperationEntityListResultInternal

    {
        /// <summary>The link used to get the next page of operations.</summary>
        string NextLink { get; set; }
        /// <summary>The list of operations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationEntity[] Value { get; set; }

    }
}