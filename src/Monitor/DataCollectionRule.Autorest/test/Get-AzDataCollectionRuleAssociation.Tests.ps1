if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDataCollectionRuleAssociation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataCollectionRuleAssociation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDataCollectionRuleAssociation' {
    It 'List' {
        {
            $association = Get-AzDataCollectionRuleAssociation -ResourceUri $env.VMId
            $association.Count | Should -BeGreaterorEqual 1
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $association = Get-AzDataCollectionRuleAssociation -ResourceUri $env.VMId -AssociationName $env.testAssociation2
            $association.Name | Should -Be $env.testAssociation2
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List1' {
        {
            $association = Get-AzDataCollectionRuleAssociation -ResourceGroupName $env.resourceGroup2 -DataCollectionRuleName $env.testCollectionRule2
            $association.Name | Should -Be $env.testAssociation2
        } | Should -Not -Throw
    }

    It 'List2' {
        {
            $association = Get-AzDataCollectionRuleAssociation -ResourceGroupName $env.resourceGroup -DataCollectionEndpointName $env.testCollectionEndpoint
            $association.Name | Should -Be $env.testEndpointAssociation
        } | Should -Not -Throw
    }
}
