function Get-AzLabServicesSchedule_LabObject {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ISchedule])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter(Mandatory)]
        [System.String]
        ${ResourceId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}
    )
    
    process {

        $PSBoundParameters = & $PSScriptRoot\Utilities\HandleScheduleResourceId.ps1 -ResourceId $ResourceId

        if ($PSBoundParameters) {
            return Az.LabServices\Get-AzLabServicesSchedule @PSBoundParameters
        } else {
            Write-Error -Message "Error: Invalid Schedule Resource Id." -ErrorAction Stop
        }

    }
    
    }
    