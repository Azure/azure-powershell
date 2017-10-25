
$rpName = "fabric"
$location = pwd
$psswagger = "E:\github\PSswagger"
$module = "TestModule"
. ..\..\..\tools\GeneratePSSwagger.ps1 -RPName $rpName -Location $location -Admin -ModuleDirectory $module -AzureStack -PSSwaggerLocation $psswagger