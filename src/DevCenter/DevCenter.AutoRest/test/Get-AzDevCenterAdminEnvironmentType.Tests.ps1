if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminEnvironmentType'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminEnvironmentType.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminEnvironmentType' {
    It 'List' {
        $listOfEnvTypes = Get-AzDevCenterAdminEnvironmentType -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName
        $listOfEnvTypes.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $envType = Get-AzDevCenterAdminEnvironmentType -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name $env.environmentTypeName
        $envType.Name | Should -Be $env.environmentTypeName
    }

    It 'GetViaIdentity' {
        $envType = Get-AzDevCenterAdminEnvironmentType -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name $env.environmentTypeName
        $envType = Get-AzDevCenterAdminEnvironmentType -InputObject $envType
        $envType.Name | Should -Be $env.environmentTypeName
    }
}
