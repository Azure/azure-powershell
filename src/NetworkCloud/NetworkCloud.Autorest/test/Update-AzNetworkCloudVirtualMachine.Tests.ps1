if (($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkCloudVirtualMachine')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudVirtualMachine.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkCloudVirtualMachine' {
    It 'Update' {
        { $tagUpdatedHash = @{
                tag1 = $global:config.AzNetworkCloudVirtualMachine.tags
                tag2 = $global:config.AzNetworkCloudVirtualMachine.tagsUpdate
            }
            $securePassword = ConvertTo-SecureString $global:config.AzNetworkCloudVirtualMachine.registryPassword -AsPlainText -Force
            Update-AzNetworkCloudVirtualMachine -Name $global:config.AzNetworkCloudVirtualMachine.vmName `
                -ResourceGroupName $global:config.AzNetworkCloudVirtualMachine.vmResourceGroup -Tag $tagUpdatedHash `
                -VMImageRepositoryCredentialsRegistryUrl $global:config.AzNetworkCloudVirtualMachine.registryUrl `
                -VMImageRepositoryCredentialsUsername $global:config.AzNetworkCloudVirtualMachine.registryUsername `
                -VMImageRepositoryCredentialsPassword $securePassword `
                -SubscriptionId $global:config.AzNetworkCloudVirtualMachine.subscriptionId
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
