if(($null -eq $TestName) -or ($TestName -contains 'Get-AzLogzSubAccountVMHost'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLogzSubAccountVMHost.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzLogzSubAccountVMHost' {
    It 'List' {
        { Get-AzLogzSubAccountVMHost -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name $env.subAccountName01 } | Should -Not -Throw
    }
}
