<#
.SYNOPSIS
    Enables Azure Data Transfer connections.

.DESCRIPTION
    The Enable-AzDataTransferConnection cmdlet enables previously disabled Azure Data Transfer connections.
    This allows the connections to resume data transfer operations and allows new flows to be created within them.

.PARAMETER PipelineName
    The name of the pipeline containing the connections.

.PARAMETER ResourceGroupName
    The name of the resource group containing the pipeline.

.PARAMETER ConnectionId
    One or more connection resource IDs to enable. These should be full ARM resource IDs.

.PARAMETER SubscriptionId
    The ID of the target subscription. If not specified, uses the current context subscription.

.PARAMETER Justification
    Business justification for enabling the connections.

.PARAMETER DefaultProfile
    The credentials, account, tenant, and subscription used for communication with Azure.

.PARAMETER AsJob
    Run the command as a job.

.PARAMETER NoWait
    Run the command asynchronously.

.EXAMPLE
    Enable-AzDataTransferConnection -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -ConnectionId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01"
    
    Enables a single connection.

.EXAMPLE
    $connectionIds = @(
        "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01",
        "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection02"
    )
    Enable-AzDataTransferConnection -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -ConnectionId $connectionIds
    
    Enables multiple connections.

.EXAMPLE
    Enable-AzDataTransferConnection -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -ConnectionId $connectionId -Justification "Re-enabling after maintenance window"
    
    Enables a connection with a business justification.
#>
function Enable-AzDataTransferConnection {
    [OutputType([ADT.Models.IPipeline])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory=$true, HelpMessage="The name of the pipeline containing the connections")]
        [ValidateNotNullOrEmpty()]
        [string]$PipelineName,
        
        [Parameter(Mandatory=$true, HelpMessage="The name of the resource group")]
        [ValidateNotNullOrEmpty()]
        [string]$ResourceGroupName,
        
        [Parameter(Mandatory=$true, HelpMessage="One or more connection resource IDs to enable")]
        [ValidateNotNullOrEmpty()]
        [string[]]$ConnectionId,
        
        [Parameter(HelpMessage="The ID of the target subscription")]
        [string]$SubscriptionId,
        
        [Parameter(HelpMessage="Business justification for enabling the connections")]
        [string]$Justification,
        
        [Parameter(HelpMessage="The credentials, account, tenant, and subscription used for communication with Azure")]
        [PSObject]$DefaultProfile,
        
        [Parameter(HelpMessage="Run the command as a job")]
        [switch]$AsJob,
        
        [Parameter(HelpMessage="Run the command asynchronously")]
        [switch]$NoWait
    )
    
    begin {
        Write-Verbose "Enabling $($ConnectionId.Count) connection(s) in pipeline: $PipelineName"
    }
    
    process {
        $connectionList = $ConnectionId -join ", "
        if ($PSCmdlet.ShouldProcess($connectionList, "Enable Azure Data Transfer Connection(s)")) {
            try {
                # Prepare parameters for the underlying command
                $invokeParams = @{
                    PipelineName = $PipelineName
                    ResourceGroupName = $ResourceGroupName
                    ActionType = "AllowUpdates"
                    Target = $ConnectionId
                    TargetType = "Connection"
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
