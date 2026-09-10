if(($null -eq $TestName) -or ($TestName -contains 'Update-AzMonitorHealthModelEntity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMonitorHealthModelEntity.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzMonitorHealthModelEntity' {
    It 'UpdateExpanded' {
        {
            $groups = @(
                @{ Name = 'availability'; AggregationType = 'WorstOf'; Member = @('signal-one', 'signal-two'); IgnoreUnknown = $true }
                @{ Name = 'performance'; AggregationType = 'BestOf'; Member = @('signal-three'); IgnoreUnknown = $false }
            )
            Update-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.EntityName -SignalAggregationGroup $groups | Out-Null
            $before = Get-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.EntityName
            @($before.SignalAggregationGroup).Count | Should -Be 2

            $updatedGroups = @(
                @{ Name = 'availability'; AggregationType = 'BestOf'; Member = @('signal-one', 'signal-two', 'signal-three'); IgnoreUnknown = $false }
            )
            $result = Update-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.EntityName -DisplayName 'Shared entity updated' -HealthObjective 99.7 -Impact Standard -SignalAggregationGroup $updatedGroups
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.EntityName
            $result.DisplayName | Should -Be 'Shared entity updated'
            $stored = Get-AzMonitorHealthModelEntity -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.EntityName
            foreach ($entity in @($result, $stored)) {
                @($entity.SignalAggregationGroup).Count | Should -Be 1
                $actual = @($entity.SignalAggregationGroup | Where-Object Name -eq $updatedGroups[0].Name)
                $actual.Count | Should -Be 1
                $actual[0].AggregationType | Should -Be $updatedGroups[0].AggregationType
                $actual[0].IgnoreUnknown | Should -Be $false
                @($actual[0].Member).Count | Should -Be 3
                ($actual[0].Member | Sort-Object) -join ',' | Should -Be (($updatedGroups[0].Member | Sort-Object) -join ',')
            }
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityHealthmodelExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
