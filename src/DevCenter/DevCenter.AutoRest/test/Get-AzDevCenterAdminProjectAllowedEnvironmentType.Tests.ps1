if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminProjectAllowedEnvironmentType'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminProjectAllowedEnvironmentType.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminProjectAllowedEnvironmentType' {
    It 'List' {
        $listOfAllowedEnvTypes = Get-AzDevCenterAdminProjectAllowedEnvironmentType -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup
        $listOfAllowedEnvTypes.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $envType = Get-AzDevCenterAdminProjectAllowedEnvironmentType -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -EnvironmentTypeName $env.environmentTypeName
        $envType.Name | Should -Be $env.environmentTypeName
    }

    It 'GetViaIdentity' {
        $envType = Get-AzDevCenterAdminProjectAllowedEnvironmentType -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -EnvironmentTypeName $env.environmentTypeName
        $envType = Get-AzDevCenterAdminProjectAllowedEnvironmentType -InputObject $envType
        $envType.Name | Should -Be $env.environmentTypeName
    }
}
