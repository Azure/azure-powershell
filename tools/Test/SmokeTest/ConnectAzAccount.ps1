[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $true)]
    $pwd,
    
    [string]
    [Parameter(Mandatory = $true)]
    $servicePrincipal,

    [string]
    [Parameter(Mandatory = $true)]
    $tenantId
)

Write-Host "Connecting Az.Account..."
$secret = ConvertTo-SecureString -String $pwd -AsPlainText -Force
$credential = New-Object -TypeName System.Management.Automation.PSCredential($servicePrincipal, $secret)
Connect-AzAccount -ServicePrincipal -Credential $credential -Tenant $tenantId
Set-AzContext -Subscription "Azure SDK Powershell Test"
Enable-AzureRmAlias