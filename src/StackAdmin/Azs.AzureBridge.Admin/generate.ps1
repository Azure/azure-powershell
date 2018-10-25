$rpName = "azurebridge"
$name = "AzureBridge"
$location = Get-Location
$psswagger = "E:\github\PSswagger"
$module = "TestModule"
$namespace = "Microsoft.AzureStack.Management.$Name.Admin"
$assembly = "$namespace.dll"
$client = "$namespace.AzureBridgeAdminClient"

. ../../../tools/GeneratePSSwagger.ps1 `
    -RPName $rpName `
    -Location $location `
    -Admin `
    -ModuleDirectory $module `
    -AzureStack `
    -PSSwaggerLocation $psswagger `
    -GithubAccount Microsoft `
    -GithubBranch stack-admin `
    -PredefinedAssemblies $assembly `
    -Name $name `
    -ClientTypeName $client
