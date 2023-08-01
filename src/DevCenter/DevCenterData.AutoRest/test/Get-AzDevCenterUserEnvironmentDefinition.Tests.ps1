if (($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserEnvironmentDefinition')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserEnvironmentDefinition.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterUserEnvironmentDefinition' {
    It 'List'  {
        $listOfEnvDefs = Get-AzDevCenterUserEnvironmentDefinition -Endpoint $env.endpoint -ProjectName $env.projectName
        $listOfEnvDefs.Count | Should -Be 3

        if ($Record -or $Live) {
            $listOfEnvDefs = Get-AzDevCenterUserEnvironmentDefinition -DevCenter $env.devCenterName -ProjectName $env.projectName
            $listOfEnvDefs.Count | Should -Be 3
        }

    
    }

    It 'List1'  {
        $listOfEnvDefs = Get-AzDevCenterUserEnvironmentDefinition -Endpoint $env.endpoint -ProjectName $env.projectName -CatalogName $env.catalogName  
        $listOfEnvDefs.Count | Should -Be 3
        
        if ($Record -or $Live) {
            $listOfEnvDefs = Get-AzDevCenterUserEnvironmentDefinition -DevCenter $env.devCenterName -ProjectName $env.projectName -CatalogName $env.catalogName 
            $listOfEnvDefs.Count | Should -Be 3
        }
    }

    It 'Get'  {
        $envDef = Get-AzDevCenterUserEnvironmentDefinition -Endpoint $env.endpoint -ProjectName $env.projectName -CatalogName $env.catalogName -DefinitionName $env.sandbox
        $envDef.CatalogName | Should -Be $env.catalogName
        $envDef.Name | Should -Be $env.sandbox
        $envDef.TemplatePath | Should -Be "Environments/Sandbox/azuredeploy.json"


        if ($Record -or $Live) {
            $envDef = Get-AzDevCenterUserEnvironmentDefinition -DevCenter $env.devCenterName -ProjectName $env.projectName -CatalogName $env.catalogName -DefinitionName $env.functionApp
            $envDef.CatalogName | Should -Be $env.catalogName
            $envDef.Name | Should -Be $env.functionApp
            $envDef.TemplatePath | Should -Be "Environments/FunctionApp/azuredeploy.json"
        }

        
    }

    It 'GetViaIdentity'  {
        $envDefInput = @{"ProjectName" = $env.projectName; "CatalogName" = $env.catalogName; "DefinitionName" = $env.sandbox }

        $envDef = Get-AzDevCenterUserEnvironmentDefinition -Endpoint $env.endpoint -InputObject $envDefInput
        $envDef.CatalogName | Should -Be $env.catalogName
        $envDef.Name | Should -Be $env.sandbox
        $envDef.TemplatePath | Should -Be "Environments/Sandbox/azuredeploy.json"

        if ($Record -or $Live) {
            $envDef = Get-AzDevCenterUserEnvironmentDefinition -DevCenter $env.devCenterName -InputObject $envDefInput
            $envDef.CatalogName | Should -Be $env.catalogName
            $envDef.Name | Should -Be $env.sandbox
            $envDef.TemplatePath | Should -Be "Environments/Sandbox/azuredeploy.json"
        }
    }
}
