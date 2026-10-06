# ----------------------------------------------------------------------------------
#
# Session-local helper (NOT part of the test suite).
#
# Resets the local Azure File Sync server registration so the machine is in a clean
# state before running the remote server registration sequence in Record mode.
#
# Usage (run elevated on the target server):
#   pwsh -File reset.ps1
#
# If not already elevated, the script relaunches itself as administrator via `pwsh` RunAs.
# ----------------------------------------------------------------------------------

[CmdletBinding()]
param(
    [string] $ServerCmdletsModule = 'C:\Program Files\Azure\StorageSyncAgent\StorageSync.Management.ServerCmdlets.dll'
)

$ErrorActionPreference = 'Stop'

# Self-elevate: relaunch this script as administrator if the current session is not elevated.
$identity = [System.Security.Principal.WindowsIdentity]::GetCurrent()
$principal = New-Object System.Security.Principal.WindowsPrincipal($identity)
if (-not $principal.IsInRole([System.Security.Principal.WindowsBuiltInRole]::Administrator))
{
    Write-Host "Not elevated. Relaunching reset.ps1 as administrator via pwsh RunAs..."
    $pwshPath = (Get-Process -Id $PID).Path
    if (-not $pwshPath) { $pwshPath = 'pwsh' }
    $arguments = @('-NoLogo', '-NoProfile', '-ExecutionPolicy', 'Bypass', '-File', "`"$PSCommandPath`"", '-ServerCmdletsModule', "`"$ServerCmdletsModule`"")
    Start-Process -FilePath $pwshPath -ArgumentList $arguments -Verb RunAs -Wait
    return
}

if (-not (Test-Path -LiteralPath $ServerCmdletsModule))
{
    throw "Azure File Sync server cmdlets module not found at '$ServerCmdletsModule'. Ensure the Azure File Sync agent is installed."
}

Write-Host "Importing Azure File Sync server cmdlets module: $ServerCmdletsModule"
Import-Module $ServerCmdletsModule -Force

Write-Host "Resetting local Azure File Sync server registration (Reset-StorageSyncServer -Force)"
try
{
    Reset-StorageSyncServer -Force
    Write-Host "Local server registration reset complete."
}
catch
{
    # A ServerRegistrationException here typically means the server is not currently
    # registered, so there is nothing to reset. Treat that as an already-clean state.
    Write-Warning "Reset-StorageSyncServer -Force reported: $($_.Exception.Message)"
    Write-Warning "If the server was not registered, it is already in a clean state. If this was an access error, re-run this script from an elevated PowerShell session."
}
