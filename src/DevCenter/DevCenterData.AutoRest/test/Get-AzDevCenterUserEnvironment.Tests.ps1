if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserEnvironment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserEnvironment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}
#Add parameter check
Describe 'Get-AzDevCenterUserEnvironment' {
    It 'List' -skip {
        $listOfEnvs = Get-AzDevCenterUserEnvironment -Endpoint $env.endpoint -ProjectName $env.projectName
        $listOfEnvs.Count | Should -BeGreaterOrEqual 2

        $listOfEnvs = Get-AzDevCenterUserEnvironment -DevCenter $env.devCenterName -ProjectName $env.projectName
        $listOfEnvs.Count | Should -BeGreaterOrEqual 2
        }

    It 'Get' -skip {
        $environment = Get-AzDevCenterUserEnvironment -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name $env.envName
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.sandbox
        $environment.Name | Should -Be $env.envName
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId

        $environment = Get-AzDevCenterUserEnvironment -DevCenter $env.devCenterName -ProjectName $env.projectName -UserId "me" -Name $env.envName2
        #add parameter
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.functionApp
        $environment.Name | Should -Be $env.envName2
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId
    }

    It 'List1' -skip {
        $listOfEnvs = Get-AzDevCenterUserEnvironment -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" 
        $listOfEnvs.Count | Should -BeGreaterOrEqual 2

        $listOfEnvs = Get-AzDevCenterUserEnvironment -DevCenter $env.devCenterName -ProjectName $env.projectName -UserId "me"
        $listOfEnvs.Count | Should -BeGreaterOrEqual 2
    
    }

    It 'GetViaIdentity' -skip {
        $envInput = @{"UserId" = "me"; "ProjectName" = $env.projectName; "EnvironmentName" = $env.envName}

        $environment = Get-AzDevCenterUserEnvironment -Endpoint $env.endpoint -InputObject $envInput
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.sandbox
        $environment.Name | Should -Be $env.envName
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId

        $environment = Get-AzDevCenterUserEnvironment -DevCenter $env.devCenterName -InputObject $envInput
        $environment.CatalogName | Should -Be $env.catalogName
        $environment.DefinitionName | Should -Be $env.sandbox
        $environment.Name | Should -Be $env.envName
        $environment.Type | Should -Be $env.environmentTypeName
        $environment.User | Should -Be $env.userObjectId
        }
}
