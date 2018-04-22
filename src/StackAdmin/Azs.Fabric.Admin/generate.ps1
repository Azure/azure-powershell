
$rpName = "fabric"
$name = "Fabric"
$location = Get-Location
$psswagger = "C:\work\PSSwagger"
$module = "TestModule"
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
    -GithubAccount deathly809 `
    -GithubBranch azs.$rpname.admin `
    -PredefinedAssemblies $assembly `
    -Name $name `
    -ClientTypeName $client `
    -GenerateSwagger:$true
