<#
.SYNOPSIS
Updates a ChangeRecord with a simplified -Targets parameter.

.DESCRIPTION
This is a custom cmdlet that provides an easier way to update ChangeRecords 
using a -Targets array instead of the individual ChangeDefinition* parameters.
Accepts one or more target definitions.

.PARAMETER Targets
An array of hashtables, each containing target selection criteria. Common keys include:
- resourceType: The Azure resource type (e.g., "Microsoft.Compute/virtualMachines")
- subscriptions: Array of subscription IDs
- resourceGroups: Array of resource group names
- regions: Array of Azure regions

.PARAMETER TargetName
Optional name for the target definition.

.EXAMPLE
Update-AzChangeSafetyChangeRecord -Name "mychange" -Targets @{
    resourceType = "Microsoft.Compute/virtualMachines"
    regions = @("eastus", "westus", "centralus")
}

Updates an existing change record with new target regions (single target).

.EXAMPLE
Update-AzChangeSafetyChangeRecord -Name "mychange" -Targets @(
    @{
        resourceType = "Microsoft.Compute/virtualMachines"
        regions = @("eastus", "westus")
    },
    @{
        resourceType = "Microsoft.Storage/storageAccounts"
        regions = @("eastus")
    }
)

Updates an existing change record with multiple targets.
#>
function Update-AzChangeSafetyChangeRecord_Targets {
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

        [Parameter(Mandatory, HelpMessage = "One or more target selection criteria as hashtables.")]
        [object[]]
        $Targets,

        [Parameter(HelpMessage = "Name for the target definition.")]
        [string]
        $TargetName,

        [Parameter(HelpMessage = "Describes the nature of the change.")]
        [string]
        $ChangeType,

        [Parameter(HelpMessage = "Brief description about the change.")]
        [string]
        $Description,

        [Parameter(HelpMessage = "Expected start time when the change execution should begin.")]
        [datetime]
        $AnticipatedStartTime,

        [Parameter(HelpMessage = "Expected completion time when the change should be finished.")]
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

        [Parameter(HelpMessage = "Comments about the update.")]
        [string]
        $Comment,

        [Parameter(HelpMessage = "ARM resource ID for the nested stagemap resource.")]
        [string]
        $StageMapResourceId,

        [Parameter(HelpMessage = "Key value pairs of parameter names & their values for the stageMap.")]
        [hashtable]
        $StageMapParameter,

        [Parameter(HelpMessage = "Schema of parameters for each stageProgression.")]
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
        $params = @{}
        
        # Copy common parameters
        if ($PSBoundParameters.ContainsKey('Name')) { $params['Name'] = $Name }
        if ($PSBoundParameters.ContainsKey('ResourceGroupName')) { $params['ResourceGroupName'] = $ResourceGroupName }
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) { $params['SubscriptionId'] = $SubscriptionId }
        if ($PSBoundParameters.ContainsKey('ChangeType')) { $params['ChangeType'] = $ChangeType }
        if ($PSBoundParameters.ContainsKey('Description')) { $params['Description'] = $Description }
        if ($PSBoundParameters.ContainsKey('AnticipatedStartTime')) { $params['AnticipatedStartTime'] = $AnticipatedStartTime }
        if ($PSBoundParameters.ContainsKey('AnticipatedEndTime')) { $params['AnticipatedEndTime'] = $AnticipatedEndTime }
        if ($PSBoundParameters.ContainsKey('RolloutType')) { $params['RolloutType'] = $RolloutType }
        if ($PSBoundParameters.ContainsKey('OrchestrationTool')) { $params['OrchestrationTool'] = $OrchestrationTool }
        if ($PSBoundParameters.ContainsKey('ReleaseLabel')) { $params['ReleaseLabel'] = $ReleaseLabel }
        if ($PSBoundParameters.ContainsKey('Comment')) { $params['Comment'] = $Comment }
        if ($PSBoundParameters.ContainsKey('StageMapResourceId')) { $params['StageMapResourceId'] = $StageMapResourceId }
        if ($PSBoundParameters.ContainsKey('StageMapParameter')) { $params['StageMapParameter'] = $StageMapParameter }
        if ($PSBoundParameters.ContainsKey('Parameter')) { $params['Parameter'] = $Parameter }
        if ($PSBoundParameters.ContainsKey('Link')) { $params['Link'] = $Link }
        if ($PSBoundParameters.ContainsKey('AdditionalData')) { $params['AdditionalData'] = $AdditionalData }
        
        # Set ChangeDefinition parameters based on -Targets
        $params['ChangeDefinitionKind'] = 'Targets'
        # Name is required by the API schema
        if ($PSBoundParameters.ContainsKey('TargetName')) { 
            $params['ChangeDefinitionName'] = $TargetName 
        } else {
            # Default name if not provided - required by API
            $params['ChangeDefinitionName'] = 'TargetDefinition'
        }
        
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
        if ($PSCmdlet.ShouldProcess($Name, "Update ChangeRecord with Targets")) {
            if ($PSBoundParameters.ContainsKey('ResourceGroupName')) {
                # Resource group scoped
                Az.ChangeSafety.private\Update-AzChangeSafetyChangeRecord_UpdateExpanded1 @params
            } else {
                # Subscription scoped
                Az.ChangeSafety.private\Update-AzChangeSafetyChangeRecord_UpdateExpanded @params
            }
        }
    }
}
