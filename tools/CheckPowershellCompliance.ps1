# This Powershell script checks Powershell compatibility of any custom scripts
# in the repository.  It assumes configuration for this is present in the
# README.md. 
#
# The configuration should look like this:
#
#     ### PSScriptAnalyzer Configuration
#     ```yaml
#     targetVersions:
#     - "5.1"
#     - "7.0"
#     targetProfiles:
#     - "win-48_x64_10.0.17763.0_5.1.17763.316_x64_4.0.30319.42000_framework"
#     - "win-4_x64_10.0.18362.0_7.0.0_x64_3.1.2_core"
#     ```

function Read-ComplianceConfiguration {
    $path = "README.md"
    $configMarker = "### PSScriptAnalyzer Configuration"
    $backTicksYaml = '```yaml'
    $backTicks = '```'

    $readme = Get-Content $path

    # Extract out the YAML which sits between backticks markers after the 
    # PSScriptAnalyzer configuration marker.
    $yaml = ""
    $inConfig = $false
    for ($i = 0; $i -lt $readme.Length; $i++) {
        if ($readme[$i] -eq $configMarker) {
            $inConfig = $true
        }
        if ($inConfig -and ($readme[$i] -eq $backTicksYaml)) {
            $i++
            while ($i -lt $readme.Length -and $readme[$i] -ne $backticks) {
                $yaml += "`n" + $readme[$i]
                $i++
            }
            break
        }
    }

    if ("" -eq $yaml) {
        Throw "No PSScriptAnalyzer Configuration found in README.md"
    }

    # Parse the YAML.
    $yamlObj = ConvertFrom-YAML $yaml

    # Confirm that there is at least one TargetVersion and that there are the
    # same number of TargetVersions as TargetProfiles.
    if ($yamlObj.targetVersions.Count -eq 0) {
        Throw "No TargetVersions found in PSScriptAnalyzer Configuration."
    }
    if ($yamlObj.targetVersions.Count -ne $yamlObj.targetProfiles.Count) {
        Throw "Number of TargetVersions ($($yamlObj.targetVersions.Count)) and TargetProfiles ($($yamlObj.targetprofiles.Count)) do not match."
    }

    return $yamlObj
}

function Confirm-Compliance {
    param(
        [string[]]$TargetVersions,
        [string[]]$TargetProfiles
    )
    Write-Output -ForegroundColor Green 'Linting and checking Powershell back-compatibility...'
    Install-Module PSScriptAnalyzer -Scope CurrentUser -Force
    $settings = @{
        # Ref: https://devblogs.microsoft.com/powershell/using-psscriptanalyzer-to-check-powershell-version-compatibility/
        Rules = @{
            PSUseCompatibleSyntax   = @{
                # This turns the rule on (setting it to false will turn it off)
                Enable         = $true

                # List the targeted versions of PowerShell here
                TargetVersions = $TargetVersions
            }
            PSUseCompatibleCommands = @{
                # Turns the rule on
                Enable         = $true

                # Lists the PowerShell platforms we want to check compatibility with
                # Ref: https://learn.microsoft.com/en-gb/powershell/utility-modules/psscriptanalyzer/rules/usecompatiblecommands?view=ps-modules
                TargetProfiles = $TargetProfiles
            }
        }
    }

    # Recursively find all *.ps1 files and run Invoke-ScriptAnalyzer against them.
    $problems = $(Get-ChildItem -Path ./custom -Recurse -Include '*.ps1' | Invoke-ScriptAnalyzer -Settings $settings)
    if ("" -ne $problems) {
        Write-Output $problems
        Throw 'ScriptAnalyzer found (possibly back-compatibility) issues.'
    }
}

function Confirm-CustomScript {
    Write-Debug "Confirm custom scripts are present."

    # Get all *.ps1 files in the current directory
    $scripts = Get-ChildItem -Path ./custom -Recurse -Include '*.ps1'
    if ($scripts.Length -eq 0) {
        Throw "No custom scripts found in the repository."
    }
}

function Confirm-InAutorestEnv {
    Write-Debug "Confirm in an autorest directory."

    # Get current working directory then confirm it ends in ".autorest"
    $cwd = Get-Location
    if ($cwd -notlike "*.autorest") {
        Throw "This script should be run from an autorest directory."
    }

}

# Confirm that the required modules are installed.
if (-not(Get-InstalledModule -Name "powershell-yaml")) {
    Throw "powershell-yaml module is required. Please install it."
}
if (-not(Get-InstalledModule -Name PSScriptAnalyzer)) {
    Throw "PSScriptAnalyzer module is required. Please install it."
}

# Run the script.
Confirm-InAutorestEnv
Confirm-CustomScript
$configuration = Read-ComplianceConfiguration
Confirm-Compliance -TargetVersions $configuration.targetVersions -TargetProfiles $configuration.targetProfiles