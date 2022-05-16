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
        "Enabled" | Should -Be $component.PublicNetworkAccessForIngestion
        "Enabled" | Should -Be $component.PublicNetworkAccessForQuery

        $component = Update-AzApplicationInsights -ResourceGroupName $env.resourceGroup -Name $env.component1 -Tag $tag -PublicNetworkAccessForIngestion "Disabled" -PublicNetworkAccessForQuery "Disabled"

        "Disabled" | Should -Be $component.PublicNetworkAccessForIngestion
        "Disabled" | Should -Be $component.PublicNetworkAccessForQuery
        $val | Should -Be $component.Tag[$key]

        Remove-AzApplicationInsights -ResourceGroupName $env.resourceGroup -Name $env.component1
    }
}