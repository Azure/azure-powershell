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

$global:Client = $null

if (Test-Path "$PSScriptRoot\Override.ps1") {
    . $PSScriptRoot\Override.ps1
}