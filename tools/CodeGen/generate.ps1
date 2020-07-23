param([switch]$Isolated)

$ErrorActionPreference = 'Stop'

if($PSEdition -ne 'Core') {
    Write-Error 'This script requires PowerShell Core to execute. [Note] Generated cmdlets will work in both PowerShell Core or Windows PowerShell.'
}

$generate_info = @{}

if(-not $Isolated) {
    Write-Host -ForegroundColor Green 'Creating isolated process...'
    $pwsh = [System.Diagnostics.Process]::GetCurrentProcess().Path
    & "$pwsh" -NoExit -NoLogo -NoProfile -File $MyInvocation.MyCommand.Path @PSBoundParameters -Isolated
    return
}

# Get the latest commit id of the swagger master branch 
$repo = "https://github.com/Azure/azure-rest-api-specs"
$commit = git ls-remote $repo HEAD
$generate_info.Add("swagger_commit", $commit.Substring(0, 40))

$srcDir = Get-Location
Set-Location $srcDir

$moduleName = (Get-Item -Path ./).BaseName

Write-Host -ForegroundColor Green "Clean old extenstions"
$null = autorest-beta --reset
Write-Host -ForegroundColor Green "Extensions cleaning is completed"

Write-Host -ForegroundColor Green "Start to generate code with latest extensions"
$null = autorest-beta
$null = ./build-module.ps1
Write-Host -ForegroundColor Green "Code generation is completed"

Write-Host -ForegroundColor Green "Start post-generation $moduleName"
if (Test-Path -Path ../artifacts/$moduleName)
{
    rm -r ../artifacts/$moduleName
}
mkdir ../artifacts/$moduleName
$null = cp .\examples,.\custom,.\exports,.\generated,.\internal,.\test,Az.$moduleName.format.ps1xml,Az.$moduleName.psd1,Az.$moduleName.psm1,build-module.ps1,check-dependencies.ps1,export-surface.ps1,generate-help.ps1,how-to.md,MSSharedLibKey.snk,pack-module.ps1,readme.md,run-module.ps1,test-module.ps1 -Recurse  -Destination ../artifacts/$moduleName
$null = cp -r docs -Exclude docs/readme.md ../artifacts/$moduleName/help
$null = rm ../artifacts/$moduleName/help/readme.md
$null = rm -r ../artifacts/$moduleName/generated/modules
#$null = git stash
#$null = git checkout master
Write-Host -ForegroundColor Green "Post-generation is completed"

Write-Host -ForegroundColor Green "Start to collect generation tool chain info"

# Get node version
$generate_info.Add("node", (node --version))

# Get autorest version
$autorest_info = (npm ls -g @autorest/autorest).Split('@')
$generate_info.Add("autorest", ($autorest_info[$autorest_info.count - 2]).trim())

# Get autorest/core version
$extensions = ls ~/.autorest

ForEach ($ex in $extensions) {
    $info = $ex.Name.Split('@')
    $generate_info.Add($info[1], $info[2])
}

set-content -Path (Join-Path ../artifacts/$moduleName generate-info.json) -Value (ConvertTo-Json $generate_info)

Write-Host -ForegroundColor Green "Tool chain info collection is completed. Do remember to check-in the file generate-info.json"