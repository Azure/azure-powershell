
$rpName = "InfrastructureInsights"
$location = pwd
$psswagger = "E:\github\PSswagger"
$module = "Module"
. ..\..\..\tools\GeneratePSSwagger.ps1 -RPName $rpName -Location $location -Admin -ModuleDirectory $module -AzureStack -PSSwaggerLocation $psswagger