if(($null -eq $TestName) -or ($TestName -contains 'Get-AzApplicationInsightsMyWorkbook'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzApplicationInsightsMyWorkbook.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzApplicationInsightsMyWorkbook' {
	It 'List1' {
		{
			Get-AzApplicationInsightsMyWorkbook -Category 'workbook'
		} | Should -Not -Throw
	}

	It 'Get' {
		{
			New-AzApplicationInsightsMyWorkbook -ResourceGroupName $env.resourceGroup -Name $env.myWorkbook01 -Location $env.location  -DisplayName "$($env.myWorkbook01)-pwsh" `
												-SourceId "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.resourceGroup)/providers/microsoft.insights/components/$($env.appInsights01)" -Category 'workbook' -SerializedData $null
			$myWorkbook = Get-AzApplicationInsightsMyWorkbook -ResourceGroupName $env.resourceGroup -Name $env.myWorkbook01
			$myWorkbook.DisplayName = "pwsh01"
			Update-AzApplicationInsightsMyWorkbook -ResourceGroupName $env.resourceGroup -Name $env.myWorkbook01 -WorkbookProperty $myWorkbook
			Remove-AzApplicationInsightsMyWorkbook -ResourceGroupName $env.resourceGroup -Name $env.myWorkbook01
		} | Should -Not -Throw
	}
	It 'List' {
		{
			Get-AzApplicationInsightsMyWorkbook -ResourceGroupName $env.resourceGroup -Category 'workbook'
		} | Should -Not -Throw
	}
}
