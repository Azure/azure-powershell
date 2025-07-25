if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDataCollectionRuleAssociation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDataCollectionRuleAssociation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDataCollectionRuleAssociation' {
    It 'UpdateExpanded' {
        {
            Update-AzDataCollectionRuleAssociation -AssociationName $env.testEndpointAssociation -DataCollectionEndpointId $env.endpointId -ResourceUri $env.VMId -Description "monitor test VM endpoint association"
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        {
            $association = Get-AzDataCollectionRuleAssociation -ResourceUri $env.VMId -AssociationName $env.testAssociation2
            Update-AzDataCollectionRuleAssociation -InputObject $association -Description "test VM AMCS association"
        } | Should -Not -Throw
    }
}
