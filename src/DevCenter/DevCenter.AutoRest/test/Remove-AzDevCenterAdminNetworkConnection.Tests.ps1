if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterAdminNetworkConnection')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterAdminNetworkConnection.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterAdminNetworkConnection' {
    It 'Delete' {
        Remove-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionNameDelete -ResourceGroupName $env.resourceGroup
        { Get-AzDevCenterAdminNetworkConnection -ResourceGroupName $env.resourceGroup -Name $env.networkConnectionNameDelete } | Should -Throw

    }


    It 'DeleteViaIdentity' {
        $networkConnection = Get-AzDevCenterAdminNetworkConnection -ResourceGroupName $env.resourceGroup -Name $env.networkConnectionNameDelete2
        Remove-AzDevCenterAdminNetworkConnection -InputObject $networkConnection
        { Get-AzDevCenterAdminNetworkConnection -ResourceGroupName $env.resourceGroup -Name $env.networkConnectionNameDelete2 } | Should -Throw
    }
}
