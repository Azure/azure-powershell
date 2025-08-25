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
    One or more flow type names to enable (e.g., "FlowType01", "FlowType02").

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
    Enable-AzDataTransferFlowType -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowType "FlowType01"
    
    Enables the "FlowType01" flow type.

.EXAMPLE
    Enable-AzDataTransferFlowType -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowType @("FlowType01", "FlowType02")
    
    Enables both "FlowType01" and "FlowType02" flow types.

.EXAMPLE
    Enable-AzDataTransferFlowType -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowType "FlowType01" -Justification "Re-enabling after security review"
    
    Enables a flow type with a business justification.
#>
function Enable-AzDataTransferFlowType {
    [OutputType([ADT.Models.IPipeline])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
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
