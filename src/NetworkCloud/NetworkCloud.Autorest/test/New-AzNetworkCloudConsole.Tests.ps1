if (($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkCloudConsole')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudConsole.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkCloudConsole' {
    It 'Create' {
        {
            New-AzNetworkCloudConsole -ResourceGroupName $global:config.AzNetworkCloudConsole.consoleRg `
                -Name $global:config.AzNetworkCloudConsole.consoleName -Location  $global:config.common.location `
                -ExtendedLocationName $global:config.AzNetworkCloudConsole.extendedLocation `
                -ExtendedLocationType $global:config.AzNetworkCloudConsole.customLocationType `
                -Subscription $global:config.AzNetworkCloudConsole.subscriptionId `
                -Tag @{tags = $global:config.AzNetworkCloudConsole.tags } `
                -Enabled $global:config.AzNetworkCloudConsole.enabled `
                -VirtualMachineName $global:config.AzNetworkCloudConsole.virtualMachineName `
                -SshPublicKeyData $global:config.AzNetworkCloudConsole.sshPublicKeyData `
                -Expiration $global:config.AzNetworkCloudConsole.expiration `

        } | Should -Not -Throw
    }
}
