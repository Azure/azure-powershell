if(($null -eq $TestName) -or ($TestName -contains 'Update-AzApplicationInsightsWebTestTag'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzApplicationInsightsWebTestTag.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzApplicationInsightsWebTestTag' {
    It 'UpdateExpanded' {
        $webTest = Update-AzApplicationInsightsWebTestTag -ResourceGroup $env.resourceGroup -Name $env.standardWebTest01 -Tag @{"hidden-link:$($env.appInsights02Id)" = "Resource"}
        $webTest.Tag.ContainsKey("hidden-link:$($env.appInsights02Id)") | Should -BeTrue
    }

    It 'UpdateViaIdentityExpanded' {
        $webTest = Get-AzApplicationInsightsWebTest -ResourceGroup $env.resourceGroup -Name $env.standardWebTest01 
        $webTest = Update-AzApplicationInsightsWebTestTag -InputObject $webTest -Tag @{"hidden-link:$($env.appInsights01Id)" = "Resource"}
        $webTest.Tag.ContainsKey("hidden-link:$($env.appInsights01Id)") | Should -BeTrue
    }
}
