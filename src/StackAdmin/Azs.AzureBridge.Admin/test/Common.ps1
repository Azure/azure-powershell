$global:SkippedTests = @(
    "TestDownloadAzsAzureBridgeProductPipeline",
    "TestRemoveAzsAzureBridgeDownloadedProduct",
    "TestRemoveAzsAzureBridgeDownloadedProductPipeline"
)

$global:Provider = "Microsoft.AzureBridge.Admin"

$global:ActivationName = "default"
$global:ResourceGroupName = "azurestack-activation"
$global:ProductName1 = "microsoft.windowsserver2016datacenter-arm-2016.127.20171216"
$global:DProductName1 = "canonical.ubuntuserver1804lts-arm-18.04.20180911"
$global:ProductName2 = "microsoft.docker-arm.1.1.0"

$global:Client = $null

if (Test-Path "$PSScriptRoot\Override.ps1") {
    . $PSScriptRoot\Override.ps1
}