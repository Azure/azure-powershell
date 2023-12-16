if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDataCollectionEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataCollectionEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDataCollectionEndpoint' {
    It 'List1' {
        {
            $ruleList = Get-AzDataCollectionEndpoint
            $ruleList.Count | Should -BeGreaterThan 1
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $rule = Get-AzDataCollectionEndpoint -ResourceGroupName $env.resourceGroup -Name $env.testCollectionEndpoint
            $rule.Name | Should -Be $env.testCollectionEndpoint
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $ruleList2 = Get-AzDataCollectionEndpoint -ResourceGroupName $env.resourceGroup
            $ruleList2.Count | Should -BeGreaterorEqual 1
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $object = "/subscriptions/"+$env.SubscriptionId+"/resourceGroups/"+$env.resourceGroup+"/providers/Microsoft.Insights/dataCollectionEndpoints/"+$env.testCollectionEndpoint
            $rule2 = Get-AzDataCollectionEndpoint -InputObject $object
            $rule2.Name | Should -Be $env.testCollectionEndpoint
        } | Should -Not -Throw
    }
}
