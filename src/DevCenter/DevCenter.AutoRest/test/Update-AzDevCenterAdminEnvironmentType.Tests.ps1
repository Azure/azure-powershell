if (($null -eq $TestName) -or ($TestName -contains 'Update-AzDevCenterAdminEnvironmentType')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDevCenterAdminEnvironmentType.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDevCenterAdminEnvironmentType' {
    It 'UpdateExpanded' {
        $tags = @{"dev" = "test" }

        $envType = Update-AzDevCenterAdminEnvironmentType -DevCenterName $env.devCenterName -Name $env.environmentTypeUpdate -ResourceGroupName $env.resourceGroup -Tag $tags
        $envType.Name | Should -Be $env.environmentTypeUpdate
        $envTypeTag = $envType.Tag | ConvertTo-Json | ConvertFrom-Json
        $envTypeTag.Keys[0] | Should -Be "dev"
        $envTypeTag.Values[0] | Should -Be "test"
    }

    It 'UpdateViaIdentityExpanded' {

        $envTypeInput = Get-AzDevCenterAdminEnvironmentType -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name $env.environmentTypeUpdate
        $tags = @{"dev" = "test" }

        $envType = Update-AzDevCenterAdminEnvironmentType -InputObject $envTypeInput -Tag $tags
        $envType.Name | Should -Be $env.environmentTypeUpdate
        $envTypeTag = $envType.Tag | ConvertTo-Json | ConvertFrom-Json
        $envTypeTag.Keys[0] | Should -Be "dev"
        $envTypeTag.Values[0] | Should -Be "test"
    }

}
