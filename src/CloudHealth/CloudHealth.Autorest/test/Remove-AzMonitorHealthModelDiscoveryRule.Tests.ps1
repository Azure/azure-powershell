if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzMonitorHealthModelDiscoveryRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMonitorHealthModelDiscoveryRule.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzMonitorHealthModelDiscoveryRule' {
    It 'Delete' {
        {
            $specification = New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where isnotempty(id) | project id | take 1"
            New-AzMonitorHealthModelDiscoveryRule -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.DiscoveryRuleDeleteName -AuthenticationSetting $env.AuthenticationSettingName -AddRecommendedSignal Enabled -AddResourceHealthSignal Disabled -DiscoverRelationship Disabled -DisplayName 'Delete discovery rule' -Specification $specification | Out-Null
            $deleted = Remove-AzMonitorHealthModelDiscoveryRule -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.DiscoveryRuleDeleteName -PassThru
            $deleted | Should -BeTrue
            { Get-AzMonitorHealthModelDiscoveryRule -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.DiscoveryRuleDeleteName -ErrorAction Stop } | Should -Throw
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityHealthmodel' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
