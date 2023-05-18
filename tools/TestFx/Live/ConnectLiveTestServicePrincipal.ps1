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
Connect-AzAccount -SubscriptionId $SubscriptionId -TenantId $TenantId -Credential $servicePrincipalCredential -ServicePrincipal

$ErrorActionPreference = $PreErrorActionPreference
