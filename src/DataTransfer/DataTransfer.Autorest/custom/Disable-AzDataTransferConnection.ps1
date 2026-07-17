<#
.SYNOPSIS
    Disables Azure Data Transfer connections.

.DESCRIPTION
    The Disable-AzDataTransferConnection cmdlet disables Azure Data Transfer connections.
    This prevents data transfer operations on the connections and disables all flows within them.

.PARAMETER PipelineName
    The name of the pipeline containing the connections.

.PARAMETER ResourceGroupName
    The name of the resource group containing the pipeline.

.PARAMETER ConnectionId
    One or more connection resource IDs to disable. These should be full ARM resource IDs.

.PARAMETER SubscriptionId
    The ID of the target subscription. If not specified, uses the current context subscription.

.PARAMETER Justification
    Business justification for disabling the connections.

.PARAMETER DefaultProfile
    The credentials, account, tenant, and subscription used for communication with Azure.

.PARAMETER AsJob
    Run the command as a job.

.PARAMETER NoWait
    Run the command asynchronously.

.EXAMPLE
    Disable-AzDataTransferConnection -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -ConnectionId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01"
    
    Disables a single connection.

.EXAMPLE
    $connectionIds = @(
        "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01",
        "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection02"
    )
    Disable-AzDataTransferConnection -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -ConnectionId $connectionIds
    
    Disables multiple connections.

.EXAMPLE
    Disable-AzDataTransferConnection -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -ConnectionId $connectionId -Justification "Security incident response"
    
    Disables a connection with a business justification.

.EXAMPLE
    Disable-AzDataTransferConnection -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -ConnectionId $connectionId -WhatIf
    
    Shows what would happen if the connection was disabled without actually disabling it.

.NOTES
    This action will also disable all flows within the specified connections.
#>
function Disable-AzDataTransferConnection {
    [OutputType([ADT.Models.IPipeline])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='High')]
    param(
        [Parameter(Mandatory=$true, HelpMessage="The name of the pipeline containing the connections")]
        [ValidateNotNullOrEmpty()]
        [string]$PipelineName,
        
        [Parameter(Mandatory=$true, HelpMessage="The name of the resource group")]
        [ValidateNotNullOrEmpty()]
        [string]$ResourceGroupName,
        
        [Parameter(Mandatory=$true, HelpMessage="One or more connection resource IDs to disable")]
        [ValidateNotNullOrEmpty()]
        [string[]]$ConnectionId,
        
        [Parameter(HelpMessage="The ID of the target subscription")]
        [string]$SubscriptionId,
        
        [Parameter(HelpMessage="Business justification for disabling the connections")]
        [string]$Justification,
        
        [Parameter(HelpMessage="The credentials, account, tenant, and subscription used for communication with Azure")]
        [PSObject]$DefaultProfile,
        
        [Parameter(HelpMessage="Run the command as a job")]
        [switch]$AsJob,
        
        [Parameter(HelpMessage="Run the command asynchronously")]
        [switch]$NoWait
    )
    
    begin {
        Write-Verbose "Disabling $($ConnectionId.Count) connection(s) in pipeline: $PipelineName"
        Write-Warning "This action will disable the specified connections and all flows within them."
    }
    
    process {
        $connectionList = $ConnectionId -join ", "
        if ($PSCmdlet.ShouldProcess($connectionList, "Disable Azure Data Transfer Connection(s)")) {
            try {
                # Prepare parameters for the underlying command
                $invokeParams = @{
                    PipelineName = $PipelineName
                    ResourceGroupName = $ResourceGroupName
                    ActionType = "ForceDisable"
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
