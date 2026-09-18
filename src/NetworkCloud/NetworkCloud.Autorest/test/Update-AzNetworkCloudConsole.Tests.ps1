if (($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkCloudConsole')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudConsole.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkCloudConsole' {
    It 'Update' {
        {
            $tagUpdatedHash = @{
                tag1 = $global:config.AzNetworkCloudConsole.tags
                tag2 = $global:config.AzNetworkCloudConsole.tagsUpdate
            }
            Update-AzNetworkCloudConsole -ResourceGroupName $global:config.AzNetworkCloudConsole.consoleRg `
                -VirtualMachineName $global:config.AzNetworkCloudConsole.virtualMachineName `
                -Subscription $global:config.AzNetworkCloudConsole.subscriptionId `
                -Name $global:config.AzNetworkCloudConsole.consoleName -Tag $tagUpdatedHash `
                -Expiration $global:config.AzNetworkCloudConsole.expirationUpdate `
                -SshPublicKeyData $global:config.AzNetworkCloudConsole.sshPublicKeyData `
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
