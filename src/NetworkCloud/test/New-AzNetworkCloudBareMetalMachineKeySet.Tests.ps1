$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudBareMetalMachineKeySet.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzNetworkCloudBareMetalMachineKeySet' {
    It 'Create' {
        { $bmmksconfig = $global:config.AzNetworkCloudBareMetalMachineKeySet
            $common = $global:config.common
            $tagHash = @{
                tag1 = $bmmksconfig.tags
            }
            $userList = @{
                description   = $bmmksconfig.userDescription
                azureUserName = $bmmksconfig.userName
                sshPublicKey  = @{
                    keyData = $bmmksconfig.sshKey
                }
            }
            New-AzNetworkCloudBareMetalMachineKeySet -ResourceGroupName $bmmksconfig.bmmksrg `
                -Name $bmmksconfig.bmmKeySetName -ClusterName $bmmksconfig.clusterName `
                -AzureGroupId $bmmksconfig.azureGroupId `
                -Expiration $bmmksconfig.expiration -OSGroupName $bmmksconfig.osGroupName `
                -ExtendedLocationName $common.extendedLocation `
                -ExtendedLocationType $common.customLocationType -Location $common.location `
                -PrivilegeLevel $bmmksconfig.privilegeLevel -JumpHostsAllowed $bmmksconfig.jumpHostsAllowed `
                -UserList $userList -Tag $tagHash `
                -Subscription $bmmksconfig.subscriptionId
        } | Should -Not -Throw
    }
}
