[CmdletBinding()]
Param(
[Parameter(Mandatory=$True, Position=0)]
[String]$TenantId,
[Parameter(Mandatory=$True, Position=1)]
[String]$ClientId,
[Parameter(Mandatory=$True, Position=2)]
[String]$ClientSecret,
[Parameter(Mandatory=$True, Position=3)]
[String]$SubscriptionId
)

$secpasswd = ConvertTo-SecureString "$ClientSecret" -AsPlainText -Force
$mycreds = New-Object System.Management.Automation.PSCredential ("$ClientId", $secpasswd)

Login-AzureRmAccount -ServicePrincipal -Tenant "$TenantId" -Credential $mycreds
Set-AzureRmContext -TenantId "$TenantId" -SubscriptionId $SubscriptionId