if(($null -eq $TestName) -or ($TestName -contains 'New-AzMonitorHealthModelEntity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMonitorHealthModelEntity.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMonitorHealthModelEntity' {
    It 'CreateExpanded' {
        {
            $groups = @(
                @{ Name = 'availability'; AggregationType = 'WorstOf'; Member = @('signal-one', 'signal-two'); IgnoreUnknown = $true }
                @{ Name = 'performance'; AggregationType = 'BestOf'; Member = @('signal-three'); IgnoreUnknown = $false }
            )
            $result = New-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.EntityCreateName -DisplayName 'Create entity' -Impact Standard -HealthObjective 99.5 -SignalAggregationGroup $groups
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.EntityCreateName
            $result.DisplayName | Should -Be 'Create entity'
            $stored = Get-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.EntityCreateName
            foreach ($entity in @($result, $stored)) {
                @($entity.SignalAggregationGroup).Count | Should -Be 2
                foreach ($expected in $groups) {
                    $actual = @($entity.SignalAggregationGroup | Where-Object Name -eq $expected.Name)
                    $actual.Count | Should -Be 1
                    $actual[0].AggregationType | Should -Be $expected.AggregationType
                    $actual[0].IgnoreUnknown | Should -Be $expected.IgnoreUnknown
                    @($actual[0].Member).Count | Should -Be $expected.Member.Count
                    ($actual[0].Member | Sort-Object) -join ',' | Should -Be (($expected.Member | Sort-Object) -join ',')
                }
            }
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
