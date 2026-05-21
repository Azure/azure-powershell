if(($null -eq $TestName) -or ($TestName -contains 'Set-AzStorageAdvancedPlatformMetric'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzStorageAdvancedPlatformMetric.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzStorageAdvancedPlatformMetric' {
    It 'CreateUpdateGetRemove-AdvancedPlatformMetric' {
        $apt = Set-AzStorageAdvancedPlatformMetric -ResourceGroupName $env.ResourceGroupName -AccountName $env.AptAccount -RuleConfigFilterType AllContainersFilter  -Enabled
        $apt.RuleConfigFilterType | Should -Be "AllContainersFilter"
        $apt.RuleConfigFilterValue | Should -BeNullOrEmpty 
        $apt.Enabled | Should -be $true

        $apt = Set-AzStorageAdvancedPlatformMetric -ResourceGroupName $env.ResourceGroupName -AccountName $env.AptAccount -RuleConfigFilterType ContainerPrefixFilter -RuleConfigFilterValue "logs","data"  -Enabled 
        $apt.RuleConfigFilterType | Should -Be "ContainerPrefixFilter"
        $apt.RuleConfigFilterValue | Should -Be "logs","data"
        $apt.Enabled | Should -be $true

        $apt = Set-AzStorageAdvancedPlatformMetric -ResourceGroupName $env.ResourceGroupName -AccountName $env.AptAccount -RuleConfigFilterType ContainerListFilter -RuleConfigFilterValue "container1","container2","container3"
        $apt.RuleConfigFilterType | Should -Be "ContainerListFilter"
        $apt.RuleConfigFilterValue | Should -Be "container1","container2","container3"
        $apt.Enabled | Should -be $false

        $apt = Get-AzStorageAdvancedPlatformMetric -ResourceGroupName $env.ResourceGroupName -AccountName $env.AptAccount
        $apt.RuleConfigFilterType | Should -Be "ContainerListFilter"
        $apt.RuleConfigFilterValue | Should -Be "container1","container2","container3"
        $apt.Enabled | Should -be $false

         Remove-AzStorageAdvancedPlatformMetric -ResourceGroupName $env.ResourceGroupName -AccountName $env.AptAccount
    }
}
