if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSecurityConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSecurityConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSecurityConnector' {
    It 'UpdateExpanded' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        Update-AzSecurityConnector -SubscriptionId $sid -ResourceGroupName $rg -Name "dfdsdktests-azdo-01" -Tag @{ pwshsdktest="true"}
    }

    It 'UpdateViaIdentityExpanded' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $connector = Get-AzSecurityConnector -SubscriptionId $sid -ResourceGroupName $rg -Name "dfdsdktests-azdo-01"
        Update-AzSecurityConnector -InputObject $connector -Tag @{ pwshsdktest2="true"}
    }
}
