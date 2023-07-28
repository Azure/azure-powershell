if(($null -eq $TestName) -or ($TestName -contains 'Set-AzDevCenterUserEnvironment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDevCenterUserEnvironment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}
Describe 'Set-AzDevCenterUserEnvironment' {
    It 'ReplaceExpanded' {
        $functionAppParameters = @{"name" = $env.functionAppName10 }

        $environment = Set-AzDevCenterUserEnvironment -Endpoint $env.endpoint -Name "envtest1" -ProjectName $env.projectName -CatalogName $env.catalogName -EnvironmentDefinitionName $env.functionApp -EnvironmentType $env.environmentTypeName -Parameter $functionAppParameters
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.functionApp
        $environment.Name | Should -Be "envtest1"
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId


        $environment = Set-AzDevCenterUserEnvironment -DevCenter $env.devCenterName -Name "envtest2" -ProjectName $env.projectName -CatalogName $env.catalogName -EnvironmentDefinitionName $env.sandbox -EnvironmentType $env.environmentTypeName
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.sandbox
        $environment.Name | Should -Be "envtest2"
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId
        }

    It 'ReplaceViaIdentity' {
        $functionAppParameters = @{"name" = $env.functionAppName13 }
        $envInput1 = @{"UserId" = "me";}
        $envInput2 = @{"UserId" = "me";}


        $environment = Set-AzDevCenterUserEnvironment -Endpoint $env.endpoint -Name "envtest7" -ProjectName $env.projectName -InputObject $envInput1 -CatalogName $env.catalogName -EnvironmentDefinitionName $env.sandbox -EnvironmentType $env.environmentTypeName
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.sandbox
        $environment.Name | Should -Be "envtest7"
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId

        $environment = Set-AzDevCenterUserEnvironment -DevCenter $env.devCenterName -Name "envtest8" -ProjectName $env.projectName -InputObject $envInput2 -CatalogName $env.catalogName -EnvironmentDefinitionName $env.functionApp -EnvironmentType $env.environmentTypeName -Parameter $functionAppParameters
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.functionApp
        $environment.Name | Should -Be "envtest8"
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId
        }
}
