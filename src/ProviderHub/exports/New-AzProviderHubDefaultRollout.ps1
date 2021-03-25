
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
Creates or updates the rollout details.
.Description
Creates or updates the rollout details.
.Example
PS C:\> New-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10" -RestOfTheWorldGroupTwoWaitDuration New-TimeSpan -Hours 24 -CanarySkipRegion "brazilus"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRollout
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRollout
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IProviderHubIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [NestedResourceTypeFirst <String>]: The first child resource type.
  [NestedResourceTypeSecond <String>]: The second child resource type.
  [NestedResourceTypeThird <String>]: The third child resource type.
  [NotificationRegistrationName <String>]: The notification registration.
  [ProviderNamespace <String>]: The name of the resource provider hosted within ProviderHub.
  [ResourceType <String>]: The resource type.
  [RolloutName <String>]: The rollout name.
  [Sku <String>]: The SKU.
  [SubscriptionId <String>]: The ID of the target subscription.

PROPERTY <IDefaultRollout>: Default rollout definition.
  [CanaryRegion <String[]>]: 
  [CanarySkipRegion <String[]>]: 
  [HighTrafficRegion <String[]>]: 
  [HighTrafficWaitDuration <TimeSpan?>]: 
  [LowTrafficRegion <String[]>]: 
  [LowTrafficWaitDuration <TimeSpan?>]: 
  [MediumTrafficRegion <String[]>]: 
  [MediumTrafficWaitDuration <TimeSpan?>]: 
  [ProvisioningState <String>]: 
  [RestOfTheWorldGroupOneRegion <String[]>]: 
  [RestOfTheWorldGroupOneWaitDuration <TimeSpan?>]: 
  [RestOfTheWorldGroupTwoRegion <String[]>]: 
  [RestOfTheWorldGroupTwoWaitDuration <TimeSpan?>]: 
  [SpecificationProviderRegistration <IProviderRegistration>]: 
    [Capability <IResourceProviderCapabilities[]>]: 
      Effect <String>: 
      QuotaId <String>: 
      [RequiredFeature <String[]>]: 
    [FeatureRuleRequiredFeaturesPolicy <String>]: 
    [ManagementIncidentContactEmail <String>]: 
    [ManagementIncidentRoutingService <String>]: 
    [ManagementIncidentRoutingTeam <String>]: 
    [ManagementManifestOwner <String[]>]: 
    [ManagementResourceAccessPolicy <String>]: 
    [ManagementResourceAccessRole <IResourceProviderManagementResourceAccessRolesItem[]>]: 
    [ManagementSchemaOwner <String[]>]: 
    [ManagementServiceTreeInfo <IServiceTreeInfo[]>]: 
      [ComponentId <String>]: 
      [ServiceId <String>]: 
    [Metadata <IResourceProviderManifestPropertiesMetadata>]: Dictionary of <string>
      [(Any) <String>]: This indicates any property can be added to this object.
    [Namespace <String>]: 
    [ProviderAuthenticationAllowedAudience <String[]>]: 
    [ProviderAuthorization <IResourceProviderAuthorization[]>]: 
      [ApplicationId <String>]: 
      [ManagedByRoleDefinitionId <String>]: 
      [RoleDefinitionId <String>]: 
    [ProviderHubMetadataProviderAuthenticationAllowedAudience <String[]>]: 
    [ProviderHubMetadataProviderAuthorization <IResourceProviderAuthorization[]>]: 
    [ProviderType <String>]: 
    [ProviderVersion <String>]: 
    [ProvisioningState <String>]: 
    [RequestHeaderOptionOptInHeader <String>]: 
    [RequiredFeature <String[]>]: 
    [SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]: 
    [SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]: 
      Action <String>: 
      State <String>: 
    [TemplateDeploymentOptionPreflightOption <String[]>]: 
    [TemplateDeploymentOptionPreflightSupported <Boolean?>]: 
    [ThirdPartyProviderAuthorizationAuthorizationszzz <ILightHouseAuthorization[]>]: 
      PrincipalId <String>: 
      RoleDefinitionId <String>: 
    [ThirdPartyProviderAuthorizationManagedByTenantId <String>]: 
  [SpecificationResourceTypeRegistration <IResourceTypeRegistration[]>]: 
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
        [ExtensionCategory <String[]>]: 
        [Timeout <TimeSpan?>]: 
      [FeatureRuleRequiredFeaturesPolicy <String>]: 
      [Location <String[]>]: 
      [RequiredFeature <String[]>]: 
      [Timeout <TimeSpan?>]: 
    [ExtendedLocation <IExtendedLocationOptions[]>]: 
      [SupportedPolicy <String>]: 
      [Type <String>]: 
    [FeatureRuleRequiredFeaturesPolicy <String>]: 
    [IdentityManagementApplicationId <String>]: 
    [IdentityManagementType <String>]: 
    [IsPureProxy <Boolean?>]: 
    [LinkedAccessCheck <ILinkedAccessCheck[]>]: 
      [ActionName <String>]: 
      [LinkedAction <String>]: 
      [LinkedActionVerb <String>]: 
      [LinkedProperty <String>]: 
      [LinkedType <String>]: 
    [LoggingRule <ILoggingRule[]>]: 
      Action <String>: 
      DetailLevel <String>: 
      Direction <String>: 
      [HiddenPropertyPathHiddenPathsOnRequest <String[]>]: 
      [HiddenPropertyPathHiddenPathsOnResponse <String[]>]: 
    [MarketplaceType <String>]: 
    [ProvisioningState <String>]: 
    [Regionality <String>]: 
    [RequestHeaderOptionOptInHeader <String>]: 
    [RequiredFeature <String[]>]: 
    [ResourceCreationBeginRequest <String[]>]: 
    [ResourceCreationBeginResponse <String[]>]: 
    [ResourceDeletionPolicy <String>]: 
    [ResourceMovePolicyCrossResourceGroupMoveEnabled <Boolean?>]: 
    [ResourceMovePolicyCrossSubscriptionMoveEnabled <Boolean?>]: 
    [ResourceMovePolicyValidationRequired <Boolean?>]: 
    [RoutingType <String>]: 
    [ServiceTreeInfo <IServiceTreeInfo[]>]: 
    [SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]: 
    [SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]: 
    [SubscriptionStateRule <ISubscriptionStateRule[]>]: 
      [AllowedAction <String[]>]: 
      [State <String>]: 
    [SwaggerSpecification <ISwaggerSpecification[]>]: 
      [ApiVersion <String[]>]: 
      [SwaggerSpecFolderUri <String>]: 
    [TemplateDeploymentOptionPreflightOption <String[]>]: 
    [TemplateDeploymentOptionPreflightSupported <Boolean?>]: 
    [ThrottlingRule <IThrottlingRule[]>]: 
      Action <String>: 
      Metric <IThrottlingMetric[]>: 
        Limit <Int64>: 
        Type <String>: 
        [Interval <TimeSpan?>]: 
      [RequiredFeature <String[]>]: 
  [StatusCompletedRegion <String[]>]: 
  [StatusFailedOrSkippedRegion <IRolloutStatusBaseFailedOrSkippedRegions>]: Dictionary of <ExtendedErrorInfo>
    [(Any) <IExtendedErrorInfo>]: This indicates any property can be added to this object.
  [StatusNextTrafficRegion <String>]: 
  [StatusNextTrafficRegionScheduledTime <DateTime?>]: 
  [StatusSubscriptionReregistrationResult <String>]: 

SPECIFICATIONPROVIDERREGISTRATION <IProviderRegistration>: .
  [Capability <IResourceProviderCapabilities[]>]: 
    Effect <String>: 
    QuotaId <String>: 
    [RequiredFeature <String[]>]: 
  [FeatureRuleRequiredFeaturesPolicy <String>]: 
  [ManagementIncidentContactEmail <String>]: 
  [ManagementIncidentRoutingService <String>]: 
  [ManagementIncidentRoutingTeam <String>]: 
  [ManagementManifestOwner <String[]>]: 
  [ManagementResourceAccessPolicy <String>]: 
  [ManagementResourceAccessRole <IResourceProviderManagementResourceAccessRolesItem[]>]: 
  [ManagementSchemaOwner <String[]>]: 
  [ManagementServiceTreeInfo <IServiceTreeInfo[]>]: 
    [ComponentId <String>]: 
    [ServiceId <String>]: 
  [Metadata <IResourceProviderManifestPropertiesMetadata>]: Dictionary of <string>
    [(Any) <String>]: This indicates any property can be added to this object.
  [Namespace <String>]: 
  [ProviderAuthenticationAllowedAudience <String[]>]: 
  [ProviderAuthorization <IResourceProviderAuthorization[]>]: 
    [ApplicationId <String>]: 
    [ManagedByRoleDefinitionId <String>]: 
    [RoleDefinitionId <String>]: 
  [ProviderHubMetadataProviderAuthenticationAllowedAudience <String[]>]: 
  [ProviderHubMetadataProviderAuthorization <IResourceProviderAuthorization[]>]: 
  [ProviderType <String>]: 
  [ProviderVersion <String>]: 
  [ProvisioningState <String>]: 
  [RequestHeaderOptionOptInHeader <String>]: 
  [RequiredFeature <String[]>]: 
  [SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]: 
  [SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]: 
    Action <String>: 
    State <String>: 
  [TemplateDeploymentOptionPreflightOption <String[]>]: 
  [TemplateDeploymentOptionPreflightSupported <Boolean?>]: 
  [ThirdPartyProviderAuthorizationAuthorizationszzz <ILightHouseAuthorization[]>]: 
    PrincipalId <String>: 
    RoleDefinitionId <String>: 
  [ThirdPartyProviderAuthorizationManagedByTenantId <String>]: 

SPECIFICATIONRESOURCETYPEREGISTRATION <IResourceTypeRegistration[]>: .
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
      [ExtensionCategory <String[]>]: 
      [Timeout <TimeSpan?>]: 
    [FeatureRuleRequiredFeaturesPolicy <String>]: 
    [Location <String[]>]: 
    [RequiredFeature <String[]>]: 
    [Timeout <TimeSpan?>]: 
  [ExtendedLocation <IExtendedLocationOptions[]>]: 
    [SupportedPolicy <String>]: 
    [Type <String>]: 
  [FeatureRuleRequiredFeaturesPolicy <String>]: 
  [IdentityManagementApplicationId <String>]: 
  [IdentityManagementType <String>]: 
  [IsPureProxy <Boolean?>]: 
  [LinkedAccessCheck <ILinkedAccessCheck[]>]: 
    [ActionName <String>]: 
    [LinkedAction <String>]: 
    [LinkedActionVerb <String>]: 
    [LinkedProperty <String>]: 
    [LinkedType <String>]: 
  [LoggingRule <ILoggingRule[]>]: 
    Action <String>: 
    DetailLevel <String>: 
    Direction <String>: 
    [HiddenPropertyPathHiddenPathsOnRequest <String[]>]: 
    [HiddenPropertyPathHiddenPathsOnResponse <String[]>]: 
  [MarketplaceType <String>]: 
  [ProvisioningState <String>]: 
  [Regionality <String>]: 
  [RequestHeaderOptionOptInHeader <String>]: 
  [RequiredFeature <String[]>]: 
  [ResourceCreationBeginRequest <String[]>]: 
  [ResourceCreationBeginResponse <String[]>]: 
  [ResourceDeletionPolicy <String>]: 
  [ResourceMovePolicyCrossResourceGroupMoveEnabled <Boolean?>]: 
  [ResourceMovePolicyCrossSubscriptionMoveEnabled <Boolean?>]: 
  [ResourceMovePolicyValidationRequired <Boolean?>]: 
  [RoutingType <String>]: 
  [ServiceTreeInfo <IServiceTreeInfo[]>]: 
    [ComponentId <String>]: 
    [ServiceId <String>]: 
  [SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]: 
  [SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]: 
    Action <String>: 
    State <String>: 
  [SubscriptionStateRule <ISubscriptionStateRule[]>]: 
    [AllowedAction <String[]>]: 
    [State <String>]: 
  [SwaggerSpecification <ISwaggerSpecification[]>]: 
    [ApiVersion <String[]>]: 
    [SwaggerSpecFolderUri <String>]: 
  [TemplateDeploymentOptionPreflightOption <String[]>]: 
  [TemplateDeploymentOptionPreflightSupported <Boolean?>]: 
  [ThrottlingRule <IThrottlingRule[]>]: 
    Action <String>: 
    Metric <IThrottlingMetric[]>: 
      Limit <Int64>: 
      Type <String>: 
      [Interval <TimeSpan?>]: 
    [RequiredFeature <String[]>]: 
.Link
https://docs.microsoft.com/en-us/powershell/module/az.providerhub/new-azproviderhubdefaultrollout
#>
function New-AzProviderHubDefaultRollout {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRollout])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The rollout name.
    ${RolloutName},

    [Parameter(ParameterSetName='Create')]
    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Create', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRollout]
    # Default rollout definition.
    # To construct, see NOTES section for PROPERTY properties and create a hash table.
    ${Property},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${CanaryRegion},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${CanarySkipRegion},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${HighTrafficRegion},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.TimeSpan]
    # .
    ${HighTrafficWaitDuration},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${LowTrafficRegion},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.TimeSpan]
    # .
    ${LowTrafficWaitDuration},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${MediumTrafficRegion},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.TimeSpan]
    # .
    ${MediumTrafficWaitDuration},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${ProvisioningState},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${RestOfTheWorldGroupOneRegion},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.TimeSpan]
    # .
    ${RestOfTheWorldGroupOneWaitDuration},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${RestOfTheWorldGroupTwoRegion},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.TimeSpan]
    # .
    ${RestOfTheWorldGroupTwoWaitDuration},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration]
    # .
    # To construct, see NOTES section for SPECIFICATIONPROVIDERREGISTRATION properties and create a hash table.
    ${SpecificationProviderRegistration},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration[]]
    # .
    # To construct, see NOTES section for SPECIFICATIONRESOURCETYPEREGISTRATION properties and create a hash table.
    ${SpecificationResourceTypeRegistration},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${StatusCompletedRegion},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegions]))]
    [System.Collections.Hashtable]
    # Dictionary of <ExtendedErrorInfo>
    ${StatusFailedOrSkippedRegion},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${StatusNextTrafficRegion},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.DateTime]
    # .
    ${StatusNextTrafficRegionScheduledTime},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${StatusSubscriptionReregistrationResult},

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
            Create = 'ProviderHub.private\New-AzProviderHubDefaultRollout_Create';
            CreateExpanded = 'ProviderHub.private\New-AzProviderHubDefaultRollout_CreateExpanded';
            CreateViaIdentity = 'ProviderHub.private\New-AzProviderHubDefaultRollout_CreateViaIdentity';
            CreateViaIdentityExpanded = 'ProviderHub.private\New-AzProviderHubDefaultRollout_CreateViaIdentityExpanded';
        }
        if (('Create', 'CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
