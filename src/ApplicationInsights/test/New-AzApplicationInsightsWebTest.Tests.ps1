if(($null -eq $TestName) -or ($TestName -contains 'New-AzApplicationInsightsWebTest'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzApplicationInsightsWebTest.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzApplicationInsightsWebTest' {
    It 'CreateStandard' {
        $geoLocation = @()
        $geoLocation += New-AzApplicationInsightsWebTestGeolocationObject -Location $env.geoLocation01
        $geoLocation += New-AzApplicationInsightsWebTestGeolocationObject -Location $env.geoLocation02
        $webtest = New-AzApplicationInsightsWebTest -ResourceGroup $env.resourceGroup -Name $env.standardWebTest02 -Location $env.location `
        -Tag @{"hidden-link:$($env.appInsights01Id)" = "Resource"} `
        -RequestUrl "https://learn.microsoft.com/" -RequestHttpVerb "GET" -TestName $env.standardWebTest02 `
        -RuleExpectedHttpStatusCode 200 -Frequency 300 -Enabled -Timeout 120 -Kind 'standard' -RetryEnabled -GeoLocation $geoLocation
        $webtest.ProvisioningState | Should -Be 'Succeeded'

        Remove-AzApplicationInsightsWebTest -ResourceGroup $env.resourceGroup -Name $env.standardWebTest02
        $webtestList = Get-AzApplicationInsightsWebTest -ResourceGroup $env.resourceGroup
        $webtestList.Name | Should -Not -Contain $env.standardWebTest02
    }

    It 'CreatePing' {
        $geoLocation = @()
        $geoLocation += New-AzApplicationInsightsWebTestGeolocationObject -Location $env.geoLocation01
        $geoLocation += New-AzApplicationInsightsWebTestGeolocationObject -Location $env.geoLocation02
        $webtest = New-AzApplicationInsightsWebTest -ResourceGroup $env.resourceGroup -Name $env.basicWebTest03 -Location $env.location `
        -Tag @{"hidden-link:$($env.appInsights01Id)" = "Resource"} `
        -RequestUrl "https://learn.microsoft.com/" -TestName $env.basicWebTest03 `
        -RuleExpectedHttpStatusCode 200 -Frequency 300 -Enabled -Timeout 120 -Kind 'ping' -RetryEnabled -GeoLocation $geoLocation
        $webtest.ProvisioningState | Should -Be 'Succeeded'

        Remove-AzApplicationInsightsWebTest -InputObject $webtest
        $webtestList = Get-AzApplicationInsightsWebTest -ResourceGroup $env.resourceGroup
        $webtestList.Name | Should -Not -Contain $env.basicWebTest03
    }
}
