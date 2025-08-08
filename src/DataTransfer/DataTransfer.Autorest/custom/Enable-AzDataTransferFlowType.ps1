<#
.SYNOPSIS
    Enables Azure Data Transfer flow types.

.DESCRIPTION
    The Enable-AzDataTransferFlowType cmdlet enables previously disabled flow types within an Azure Data Transfer pipeline.
    This allows new flows of the specified types to be created and existing flows of those types to resume operations.

.PARAMETER PipelineName
    The name of the pipeline containing the flow types.

.PARAMETER ResourceGroupName
    The name of the resource group containing the pipeline.

.PARAMETER FlowType
    One or more flow type names to enable (e.g., "Mission", "Complex").

.PARAMETER SubscriptionId
    The ID of the target subscription. If not specified, uses the current context subscription.

.PARAMETER Justification
    Business justification for enabling the flow types.

.PARAMETER DefaultProfile
    The credentials, account, tenant, and subscription used for communication with Azure.

.PARAMETER AsJob
    Run the command as a job.

.PARAMETER NoWait
    Run the command asynchronously.

.EXAMPLE
    Enable-AzDataTransferFlowType -PipelineName "corp" -ResourceGroupName "rpaas-rg" -FlowType "Mission"
    
    Enables the "Mission" flow type.

.EXAMPLE
    Enable-AzDataTransferFlowType -PipelineName "corp" -ResourceGroupName "rpaas-rg" -FlowType @("Mission", "Complex")
    
    Enables both "Mission" and "Complex" flow types.

.EXAMPLE
    Enable-AzDataTransferFlowType -PipelineName "corp" -ResourceGroupName "rpaas-rg" -FlowType "Mission" -Justification "Re-enabling after security review"
    
    Enables a flow type with a business justification.

.NOTES
    This is a wrapper around Invoke-AzDataTransferExecutePipelineAction with ActionType "AllowUpdates" and TargetType "FlowType".
#>
function Enable-AzDataTransferFlowType {
    [CmdletBinding(SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory=$true, HelpMessage="The name of the pipeline containing the flow types")]
        [ValidateNotNullOrEmpty()]
        [string]$PipelineName,
        
        [Parameter(Mandatory=$true, HelpMessage="The name of the resource group")]
        [ValidateNotNullOrEmpty()]
        [string]$ResourceGroupName,
        
        [Parameter(Mandatory=$true, HelpMessage="One or more flow type names to enable")]
        [ValidateNotNullOrEmpty()]
        [string[]]$FlowType,
        
        [Parameter(HelpMessage="The ID of the target subscription")]
        [string]$SubscriptionId,
        
        [Parameter(HelpMessage="Business justification for enabling the flow types")]
        [string]$Justification,
        
        [Parameter(HelpMessage="The credentials, account, tenant, and subscription used for communication with Azure")]
        [PSObject]$DefaultProfile,
        
        [Parameter(HelpMessage="Run the command as a job")]
        [switch]$AsJob,
        
        [Parameter(HelpMessage="Run the command asynchronously")]
        [switch]$NoWait
    )
    
    begin {
        Write-Verbose "Enabling flow type(s): $($FlowType -join ', ') in pipeline: $PipelineName"
        
        # Validate flow type names (basic validation - actual valid values depend on the service)
        foreach ($type in $FlowType) {
            if ([string]::IsNullOrWhiteSpace($type)) {
                throw "Flow type cannot be null or empty"
            }
        }
    }
    
    process {
        $flowTypeList = $FlowType -join ", "
        if ($PSCmdlet.ShouldProcess($flowTypeList, "Enable Azure Data Transfer Flow Type(s)")) {
            try {
                # Prepare parameters for the underlying command
                $invokeParams = @{
                    PipelineName = $PipelineName
                    ResourceGroupName = $ResourceGroupName
                    ActionType = "AllowUpdates"
                    Target = $FlowType
                    TargetType = "FlowType"
                }
                
                # Add optional parameters if provided
                if ($SubscriptionId) { $invokeParams.SubscriptionId = $SubscriptionId }
                if ($Justification) { $invokeParams.Justification = $Justification }
                if ($DefaultProfile) { $invokeParams.DefaultProfile = $DefaultProfile }
                if ($AsJob) { $invokeParams.AsJob = $AsJob }
                if ($NoWait) { $invokeParams.NoWait = $NoWait }
                
                # Call the underlying command
                Invoke-AzDataTransferExecutePipelineAction @invokeParams
            }
            catch {
                $PSCmdlet.ThrowTerminatingError($_)
            }
        }
    }
}
