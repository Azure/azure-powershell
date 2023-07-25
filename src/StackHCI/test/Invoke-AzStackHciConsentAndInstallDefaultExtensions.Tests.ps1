if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzStackHciConsentAndInstallDefaultExtensions'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzStackHciConsentAndInstallDefaultExtensions.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzStackHciConsentAndInstallDefaultExtensions' {
    It 'And' {
        $job = Invoke-AzStackHciConsentAndInstallDefaultExtensions -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroup  
        $job.DefaultExtension | Should -Not -BeNullOrEmpty
    }
}
