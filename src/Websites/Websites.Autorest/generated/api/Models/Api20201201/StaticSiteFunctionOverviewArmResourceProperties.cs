namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>StaticSiteFunctionOverviewARMResource resource specific properties</summary>
    public partial class StaticSiteFunctionOverviewArmResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteFunctionOverviewArmResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteFunctionOverviewArmResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="FunctionName" /> property.</summary>
        private string _functionName;

        /// <summary>The name for the function</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string FunctionName { get => this._functionName; }

        /// <summary>Internal Acessors for FunctionName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteFunctionOverviewArmResourcePropertiesInternal.FunctionName { get => this._functionName; set { {_functionName = value;} } }

        /// <summary>Internal Acessors for TriggerType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.TriggerTypes? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteFunctionOverviewArmResourcePropertiesInternal.TriggerType { get => this._triggerType; set { {_triggerType = value;} } }

        /// <summary>Backing field for <see cref="TriggerType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.TriggerTypes? _triggerType;

        /// <summary>The trigger type of the function</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.TriggerTypes? TriggerType { get => this._triggerType; }

        /// <summary>
        /// Creates an new <see cref="StaticSiteFunctionOverviewArmResourceProperties" /> instance.
        /// </summary>
        public StaticSiteFunctionOverviewArmResourceProperties()
        {

        }
    }
    /// StaticSiteFunctionOverviewARMResource resource specific properties
    public partial interface IStaticSiteFunctionOverviewArmResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>The name for the function</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name for the function",
        SerializedName = @"functionName",
        PossibleTypes = new [] { typeof(string) })]
        string FunctionName { get;  }
        /// <summary>The trigger type of the function</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The trigger type of the function",
        SerializedName = @"triggerType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.TriggerTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.TriggerTypes? TriggerType { get;  }

    }
    /// StaticSiteFunctionOverviewARMResource resource specific properties
    internal partial interface IStaticSiteFunctionOverviewArmResourcePropertiesInternal

    {
        /// <summary>The name for the function</summary>
        string FunctionName { get; set; }
        /// <summary>The trigger type of the function</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.TriggerTypes? TriggerType { get; set; }

    }
}