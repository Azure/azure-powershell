function Update-AzLabServicesUser_ResourceId {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IUser])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [System.String]
    ${ResourceId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [System.TimeSpan]
    # The amount of usage quota time the user gets in addition to the lab usage quota.
    ${AdditionalUsageQuota},

    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob}
)

process {
    $resourceHash = & $PSScriptRoot\Utilities\HandleUserResourceId.ps1 -ResourceId $ResourceId
    if ($resourceHash) {
        $resourceHash.Keys | ForEach-Object {
            $PSBoundParameters.Add($_, $($resourceHash[$_]))
        }
   
        $PSBoundParameters.Remove("ResourceId") > $null

        return Az.LabServices\Update-AzLabServicesUser @PSBoundParameters
    } else {
        Write-Error -Message "Error: Invalid User Resource Id." -ErrorAction Stop   
    }
}

}
