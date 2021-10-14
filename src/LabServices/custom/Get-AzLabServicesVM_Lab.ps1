function Get-AzLabServicesVM_Lab {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachine])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.Lab]
        ${Lab},
   
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [System.String]
        ${Name},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}
    )
    
    process {

        $PSBoundParameters = $Lab.BindResourceParameters($PSBoundParameters)
        $PSBoundParameters.Remove("Lab") > $null

        if ($PSBoundParameters.ContainsKey('Name')) {
            return Az.LabServices.private\Get-AzLabServicesVM_Get @PSBoundParameters
        } else {
            return Az.LabServices.private\Get-AzLabServicesVM_List @PSBoundParameters
        }
    }
    
    }
    