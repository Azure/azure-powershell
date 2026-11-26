param (
    [Parameter(Mandatory, Position = 0)]
    [ValidateNotNullOrEmpty()]
    [guid] $SubscriptionId,

    [Parameter(Mandatory, Position = 1)]
    [ValidateNotNullOrEmpty()]
    [guid] $TenantId,

    [Parameter(Mandatory, Position = 2)]
    [ValidateNotNullOrEmpty()]
    [guid] $ServicePrincipalId,

    [Parameter(Mandatory, Position = 3)]
    [ValidateNotNullOrEmpty()]
    [string] $ServicePrincipalSecret
)

$PreErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop"

$servicePrincipalSecureSecret = ConvertTo-SecureString -String $ServicePrincipalSecret -AsPlainText -Force
$servicePrincipalCredential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $ServicePrincipalId, $servicePrincipalSecureSecret
try {
    Connect-AzAccount -SubscriptionId $SubscriptionId -TenantId $TenantId -Credential $servicePrincipalCredential -ServicePrincipal
}
catch {
    # TenantSetupDocUrl is an optional pipeline variable pointing at the internal test tenant setup guide.
    $reason = ($_.Exception.Message -replace '\s+', ' ').Trim()
    $message = "Failed to sign in to test tenant '$TenantId' as service principal '$ServicePrincipalId' (subscription '$SubscriptionId'). The test tenant may have been reset, or the service principal, secret or pipeline variables may be out of date. Error: $reason"
    if ($env:TENANTSETUPDOCURL) {
        $message += " Read this to fix: $env:TENANTSETUPDOCURL"
    }
    Write-Host "##vso[task.logissue type=error]$message"
    throw
}

$ErrorActionPreference = $PreErrorActionPreference
