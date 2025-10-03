if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOracleResourceAnchor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOracleResourceAnchor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOracleResourceAnchor' {
    $subscriptionId = $env:AZURE_SUBSCRIPTION_ID
    $rgName         = 'PowerShellTestRg'
    $raName         = 'OFake_PowerShellTestResourceAnchor'  # avoid Pester's $Name
    $resourceId     = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Oracle.Database/resourceAnchors/$raName"

    It 'Warmup' {
        # Ensure at least one real HTTP call flows through the AutoRest pipeline so the recorder writes the file
        # Using an existing generated cmdlet that performs a GET
        Get-AzOracleGiVersion -Location 'eastus' | Out-Null
    }

    It 'List' {
        $list = Get-AzOracleResourceAnchor -ResourceGroupName $rgName
        if ($list -and $list.value) { $list = $list.value }  # handle non-flattened playback
        $list | Should -Not -BeNullOrEmpty
        ($list | Where-Object Name -eq $raName).Id | Should -Be $resourceId
    }

    It 'Get' {
        $item = Get-AzOracleResourceAnchor -ResourceGroupName $rgName -Name $raName
        $item | Should -Not -BeNullOrEmpty
        $item.Id   | Should -Be $resourceId
        $item.Name | Should -Be $raName
    }

    It 'List1' {
        $list = Get-AzOracleResourceAnchor -SubscriptionId $subscriptionId
        if ($list -and $list.value) { $list = $list.value }  # handle non-flattened playback
        $list | Should -Not -BeNullOrEmpty
        ($list | Where-Object Name -eq $raName).Id | Should -Be $resourceId
    }

    It 'GetViaIdentity' {
        $input = @{ Id = $resourceId }
        $item  = Get-AzOracleResourceAnchor -InputObject $input
        $item | Should -Not -BeNullOrEmpty
        $item.Id   | Should -Be $resourceId
        $item.Name | Should -Be $raName
    }
}
