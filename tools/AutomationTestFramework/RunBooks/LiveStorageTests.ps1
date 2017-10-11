loginWithConnection -connectionName "AzureRunAsConnection"
# from StorageAccountTests.ps1
$StorageAccountTests = @(
	 'Test-GetAzureStorageAccount'
	,'Test-NewAzureStorageAccount'
	,'Test-SetAzureStorageAccount'
	,'Test-StorageAccount'
)
$testList =
	$StorageAccountTests
TestRunner $testList
