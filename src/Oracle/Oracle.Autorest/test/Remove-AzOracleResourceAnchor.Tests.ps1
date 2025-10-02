if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzOracleResourceAnchor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzOracleResourceAnchor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzOracleResourceAnchor' {
    $subscriptionId = 'fd42b73d-5f28-4a23-ae7c-ca08c625fe07'
    $rgName         = 'PowerShellTestRg'
    $name           = 'OFake_PowerShellTestResourceAnchor'
    $resourceId     = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Oracle.Database/resourceAnchors/$name"

    It 'Delete' {
        {
            Remove-AzOracleResourceAnchor -ResourceGroupName $rgName -Name $name -Force -Confirm:$false -NoWait
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $input = @{ Id = $resourceId }
            Remove-AzOracleResourceAnchor -InputObject $input -Force -Confirm:$false -NoWait
        } | Should -Not -Throw
    }
}
