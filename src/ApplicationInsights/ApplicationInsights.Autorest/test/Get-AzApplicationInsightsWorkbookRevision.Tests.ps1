if(($null -eq $TestName) -or ($TestName -contains 'Get-AzApplicationInsightsWorkbookRevision'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzApplicationInsightsWorkbookRevision.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzApplicationInsightsWorkbookRevision' {
	It 'List' {
		{
			New-AzApplicationInsightsWorkbook -ResourceGroupName $env.resourceGroup -Name $env.workbook01 -Location $env.location  -DisplayName "$($env.myWorkbook01)-pwsh"  `
											-SourceId "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.resourceGroup)/providers/microsoft.insights/components/$($env.appInsights01)" -SerializedData $null

			$workbook = Get-AzApplicationInsightsWorkbookRevision -ResourceGroupName $env.resourceGroup -Name $env.workbook01
			Get-AzApplicationInsightsWorkbookRevision -ResourceGroupName $env.resourceGroup -Name $env.workbook01 -RevisionId $workbook[0].Revision
		} | Should -Not -Throw
	}
}
