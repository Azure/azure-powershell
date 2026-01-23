<#
.SYNOPSIS
Creates a ChangeRecord with a simplified -Targets parameter.

.DESCRIPTION
This is a custom cmdlet that provides an easier way to create ChangeRecords 
using a -Targets array instead of the individual ChangeDefinition* parameters.

The -Targets parameter automatically sets:
- ChangeDefinitionKind = "Targets"
- ChangeDefinitionName = "TargetSelection" (or custom name via -TargetName)
- ChangeDefinitionDetail = { targets: [...] }

.PARAMETER Targets
An array of hashtables, each containing target selection criteria. Common keys include:
- resourceType: The Azure resource type (e.g., "Microsoft.Compute/virtualMachines")
- subscriptions: Array of subscription IDs
- resourceGroups: Array of resource group names
- regions: Array of Azure regions

.PARAMETER TargetName
Optional name for the target definition. Defaults to "TargetSelection".

.EXAMPLE
New-AzChangeSafetyChangeRecord -Name "mychange" -Targets @{
    resourceType = "Microsoft.Compute/virtualMachines"
    subscriptions = @("/subscriptions/12345678-1234-1234-1234-123456789012")
    regions = @("eastus", "westus")
}

Creates a change record with a single target for VMs.

.EXAMPLE
New-AzChangeSafetyChangeRecord -Name "mychange" -Targets @(
    @{
        resourceType = "Microsoft.Compute/virtualMachines"
        regions = @("eastus")
    },
    @{
        resourceType = "Microsoft.Storage/storageAccounts"
        regions = @("westus")
    }
)

Creates a change record with multiple targets (VMs and Storage Accounts).

.EXAMPLE
New-AzChangeSafetyChangeRecord -Name "mychange" -Targets @{
    resourceType = "Microsoft.Web/sites"
    resourceGroups = @("rg-prod-webapp")
} -TargetName "ProductionWebApps"

Creates a change record targeting web apps with a custom target name.
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

        [Parameter(Mandatory, HelpMessage = "Target selection criteria. Can be a single hashtable or an array of hashtables. Keys include: resourceType, subscriptions, resourceGroups, regions.")]
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
        if ($PSBoundParameters.ContainsKey('AnticipatedStartTime')) { $params['AnticipatedStartTime'] = $AnticipatedStartTime }
        if ($PSBoundParameters.ContainsKey('AnticipatedEndTime')) { $params['AnticipatedEndTime'] = $AnticipatedEndTime }
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
        
        # Wrap targets in the expected structure: { targets: [...] }
        # If a single hashtable is passed, wrap it in an array
        $targetArray = if ($Targets -is [hashtable]) { @($Targets) } else { $Targets }
        $params['ChangeDefinitionDetail'] = @{ targets = $targetArray }

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
