if (($null -eq $TestName) -or ($TestName -contains 'Start-AzNetworkCloudVirtualMachine')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzNetworkCloudVirtualMachine.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzNetworkCloudVirtualMachine' {
    It 'Start' {
        { Start-AzNetworkCloudVirtualMachine -Name $global:config.AzNetworkCloudVirtualMachine.vmName -ResourceGroupName $global:config.AzNetworkCloudVirtualMachine.vmResourceGroup -SubscriptionId $global:config.AzNetworkCloudVirtualMachine.subscriptionId } | Should -Not -Throw
    }

    It 'StartViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
