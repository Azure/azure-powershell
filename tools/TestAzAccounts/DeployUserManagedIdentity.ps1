[CmdletBinding()]
Param
(
    [Parameter(Mandatory = $true)]
    [string]
    $Tenant,

    [Parameter(Mandatory = $true)]
    [string]
    $Subscription,

    [Parameter(Mandatory = $true)]
    [string]
    $ResourceGroupName,

    [Parameter(Mandatory = $true)]
    [string]
    $UserManagedIdentity,

    [Parameter()]
    [string]
    $Location
)

if ($Location.Length -le 0)
{
    $Location = 'eastus'
}

Set-AzContext -SubscriptionName $Subscription -TenantId $Tenant
New-AzUserAssignedIdentity -ResourceGroupName $ResourceGroupName -Name $UserManagedIdentity -Location $Location