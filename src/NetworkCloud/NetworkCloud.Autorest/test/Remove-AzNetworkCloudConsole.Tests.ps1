if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkCloudConsole')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkCloudConsole.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkCloudConsole' {
    It 'Delete' {
        { Remove-AzNetworkCloudConsole -Name $global:config.AzNetworkCloudConsole.consoleName `
                -ResourceGroupName $global:config.AzNetworkCloudConsole.consoleRg `
                -Subscription $global:config.AzNetworkCloudConsole.subscriptionId `
                -VirtualMachineName $global:config.AzNetworkCloudConsole.virtualMachineName `
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
