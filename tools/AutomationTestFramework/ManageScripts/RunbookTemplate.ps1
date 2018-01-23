Param(
	[parameter(Mandatory=$true)]
	[string] $subscriptionName,
	[parameter(Mandatory=$true)]
	[string] $automationAccountName,
	[parameter(Mandatory=$true)]
	[string] $aaResourseGroupName,
	[parameter(Mandatory=$true)]
	[string] $storageAccountName,
	[parameter(Mandatory=$true)]
	[string] $saResourseGroupName,
	[parameter(Mandatory=$true)]
	[string] $containerName,
	[parameter(Mandatory=$true)]
	[string] $reportFolderPrefix
)

loginWithConnection %CONNECTION-NAME%

%TEST-LIST%

TestRunner $testList

$jobId = $PsPrivateMetaData.JobId.Guid

SaveResultsInStorageAccount `
    -jobId $jobId `
    -subscriptionName $subscriptionName `
    -automationAccountName $automationAccountName `
    -aaResourseGroupName $aaResourseGroupName `
    -storageAccountName $storageAccountName `
    -saResourseGroupName $saResourseGroupName `
    -containerName $containerName `
    -reportFolderPrefix $reportFolderPrefix
    
