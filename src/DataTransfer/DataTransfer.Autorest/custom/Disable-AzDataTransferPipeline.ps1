<#
.SYNOPSIS
    Disables an Azure Data Transfer pipeline.

.DESCRIPTION
    The Disable-AzDataTransferPipeline cmdlet disables an Azure Data Transfer pipeline.
    This prevents new connections and flows from being created within the pipeline and disables existing resources.

.PARAMETER PipelineName
    The name of the pipeline to disable.

.PARAMETER ResourceGroupName
    The name of the resource group containing the pipeline.

.PARAMETER SubscriptionId
    The ID of the target subscription. If not specified, uses the current context subscription.

.PARAMETER Justification
    Business justification for disabling the pipeline.

.PARAMETER DefaultProfile
    The credentials, account, tenant, and subscription used for communication with Azure.

.PARAMETER AsJob
    Run the command as a job.

.PARAMETER NoWait
    Run the command asynchronously.

.EXAMPLE
    Disable-AzDataTransferPipeline -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01"
    
    Disables the pipeline named "Pipeline01" in the "ResourceGroup01" resource group.

.EXAMPLE
    Disable-AzDataTransferPipeline -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -Justification "Emergency shutdown for security review"
    
    Disables the pipeline with a business justification.

.EXAMPLE
    Disable-AzDataTransferPipeline -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -WhatIf
    
    Shows what would happen if the pipeline was disabled without actually disabling it.
#>
function Disable-AzDataTransferPipeline {
    [OutputType([ADT.Models.IPipeline])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='High')]
    param(
        [Parameter(Mandatory=$true, HelpMessage="The name of the pipeline to disable")]
        [ValidateNotNullOrEmpty()]
        [string]$PipelineName,
        
        [Parameter(Mandatory=$true, HelpMessage="The name of the resource group")]
        [ValidateNotNullOrEmpty()]
        [string]$ResourceGroupName,
        
        [Parameter(HelpMessage="The ID of the target subscription")]
        [string]$SubscriptionId,
        
        [Parameter(HelpMessage="Business justification for disabling the pipeline")]
        [string]$Justification,
        
        [Parameter(HelpMessage="The credentials, account, tenant, and subscription used for communication with Azure")]
        [PSObject]$DefaultProfile,
        
        [Parameter(HelpMessage="Run the command as a job")]
        [switch]$AsJob,
        
        [Parameter(HelpMessage="Run the command asynchronously")]
        [switch]$NoWait
    )
    
    begin {
        Write-Verbose "Disabling pipeline: $PipelineName"
        Write-Warning "This action will disable the entire pipeline and all its connections and flows."
    }
    
    process {
        if ($PSCmdlet.ShouldProcess($PipelineName, "Disable Azure Data Transfer Pipeline")) {
            try {
                # Prepare parameters for the underlying command
                $invokeParams = @{
                    PipelineName = $PipelineName
                    ResourceGroupName = $ResourceGroupName
                    ActionType = "ForceDisable"
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
