if(($null -eq $TestName) -or ($TestName -contains 'Get-AzApplicationInsightsWorkbook'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzApplicationInsightsWorkbook.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzApplicationInsightsWorkbook' {
	It 'List' {
		{
			Get-AzApplicationInsightsWorkbook -Category 'workbook'
		} | Should -Not -Throw
	}

	It 'Get' {
		{
			New-AzApplicationInsightsWorkbook -ResourceGroupName $env.resourceGroup -Name $env.workbook01 -Location $env.location  -DisplayName "$($env.myWorkbook01)-pwsh"  `
											-SourceId "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.resourceGroup)/providers/microsoft.insights/components/$($env.appInsights01)" -SerializedData $null
			Get-AzApplicationInsightsWorkbook -ResourceGroupName $env.resourceGroup -Name $env.workbook01
			Update-AzApplicationInsightsWorkbook -ResourceGroupName $env.resourceGroup -Name $env.workbook01 -DisplayName "$($env.myWorkbook01)-pwshnew"
			Remove-AzApplicationInsightsWorkbook -ResourceGroupName $env.resourceGroup -Name $env.workbook01
		} | Should -Not -Throw
	}

	It 'GetViaIdentity' {
		{
			$workbook = New-AzApplicationInsightsWorkbook -ResourceGroupName $env.resourceGroup -Name $env.workbook01 -Location $env.location  -DisplayName "$($env.myWorkbook01)-pwsh"  `
											-SourceId "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.resourceGroup)/providers/microsoft.insights/components/$($env.appInsights01)" -SerializedData $null
			Get-AzApplicationInsightsWorkbook -InputObject $workbook
			Update-AzApplicationInsightsWorkbook -InputObject $workbook -DisplayName "$($env.myWorkbook01)-pwshnew"
			Remove-AzApplicationInsightsWorkbook -InputObject $workbook
		} | Should -Not -Throw
	}

	It 'List1' {
		{
			Get-AzApplicationInsightsWorkbook -ResourceGroupName $env.resourceGroup -Category 'workbook'
		} | Should -Not -Throw
	}
}
