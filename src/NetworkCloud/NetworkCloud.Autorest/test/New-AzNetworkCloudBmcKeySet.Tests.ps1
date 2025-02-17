$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudBmcKeySet.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzNetworkCloudBmcKeySet' {
    It 'Create' {
        { $bmcksconfig = $global:config.AzNetworkCloudBmcKeySet
            $common = $global:config.common
            $tagHash = @{
                tag1 = $bmcksconfig.tags
            }
            $userList = New-AzNetworkCloudKeySetUserObject `
                -description $bmcksconfig.userDescription `
                -azureUserName $bmcksconfig.userName `
                -sshPublicKey @{
                keyData = $bmcksconfig.sshKey
            }

            New-AzNetworkCloudBmcKeySet -ResourceGroupName $bmcksconfig.bmcksrg `
                -Name $bmcksconfig.bmcKeySetName -ClusterName $bmcksconfig.clusterName `
                -AzureGroupId $bmcksconfig.azureGroupId `
                -Expiration $bmcksconfig.expiration `
                -ExtendedLocationName $bmcksconfig.clusterExtendedLocation `
                -ExtendedLocationType $common.customLocationType -Location $common.location `
                -PrivilegeLevel $bmcksconfig.privilegeLevel `
                -UserList $userList -Tag $tagHash `
                -Subscription $bmcksconfig.subscriptionId
        } | Should -Not -Throw
    }
}
