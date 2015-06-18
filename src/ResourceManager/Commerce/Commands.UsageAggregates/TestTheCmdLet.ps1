$subscription = <Add subscription ID>

Import-Module C:\GitHub\MyGitHub\azure-powershell\src\Package\Debug\ResourceManager\AzureResourceManager\UsageAggregates\Microsoft.Azure.Commands.UsageAggregates.dll

Add-AzureAccount 

Set-AzureSubscription -SubscriptionId $subscription

$agggregate = get-UsageAggregates -ReportedStartTime "5/2/2015" -ReportedEndTime "5/5/2015"

Write-Host $agggregate.NextLink
Write-Host "Result count: " + $agggregate.UsageAggregations.Count

$agggregate.UsageAggregations | ForEach-Object {
	Write-Host $_.Name
}
