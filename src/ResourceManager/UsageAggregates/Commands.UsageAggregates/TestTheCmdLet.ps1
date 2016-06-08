# sample script to help the developer verify changes using PowerShell and importing the dll.
$subscription = "<Add subscription ID>"

Import-Module "<path to>"Microsoft.Azure.Commands.UsageAggregates.dll

Add-AzureRmAccount 

Set-AzureRmSubscription -SubscriptionId $subscription

$agggregate = get-UsageAggregates -ReportedStartTime "5/2/2015" -ReportedEndTime "5/5/2015"

Write-Host $agggregate.NextLink
Write-Host "Result count: " + $agggregate.UsageAggregations.Count

$agggregate.UsageAggregations | ForEach-Object {
	Write-Host $_.Name
}
