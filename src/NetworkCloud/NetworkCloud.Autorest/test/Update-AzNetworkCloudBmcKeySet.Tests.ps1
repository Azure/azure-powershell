if (($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkCloudBmcKeySet')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudBmcKeySet.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkCloudBmcKeySet' {
    It 'Update' {
        {
            $bmcksconfig = $global:config.AzNetworkCloudBmcKeySet
            $tagUpdatedHash = @{
                tag1 = $bmcksconfig.tags
                tag2 = $bmcksconfig.tagsUpdate
            }
            $userList = @{
                description   = $bmcksconfig.userDescriptionUpdate
                azureUserName = $bmcksconfig.userNameUpdate
                sshPublicKey  = @{
                    keyData = $bmcksconfig.sshKeyUpdate
                }
            }
            Update-AzNetworkCloudBmcKeySet -ResourceGroupName $bmcksconfig.bmcksrg `
                -Name $bmcksconfig.bmcKeySetName -Tag $tagUpdatedHash -ClusterName $bmcksconfig.clusterName -UserList $userList `
                -Subscription $bmcksconfig.subscriptionId
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
