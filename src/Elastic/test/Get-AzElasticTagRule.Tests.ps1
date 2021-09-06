if(($null -eq $TestName) -or ($TestName -contains 'Get-AzElasticTagRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzElasticTagRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzElasticTagRule' {
    It 'List' {
        { 
            Get-AzElasticTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.elasticName01
        } | Should -Not -Throw
    }

    It 'Get' {
        $tagRule = Get-AzElasticTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.elasticName01 -Name default
        $tagRule.Name | Should -Be 'default'
    }

    It 'GetViaIdentity' {
        $tagrule = Get-AzElasticTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.elasticName01 -Name default
        $tagrule = Get-AzElasticTagRule -InputObject $tagrule
        $tagRule.Name | Should -Be 'default'
    }
}
