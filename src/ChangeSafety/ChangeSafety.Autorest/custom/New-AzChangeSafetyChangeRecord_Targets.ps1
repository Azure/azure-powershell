<#
.SYNOPSIS
Creates a ChangeRecord with a simplified -Targets parameter.

.DESCRIPTION
This is a custom cmdlet that provides an easier way to create ChangeRecords 
using a -Targets array instead of the individual ChangeDefinition* parameters.

The -Targets parameter automatically sets:
- ChangeDefinitionKind = "Targets"
- ChangeDefinitionName = "TargetSelection" (or custom name via -TargetName)

.PARAMETER Targets
The target or targets that the change is authorized against. Supported keys include:
- resourceId: the ARM resource ID.
- subscriptionId: the subscription ID.
- resourceGroupName: the name of the resource group.
- resourceType: the type of the resource.
- resourceName: the name of the ARM resource.
- httpMethod: the HTTP method.
All supported target keys are optional; include only the fields that apply to the authorized target. Valid httpMethod values are DELETE, GET, HEAD, PATCH, POST, and PUT.

.PARAMETER TargetName
Optional name for the target definition. Defaults to "TargetSelection".

.EXAMPLE
New-AzChangeSafetyChangeRecord -Name "storageAccountCleanup" `
    -ResourceGroupName "rg-changeops" `
    -ChangeType "ManualTouch" `
    -RolloutType "Hotfix" `
    -Description "Delete unused storage account for cleanup" `
    -Targets @{
        subscriptionId = (Get-AzContext).Subscription.Id
    }

Creates a stageless change record authorized against the current subscription.

.EXAMPLE
New-AzChangeSafetyChangeRecord -Name "trafficManagerCleanup" `
    -ResourceGroupName "rg-changeops" `
    -ChangeType "ManualTouch" `
    -RolloutType "Hotfix" `
    -Description "Delete Traffic Manager profile" `
    -Targets @{
        resourceId = "/subscriptions/$((Get-AzContext).Subscription.Id)/resourceGroups/rg-test/providers/Microsoft.Network/trafficManagerProfiles/myProfile"
        httpMethod = "DELETE"
    }

Creates a ChangeRecord for one resource-scoped DELETE operation.

.EXAMPLE
New-AzChangeSafetyChangeRecord -Name "regionalCleanup" `
    -ResourceGroupName "rg-changeops" `
    -ChangeType "ManualTouch" `
    -RolloutType "Normal" `
    -Targets @(
        @{
            subscriptionId = (Get-AzContext).Subscription.Id
            resourceGroupName = "rg-prod-eastus"
        },
        @{
            subscriptionId = (Get-AzContext).Subscription.Id
            resourceGroupName = "rg-prod-westus"
        }
    ) `
    -TargetName "RegionalCleanupTargets"

Creates a ChangeRecord with multiple subscription/resource-group scoped targets and a custom target definition name.
#>
function New-AzChangeSafetyChangeRecord_Targets {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeRecord])]
    [CmdletBinding(PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(Mandatory, HelpMessage = "The name of the ChangeRecord resource.")]
        [Alias('ChangeRecordName')]
        [string]
        $Name,

        [Parameter(HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [string]
        $ResourceGroupName,

        [Parameter(HelpMessage = "The ID of the target subscription. The value must be an UUID.")]
        [string]
        $SubscriptionId,

        [Parameter(Mandatory, HelpMessage = "The target or targets that the change is authorized against. Supported keys include resourceId, subscriptionId, resourceGroupName, resourceType, resourceName, and httpMethod. All supported target keys are optional; include only the fields that apply to the authorized target. Valid httpMethod values are DELETE, GET, HEAD, PATCH, POST, and PUT.")]
        [object[]]
        $Targets,

        [Parameter(HelpMessage = "Name for the target definition. Defaults to 'TargetSelection'.")]
        [string]
        $TargetName = "TargetSelection",

        [Parameter(HelpMessage = "Describes the nature of the change.")]
        [string]
        $ChangeType,

        [Parameter(HelpMessage = "Brief description about the change.")]
        [string]
        $Description,

        [Parameter(HelpMessage = "Expected start time when the change execution should begin, in ISO 8601 format.")]
        [datetime]
        $AnticipatedStartTime,

        [Parameter(HelpMessage = "Expected completion time when the change should be finished, in ISO 8601 format.")]
        [datetime]
        $AnticipatedEndTime,

        [Parameter(HelpMessage = "Describes the type of the rollout used for the change.")]
        [string]
        $RolloutType,

        [Parameter(HelpMessage = "Tool used for deployment orchestration of this change.")]
        [string]
        $OrchestrationTool,

        [Parameter(HelpMessage = "Label for the release associated with this change.")]
        [string]
        $ReleaseLabel,

        [Parameter(HelpMessage = "Comments about the last update to the ChangeRecord resource.")]
        [string]
        $Comment,

        [Parameter(HelpMessage = "ARM resource ID for the nested stagemap resource.")]
        [string]
        $StageMapResourceId,

        [Parameter(HelpMessage = "Key value pairs of parameter names & their values for the stageMap.")]
        [hashtable]
        $StageMapParameter,

        [Parameter(HelpMessage = "Schema of parameters that will be provided for each stageProgression.")]
        [hashtable]
        $Parameter,

        [Parameter(HelpMessage = "Collection of related links for the change.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.ILink[]]
        $Link,

        [Parameter(HelpMessage = "Additional metadata for the change.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IAny]
        $AdditionalData,

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        $DefaultProfile,

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        $Break,

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Runtime.SendAsyncStep[]]
        $HttpPipelineAppend,

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Runtime.SendAsyncStep[]]
        $HttpPipelinePrepend,

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Category('Runtime')]
        [System.Uri]
        $Proxy,

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        $ProxyCredential,

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        $ProxyUseDefaultCredentials
    )

    process {
        # Build parameters for the underlying cmdlet
        $params = @{}
        
        # Copy common parameters
        if ($PSBoundParameters.ContainsKey('Name')) { $params['Name'] = $Name }
        if ($PSBoundParameters.ContainsKey('ResourceGroupName')) { $params['ResourceGroupName'] = $ResourceGroupName }
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) { $params['SubscriptionId'] = $SubscriptionId }
        if ($PSBoundParameters.ContainsKey('Description')) { $params['Description'] = $Description }
        # Default the anticipated change window to [now, now + 8h] when the caller
        # does not specify it. An unbound [datetime] is DateTime.MinValue, which the
        # generated cmdlet serializes as "0001-01-01" and the service treats as an
        # expired change (guarded operations then fail with "The ChangeState is
        # expired"). This mirrors the CLI behavior of an 8-hour default window.
        $anticipatedStart = if ($PSBoundParameters.ContainsKey('AnticipatedStartTime')) { $AnticipatedStartTime } else { (Get-Date).ToUniversalTime() }
        $params['AnticipatedStartTime'] = $anticipatedStart
        $params['AnticipatedEndTime'] = if ($PSBoundParameters.ContainsKey('AnticipatedEndTime')) { $AnticipatedEndTime } else { $anticipatedStart.AddHours(8) }
        if ($PSBoundParameters.ContainsKey('OrchestrationTool')) { $params['OrchestrationTool'] = $OrchestrationTool }
        if ($PSBoundParameters.ContainsKey('ReleaseLabel')) { $params['ReleaseLabel'] = $ReleaseLabel }
        if ($PSBoundParameters.ContainsKey('Comment')) { $params['Comment'] = $Comment }
        if ($PSBoundParameters.ContainsKey('StageMapResourceId')) { $params['StageMapResourceId'] = $StageMapResourceId }
        if ($PSBoundParameters.ContainsKey('StageMapParameter')) { $params['StageMapParameter'] = $StageMapParameter }
        if ($PSBoundParameters.ContainsKey('Parameter')) { $params['Parameter'] = $Parameter }
        if ($PSBoundParameters.ContainsKey('Link')) { $params['Link'] = $Link }
        if ($PSBoundParameters.ContainsKey('AdditionalData')) { $params['AdditionalData'] = $AdditionalData }
        
        # Set required properties with defaults
        # ChangeType is required at the properties level - default to AppDeployment
        $params['ChangeType'] = if ($PSBoundParameters.ContainsKey('ChangeType')) { $ChangeType } else { 'AppDeployment' }
        # RolloutType is required at the properties level - default to Normal
        $params['RolloutType'] = if ($PSBoundParameters.ContainsKey('RolloutType')) { $RolloutType } else { 'Normal' }
        
        # Set ChangeDefinition parameters based on -Targets
        $params['ChangeDefinitionKind'] = 'Targets'
        $params['ChangeDefinitionName'] = $TargetName

        # Use a typed list so that even a single target is preserved as an array
        # during the IAny (free-form) conversion.
        $targetList = [System.Collections.Generic.List[object]]::new()
        foreach ($target in $Targets) { $targetList.Add($target) }
        $params['ChangeDefinitionDetail'] = @{ targets = $targetList }

        # Copy runtime parameters
        if ($PSBoundParameters.ContainsKey('DefaultProfile')) { $params['DefaultProfile'] = $DefaultProfile }
        if ($PSBoundParameters.ContainsKey('Break')) { $params['Break'] = $Break }
        if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) { $params['HttpPipelineAppend'] = $HttpPipelineAppend }
        if ($PSBoundParameters.ContainsKey('HttpPipelinePrepend')) { $params['HttpPipelinePrepend'] = $HttpPipelinePrepend }
        if ($PSBoundParameters.ContainsKey('Proxy')) { $params['Proxy'] = $Proxy }
        if ($PSBoundParameters.ContainsKey('ProxyCredential')) { $params['ProxyCredential'] = $ProxyCredential }
        if ($PSBoundParameters.ContainsKey('ProxyUseDefaultCredentials')) { $params['ProxyUseDefaultCredentials'] = $ProxyUseDefaultCredentials }

        # Call the generated cmdlet - use the correct variant based on scope
        if ($PSCmdlet.ShouldProcess($Name, "Create ChangeRecord with Targets")) {
            if ($PSBoundParameters.ContainsKey('ResourceGroupName')) {
                # Resource group scoped
                Az.ChangeSafety.private\New-AzChangeSafetyChangeRecord_CreateExpanded1 @params
            } else {
                # Subscription scoped
                Az.ChangeSafety.private\New-AzChangeSafetyChangeRecord_CreateExpanded @params
            }
        }
    }
}
