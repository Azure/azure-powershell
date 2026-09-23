if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDisconnectedOperationsImageDownloadUri'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDisconnectedOperationsImageDownloadUri.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDisconnectedOperationsImageDownloadUri' {
    It 'List' {
        { Get-AzDisconnectedOperationsImageDownloadUri -ImageName $env.ImageName -Name $env.Name -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -ErrorAction Stop} | Should -Throw
    }
}
