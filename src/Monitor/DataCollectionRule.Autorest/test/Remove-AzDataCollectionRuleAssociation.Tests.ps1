if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDataCollectionRuleAssociation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDataCollectionRuleAssociation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDataCollectionRuleAssociation' {
    It 'Delete' {
        {
            Remove-AzDataCollectionRuleAssociation -AssociationName $env.testAssociation1 -ResourceUri $env.VMId
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        {
            $association = New-AzDataCollectionRuleAssociation -AssociationName $env.testAssociation1 -ResourceUri $env.VMId -DataCollectionRuleId $env.ruleID
            Remove-AzDataCollectionRuleAssociation -InputObject $association
        } | Should -Not -Throw
    }
}
