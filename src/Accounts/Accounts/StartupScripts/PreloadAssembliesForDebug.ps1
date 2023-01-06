<#
The script is to preload assemblies on Windows PowerShell when developing / debugging.

The reason is, when building Az.Accounts module, some of the restored assemblies (e.g. System.Text.Json)
are the netcoreapp version. When importing the module on Windows PowerShell, it tries to load
the netcoreapp assemblies from module root directory (artifacts/Debug/Az.Accounts/).
However, it will throw exception at runtime (System.Runtime not found).

This issue does not reproduce in signed pipeline because the redundant assemblies
in module root directory are deleted (tools/CleanupBuild.ps1).

This script preloads the correct assemblies in lib/ so that those in the module root directory
will not be loaded.
#>

function PreloadAssembly {
    param (
        [string]
        $AssemblyDirectory
    )
    if($PSEdition -eq 'Desktop' -and (Test-Path $AssemblyDirectory -ErrorAction Ignore))
    {
        try
        {
            Get-ChildItem -ErrorAction Stop -Path $AssemblyDirectory -Filter "*.dll" | ForEach-Object {
                try
                {
                    Add-Type -Path $_.FullName -ErrorAction Ignore | Out-Null
                }
                catch {
                    Write-Verbose $_
                }
            }
        }
        catch {}
    }
}

$preloadPath = (Join-Path $PSScriptRoot -ChildPath '../lib/netfx')
PreloadAssembly -AssemblyDirectory $preloadPath
$preloadPath = (Join-Path $PSScriptRoot -ChildPath '../lib/netstandard2.0')
PreloadAssembly -AssemblyDirectory $preloadPath
