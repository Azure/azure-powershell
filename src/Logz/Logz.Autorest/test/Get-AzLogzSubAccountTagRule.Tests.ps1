if(($null -eq $TestName) -or ($TestName -contains 'Get-AzLogzSubAccountTagRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLogzSubAccountTagRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzLogzSubAccountTagRule' {
    It 'Get' {
        $tagRule = Get-AzLogzSubAccountTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -SubAccountName $env.subAccountName01
        $tagRule.Name | Should -Be 'default'
    }

    It 'GetViaIdentity' {
        $tagRule = Get-AzLogzSubAccountTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -SubAccountName $env.subAccountName01
        $tagRule = Get-AzLogzSubAccountTagRule -InputObject $tagRule
        $tagRule.Name | Should -Be 'default'
    }
}
