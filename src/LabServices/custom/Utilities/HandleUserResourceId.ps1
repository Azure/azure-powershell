#This script uses regex to confirm lab plan resource Id
[Microsoft.Azure.PowerShell.Cmdlets.LabServices.DoNotExportAttribute()]
param(
    [Parameter()]
    [System.String]
    $ResourceId
)

& $PSScriptRoot\VerificationRegex.ps1

if ($ResourceId -match $userRegex){
    return @{
        "SubscriptionId" = $($Matches['subscriptionId'])
        "ResourceGroupName" = $($Matches['resourceGroupName'])
        "LabName" = $($Matches['labName'])
        "UserName" = $($Matches['UserName'])
    }
} else {
    #Can't throw or error build will fail.
  return $null
}

