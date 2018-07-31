$ErrorActionPreference = "Stop"
$scriptpath = $MyInvocation.MyCommand.Path
$scriptDirectory = Split-Path $scriptpath
$scriptFileName = Split-Path $scriptpath -Leaf


function prompt 
{ 
    Write-Host "[$((Get-Location).Path)]"
    Write-Host "StorageSyncDevOps " -NoNewLine -foreground White
    "PS> "
}

function reload
{
    Remove-Module StorageSyncDevOps
    ipmo "$($scriptDirectory)\StorageSyncDevOps.psm1" -DisableNameChecking -Scope Global
}

ipmo "$($scriptDirectory)\StorageSyncDevOps.psm1" -DisableNameChecking -Scope Global