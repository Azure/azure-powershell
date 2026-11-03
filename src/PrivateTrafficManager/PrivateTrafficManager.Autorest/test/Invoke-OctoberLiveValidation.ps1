#Requires -Version 7.0
[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$SubscriptionId,
    [Parameter(Mandatory)]
    [string]$GatewayId,
    [Parameter(Mandatory)]
    [string]$RecordingPath,
    [string]$Location = 'westcentralus'
)

$ErrorActionPreference = 'Stop'
if (Test-Path $RecordingPath) {
    throw 'Use a new recording path for each live run.'
}
$artifactRoot = Join-Path $PSScriptRoot '../../../../artifacts/Debug'
Import-Module (Join-Path $artifactRoot 'Az.Accounts/Az.Accounts.psd1') -ErrorAction Stop
Import-Module (Join-Path $artifactRoot 'Az.PrivateTrafficManager/Az.PrivateTrafficManager.psd1') -ErrorAction Stop
$groupName = 'ptm-pwsh-oct-' + [guid]::NewGuid().ToString('N').Substring(0, 10)
$exists = az group exists --name $groupName --subscription $SubscriptionId
if ($LASTEXITCODE -ne 0 -or $exists -ne 'false') {
    throw 'The temporary group absence could not be confirmed.'
}
$created = $false
try {
    $null = az group create --name $groupName --location $Location --subscription $SubscriptionId --tags purpose=ptm-powershell-october-validation --output json
    if ($LASTEXITCODE -ne 0) { throw 'Temporary group creation failed.' }
    $created = $true
    Write-Information "Owned test group: $groupName" -InformationAction Continue
    $null = az network vnet create --resource-group $groupName --name validation-vnet --location $Location --address-prefixes 10.1.0.0/16 --subscription $SubscriptionId --output json
    if ($LASTEXITCODE -ne 0) { throw 'Temporary VNet creation failed.' }
    $virtualNetworkId = "/subscriptions/$SubscriptionId/resourceGroups/$groupName/providers/Microsoft.Network/virtualNetworks/validation-vnet"
    & (Join-Path $PSScriptRoot 'Invoke-OctoberApiValidation.ps1') -SubscriptionId $SubscriptionId -ResourceGroupName $groupName -GatewayId $GatewayId -VirtualNetworkId $virtualNetworkId -Location global -Mode Record -RecordingPath $RecordingPath
}
finally {
    if ($created) {
        $ownedProfiles = @(Get-AzPrivateTrafficManagerProfile -SubscriptionId $SubscriptionId -ResourceGroupName $groupName)
        foreach ($ownedProfile in $ownedProfiles) {
            Remove-AzPrivateTrafficManagerProfile -SubscriptionId $SubscriptionId -ResourceGroupName $groupName -PrivateTrafficManagerProfileName $ownedProfile.Name -Confirm:$false
        }
        $ownedMaps = @(Get-AzPrivateTrafficManagerTopologyMap -SubscriptionId $SubscriptionId -ResourceGroupName $groupName)
        foreach ($ownedMap in $ownedMaps) {
            Remove-AzPrivateTrafficManagerTopologyMap -SubscriptionId $SubscriptionId -ResourceGroupName $groupName -Name $ownedMap.Name -Confirm:$false
        }
        az group delete --name $groupName --subscription $SubscriptionId --yes
        if ($LASTEXITCODE -ne 0) { throw "Cleanup failed for owned group $groupName" }
        $exists = az group exists --name $groupName --subscription $SubscriptionId
        if ($LASTEXITCODE -ne 0 -or $exists -ne 'false') { throw "Cleanup unverified for $groupName" }
        Write-Information "Cleanup verified: $groupName no longer exists." -InformationAction Continue
    }
}