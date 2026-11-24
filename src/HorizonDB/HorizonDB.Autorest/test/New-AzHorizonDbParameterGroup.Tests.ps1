if(($null -eq $TestName) -or ($TestName -contains 'New-AzHorizonDbParameterGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzHorizonDbParameterGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzHorizonDbParameterGroup' {
    It 'CreateExpanded' {
        $parameters = @(Get-HorizonDbTestParameter)
        $parameterGroup = New-AzHorizonDbParameterGroup -ResourceGroupName $env.clusterResourceGroup -Name $env.newParameterGroupName -SubscriptionId $env.SubscriptionId -Location $env.location -PostgreSqlVersion '17' -Tag @{ environment = 'production' } -Description 'Parameters for production transactional workloads' -Parameter $parameters -ErrorAction Stop

        $parameterGroup.Name | Should -Be $env.newParameterGroupName
        $parameterGroup.ResourceGroupName | Should -Be $env.clusterResourceGroup
        $parameterGroup.Id | Should -Be "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.clusterResourceGroup)/providers/Microsoft.HorizonDb/parameterGroups/$($env.newParameterGroupName)"
        $parameterGroup.Type | Should -Be 'Microsoft.HorizonDb/parameterGroups'
        $parameterGroup.Location | Should -Be $env.location
        $parameterGroup.PostgreSqlVersion | Should -Be '17'
        $parameterGroup.Tag['environment'] | Should -Be 'production'
        $parameterGroup.Description | Should -Be 'Parameters for production transactional workloads'
        foreach ($expected in $parameters) {
            $matching = @($parameterGroup.Parameter | Where-Object { $_.Name -eq $expected.Name })
            $matching.Count | Should -Be 1
            $matching[0].Value | Should -Be $expected.Value
        }
    }

    It 'Delete' {
        $parameterGroupName = $env.newParameterGroupName + '-delete'
        $parameterGroup = New-AzHorizonDbParameterGroup -ResourceGroupName $env.clusterResourceGroup -Name $parameterGroupName -SubscriptionId $env.SubscriptionId -Location $env.location -PostgreSqlVersion '17' -Parameter @(Get-HorizonDbTestParameter) -ErrorAction Stop
        $parameterGroup.Name | Should -Be $parameterGroupName

        $removed = Remove-AzHorizonDbParameterGroup -ResourceGroupName $env.clusterResourceGroup -Name $parameterGroupName -SubscriptionId $env.SubscriptionId -PassThru -Confirm:$false -ErrorAction Stop
        $removed | Should -Be $true

        $parameterGroups = @(Get-AzHorizonDbParameterGroup -ResourceGroupName $env.clusterResourceGroup -SubscriptionId $env.SubscriptionId -ErrorAction Stop)
        @($parameterGroups | Where-Object { $_.Name -eq $parameterGroupName }).Count | Should -Be 0
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
