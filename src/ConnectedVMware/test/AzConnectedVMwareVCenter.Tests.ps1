if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedVMwareVCenter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedVMwareVCenter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedVMwareVCenter' {
    It 'Get' {
        $vc = Get-AzConnectedVMwareVCenter -ResourceGroupName $env.ResourceGroupName -Name $env.vcenterName
        $vc.Name | Should -Be $env.vcenterName
    }
}
