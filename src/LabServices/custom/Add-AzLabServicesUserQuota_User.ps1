function Add-AzLabServicesUserQuota_User {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IUser])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.User]
        ${User},
   
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
        $PSBoundParameters.Remove('AdditionalUsageQuota') > $null
        $PSBoundParameters = $User.BindResourceParameters($PSBoundParameters)
        $quota = $User.AdditionalUsageQuota + $UsageQuotaToAddToExisting
        $PSBoundParameters.Add('AdditionalUsageQuota', $quota)
        $PSBoundParameters.Remove('User') > $null
        $PSBoundParameters.Remove('UsageQuotaToAddToExisting') > $null
        return Az.LabServices\Update-AzLabServicesUser @PSBoundParameters
    }
    
}
    