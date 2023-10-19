if(($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterAdminEnvironmentType'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterAdminEnvironmentType.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterAdminEnvironmentType' {
    It 'CreateExpanded' {
        $tags = @{"dev" ="test"}

        $envType = New-AzDevCenterAdminEnvironmentType -DevCenterName $env.devCenterName -Name $env.envTypeNew -ResourceGroupName $env.resourceGroup -Tag $tags
        $envType.Name | Should -Be $env.envTypeNew
        $envTypeTag = $envType.Tag | ConvertTo-Json | ConvertFrom-Json
        $envTypeTag.Keys[0] | Should -Be "dev"
        $envTypeTag.Values[0] | Should -Be "test"

    }

}
