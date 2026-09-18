if(($null -eq $TestName) -or ($TestName -contains 'Update-AzMdpPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMdpPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzMdpPool' {
    It 'Update' {
        $pool = Update-AzMdpPool -ResourceGroupName $env.ResourceGroup -Name $env.MdpPoolNameGet -Tag @{"tag1"= "update1"}
        $pool.Name | Should -Be $env.MdpPoolNameGet
        $pool.Tag["tag1"] | Should -Be "update1"
    }
}
