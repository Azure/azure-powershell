# Script to lint and confirm Powershell v5.1 abck-compatibility.
# PSAvoidUsingWriteHost
[Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSAvoidUsingWriteHost', '',
    Justification = 'Command linenonly and want colour')]
param(
    [string]$Path
)
Write-Host -ForegroundColor Green 'Linting and checking Powershell back-compatibility...'
Install-Module PSScriptAnalyzer -Scope CurrentUser
$settings = @{
    # Ref: https://devblogs.microsoft.com/powershell/using-psscriptanalyzer-to-check-powershell-version-compatibility/
    Rules = @{
        PSUseCompatibleSyntax   = @{
            # This turns the rule on (setting it to false will turn it off)
            Enable         = $true

            # List the targeted versions of PowerShell here
            TargetVersions = @(
                '5.1',
                '7.0'
            )
        }
        PSUseCompatibleCommands = @{
            # Turns the rule on
            Enable         = $true

            # Lists the PowerShell platforms we want to check compatibility with
            # Ref: https://learn.microsoft.com/en-gb/powershell/utility-modules/psscriptanalyzer/rules/usecompatiblecommands?view=ps-modules
            TargetProfiles = @(
                'win-8_x64_10.0.17763.0_5.1.17763.316_x64_4.0.30319.42000_framework',
                'win-8_x64_10.0.14393.0_7.0.0_x64_3.1.2_core'
            )
        }
    }
}

# Convert the relative path to an absolute path.
$Path = (Get-Item -Path $Path).FullName

# Recursivley find all *.ps1 files and run Invoke-ScriptAnalyzer against them.
Get-ChildItem -Path $Path -Recurse -Include '*.ps1' | Invoke-ScriptAnalyzer -Settings $settings
