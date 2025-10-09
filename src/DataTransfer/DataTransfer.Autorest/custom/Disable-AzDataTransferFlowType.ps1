<#
.SYNOPSIS
    Disables Azure Data Transfer flow types.

.DESCRIPTION
    The Disable-AzDataTransferFlowType cmdlet disables flow types within an Azure Data Transfer pipeline.
    This prevents new flows of the specified types from being created and disables existing flows of those types.

.PARAMETER PipelineName
    The name of the pipeline containing the flow types.

.PARAMETER ResourceGroupName
    The name of the resource group containing the pipeline.

.PARAMETER FlowType
    One or more flow type names to disable (e.g., "FlowType01", "FlowType02").

.PARAMETER SubscriptionId
    The ID of the target subscription. If not specified, uses the current context subscription.

.PARAMETER Justification
    Business justification for disabling the flow types.

.PARAMETER DefaultProfile
    The credentials, account, tenant, and subscription used for communication with Azure.

.PARAMETER AsJob
    Run the command as a job.

.PARAMETER NoWait
    Run the command asynchronously.

.EXAMPLE
    Disable-AzDataTransferFlowType -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowType "FlowType01"
    
    Disables the "FlowType01" flow type.

.EXAMPLE
    Disable-AzDataTransferFlowType -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowType @("FlowType01", "FlowType02")
    
    Disables both "FlowType01" and "FlowType02" flow types.

.EXAMPLE
    Disable-AzDataTransferFlowType -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowType "FlowType01" -Justification "Security incident response"
    
    Disables a flow type with a business justification.

.EXAMPLE
    Disable-AzDataTransferFlowType -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowType "FlowType01" -WhatIf
    
    Shows what would happen if the flow type was disabled without actually disabling it.

.NOTES
    This action will disable all flows of the specified types across all connections in the pipeline.
#>
function Disable-AzDataTransferFlowType {
    [OutputType([ADT.Models.IPipeline])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='High')]
    param(
        [Parameter(Mandatory=$true, HelpMessage="The name of the pipeline containing the flow types")]
        [ValidateNotNullOrEmpty()]
        [string]$PipelineName,
        
        [Parameter(Mandatory=$true, HelpMessage="The name of the resource group")]
        [ValidateNotNullOrEmpty()]
        [string]$ResourceGroupName,
        
        [Parameter(Mandatory=$true, HelpMessage="One or more flow type names to disable")]
        [ValidateNotNullOrEmpty()]
        [string[]]$FlowType,
        
        [Parameter(HelpMessage="The ID of the target subscription")]
        [string]$SubscriptionId,
        
        [Parameter(HelpMessage="Business justification for disabling the flow types")]
        [string]$Justification,
        
        [Parameter(HelpMessage="The credentials, account, tenant, and subscription used for communication with Azure")]
        [PSObject]$DefaultProfile,
        
        [Parameter(HelpMessage="Run the command as a job")]
        [switch]$AsJob,
        
        [Parameter(HelpMessage="Run the command asynchronously")]
        [switch]$NoWait
    )
    
    begin {
        Write-Verbose "Disabling flow type(s): $($FlowType -join ', ') in pipeline: $PipelineName"
        Write-Warning "This action will disable all flows of the specified types across all connections in the pipeline."
        
        # Validate flow type names (basic validation - actual valid values depend on the service)
        foreach ($type in $FlowType) {
            if ([string]::IsNullOrWhiteSpace($type)) {
                throw "Flow type cannot be null or empty"
            }
        }
    }
    
    process {
        $flowTypeList = $FlowType -join ", "
        if ($PSCmdlet.ShouldProcess($flowTypeList, "Disable Azure Data Transfer Flow Type(s)")) {
            try {
                # Prepare parameters for the underlying command
                $invokeParams = @{
                    PipelineName = $PipelineName
                    ResourceGroupName = $ResourceGroupName
                    ActionType = "ForceDisable"
                    Target = $FlowType
                    TargetType = "FlowType"
                }
                
                # Add optional parameters if provided
                if ($SubscriptionId) { $invokeParams.SubscriptionId = $SubscriptionId }
                if ($Justification) { $invokeParams.Justification = $Justification }
                if ($DefaultProfile) { $invokeParams.DefaultProfile = $DefaultProfile }
                if ($AsJob) { $invokeParams.AsJob = $AsJob }
                if ($NoWait) { $invokeParams.NoWait = $NoWait }
                
                # Call the underlying command and return the result
                $result = Invoke-AzDataTransferExecutePipelineAction @invokeParams
                return $result
            }
            catch {
                $PSCmdlet.ThrowTerminatingError($_)
            }
        }
    }
}
