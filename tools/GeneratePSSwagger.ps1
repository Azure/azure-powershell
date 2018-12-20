<#
.DESCRIPTION
Create PSSwagger based modules.

.PARAMETER RPName
The name of the resource provider located in azure-rest-api-specs.  This name is used to form your module name using the format "Azs.$RPName" or "Azs.$RPName.Admin" if Admin is selected.

.PARAMETER Location
The root directory where output is produced.

.PARAMETER Admin
Designates that the output is an admin module.

.PARAMETER PSSwaggerFolderPath
If using a custom PSSwagger tool provide the location.  If not provided we attempt to import the PSSwagger module.

.PARAMETER Name
The name of your module.  If this is left blank we use the RPName.

.PARAMETER ModuleDirectory
The name of the output directory the module is placed.

#>
param(
    [Parameter(Mandatory=$true)]
    [ValidateNotNullOrEmpty()]
    [System.String]$RPName,
    
    [Parameter(Mandatory=$true)]
    [ValidateNotNullOrEmpty()]
    [System.String]$Location,
    
    [ValidateNotNullOrEmpty()]
    [System.String]$PSSwaggerLocation = $null,
    
    [switch]$Admin,

    [switch]$AzureStack,

    [ValidateNotNullOrEmpty()]
    [System.String]$Name,
    
    [ValidateNotNullOrEmpty()]
    [System.String]$ModuleDirectory = "Module",
    
    [ValidateNotNullOrEmpty()]
    [System.Version]$Version = "0.1.0",

    [ValidateNotNullOrEmpty()]
    [System.String]$GithubAccount = "Azure",

    [ValidateNotNullOrEmpty()]
    [System.String]$GithubBranch = "current",

    [ValidateNotNullOrEmpty()]
    [System.String]
    $PredefinedAssemblies,

    [ValidateNotNullOrEmpty()]
    [System.String]
    $ClientTypeName,
    
    [switch]$GenerateSwagger
)

if($GenerateSwagger) {
    $file="https://github.com/$GithubAccount/azure-rest-api-specs/blob/$GithubBranch/specification/azsadmin/resource-manager/$RPName/readme.md"
    Invoke-Expression "& autorest $file --version=latest --output-artifact=swagger-document.json --output-folder=$Location"
}

if($PSSwaggerLocation) {
    $clone = $env:PSModulePath.Clone()
    try {
        $env:PSModulePath = "$PSSwaggerLocation;$env:PSModulePath"
        $env:PSModulePath = "$PSSwaggerLocation\PSSwagger;$env:PSModulePath"
        Import-Module PSSwagger -Force
    } finally {
        $env:PSModulePath = $clone
    }
} else {
    Import-Module PSSwagger -Force
}

if(-not $Name) {
    $Name = $RPName
}

$postfix = ""
$prefix = "Az."

if($Admin) {
    $postFix = ".Admin"
}

if($AzureStack) {
    $preFix = "Azs."
}

$RPName = $RPName.Substring(0,1).ToUpper() + $RPName.Substring(1);

$specPath = Join-Path $Location -ChildPath "$Name.json"
$namespace = "$prefix$RPName$postfix"
$output = Join-Path $Location -ChildPath $ModuleDirectory

New-PSSwaggerModule `
    -SpecificationPath $specPath `
    -Path $output `
    -AssemblyFileName $PredefinedAssemblies `
    -ClientTypeName $clientTypeName `
    -Name $namespace `
    -Version $Version `
    -NoVersionFolder `
    -UseAzureCsharpGenerator `
    -Header MICROSOFT_MIT_NO_CODEGEN `
    -Verbose `
    -CopyUtilityModuleToOutput `
    -Debug