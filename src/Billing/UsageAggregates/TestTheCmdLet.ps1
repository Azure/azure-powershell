# sample script to help the developer verify changes using PowerShell and importing the dll.
$subscription = "<Add subscription ID>"

Import-Module "<path to>"Microsoft.Azure.Commands.UsageAggregates.dll

Connect-AzureRmAccount 

Set-AzureRmSubscription -SubscriptionId $subscription

$aggregate = get-UsageAggregates -ReportedStartTime "5/2/2015" -ReportedEndTime "5/5/2015"

Write-Host $aggregate.NextLink
Write-Host "Result count: " + $aggregate.UsageAggregations.Count

$aggregate.UsageAggregations | ForEach-Object {
	Write-Host $_.Name
}
