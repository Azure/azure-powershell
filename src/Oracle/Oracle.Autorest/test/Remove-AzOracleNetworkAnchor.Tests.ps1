if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzOracleNetworkAnchor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzOracleNetworkAnchor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzOracleNetworkAnchor' {
    $subscriptionId = 'fd42b73d-5f28-4a23-ae7c-ca08c625fe07'
    $rgName         = 'PowerShellTestRg'
    $name           = 'OFake_PowerShellTestNetworkAnchor'
    $resourceId     = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Oracle.Database/networkAnchors/$name"

    It 'Delete' {
        {
            Remove-AzOracleNetworkAnchor -ResourceGroupName $rgName -Name $name -Force -Confirm:$false -NoWait
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $input = @{ Id = $resourceId }
            Remove-AzOracleNetworkAnchor -InputObject $input -Force -Confirm:$false -NoWait
        } | Should -Not -Throw
    }
}
