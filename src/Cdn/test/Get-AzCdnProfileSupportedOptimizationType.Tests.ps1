if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnProfileSupportedOptimizationType'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCdnProfileSupportedOptimizationType.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCdnProfileSupportedOptimizationType'  {
    It 'List' {
        Get-AzCdnProfile -ResourceGroupName $env.ResourceGroupName -Name $env.ClassicCdnProfileName

        $optimizationType = Get-AzCdnProfileSupportedOptimizationType -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $optimizationType
    }
}
