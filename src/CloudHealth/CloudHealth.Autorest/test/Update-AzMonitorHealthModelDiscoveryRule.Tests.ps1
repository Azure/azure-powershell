if(($null -eq $TestName) -or ($TestName -contains 'Update-AzMonitorHealthModelDiscoveryRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMonitorHealthModelDiscoveryRule.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzMonitorHealthModelDiscoveryRule' {
    It 'UpdateExpanded' {
        {
            $specification = New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where type =~ 'microsoft.compute/virtualmachines' | project id | take 1"
            $property = New-AzMonitorHealthModelDiscoveryRulePropertiesObject -AuthenticationSetting $env.AuthenticationSettingName -AddRecommendedSignal Enabled -AddResourceHealthSignal Enabled -DiscoverRelationship Disabled -DisplayName 'Updated discovery rule' -Specification $specification
            $result = Update-AzMonitorHealthModelDiscoveryRule -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.DiscoveryRuleName -Property $property
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.DiscoveryRuleName
            ($result | ConvertTo-Json -Depth 20) | Should -Match 'Updated discovery rule'
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityHealthmodelExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
