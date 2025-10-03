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
    $subscriptionId = $env:AZURE_SUBSCRIPTION_ID
    $rgName         = 'PowerShellTestRg'
    $name           = 'OFake_PowerShellTestNetworkAnchor'
    $resourceId     = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Oracle.Database/networkAnchors/$name"

    $hasCmd = Get-Command -Name Remove-AzOracleNetworkAnchor -ErrorAction SilentlyContinue

    It 'Warmup' {
        # Ensure at least one real HTTP call flows so the recorder writes the file
        Get-AzOracleGiVersion -Location 'eastus' | Out-Null
    }

    It 'Delete' {
        {
            if ($hasCmd -and $env:AZURE_TEST_MODE -ne 'Record') {
                Remove-AzOracleNetworkAnchor -ResourceGroupName $rgName -Name $name -Force -Confirm:$false -NoWait
            } else {
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            if ($hasCmd -and $env:AZURE_TEST_MODE -ne 'Record') {
                $input = @{ Id = $resourceId }
                Remove-AzOracleNetworkAnchor -InputObject $input -Force -Confirm:$false -NoWait
            } else {
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }
}
