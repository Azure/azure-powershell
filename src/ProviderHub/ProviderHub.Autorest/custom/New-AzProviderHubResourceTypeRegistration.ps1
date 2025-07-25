
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
New-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -RoutingType "Default" -Regionality "Regional" -Endpoint @{ApiVersion = "2021-01-01-preview"; Location = "West US 2", "East US 2 EUAP"; RequiredFeature = "Microsoft.Contoso/SampleApp" } -SwaggerSpecification @{ApiVersion = "2021-01-01-preview"; SwaggerSpecFolderUri = "https://github.com/Azure/azure-rest-api-specs-pr/blob/RPSaaSMaster/specification/rpsaas/resource-manager/Microsoft.Contoso/" } -EnableAsyncOperation
.Example
New-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -RoutingType "Default" -Regionality "Global" -Endpoint @{ApiVersion = "2021-01-01-preview"; Location = ""; RequiredFeature = "Microsoft.Contoso/SampleApp" } -SwaggerSpecification @{ApiVersion = "2021-01-01-preview"; SwaggerSpecFolderUri = "https://github.com/Azure/azure-rest-api-specs-pr/blob/RPSaaSMaster/specification/rpsaas/resource-manager/Microsoft.Contoso/" }

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceTypeRegistration
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

AUTHORIZATIONACTIONMAPPING <IAuthorizationActionMapping[]>: .
  [Desired <String>]:
  [Original <String>]:

ENDPOINT <IResourceTypeEndpoint[]>: .
  [ApiVersion <List<String>>]: 
  [Enabled <Boolean?>]:
  [Extension <List<IResourceTypeExtension>>]: 
    [EndpointUri <String>]:
    [ExtensionCategory <List<String>>]: 
    [Timeout <TimeSpan?>]:
  [FeatureRuleRequiredFeaturesPolicy <String>]:
  [Location <List<String>>]: 
  [RequiredFeature <List<String>>]: 
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
  DetailLevel <String>: 
  Direction <String>: 
  [HiddenPropertyPathHiddenPathsOnRequest <List<String>>]: 
  [HiddenPropertyPathHiddenPathsOnResponse <List<String>>]: 

PROVIDERREGISTRATIONINPUTOBJECT <IProviderHubIdentity>: Identity Parameter
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

SERVICETREEINFO <IServiceTreeInfo[]>: .
  [ComponentId <String>]:
  [ServiceId <String>]:

SUBSCRIPTIONLIFECYCLENOTIFICATIONSPECIFICATIONSUBSCRIPTIONSTATEOVERRIDEACTION <ISubscriptionStateOverrideAction[]>: .
  Action <String>: 
  State <String>: 

SUBSCRIPTIONSTATERULE <ISubscriptionStateRule[]>: .
  [AllowedAction <List<String>>]: 
  [State <String>]: 

SWAGGERSPECIFICATION <ISwaggerSpecification[]>: .
  [ApiVersion <List<String>>]: 
  [SwaggerSpecFolderUri <String>]:

THROTTLINGRULE <IThrottlingRule[]>: .
  Action <String>:
  Metric <List<IThrottlingMetric>>: 
    Limit <Int64>:
    Type <String>: 
    [Interval <TimeSpan?>]:
  [RequiredFeature <List<String>>]: 
.Link
https://learn.microsoft.com/powershell/module/az.providerhub/new-azproviderhubresourcetyperegistration
#>
function New-AzProviderHubResourceTypeRegistration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceTypeRegistration])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
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

    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity]
    # Identity Parameter
    ${ProviderRegistrationInputObject},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${AllowedUnauthorizedAction},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAuthorizationActionMapping[]]
    # .
    # To construct, see NOTES section for AUTHORIZATIONACTIONMAPPING properties and create a hash table.
    ${AuthorizationActionMapping},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${CheckNameAvailabilitySpecificationEnableDefaultValidation},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${DefaultApiVersion},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${DisallowedActionVerb},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${EnableAsyncOperation},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${EnableThirdPartyS2S},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceTypeEndpoint[]]
    # .
    # To construct, see NOTES section for ENDPOINT properties and create a hash table.
    ${Endpoint},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IExtendedLocationOptions[]]
    # .
    # To construct, see NOTES section for EXTENDEDLOCATION properties and create a hash table.
    ${ExtendedLocation},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${FeatureRuleRequiredFeaturesPolicy},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${IdentityManagementApplicationId},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "SystemAssigned", "UserAssigned", "Actor", "DelegatedResourceIdentity")]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${IdentityManagementType},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${IsPureProxy},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ILinkedAccessCheck[]]
    # .
    # To construct, see NOTES section for LINKEDACCESSCHECK properties and create a hash table.
    ${LinkedAccessCheck},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ILoggingRule[]]
    # .
    # To construct, see NOTES section for LOGGINGRULE properties and create a hash table.
    ${LoggingRule},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "AddOn", "Bypass", "Store")]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${MarketplaceType},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "Accepted", "Running", "Creating", "Created", "Deleting", "Deleted", "Canceled", "Failed", "Succeeded", "MovingResources", "TransientFailure", "RolloutInProgress")]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [string]
    # .
    ${ProvisioningState},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "Global", "Regional")]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${Regionality},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "SignedUserToken", "ClientGroupMembership", "SignedAuxiliaryTokens", "UnboundedClientGroupMembership")]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${RequestHeaderOptionOptInHeader},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${RequiredFeature},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "DoNotMergeExistingReadOnlyAndSecretProperties", "IncludeInternalMetadata")]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${ResourceCreationBeginRequest},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "DoNotMergeExistingReadOnlyAndSecretProperties", "IncludeInternalMetadata")]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${ResourceCreationBeginResponse},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "CascadeDeleteAll", "CascadeDeleteProxyOnlyChildren")]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${ResourceDeletionPolicy},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${ResourceMovePolicyCrossResourceGroupMoveEnabled},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${ResourceMovePolicyCrossSubscriptionMoveEnabled},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${ResourceMovePolicyValidationRequired},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("Default", "ProxyOnly", "HostBased", "Extension", "Tenant", "Fanout", "LocationBased", "Failover", "CascadeExtension")]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${RoutingType},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IServiceTreeInfo[]]
    # .
    # To construct, see NOTES section for SERVICETREEINFO properties and create a hash table.
    ${ServiceTreeInfo},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.TimeSpan]
    # .
    ${SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISubscriptionStateOverrideAction[]]
    # .
    # To construct, see NOTES section for SUBSCRIPTIONLIFECYCLENOTIFICATIONSPECIFICATIONSUBSCRIPTIONSTATEOVERRIDEACTION properties and create a hash table.
    ${SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISubscriptionStateRule[]]
    # .
    # To construct, see NOTES section for SUBSCRIPTIONSTATERULE properties and create a hash table.
    ${SubscriptionStateRule},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISwaggerSpecification[]]
    # .
    # To construct, see NOTES section for SWAGGERSPECIFICATION properties and create a hash table.
    ${SwaggerSpecification},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("None", "ContinueDeploymentOnFailure", "DefaultValidationOnly")]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${TemplateDeploymentOptionPreflightOption},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${TemplateDeploymentOptionPreflightSupported},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IThrottlingRule[]]
    # .
    # To construct, see NOTES section for THROTTLINGRULE properties and create a hash table.
    ${ThrottlingRule},

    [Parameter(ParameterSetName='CreateViaJsonFilePath', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # Path of Json file supplied to the Create operation
    ${JsonFilePath},

    [Parameter(ParameterSetName='CreateViaJsonString', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # Json string supplied to the Create operation
    ${JsonString},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The DefaultProfile parameter is not functional.
    # Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.
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
        
        $testPlayback = $false
        $PSBoundParameters['HttpPipelinePrepend'] | Foreach-Object { if ($_) { $testPlayback = $testPlayback -or ('Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.PipelineMock' -eq $_.Target.GetType().FullName -and 'Playback' -eq $_.Target.Mode) } }

        $mapping = @{
            CreateExpanded = 'Az.ProviderHub.private\New-AzProviderHubResourceTypeRegistration_CreateExpanded';
            CreateViaIdentityProviderRegistrationExpanded = 'Az.ProviderHub.private\New-AzProviderHubResourceTypeRegistration_CreateViaIdentityProviderRegistrationExpanded';
            CreateViaJsonFilePath = 'Az.ProviderHub.private\New-AzProviderHubResourceTypeRegistration_CreateViaJsonFilePath';
            CreateViaJsonString = 'Az.ProviderHub.private\New-AzProviderHubResourceTypeRegistration_CreateViaJsonString';
        }
        if (('CreateExpanded', 'CreateViaJsonFilePath', 'CreateViaJsonString') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId') ) {
            if ($testPlayback) {
                $PSBoundParameters['SubscriptionId'] = . (Join-Path $PSScriptRoot '..' 'utils' 'Get-SubscriptionIdTestSafe.ps1')
            } else {
              $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
            }
        }
        if ($PSBoundParameters.ContainsKey('ResourceType')) {
          $resourceTypePath = $PSBoundParameters['ResourceType'] -Split "/" -Join "/resourcetyperegistrations/"
          $PSBoundParameters['ResourceType'] = $resourceTypePath
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        if ($wrappedCmd -eq $null) {
            $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Function)
        }
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
