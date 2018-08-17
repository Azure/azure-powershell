
# Test Variables
$global:SkippedTests = @(
    "TestDownloadAzsAzureBridgeProductPipeline",
    "TestRemoveAzsAzureBridgeDownloadedProduct",
    "TestRemoveAzsAzureBridgeDownloadedProductPipeline"
)

$global:Provider = "Microsoft.AzureBridge.Admin"

$global:ActivationName = "default"
$global:ResourceGroupName = "azurestack-activation"
$global:ProductName1 = "Canonical.UbuntuServer1710-ARM.1.0.6"
$global:ProductName2 = "microsoft.docker-arm.1.1.0"

# Run using mocked client
if(-not $RunRaw) {
	$scriptBlock = {
		Get-MockClient -ClassName 'AzureBridgeAdminClient' -TestName $global:TestName -Verbose
	}
	Mock New-ServiceClient $scriptBlock -ModuleName $global:ModuleName
}

if (Test-Path "$PSScriptRoot\Override.ps1") {
    . $PSScriptRoot\Override.ps1
}

