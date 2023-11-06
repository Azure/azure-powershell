if (($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminEnvironmentDefinition')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminEnvironmentDefinition.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminEnvironmentDefinition' {
    It 'List' -skip {
        $listOfEnvironmentDefinitions = Get-AzDevCenterAdminEnvironmentDefinition -DevCenterName $env.devCenterNameEnvDef -Name $env.catalogName -ResourceGroupName $env.resourceGroupEnvDef - SubscriptionId $env.SubscriptionId2
        $listOfEnvironmentDefinitions.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' -skip {
        $envDef = Get-AzDevCenterAdminEnvironmentDefinition -Name "Sandbox" -DevCenterName $env.devCenterName -CatalogName $env.catalogName -ResourceGroupName $env.resourceGroup
        $envDef.Name | Should -Be "Sandbox"
    }

    It 'GetViaIdentity' -skip {
        $envDef = Get-AzDevCenterAdminEnvironmentDefinition -Name "Sandbox" -DevCenterName $env.devCenterName -CatalogName $env.catalogName -ResourceGroupName $env.resourceGroup
        $envDef = Get-AzDevCenterAdminEnvironmentDefinition -InputObject $envDef
        $envDef.Name | Should -Be "Sandbox"    
    }
}
