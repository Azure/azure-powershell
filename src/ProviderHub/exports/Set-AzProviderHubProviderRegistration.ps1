
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
Creates or updates the provider registration.
.Description
Creates or updates the provider registration.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

CAPABILITY <IResourceProviderCapabilities[]>: .
  Effect <ResourceProviderCapabilitiesEffect>: 
  QuotaId <String>: 
  [RequiredFeature <String[]>]: 

MANAGEMENTSERVICETREEINFO <IServiceTreeInfo[]>: .
  [ComponentId <String>]: 
  [ServiceId <String>]: 

PROPERTY <IProviderRegistration>: .
  [Capability <IResourceProviderCapabilities[]>]: 
    Effect <ResourceProviderCapabilitiesEffect>: 
    QuotaId <String>: 
    [RequiredFeature <String[]>]: 
  [FeatureRuleRequiredFeaturesPolicy <FeaturesPolicy?>]: 
  [ManagementIncidentContactEmail <String>]: 
  [ManagementIncidentRoutingService <String>]: 
  [ManagementIncidentRoutingTeam <String>]: 
  [ManagementManifestOwner <String[]>]: 
  [ManagementResourceAccessPolicy <String>]: 
  [ManagementResourceAccessRole <IAny[]>]: 
  [ManagementSchemaOwner <String[]>]: 
  [ManagementServiceTreeInfo <IServiceTreeInfo[]>]: 
    [ComponentId <String>]: 
    [ServiceId <String>]: 
  [Metadata <IAny>]: Any object
  [Namespace <String>]: 
  [ProviderAuthenticationAllowedAudience <String[]>]: 
  [ProviderAuthorization <IResourceProviderAuthorization[]>]: 
    [ApplicationId <String>]: 
    [ManagedByRoleDefinitionId <String>]: 
    [RoleDefinitionId <String>]: 
  [ProviderHubMetadataProviderAuthenticationAllowedAudience <String[]>]: 
  [ProviderHubMetadataProviderAuthorization <IResourceProviderAuthorization[]>]: 
  [ProviderType <ResourceProviderType?>]: 
  [ProviderVersion <String>]: 
  [ProvisioningState <ProvisioningState?>]: 
  [RequestHeaderOptionOptInHeader <OptInHeaderType?>]: 
  [RequiredFeature <String[]>]: 
  [SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]: 
  [SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]: 
    Action <SubscriptionNotificationOperation>: 
    State <SubscriptionTransitioningState>: 
  [TemplateDeploymentOptionPreflightOption <PreflightOption[]>]: 
  [TemplateDeploymentOptionPreflightSupported <Boolean?>]: 
  [ThirdPartyProviderAuthorizationAuthorizationszzz <ILightHouseAuthorization[]>]: 
    PrincipalId <String>: 
    RoleDefinitionId <String>: 
  [ThirdPartyProviderAuthorizationManagedByTenantId <String>]: 

PROVIDERAUTHORIZATION <IResourceProviderAuthorization[]>: .
  [ApplicationId <String>]: 
  [ManagedByRoleDefinitionId <String>]: 
  [RoleDefinitionId <String>]: 

PROVIDERHUBMETADATAPROVIDERAUTHORIZATION <IResourceProviderAuthorization[]>: .
  [ApplicationId <String>]: 
  [ManagedByRoleDefinitionId <String>]: 
  [RoleDefinitionId <String>]: 

SUBSCRIPTIONLIFECYCLENOTIFICATIONSPECIFICATIONSUBSCRIPTIONSTATEOVERRIDEACTION <ISubscriptionStateOverrideAction[]>: .
  Action <SubscriptionNotificationOperation>: 
  State <SubscriptionTransitioningState>: 

THIRDPARTYPROVIDERAUTHORIZATIONAUTHORIZATIONSZZZ <ILightHouseAuthorization[]>: .
  PrincipalId <String>: 
  RoleDefinitionId <String>: 
.Link
https://docs.microsoft.com/en-us/powershell/module/az.providerhub/set-azproviderhubproviderregistration
#>
function Set-AzProviderHubProviderRegistration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Update', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration]
    # .
    # To construct, see NOTES section for PROPERTY properties and create a hash table.
    ${Property},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderCapabilities[]]
    # .
    # To construct, see NOTES section for CAPABILITY properties and create a hash table.
    ${Capability},

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
    ${ManagementIncidentContactEmail},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${ManagementIncidentRoutingService},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${ManagementIncidentRoutingTeam},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${ManagementManifestOwner},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${ManagementResourceAccessPolicy},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny[]]
    # .
    ${ManagementResourceAccessRole},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${ManagementSchemaOwner},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[]]
    # .
    # To construct, see NOTES section for MANAGEMENTSERVICETREEINFO properties and create a hash table.
    ${ManagementServiceTreeInfo},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny]
    # Any object
    ${Metadata},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${Namespace},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${ProviderAuthenticationAllowedAudience},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[]]
    # .
    # To construct, see NOTES section for PROVIDERAUTHORIZATION properties and create a hash table.
    ${ProviderAuthorization},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${ProviderHubMetadataProviderAuthenticationAllowedAudience},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[]]
    # .
    # To construct, see NOTES section for PROVIDERHUBMETADATAPROVIDERAUTHORIZATION properties and create a hash table.
    ${ProviderHubMetadataProviderAuthorization},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderType]
    # .
    ${ProviderType},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${ProviderVersion},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState]
    # .
    ${ProvisioningState},

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
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[]]
    # .
    # To construct, see NOTES section for THIRDPARTYPROVIDERAUTHORIZATIONAUTHORIZATIONSZZZ properties and create a hash table.
    ${ThirdPartyProviderAuthorizationAuthorizationszzz},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${ThirdPartyProviderAuthorizationManagedByTenantId},

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
            Update = 'ProviderHub.private\Set-AzProviderHubProviderRegistration_Update';
            UpdateExpanded = 'ProviderHub.private\Set-AzProviderHubProviderRegistration_UpdateExpanded';
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
