<#
.SYNOPSIS
    Enables an Azure Data Transfer pipeline.

.DESCRIPTION
    The Enable-AzDataTransferPipeline cmdlet enables a previously disabled Azure Data Transfer pipeline.
    This allows new connections and flows to be created within the pipeline.

.PARAMETER PipelineName
    The name of the pipeline to enable.

.PARAMETER ResourceGroupName
    The name of the resource group containing the pipeline.

.PARAMETER SubscriptionId
    The ID of the target subscription. If not specified, uses the current context subscription.

.PARAMETER Justification
    Business justification for enabling the pipeline.

.PARAMETER DefaultProfile
    The credentials, account, tenant, and subscription used for communication with Azure.

.PARAMETER AsJob
    Run the command as a job.

.PARAMETER NoWait
    Run the command asynchronously.

.EXAMPLE
    Enable-AzDataTransferPipeline -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01"
    
    Enables the pipeline named "Pipeline01" in the "ResourceGroup01" resource group.

.EXAMPLE
    Enable-AzDataTransferPipeline -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -Justification "Re-enabling after maintenance"
    
    Enables the pipeline with a business justification.
#>
function Enable-AzDataTransferPipeline {
    [OutputType([ADT.Models.IPipeline])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory=$true, HelpMessage="The name of the pipeline to enable")]
        [ValidateNotNullOrEmpty()]
        [string]$PipelineName,
        
        [Parameter(Mandatory=$true, HelpMessage="The name of the resource group")]
        [ValidateNotNullOrEmpty()]
        [string]$ResourceGroupName,
        
        [Parameter(HelpMessage="The ID of the target subscription")]
        [string]$SubscriptionId,
        
        [Parameter(HelpMessage="Business justification for enabling the pipeline")]
        [string]$Justification,
        
        [Parameter(HelpMessage="The credentials, account, tenant, and subscription used for communication with Azure")]
        [PSObject]$DefaultProfile,
        
        [Parameter(HelpMessage="Run the command as a job")]
        [switch]$AsJob,
        
        [Parameter(HelpMessage="Run the command asynchronously")]
        [switch]$NoWait
    )
    
    begin {
        Write-Verbose "Enabling pipeline: $PipelineName"
    }
    
    process {
        if ($PSCmdlet.ShouldProcess($PipelineName, "Enable Azure Data Transfer Pipeline")) {
            try {
                # Prepare parameters for the underlying command
                $invokeParams = @{
                    PipelineName = $PipelineName
                    ResourceGroupName = $ResourceGroupName
                    ActionType = "AllowUpdates"
                    Target = @()
                    TargetType = "Pipeline"
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
