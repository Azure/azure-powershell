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
if ($PSVersionTable.PSEdition -eq 'Core' -and $IsMacOS)
{
    Write-Host "This is MacOs. Disable context autosaving temporarily."
    Disable-AzContextAutosave -Scope Process
}
$secret = ConvertTo-SecureString -String $pwd -AsPlainText -Force
$credential = New-Object -TypeName System.Management.Automation.PSCredential($servicePrincipal, $secret)
Connect-AzAccount -ServicePrincipal -Credential $credential -Tenant $tenantId -Subscription $subscriptionId