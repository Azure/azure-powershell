if (($null -eq $TestName) -or ($TestName -contains 'Update-AzDevCenterAdminPool')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDevCenterAdminPool.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDevCenterAdminPool' {
    It 'UpdateExpanded' {
        $pool = Update-AzDevCenterAdminPool -Name $env.poolUpdate -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -DevBoxDefinitionName $env.devBoxDefinitionSet -LocalAdministrator "Disabled" -NetworkConnectionName $env.attachedNetworkName
        $pool.Name | Should -Be $env.poolUpdate
        $pool.DevBoxDefinitionName | Should -Be $env.devBoxDefinitionSet
        $pool.LocalAdministrator | Should -Be "Disabled"
        $pool.NetworkConnectionName | Should -Be $env.attachedNetworkName
        $pool.LicenseType | Should -Be "Windows_Client"
    }

    It 'UpdateViaIdentityExpanded' {
        $poolInput = Get-AzDevCenterAdminPool -ResourceGroupName $env.resourceGroup -Name $env.poolUpdate -ProjectName $env.projectName

        $pool = Update-AzDevCenterAdminPool -InputObject $poolInput -DevBoxDefinitionName $env.devBoxDefinitionSet -LocalAdministrator "Disabled" -NetworkConnectionName $env.attachedNetworkName
        $pool.Name | Should -Be $env.poolUpdate
        $pool.DevBoxDefinitionName | Should -Be $env.devBoxDefinitionSet
        $pool.LocalAdministrator | Should -Be "Disabled"
        $pool.NetworkConnectionName | Should -Be $env.attachedNetworkName
        $pool.LicenseType | Should -Be "Windows_Client" }

}
