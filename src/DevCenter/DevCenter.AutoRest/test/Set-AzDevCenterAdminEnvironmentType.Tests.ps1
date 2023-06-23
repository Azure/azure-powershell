if(($null -eq $TestName) -or ($TestName -contains 'Set-AzDevCenterAdminEnvironmentType'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDevCenterAdminEnvironmentType.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzDevCenterAdminEnvironmentType' {
    It 'UpdateExpanded' {
        $tags = @{"dev" ="test"}

        $envType = Set-AzDevCenterAdminEnvironmentType -DevCenterName $env.devCenterName -Name $env.environmentTypeSet -ResourceGroupName $env.resourceGroup -Tag $tags
        $envType.Name | Should -Be $env.environmentTypeSet
        $envTypeTag = $envType.Tag | ConvertTo-Json | ConvertFrom-Json
        $envTypeTag.Keys[0] | Should -Be "dev"
        $envTypeTag.Values[0] | Should -Be "test"
    }

    It 'Update' {
        $tags = @{"dev1" ="test1"}
        $body = @{"Tag" = $tags}

        $envType = Set-AzDevCenterAdminEnvironmentType -DevCenterName $env.devCenterName -Name $env.environmentTypeSet -ResourceGroupName $env.resourceGroup -Body $body
        $envType.Name | Should -Be $env.environmentTypeSet
        $envTypeTag = $envType.Tag | ConvertTo-Json | ConvertFrom-Json
        $envTypeTag.Keys[0] | Should -Be "dev1"
        $envTypeTag.Values[0] | Should -Be "test1"
    }
}
