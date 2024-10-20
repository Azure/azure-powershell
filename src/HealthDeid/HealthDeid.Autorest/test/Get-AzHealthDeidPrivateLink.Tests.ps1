if(($null -eq $TestName) -or ($TestName -contains 'Get-AzHealthDeidPrivateLink'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzHealthDeidPrivateLink.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzHealthDeidPrivateLink' {
    It 'List' {
        { 
            $config = Get-AzHealthDeidPrivateLink -Name $env.deidServiceName -ResourceGroupName $env.resourceGroupName
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }

    It 'List' {
        { 
            $config = Get-AzHealthDeidPrivateLink -Name $env.deidServiceNameWithPL -ResourceGroupName $env.resourceGroupName
            $config.Count | Should -BeGreaterThan 0 # TODO: create private link
        } | Should -Not -Throw
    }
}
