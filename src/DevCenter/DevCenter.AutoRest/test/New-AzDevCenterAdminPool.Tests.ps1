if (($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterAdminPool')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterAdminPool.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

#TODO: add idle parameters when feature is available
Describe 'New-AzDevCenterAdminPool' {
    It 'CreateExpanded' {
        $pool = New-AzDevCenterAdminPool -Name $env.poolNew -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -Location $env.location -DevBoxDefinitionName $env.devBoxDefinitionName -LocalAdministrator "Enabled" -NetworkConnectionName $env.attachedNetworkName
        $pool.Name | Should -Be $env.poolNew
        $pool.DevBoxDefinitionName | Should -Be $env.devBoxDefinitionName
        $pool.LocalAdministrator | Should -Be "Enabled"
        $pool.NetworkConnectionName | Should -Be $env.attachedNetworkName
        $pool.LicenseType | Should -Be "Windows_Client"
    }

}
