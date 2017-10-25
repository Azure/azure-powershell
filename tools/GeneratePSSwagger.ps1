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
    [System.Version]$Version = "0.1.0"
)

$file="https://github.com/Azure/azure-rest-api-specs/blob/current/specification/azsadmin/resource-manager/$RPName/readme.md"

Invoke-Expression "& autorest $file --version=latest --output-artifact=swagger-document.json --output-folder=$Location"

if($PSSwaggerLocation) {
    $env:PSModulePath = "$PSSwaggerLocation;$env:PSModulePath"    
    Import-Module $PSSwaggerLocation\PSSwagger
} else {
    Import-Module PSSwagger
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
$license = Join-Path $PSScriptRoot -ChildPath "LICENSE.txt"

if(test-path $output) {
    Remove-Item "$output" -Force -Recurse
}
$null = New-Item $output -type directory

New-PSSwaggerModule -SpecificationPath $specPath -Name $namespace  -UseAzureCsharpGenerator -DefaultCommandPrefix Azs -Path $output -Version $Version -Verbose #-Header $license