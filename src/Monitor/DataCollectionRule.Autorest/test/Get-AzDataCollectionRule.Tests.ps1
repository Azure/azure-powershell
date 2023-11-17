if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDataCollectionRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataCollectionRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDataCollectionRule' {
    It 'List1' {
        {
            $ruleList = Get-AzDataCollectionRule
            $ruleList.Count | Should -BeGreaterThan 1
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $rule = Get-AzDataCollectionRule -ResourceGroupName $env.resourceGroup -Name $env.testCollectionRule1
            $rule.Name | Should -Be $env.testCollectionRule1
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $ruleList2 = Get-AzDataCollectionRule -ResourceGroupName $env.resourceGroup
            $ruleList2.Count | Should -BeGreaterorEqual 1
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $object = "/subscriptions/"+$env.SubscriptionId+"/resourceGroups/"+$env.resourceGroup+"/providers/Microsoft.Insights/dataCollectionRules/"+$env.testCollectionRule1
            $rule2 = Get-AzDataCollectionRule -InputObject $object
            $rule2.Name | Should -Be $env.testCollectionRule1
        } | Should -Not -Throw
    }
}
