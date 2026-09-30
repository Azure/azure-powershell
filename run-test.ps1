# ----------------------------------------------------------------------------------
#
# Session-local helper (NOT part of the test suite).
#
# Runs the remote server registration sequence scenario test.
#
# The Azure File Sync COM management interface (IECsManagement) requires an elevated
# session, so this script self-elevates via `pwsh` RunAs. All logs are written to the
# console (no log file). Optionally resets the local server registration first.
#
# Usage:
#   pwsh -File run-test.ps1
#   pwsh -File run-test.ps1 -SkipReset
# ----------------------------------------------------------------------------------

[CmdletBinding()]
param(
    [string] $RepoRoot = 'D:\code\ab\azure-powershell',
    [string] $Filter = 'FullyQualifiedName~RemoteServerRegistrationTests',
    [switch] $SkipReset,
    [switch] $NoBuild,
    [string] $ServerCmdletsModule = 'C:\Program Files\Azure\StorageSyncAgent\StorageSync.Management.ServerCmdlets.dll'
)

$ErrorActionPreference = 'Stop'

# Self-elevate: relaunch this script as administrator if the current session is not elevated.
$identity = [System.Security.Principal.WindowsIdentity]::GetCurrent()
$principal = New-Object System.Security.Principal.WindowsPrincipal($identity)
if (-not $principal.IsInRole([System.Security.Principal.WindowsBuiltInRole]::Administrator))
{
    Write-Host "Not elevated. Relaunching run-test.ps1 as administrator via pwsh RunAs..." -ForegroundColor Yellow
    $pwshPath = (Get-Process -Id $PID).Path
    if (-not $pwshPath) { $pwshPath = 'pwsh' }
    $relaunchArgs = @('-NoLogo', '-NoProfile', '-ExecutionPolicy', 'Bypass', '-File', "`"$PSCommandPath`"",
        '-RepoRoot', "`"$RepoRoot`"", '-Filter', "`"$Filter`"", '-ServerCmdletsModule', "`"$ServerCmdletsModule`"")
    if ($SkipReset) { $relaunchArgs += '-SkipReset' }
    if ($NoBuild)   { $relaunchArgs += '-NoBuild' }
    Start-Process -FilePath $pwshPath -ArgumentList $relaunchArgs -Verb RunAs
    return
}

Write-Host "========================================================================" -ForegroundColor Cyan
Write-Host " Remote server registration sequence test runner (elevated)" -ForegroundColor Cyan
Write-Host " RepoRoot : $RepoRoot" -ForegroundColor Cyan
Write-Host " Filter   : $Filter" -ForegroundColor Cyan
Write-Host "========================================================================" -ForegroundColor Cyan

# Optional: reset the local server registration so the machine is in a clean state.
if (-not $SkipReset)
{
    Write-Host "`n[Reset] Ensuring local server has no existing registration..." -ForegroundColor Cyan
    if (Test-Path -LiteralPath $ServerCmdletsModule)
    {
        try
        {
            Import-Module $ServerCmdletsModule -Force
            Reset-StorageSyncServer -Force
            Write-Host "[Reset] Local server registration reset complete." -ForegroundColor Green
        }
        catch
        {
            Write-Warning "[Reset] Reset-StorageSyncServer -Force reported: $($_.Exception.Message)"
            Write-Warning "[Reset] If the server was not registered, it is already clean; continuing."
        }
    }
    else
    {
        Write-Warning "[Reset] Server cmdlets module not found at '$ServerCmdletsModule'; skipping reset."
    }
}

Set-Location -LiteralPath $RepoRoot

$testProject = Join-Path $RepoRoot 'src\StorageSync\StorageSync.Test\StorageSync.Test.csproj'

$dotnetArgs = @('test', $testProject, '--filter', $Filter, '-l', 'console;verbosity=detailed')
if ($NoBuild) { $dotnetArgs += '--no-build' }

Write-Host "`n[Run] dotnet $($dotnetArgs -join ' ')" -ForegroundColor Cyan
Write-Host "------------------------------------------------------------------------" -ForegroundColor Cyan

# Stream all output directly to the console (no log file).
& dotnet @dotnetArgs
$exitCode = $LASTEXITCODE

Write-Host "------------------------------------------------------------------------" -ForegroundColor Cyan
if ($exitCode -eq 0)
{
    Write-Host "[Result] Test run PASSED (exit code 0)." -ForegroundColor Green
}
else
{
    Write-Host "[Result] Test run FAILED (exit code $exitCode)." -ForegroundColor Red
}

Read-Host "`nPress Enter to close this window"
exit $exitCode
