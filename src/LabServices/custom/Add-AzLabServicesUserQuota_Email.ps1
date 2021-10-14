function Add-AzLabServicesUserQuota_Email {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IUser])]    
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
        # The name of the user that uniqely identifies it within containing lab.
        # Used in resource URIs.
        ${Email},
   
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
        [System.TimeSpan]
        # The amount of usage quota time the user gets in addition to the current user quota.
        ${UsageQuotaToAddToExisting},
    
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
        $addQuota = $PSBoundParameters.UsageQuotaToAddToExisting
        $PSBoundParameters.Remove('UsageQuotaToAddToExisting') > $null
        $PSBoundParameters.Add("Filter","Properties/Email eq '$currentEmail'")
        # Get user to get existing quota
        $user = Get-AzLabServicesUser @PSBoundParameters
        if ($user) {

            $PSBoundParameters.Remove('Filter') > $null
            $PSBoundParameters.Add('UserName', $user.Name)
            $user.AdditionalUsageQuota += $addQuota
            $PSBoundParameters.Add('AdditionalUsageQuota', $($user.AdditionalUsageQuota))
            $PSBoundParameters.Remove('User') > $null
            return Az.LabServices\Update-AzLabServicesUser @PSBoundParameters
        } else {
            Write-Error "Unable to find user with email: $currentEmail"
        }
    }
    
}
    