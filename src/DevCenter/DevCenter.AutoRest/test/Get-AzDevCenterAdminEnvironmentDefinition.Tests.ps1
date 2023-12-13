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
    It 'List' {
        $listOfEnvironmentDefinitions = Get-AzDevCenterAdminEnvironmentDefinition -DevCenterName $env.devCenterName10 -CatalogName $env.catalogName -ResourceGroupName $env.resourceGroupName10 -SubscriptionId $env.SubscriptionId2
        $listOfEnvironmentDefinitions.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $envDef = Get-AzDevCenterAdminEnvironmentDefinition -Name "Sandbox" -DevCenterName $env.devCenterName10 -CatalogName $env.catalogName -ResourceGroupName $env.resourceGroupName10 -SubscriptionId $env.SubscriptionId2
        $envDef.Name | Should -Be "Sandbox"
    }

    It 'GetViaIdentity' {
        $envDef = Get-AzDevCenterAdminEnvironmentDefinition -Name "Sandbox" -DevCenterName $env.devCenterName10 -CatalogName $env.catalogName -ResourceGroupName $env.resourceGroupName10 -SubscriptionId $env.SubscriptionId2
        $envDef = Get-AzDevCenterAdminEnvironmentDefinition -InputObject $envDef
        $envDef.Name | Should -Be "Sandbox"    
    }
}
