if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSecurityConnectorAzureDevOpsOrgAvailable'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSecurityConnectorAzureDevOpsOrgAvailable.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSecurityConnectorAzureDevOpsOrgAvailable' {
    It 'List' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $orgs = Get-AzSecurityConnectorAzureDevOpsOrgAvailable -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01"
        $orgs.Count | Should -BeGreaterThan 0
    }
}
