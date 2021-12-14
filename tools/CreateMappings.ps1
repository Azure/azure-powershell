# Author: AaRoney.

# Define parameters.
param(
    [string] $RootPath = "$PSScriptRoot\..\src",
    [string] $OutputFile = "$PSScriptRoot\groupMapping.json",
    [string] $WarningFile = "$PSScriptRoot\groupMappingWarnings.json",
    [string] $RulesFile = "$PSScriptRoot\CreateMappings_rules.json"
);

# Load rules file from JSON.
$rules = Get-Content -Raw -Path $RulesFile | ConvertFrom-Json;

# Initialize variables.
$results = @{};
$warnings = @();

.($PSScriptRoot + "\PreloadToolDll.ps1")
$RootPath = Resolve-Path $RootPath
$RootPathRegex = [regex]::escape($RootPath) + "\\(\w*)(\\)(.*)"
# Find all cmdlet names by help file names in the repository.
$cmdlets = Get-ChildItem $RootPath -Recurse | Where-Object { $_.FullName -cmatch ".*\\help\\.*-.*.md" -and (-not [Tools.Common.Utilities.ModuleFilter]::IsAzureStackModule($_.FullName)) };

$cmdlets | ForEach-Object {
    $cmdletPath = Split-Path $_.FullName -Parent;
    $module = $null;
    if($cmdletPath -cmatch $RootPathRegex) {
        $module = $Matches.1
    }
    $cmdlet = $_.BaseName;

    $matchedRule = $null;
    # First, match to module path.
    $matchedRule = @($rules | Where-Object { $_.Regex -ne $null -and $cmdletPath -cmatch ".*$($_.Regex).*" })[0];

    # Try to match this cmdlet with at least one rule.
    $possibleBetterMatch = @($rules | Where-Object { $_.Regex -ne $null -and $cmdlet -cmatch ".*$($_.Regex).*" })[0];

    # Look for the best match.
    if(
        # Did not find a match on the folder, but found a match on the cmdlet.
        (($matchedRule -eq $null) -and ($possibleBetterMatch -ne $null)) -or
        # Found a match on the module path, but found a better match for the cmdlet (`group` field agrees).
        (($matchedRule.Group -ne $null) -and ($matchedRule.Group -eq $possibleBetterMatch.Group)))
    {
        $matchedRule = $possibleBetterMatch;
    }

    $matchedModuleRule = $null; # clear before using
    [System.Array]$matchedModuleRules = @($rules | Where-Object { $_.Module -ne $null -and $module -eq $_.Module });
    if($matchedModuleRules.Length -eq 1) {
        # If only one rule maps to module, module name is prior than other rules.
        $matchedModuleRule = $matchedModuleRules[0];
    } elseif ($matchedModuleRules.Length -gt 1) {
        # If multiple rules map to module, the first regex is prior.
        $matchedModuleRule = @($matchedModuleRules | Where-Object { $_.Regex -ne $null -and $cmdlet -cmatch ".*$($_.Regex).*" })[0];
        if($null -eq $matchedModuleRule) {
            $matchedModuleRule = $matchedModuleRules[0];
        }
    }

    if($null -ne $matchedModuleRule) {
        $results[$cmdlet] = $matchedModuleRule.Alias;
    } elseif ($null -ne $matchedRule) {
        $results[$cmdlet] = $matchedRule.Alias;
    } else {
        # Take note of unmatched cmdlets and write to outputs.
        $warnings += $cmdlet;
        $results[$cmdlet] = "Other";
    }
};

# Write to files.
$warnings | ConvertTo-Json | Out-File $WarningFile -Encoding utf8;
$results | ConvertTo-Json | Out-File $OutputFile -Encoding utf8;

# Print conclusion.
Write-Host ""
Write-Host "$($results.Count) cmdlets successfully mapped: $($OutputFile)." -ForegroundColor Green;
Write-Host ""

if($warnings.Count -gt 0) {
    Write-Host "$($warnings.Count) cmdlets could not be mapped and were placed in 'Other': $($WarningFile)." -ForegroundColor Yellow;
    throw "Some cmdlets could not be properly mapped to a documentation grouping: $($warnings -join ", ").  Please add a mapping rule to $(Resolve-Path -Path $RulesFile).";
}
