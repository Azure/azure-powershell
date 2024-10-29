if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzMdpPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMdpPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzMdpPool' {
    It 'Delete' {
        Remove-AzMdpPool -Name $env.MdpPoolNameDelete -ResourceGroupName $env.ResourceGroup
        { Get-AzMdpPool -Name $env.MdpPoolNameDelete -ResourceGroupName $env.ResourceGroup } | Should -Throw
    }
}
