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
    $subscriptionId = 'fd42b73d-5f28-4a23-ae7c-ca08c625fe07'
    $rgName         = 'PowerShellTestRg'
    $resourceName   = 'OFake_PowerShellTestNetworkAnchor'   # <- avoid $name
    $resourceId     = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Oracle.Database/networkAnchors/$resourceName"

    It 'List' {
        $list = Get-AzOracleNetworkAnchor -ResourceGroupName $rgName
        $list | Should -Not -BeNullOrEmpty
        ($list | Where-Object Name -eq $resourceName).Id | Should -Be $resourceId
    }

    It 'Get' {
        $item = Get-AzOracleNetworkAnchor -SubscriptionId $subscriptionId -ResourceGroupName $rgName -Name $resourceName
        $item | Should -Not -BeNullOrEmpty
        $item.Id   | Should -Be $resourceId
        $item.Name | Should -Be $resourceName
    }

    It 'List1' {
        $list = Get-AzOracleNetworkAnchor -SubscriptionId $subscriptionId
        $list | Should -Not -BeNullOrEmpty
        ($list | Where-Object Name -eq $resourceName).Id | Should -Be $resourceId
    }

    It 'GetViaIdentity' {
        $input = @{ Id = $resourceId }
        $item  = Get-AzOracleNetworkAnchor -InputObject $input
        $item | Should -Not -BeNullOrEmpty
        $item.Id   | Should -Be $resourceId
        $item.Name | Should -Be $resourceName
    }
}
