if(($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterUserEnvironment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterUserEnvironment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterUserEnvironment' {
    It 'CreateExpanded' -skip {
        $functionAppParameters = @{"name" = $env.functionAppName6 }

        $environment = New-AzDevCenterUserEnvironment -Endpoint $env.endpoint -Name "envtest1" -ProjectName $env.projectName -CatalogName $env.catalogName -EnvironmentDefinitionName $env.functionApp -EnvironmentType $env.environmentTypeName -Parameter $functionAppParameters
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.functionApp
        $environment.Name | Should -Be "envtest1"
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId


        $environment = New-AzDevCenterUserEnvironment -DevCenter $env.devCenterName -Name "envtest2" -ProjectName $env.projectName -CatalogName $env.catalogName -EnvironmentDefinitionName $env.sandbox -EnvironmentType $env.environmentTypeName
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.sandbox
        $environment.Name | Should -Be "envtest2"
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId
        }

    It 'Create' -skip {
        $functionAppParameters = @{"name" = $env.functionAppName7 }
        $functionAppBody = @{"CatalogName" = $env.catalogName; "DefinitionName" = $env.functionApp; "Type" = $env.environmentTypeName; "Parameter" = $functionAppParameters}
        $sandboxBody = @{"CatalogName" = $env.catalogName; "DefinitionName" = $env.sandbox; "Type" = $env.environmentTypeName}


        $environment = New-AzDevCenterUserEnvironment -Endpoint $env.endpoint -Name "envtest3" -ProjectName $env.projectName -Body $functionAppBody
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.functionApp
        $environment.Name | Should -Be "envtest3"
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId

        $environment = New-AzDevCenterUserEnvironment -DevCenter $env.devCenterName -Name "envtest4" -ProjectName $env.projectName -Body $sandboxBody
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.sandbox
        $environment.Name | Should -Be "envtest4"
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId
        }

    It 'CreateViaIdentityExpanded' -skip {
        $envInput1 = @{"UserId" = "me"; "ProjectName" = $env.projectName; "EnvironmentName" = "envtest5"}
        $envInput2 = @{"UserId" = "me"; "ProjectName" = $env.projectName; "EnvironmentName" = "envtest6"}

        $functionAppParameters = @{"name" = $env.functionAppName8 }
        $functionAppBody = @{"CatalogName" = $env.catalogName; "DefinitionName" = $env.functionApp; "Type" = $env.environmentTypeName; "Parameter" = $functionAppParameters}
        $sandboxBody = @{"CatalogName" = $env.catalogName; "DefinitionName" = $env.sandbox; "Type" = $env.environmentTypeName}

        $environment = New-AzDevCenterUserEnvironment -Endpoint $env.endpoint -InputObject $envInput1 -Body $sandboxBody
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.sandbox
        $environment.Name | Should -Be "envtest5"
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId

        $environment = New-AzDevCenterUserEnvironment -DevCenter $env.devCenterName -InputObject $envInput2 -Body $functionAppBody
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.functionApp
        $environment.Name | Should -Be "envtest6"
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId
        }

    It 'CreateViaIdentity' -skip {
        $functionAppParameters = @{"name" = $env.functionAppName9 }
        $envInput1 = @{"UserId" = "me"; "ProjectName" = $env.projectName; "EnvironmentName" = "envtest7"}
        $envInput2 = @{"UserId" = "me"; "ProjectName" = $env.projectName; "EnvironmentName" = "envtest8"}


        $environment = New-AzDevCenterUserEnvironment -Endpoint $env.endpoint -InputObject $envInput1 -CatalogName $env.catalogName -EnvironmentDefinitionName $env.sandbox -EnvironmentType $env.environmentTypeName
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.sandbox
        $environment.Name | Should -Be "envtest7"
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId

        $environment = New-AzDevCenterUserEnvironment -DevCenter $env.devCenterName -InputObject $envInput2 -CatalogName $env.catalogName -EnvironmentDefinitionName $env.functionApp -EnvironmentType $env.environmentTypeName -Parameter $functionAppParameters
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.functionApp
        $environment.Name | Should -Be "envtest8"
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId
        }
}
