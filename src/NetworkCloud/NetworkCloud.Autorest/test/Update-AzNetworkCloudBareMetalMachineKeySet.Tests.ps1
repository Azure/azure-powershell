$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudBareMetalMachineKeySet.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzNetworkCloudBareMetalMachineKeySet' {
    It 'Update' {
        {
            $bmmksconfig = $global:config.AzNetworkCloudBareMetalMachineKeySet

            $tagUpdatedHash = @{
                tag1 = $bmmksconfig.tags
                tag2 = $bmmksconfig.tagsUpdate
            }
            $userList = @{
                description   = $bmmksconfig.userDescriptionUpdate
                azureUserName = $bmmksconfig.userNameUpdate
                userPrincipalName = $bmmksconfig.userPrincipalNameUpdate
                sshPublicKey  = @{
                    keyData = $bmmksconfig.sshKeyUpdate
                }
            }
            Update-AzNetworkCloudBareMetalMachineKeySet -ResourceGroupName $bmmksconfig.bmmksrg `
                -Name $bmmksconfig.bmmKeySetName -Tag $tagUpdatedHash -ClusterName $bmmksconfig.clusterName -UserList $userList `
                -Subscription $bmmksconfig.subscriptionId
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
