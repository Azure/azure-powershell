if(($null -eq $TestName) -or ($TestName -contains 'Get-AzChangeSafetyStageMap'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzChangeSafetyStageMap.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzChangeSafetyStageMap' {
    It 'Get - By name in resource group' {
        {
            # Use hardcoded deterministic name
            $stageMapName = "test-stagemap-get-f5v8dm"
            
            # Create a StageMap first to ensure it exists
            $stages = @(
                @{ name = "canary"; sequence = 1 }
                @{ name = "production"; sequence = 2 }
            )
            New-AzChangeSafetyStageMap -Name $stageMapName `
                -ResourceGroupName $env.ResourceGroupName `
                -Stage $stages -ErrorAction SilentlyContinue
            
            $result = Get-AzChangeSafetyStageMap -Name $stageMapName `
                -ResourceGroupName $env.ResourceGroupName
            $result | Should -Not -Be $null
            $result.Name | Should -Be $stageMapName
        } | Should -Not -Throw
    }

    It 'List - All in resource group' {
        {
            $result = Get-AzChangeSafetyStageMap -ResourceGroupName $env.ResourceGroupName
            $result | Should -Not -Be $null
            $result.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }

    It 'List - All in subscription' {
        {
            $result = Get-AzChangeSafetyStageMap
            $result | Should -Not -Be $null
        } | Should -Not -Throw
    }
}
