
$rpName = "subscription"
$name = "Subscription"
$location = Get-Location
$psswagger = "D:\github\PSswagger"
$module = "Module"
$namespace = "Microsoft.AzureStack.Management.$name"
$assembly = "$namespace.dll"
$client = "$namespace.$($name)ManagementClient"

Write-Host $assembly

. ..\..\..\tools\GeneratePSSwagger.ps1 `
    -RPName $rpName `
    -Location $location `
    -ModuleDirectory $module `
    -AzureStack `
    -PSSwaggerLocation $psswagger `
    -GithubAccount bganapa `
    -GithubBranch stack-admin `
    -PredefinedAssemblies $assembly `
    -Name $name `
    -ClientTypeName $client `
    -GenerateSwagger:$false
