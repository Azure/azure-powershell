function Get-AzLabServicesUserVM_Get {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachine])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(Mandatory)]
        [System.String]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        [System.String]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        ${LabName},
   
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [System.String]
        ${Email},
   
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}
    )
    
    process {

        $currentEmail = $PSBoundParameters.Email
        $PSBoundParameters.Remove('Email') > $null
        $PSBoundParameters.Add('Filter', "Properties/Email eq '$currentEmail'")
        $user = Az.LabServices.private\Get-AzLabServicesUser_List @PSBoundParameters

        if ($user) {
            $PSBoundParameters.Remove('Filter') > $null
            $PSBoundParameters.Add('Filter', "Properties/ClaimedByUserId eq '$($user.Id)'")

            return Az.LabServices.private\Get-AzLabServicesVM_List @PSBoundParameters
        } else {
            Write-Error "No user with Email: $Email"
        }

    }
    
    }
    