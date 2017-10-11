. "$PSScriptRoot\PackAndUploadModule.ps1"

<#
ZIPs specified files and upload to Automation Account as module 
.PARAMETER path
Path to the folder where test helpers are located. 
If not specified, uses ..\TestHelper folder
.PARAMETER files
Parameter description
List of files to be added to the module.
If not specified, adds all the files from the $path folder
#>
function GenerateAndUploadTestHelperModule([string]$path, [string[]]$files) {

    $moduleName = "TestHelpers"
    
    if(!$path) {
        $path = Join-Path $PSScriptRoot "..\TestHelpers"
    }

    if (!$files -or $files.Count -eq 0) {
        $files = Get-ChildItem $path -Filter "*.ps*"
    }

    PackAndUploadModule -path $path -files $files -moduleName $moduleName

    CheckModuleProvisionState -moduleList $moduleName
}