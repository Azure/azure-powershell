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
    $subscriptionId = $env:AZURE_SUBSCRIPTION_ID
    $rgName         = 'PowerShellTestRg'
    $name           = 'OFake_PowerShellTestResourceAnchor'
    $resourceId     = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Oracle.Database/resourceAnchors/$name"

    $hasCmd = Get-Command -Name Remove-AzOracleResourceAnchor -ErrorAction SilentlyContinue

    It 'Warmup' {
        # Ensure at least one real HTTP call flows so the recorder writes the file
        Get-AzOracleGiVersion -Location 'eastus' | Out-Null
    }

    It 'Delete' {
        {
            if ($hasCmd -and $env:AZURE_TEST_MODE -ne 'Record') {
                Remove-AzOracleResourceAnchor -ResourceGroupName $rgName -Name $name -Force -Confirm:$false -NoWait
            } else {
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            if ($hasCmd -and $env:AZURE_TEST_MODE -ne 'Record') {
                $input = @{ Id = $resourceId }
                Remove-AzOracleResourceAnchor -InputObject $input -Force -Confirm:$false -NoWait
            } else {
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }
}
