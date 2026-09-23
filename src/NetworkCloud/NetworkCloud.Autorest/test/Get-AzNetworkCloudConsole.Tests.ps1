if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudConsole')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudConsole.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudConsole' {
    It 'ListByParent' {
        { Get-AzNetworkCloudConsole -Subscription $global:config.AzNetworkCloudConsole.subscriptionId -VirtualMachineName $global:config.AzNetworkCloudConsole.virtualMachineName -ResourceGroupName $global:config.AzNetworkCloudConsole.consoleRg } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzNetworkCloudConsole -Name $global:config.AzNetworkCloudConsole.consoleName -Subscription $global:config.AzNetworkCloudConsole.subscriptionId -ResourceGroupName $global:config.AzNetworkCloudConsole.consoleRg -VirtualMachineName $global:config.AzNetworkCloudConsole.virtualMachineName } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
