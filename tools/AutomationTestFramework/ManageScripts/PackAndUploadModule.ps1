
. "$PSScriptRoot\DeliverModuleToAutomationAccount.ps1"

<#
.SYNOPSIS
Zips files and uplod as module to Azure Automation Account
.PARAMETER path
Path to directory with files to pack
.PARAMETER files
List of files to pack
.PARAMETER moduleName
Resulting ZIP archive name and the name of uploaded module on Automation Account
.EXAMPLE
PackAndUploadModule -path "d:\tmp -files @(mymodule.psm1, myscript.ps1)" -moduleName 'mymodule'
#>
function PackAndUploadModule ([string] $path, [string[]] $files, [string] $moduleName) {

    #$files
    $src = $files | ForEach-Object { Join-Path $path $_}
    $dst =  Join-Path $path "$moduleName.zip"
    if (Test-Path $dst) {
            Remove-Item $dst -ErrorAction Stop
    }
    Write-Host "Creating ZIP..." -ForegroundColor Green
    Compress-Archive -LiteralPath $src -DestinationPath $dst -ErrorAction Stop

    DeliverModuleToAutomationAccount `
        -modulePath $path `
        -moduleName $moduleName
}