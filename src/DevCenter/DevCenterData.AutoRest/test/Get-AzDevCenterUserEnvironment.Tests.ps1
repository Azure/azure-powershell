if (($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserEnvironment')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserEnvironment.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}
Describe 'Get-AzDevCenterUserEnvironment' {
    It 'List'  {
        $listOfEnvs = Get-AzDevCenterUserEnvironment -Endpoint $env.endpoint -ProjectName $env.projectName
        $listOfEnvs.Count | Should -BeGreaterOrEqual 2

        if ($Record -or $Live) {
            $listOfEnvs = Get-AzDevCenterUserEnvironment -DevCenterName $env.devCenterName -ProjectName $env.projectName
            $listOfEnvs.Count | Should -BeGreaterOrEqual 2
        }
    }

    It 'Get'  {
        $environment = Get-AzDevCenterUserEnvironment -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name $env.envName
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.sandbox
        $environment.Name | Should -Be $env.envName
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId

        if ($Record -or $Live) {
            $environment = Get-AzDevCenterUserEnvironment -DevCenterName $env.devCenterName -ProjectName $env.projectName -UserId "me" -Name $env.envName2
            $environment.Parameter.Keys[0] | Should -Be "name"
            $environment.Parameter.Values[0] | Should -Be $env.functionAppName1
            $environment.CatalogName | Should -Be $env.catalogName
            $environment.DefinitionName | Should -Be $env.functionApp
            $environment.Name | Should -Be $env.envName2
            $environment.Type | Should -Be $env.environmentTypeName
            $environment.User | Should -Be $env.userObjectId
        }
    }

    It 'List1'  {
        $listOfEnvs = Get-AzDevCenterUserEnvironment -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" 
        $listOfEnvs.Count | Should -BeGreaterOrEqual 2

        if ($Record -or $Live) {
            $listOfEnvs = Get-AzDevCenterUserEnvironment -DevCenterName $env.devCenterName -ProjectName $env.projectName -UserId "me"
            $listOfEnvs.Count | Should -BeGreaterOrEqual 2
        }
    
    }

    It 'GetViaIdentity'  {
        $envInput = @{"UserId" = "me"; "ProjectName" = $env.projectName; "EnvironmentName" = $env.envName }

        $environment = Get-AzDevCenterUserEnvironment -Endpoint $env.endpoint -InputObject $envInput
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.sandbox
        $environment.Name | Should -Be $env.envName
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId
        
        if ($Record -or $Live) {
            $environment = Get-AzDevCenterUserEnvironment -DevCenterName $env.devCenterName -InputObject $envInput
            $environment.CatalogName | Should -Be $env.catalogName
            $environment.DefinitionName | Should -Be $env.sandbox
            $environment.Name | Should -Be $env.envName
            $environment.Type | Should -Be $env.environmentTypeName
            $environment.User | Should -Be $env.userObjectId
        }
    }
}
