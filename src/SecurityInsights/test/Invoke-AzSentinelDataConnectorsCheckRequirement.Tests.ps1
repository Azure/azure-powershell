if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzSentinelDataConnectorsCheckRequirement'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzSentinelDataConnectorsCheckRequirement.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzSentinelDataConnectorsCheckRequirement' {
    It 'Custom'  {
        $result = Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName -Kind AzureSecurityCenter -ASCSubscriptionId $env.SubscriptionId
        $result | Should -Not -Be $null
    }
}
