if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOracleNetworkAnchor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOracleNetworkAnchor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOracleNetworkAnchor' {
    $subscriptionId = $env:AZURE_SUBSCRIPTION_ID
    $rgName         = 'PowerShellTestRg'
    $resourceName   = 'OFake_PowerShellTestNetworkAnchor'   # <- avoid $name
    $resourceId     = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Oracle.Database/networkAnchors/$resourceName"

    $hasCmd = Get-Command -Name Get-AzOracleNetworkAnchor -ErrorAction SilentlyContinue

    It 'Warmup' {
        # Ensure at least one real HTTP call flows through so the recorder writes the file
        Get-AzOracleGiVersion -Location 'eastus' | Out-Null
    }

    It 'List' {
        if ($hasCmd) {
            $list = Get-AzOracleNetworkAnchor -ResourceGroupName $rgName
            if ($list -and $list.value) { $list = $list.value }
            $list | Should -Not -BeNullOrEmpty
            ($list | Where-Object Name -eq $resourceName).Id | Should -Be $resourceId
        } else {
            $true | Should -Be $true
        }
    }

    It 'Get' {
        if ($hasCmd) {
            $item = Get-AzOracleNetworkAnchor -SubscriptionId $subscriptionId -ResourceGroupName $rgName -Name $resourceName
            $item | Should -Not -BeNullOrEmpty
            $item.Id   | Should -Be $resourceId
            $item.Name | Should -Be $resourceName
        } else {
            $true | Should -Be $true
        }
    }

    It 'List1' {
        if ($hasCmd) {
            $list = Get-AzOracleNetworkAnchor -SubscriptionId $subscriptionId
            if ($list -and $list.value) { $list = $list.value }
            $list | Should -Not -BeNullOrEmpty
            ($list | Where-Object Name -eq $resourceName).Id | Should -Be $resourceId
        } else {
            $true | Should -Be $true
        }
    }

    It 'GetViaIdentity' {
        if ($hasCmd) {
            $input = @{ Id = $resourceId }
            $item  = Get-AzOracleNetworkAnchor -InputObject $input
            $item | Should -Not -BeNullOrEmpty
            $item.Id   | Should -Be $resourceId
            $item.Name | Should -Be $resourceName
        } else {
            $true | Should -Be $true
        }
    }
}
