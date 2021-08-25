if(($null -eq $TestName) -or ($TestName -contains 'New-AzVMwareAuthorization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwareAuthorization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzVMwareAuthorization' {
    It 'CreateExpanded' {
        {
            $config = New-AzVMwareAuthorization -Name $env.rstr4 -PrivateCloudName $env.privateCloudName3 -ResourceGroupName $env.resourceGroup3
            $config.Name | Should -Be $env.rstr4
        } | Should -Not -Throw
    }
}
