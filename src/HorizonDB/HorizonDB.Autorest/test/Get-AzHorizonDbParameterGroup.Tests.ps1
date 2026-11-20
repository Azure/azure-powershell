if(($null -eq $TestName) -or ($TestName -contains 'Get-AzHorizonDbParameterGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzHorizonDbParameterGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzHorizonDbParameterGroup' {
    It 'List' {
        $parameterGroups = @(Get-AzHorizonDbParameterGroup -ResourceGroupName $env.sharedResourceGroup -SubscriptionId $env.SubscriptionId -ErrorAction Stop)
        $matching = @($parameterGroups | Where-Object { $_.Name -eq $env.sharedParameterGroupName })
        $matching.Count | Should -Be 1
        $matching[0].ResourceGroupName | Should -Be $env.sharedResourceGroup
    }

    It 'Get' {
        $parameterGroup = Get-AzHorizonDbParameterGroup -ResourceGroupName $env.sharedResourceGroup -Name $env.sharedParameterGroupName -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $parameterGroup.Name | Should -Be $env.sharedParameterGroupName
        $parameterGroup.ResourceGroupName | Should -Be $env.sharedResourceGroup
        $parameterGroup.Id | Should -Be "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.sharedResourceGroup)/providers/Microsoft.HorizonDb/parameterGroups/$($env.sharedParameterGroupName)"
        $parameterGroup.PostgreSqlVersion | Should -Be '17'
        foreach ($expected in @(Get-HorizonDbTestParameter)) {
            $matching = @($parameterGroup.Parameter | Where-Object { $_.Name -eq $expected.Name })
            $matching.Count | Should -Be 1
            $matching[0].Value | Should -Be $expected.Value
        }
    }

    It 'List1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
