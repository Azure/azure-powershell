
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Creates or updates a resource type.
.Description
Creates or updates a resource type.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

AUTHORIZATIONACTIONMAPPING <IAuthorizationActionMapping[]>: .
  [Desired <String>]: 
  [Original <String>]: 

ENDPOINT <IResourceTypeEndpoint[]>: .
  [ApiVersion <String[]>]: 
  [Enabled <Boolean?>]: 
  [Extension <IResourceTypeExtension[]>]: 
    [EndpointUri <String>]: 
    [ExtensionCategory <ExtensionCategory[]>]: 
    [Timeout <TimeSpan?>]: 
  [FeatureRuleRequiredFeaturesPolicy <FeaturesPolicy?>]: 
  [Location <String[]>]: 
  [RequiredFeature <String[]>]: 
  [Timeout <TimeSpan?>]: 

EXTENDEDLOCATION <IExtendedLocationOptions[]>: .
  [SupportedPolicy <String>]: 
  [Type <String>]: 

LINKEDACCESSCHECK <ILinkedAccessCheck[]>: .
  [ActionName <String>]: 
  [LinkedAction <String>]: 
  [LinkedActionVerb <String>]: 
  [LinkedProperty <String>]: 
  [LinkedType <String>]: 

LOGGINGRULE <ILoggingRule[]>: .
  Action <String>: 
  DetailLevel <LoggingDetails>: 
  Direction <LoggingDirections>: 
  [HiddenPropertyPathHiddenPathsOnRequest <String[]>]: 
  [HiddenPropertyPathHiddenPathsOnResponse <String[]>]: 

PROPERTY <IResourceTypeRegistration>: .
  [AllowedUnauthorizedAction <String[]>]: 
  [AuthorizationActionMapping <IAuthorizationActionMapping[]>]: 
    [Desired <String>]: 
    [Original <String>]: 
  [CheckNameAvailabilitySpecificationEnableDefaultValidation <Boolean?>]: 
  [CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation <String[]>]: 
  [DefaultApiVersion <String>]: 
  [DisallowedActionVerb <String[]>]: 
  [EnableAsyncOperation <Boolean?>]: 
  [EnableThirdPartyS2S <Boolean?>]: 
  [Endpoint <IResourceTypeEndpoint[]>]: 
    [ApiVersion <String[]>]: 
    [Enabled <Boolean?>]: 
    [Extension <IResourceTypeExtension[]>]: 
      [EndpointUri <String>]: 
      [ExtensionCategory <ExtensionCategory[]>]: 
      [Timeout <TimeSpan?>]: 
    [FeatureRuleRequiredFeaturesPolicy <FeaturesPolicy?>]: 
    [Location <String[]>]: 
    [RequiredFeature <String[]>]: 
    [Timeout <TimeSpan?>]: 
  [ExtendedLocation <IExtendedLocationOptions[]>]: 
    [SupportedPolicy <String>]: 
    [Type <String>]: 
  [FeatureRuleRequiredFeaturesPolicy <FeaturesPolicy?>]: 
  [IdentityManagementApplicationId <String>]: 
  [IdentityManagementType <IdentityManagementTypes?>]: 
  [IsPureProxy <Boolean?>]: 
  [LinkedAccessCheck <ILinkedAccessCheck[]>]: 
    [ActionName <String>]: 
    [LinkedAction <String>]: 
    [LinkedActionVerb <String>]: 
    [LinkedProperty <String>]: 
    [LinkedType <String>]: 
  [LoggingRule <ILoggingRule[]>]: 
    Action <String>: 
    DetailLevel <LoggingDetails>: 
    Direction <LoggingDirections>: 
    [HiddenPropertyPathHiddenPathsOnRequest <String[]>]: 
    [HiddenPropertyPathHiddenPathsOnResponse <String[]>]: 
  [MarketplaceType <String>]: 
  [ProvisioningState <ProvisioningState?>]: 
  [Regionality <Regionality?>]: 
  [RequestHeaderOptionOptInHeader <OptInHeaderType?>]: 
  [RequiredFeature <String[]>]: 
  [ResourceCreationBeginRequest <ExtensionOptionType[]>]: 
  [ResourceCreationBeginResponse <ExtensionOptionType[]>]: 
  [ResourceDeletionPolicy <ResourceDeletionPolicy?>]: 
  [ResourceMovePolicyCrossResourceGroupMoveEnabled <Boolean?>]: 
  [ResourceMovePolicyCrossSubscriptionMoveEnabled <Boolean?>]: 
  [ResourceMovePolicyValidationRequired <Boolean?>]: 
  [RoutingType <RoutingType?>]: 
  [ServiceTreeInfo <IServiceTreeInfo[]>]: 
    [ComponentId <String>]: 
    [ServiceId <String>]: 
  [SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]: 
  [SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]: 
    Action <SubscriptionNotificationOperation>: 
    State <SubscriptionTransitioningState>: 
  [SubscriptionStateRule <ISubscriptionStateRule[]>]: 
    [AllowedAction <String[]>]: 
    [State <SubscriptionState?>]: 
  [SwaggerSpecification <ISwaggerSpecification[]>]: 
    [ApiVersion <String[]>]: 
    [SwaggerSpecFolderUri <String>]: 
  [TemplateDeploymentOptionPreflightOption <PreflightOption[]>]: 
  [TemplateDeploymentOptionPreflightSupported <Boolean?>]: 
  [ThrottlingRule <IThrottlingRule[]>]: 
    Action <String>: 
    Metric <IThrottlingMetric[]>: 
      Limit <Int64>: 
      Type <ThrottlingMetricType>: 
      [Interval <TimeSpan?>]: 
    [RequiredFeature <String[]>]: 

SERVICETREEINFO <IServiceTreeInfo[]>: .
  [ComponentId <String>]: 
  [ServiceId <String>]: 

SUBSCRIPTIONLIFECYCLENOTIFICATIONSPECIFICATIONSUBSCRIPTIONSTATEOVERRIDEACTION <ISubscriptionStateOverrideAction[]>: .
  Action <SubscriptionNotificationOperation>: 
  State <SubscriptionTransitioningState>: 

SUBSCRIPTIONSTATERULE <ISubscriptionStateRule[]>: .
  [AllowedAction <String[]>]: 
  [State <SubscriptionState?>]: 

SWAGGERSPECIFICATION <ISwaggerSpecification[]>: .
  [ApiVersion <String[]>]: 
  [SwaggerSpecFolderUri <String>]: 

THROTTLINGRULE <IThrottlingRule[]>: .
  Action <String>: 
  Metric <IThrottlingMetric[]>: 
    Limit <Int64>: 
    Type <ThrottlingMetricType>: 
    [Interval <TimeSpan?>]: 
  [RequiredFeature <String[]>]: 
.Link
https://docs.microsoft.com/en-us/powershell/module/az.providerhub/set-azproviderhubresourcetyperegistration
#>
function Set-AzProviderHubResourceTypeRegistration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The resource type.
    ${ResourceType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Update', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration]
    # .
    # To construct, see NOTES section for PROPERTY properties and create a hash table.
    ${Property},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${AllowedUnauthorizedAction},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping[]]
    # .
    # To construct, see NOTES section for AUTHORIZATIONACTIONMAPPING properties and create a hash table.
    ${AuthorizationActionMapping},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${CheckNameAvailabilitySpecificationEnableDefaultValidation},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${DefaultApiVersion},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${DisallowedActionVerb},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${EnableAsyncOperation},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${EnableThirdPartyS2S},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeEndpoint[]]
    # .
    # To construct, see NOTES section for ENDPOINT properties and create a hash table.
    ${Endpoint},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions[]]
    # .
    # To construct, see NOTES section for EXTENDEDLOCATION properties and create a hash table.
    ${ExtendedLocation},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.FeaturesPolicy])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.FeaturesPolicy]
    # .
    ${FeatureRuleRequiredFeaturesPolicy},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${IdentityManagementApplicationId},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes]
    # .
    ${IdentityManagementType},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${IsPureProxy},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck[]]
    # .
    # To construct, see NOTES section for LINKEDACCESSCHECK properties and create a hash table.
    ${LinkedAccessCheck},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule[]]
    # .
    # To construct, see NOTES section for LOGGINGRULE properties and create a hash table.
    ${LoggingRule},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${MarketplaceType},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState]
    # .
    ${ProvisioningState},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.Regionality])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.Regionality]
    # .
    ${Regionality},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType]
    # .
    ${RequestHeaderOptionOptInHeader},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${RequiredFeature},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[]]
    # .
    ${ResourceCreationBeginRequest},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[]]
    # .
    ${ResourceCreationBeginResponse},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceDeletionPolicy])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceDeletionPolicy]
    # .
    ${ResourceDeletionPolicy},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${ResourceMovePolicyCrossResourceGroupMoveEnabled},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${ResourceMovePolicyCrossSubscriptionMoveEnabled},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${ResourceMovePolicyValidationRequired},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.RoutingType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.RoutingType]
    # .
    ${RoutingType},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[]]
    # .
    # To construct, see NOTES section for SERVICETREEINFO properties and create a hash table.
    ${ServiceTreeInfo},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.TimeSpan]
    # .
    ${SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction[]]
    # .
    # To construct, see NOTES section for SUBSCRIPTIONLIFECYCLENOTIFICATIONSPECIFICATIONSUBSCRIPTIONSTATEOVERRIDEACTION properties and create a hash table.
    ${SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule[]]
    # .
    # To construct, see NOTES section for SUBSCRIPTIONSTATERULE properties and create a hash table.
    ${SubscriptionStateRule},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISwaggerSpecification[]]
    # .
    # To construct, see NOTES section for SWAGGERSPECIFICATION properties and create a hash table.
    ${SwaggerSpecification},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption[]]
    # .
    ${TemplateDeploymentOptionPreflightOption},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${TemplateDeploymentOptionPreflightSupported},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule[]]
    # .
    # To construct, see NOTES section for THROTTLINGRULE properties and create a hash table.
    ${ThrottlingRule},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Update = 'ProviderHub.private\Set-AzProviderHubResourceTypeRegistration_Update';
            UpdateExpanded = 'ProviderHub.private\Set-AzProviderHubResourceTypeRegistration_UpdateExpanded';
        }
        if (('Update', 'UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
