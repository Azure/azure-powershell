[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $true, Position = 0)]
    $pwd,
    
    [string]
    [Parameter(Mandatory = $true, Position = 1)]
    $servicePrincipal,

    [string]
    [Parameter(Mandatory = $true, Position = 2)]
    $tenantId,

    [string]
    [Parameter(Mandatory = $true, Position = 3)]
    $subscriptionId
)

Write-Host "Connecting Az.Account..."
$secret = ConvertTo-SecureString -String $pwd -AsPlainText -Force
$credential = New-Object -TypeName System.Management.Automation.PSCredential($servicePrincipal, $secret)
try {
    Connect-AzAccount -ServicePrincipal -Credential $credential -Tenant $tenantId -Subscription $subscriptionId -ErrorAction Stop
}
catch {
    # TenantSetupDocUrl is an optional pipeline variable pointing at the internal test tenant setup guide.
    $reason = ($_.Exception.Message -replace '\s+', ' ').Trim()
    $message = "Failed to sign in to test tenant '$tenantId' as service principal '$servicePrincipal' (subscription '$subscriptionId'). The test tenant may have been reset, or the service principal, secret or pipeline variables may be out of date. Error: $reason"
    if ($env:TENANTSETUPDOCURL) {
        $message += " Read this to fix: $env:TENANTSETUPDOCURL"
    }
    Write-Host "##vso[task.logissue type=error]$message"
    throw
}