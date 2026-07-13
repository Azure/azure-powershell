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
- resourceId: ARM resource ID for a targeted resource
- subscriptionId: Subscription ID for a subscription-level target
- httpMethod: Optional ARM method for the target operation (GET, HEAD, PUT, PATCH, POST, DELETE)

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
        [Parameter(Mandatory = $true, HelpMessage = "The name of the ChangeRecord resource.")]
        [Alias('ChangeRecordName')]
        [string]
        $Name,

        [Parameter(HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [string]
        $ResourceGroupName,

        [Parameter(HelpMessage = "The ID of the target subscription. The value must be an UUID.")]
        [string]
        $SubscriptionId,

        [Parameter(Mandatory = $true, HelpMessage = "Target selection criteria. Can be a single hashtable or an array of hashtables. Keys include: resourceId, subscriptionId, httpMethod.")]
        [object[]]
        $Targets,

        [Parameter(HelpMessage = "Name for the target definition. Defaults to 'TargetSelection'.")]
        [string]
        $TargetName = "TargetSelection",

        [Parameter(Mandatory = $true, HelpMessage = "Describes the nature of the change.")]
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

        [Parameter(Mandatory = $true, HelpMessage = "Describes the type of the rollout used for the change.")]
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
        Assert-AzChangeSafetyChangeRecordName -Name $Name

        if (-not $PSBoundParameters.ContainsKey('ChangeType')) {
            throw "Parameter 'ChangeType' is required for New-AzChangeSafetyChangeRecord when using -Targets."
        }
        Assert-AzChangeSafetyChangeRecordEnumValue -ParameterName 'ChangeType' -Value $ChangeType -AllowedValues @('AppDeployment', 'Config', 'PolicyDeployment', 'ManualTouch')

        if (-not $PSBoundParameters.ContainsKey('RolloutType')) {
            throw "Parameter 'RolloutType' is required for New-AzChangeSafetyChangeRecord when using -Targets."
        }
        Assert-AzChangeSafetyChangeRecordEnumValue -ParameterName 'RolloutType' -Value $RolloutType -AllowedValues @('Normal', 'Hotfix', 'Emergency')

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
        Assert-AzChangeSafetyChangeRecordWindow -BoundParameters $PSBoundParameters -AnticipatedStartTime $params['AnticipatedStartTime'] -AnticipatedEndTime $params['AnticipatedEndTime']
        if ($PSBoundParameters.ContainsKey('OrchestrationTool')) { $params['OrchestrationTool'] = $OrchestrationTool }
        if ($PSBoundParameters.ContainsKey('ReleaseLabel')) { $params['ReleaseLabel'] = $ReleaseLabel }
        if ($PSBoundParameters.ContainsKey('Comment')) { $params['Comment'] = $Comment }
        if ($PSBoundParameters.ContainsKey('StageMapResourceId')) { $params['StageMapResourceId'] = $StageMapResourceId }
        if ($PSBoundParameters.ContainsKey('StageMapParameter')) { $params['StageMapParameter'] = $StageMapParameter }
        if ($PSBoundParameters.ContainsKey('Parameter')) { $params['Parameter'] = $Parameter }
        if ($PSBoundParameters.ContainsKey('Link')) { $params['Link'] = $Link }
        if ($PSBoundParameters.ContainsKey('AdditionalData')) { $params['AdditionalData'] = $AdditionalData }
        
        # Set required properties with defaults
        $params['ChangeType'] = $ChangeType
        $params['RolloutType'] = $RolloutType
        
        # Set ChangeDefinition parameters based on -Targets
        $params['ChangeDefinitionKind'] = 'Targets'
        $params['ChangeDefinitionName'] = $TargetName

        # Wrap targets in the expected structure: { targets: [...] }
        # Use a typed list so that even a single target is serialized as a JSON
        # array. A bare object[] with one element gets unwrapped to a scalar
        # during the IAny (free-form) conversion, which makes the service reject
        # the payload ("ChangeDefinition ... should have 'targets'").
        $targetList = ConvertTo-AzChangeSafetyTargetList -Targets $Targets
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
