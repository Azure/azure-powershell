if (($null -eq $TestName) -or ($TestName -contains 'Deploy-AzDevCenterUserEnvironment')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Deploy-AzDevCenterUserEnvironment.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Deploy-AzDevCenterUserEnvironment' {
    It 'ReplaceExpanded' {
        $functionAppParameters = @{"name" = $env.functionAppName2 }

        $environment = Deploy-AzDevCenterUserEnvironment -Endpoint $env.endpoint -Name "envtest1" -ProjectName $env.projectName -CatalogName $env.catalogName -EnvironmentDefinitionName $env.functionApp -EnvironmentType $env.environmentTypeName -Parameter $functionAppParameters
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.functionApp
        $environment.Name | Should -Be "envtest1"
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId

        if ($Record -or $Live) {
            $environment = Deploy-AzDevCenterUserEnvironment -DevCenterName $env.devCenterName -Name "envtest2" -ProjectName $env.projectName -CatalogName $env.catalogName -EnvironmentDefinitionName $env.sandbox -EnvironmentType $env.environmentTypeName
            $environment.CatalogName | Should -Be $env.catalogName
            $environment.DefinitionName | Should -Be $env.sandbox
            $environment.Name | Should -Be "envtest2"
            $environment.Type | Should -Be $env.environmentTypeName
            $environment.User | Should -Be $env.userObjectId
        }
    }

    It 'ReplaceViaIdentity' {
        $functionAppParameters = @{"name" = $env.functionAppName9 }
        $envInput1 = @{"UserId" = "me"; "ProjectName" = $env.projectName; "EnvironmentName" = "envtest7" }
        $envInput2 = @{"UserId" = "me"; "ProjectName" = $env.projectName; "EnvironmentName" = "envtest8" }


        $environment = Deploy-AzDevCenterUserEnvironment -Endpoint $env.endpoint -InputObject $envInput1 -CatalogName $env.catalogName -EnvironmentDefinitionName $env.sandbox -EnvironmentType $env.environmentTypeName
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.sandbox
        $environment.Name | Should -Be "envtest7"
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId

        if ($Record -or $Live) {
            $environment = Deploy-AzDevCenterUserEnvironment -DevCenterName $env.devCenterName -InputObject $envInput2 -CatalogName $env.catalogName -EnvironmentDefinitionName $env.functionApp -EnvironmentType $env.environmentTypeName -Parameter $functionAppParameters
            $environment.CatalogName | Should -Be $env.catalogName
            $environment.DefinitionName | Should -Be $env.functionApp
            $environment.Name | Should -Be "envtest8"
            $environment.Type | Should -Be $env.environmentTypeName
            $environment.User | Should -Be $env.userObjectId
        }
    }
}

