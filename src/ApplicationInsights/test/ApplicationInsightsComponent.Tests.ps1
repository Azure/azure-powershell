if(($null -eq $TestName) -or ($TestName -contains 'ApplicationInsightsComponent'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'ApplicationInsightsComponent.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'ApplicationInsightsComponent' {
    It 'Component' {
        $kind = "web";
        $key = "key"
        $val = "val"
        $tag = @{$key=$val}

        New-AzApplicationInsights -ResourceGroupName $env.resourceGroup -Name $env.component1 -Location $env.location -Kind $kind
        $component = Get-AzApplicationInsights -ResourceGroupName $env.resourceGroup -Name $env.component1

        $component.Name | Should -Be $env.component1
        $component.Kind | Should -Be $kind
        $component.InstrumentationKey | Should -Not -BeNullOrEmpty
        $component.PublicNetworkAccessForIngestion | Should -Be "Enabled"
        $component.PublicNetworkAccessForQuery | Should -Be "Enabled"
        Remove-AzApplicationInsights -ResourceGroupName $env.resourceGroup -Name $env.component1
    }
}