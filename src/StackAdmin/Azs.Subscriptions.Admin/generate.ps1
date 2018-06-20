
$rpName = "subscriptions"
$name = "Subscriptions"
$location = Get-Location
$psswagger = "D:\github\PSswagger"
$module = "Module"
$namespace = "Microsoft.AzureStack.Management.$name.Admin"
$assembly = "$namespace.dll"
$client = "$namespace.$($name)AdminClient"

Write-Host $assembly

. ..\..\..\tools\GeneratePSSwagger.ps1 `
    -RPName $rpName `
    -Location $location `
    -Admin `
    -ModuleDirectory $module `
    -AzureStack `
    -PSSwaggerLocation $psswagger `
    -GithubAccount bganapa `
    -GithubBranch stack-admin `
    -PredefinedAssemblies $assembly `
    -Name $name `
    -ClientTypeName $client `
    -GenerateSwagger:$true
