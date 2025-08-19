if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzNeonPostgresBranch'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNeonPostgresBranch.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNeonPostgresBranch' {
    It 'Delete' {
        { Remove-AzNeonPostgresBranch -Name "br-proud-hill-a8k4hx9r" -OrganizationName "NeonDemoOrgPS1" -ProjectName "dawn-breeze-86932057" -ResourceGroupName "neonrg" -SubscriptionId "a81c0054-6c92-41aa-a235-4f9f98f917c6" } | Should -Not -Throw
    }
}
