
$rpName = "infrastructureinsights"
$name = "InfrastructureInsights"
$location = Get-Location
$psswagger = "E:\github\PSswagger"
$module = "Module"
$namespace = "Microsoft.AzureStack.Management.$Name.Admin"
$assembly = "$namespace.dll"
$client = "$namespace.$($name)AdminClient"

. ..\..\..\tools\GeneratePSSwagger.ps1 `
    -RPName $rpName `
    -Location $location `
    -Admin `
    -ModuleDirectory $module `
    -AzureStack `
    -PSSwaggerLocation $psswagger `
    -GithubAccount Azure `
    -GithubBranch master `
    -PredefinedAssemblies $assembly `
    -Name $name `
    -ClientTypeName $client
