# Author: AaRoney.

# Define parameters.
param(
    [string] $RootPath = "..\src", 
    [string] $OutputFile = "groupMapping.json", 
    [string] $WarningFile = "groupMappingWarnings.json", 
    [string] $RulesFile = "CreateMappings_rules.json" 
);

# Load rules file from JSON.
$rules = Get-Content -Raw -Path $RulesFile | ConvertFrom-Json;

# Initialize variables.
$results = @{};
$warnings = @();

# Find all cmdlet names by help file names in the repository.
$cmdlets = Get-ChildItem $RootPath -Recurse | Where-Object { $_.FullName -cmatch ".*\\help\\.*-.*.md" };

$k = 0;
$cmdlets | ForEach-Object {
    $cmdletPath = $_;
    $cmdlet = $cmdletPath.BaseName;

    # Try to match this cmdlet with at least one rule.
    $matchedRules = @($rules | Where-Object { $cmdlet -cmatch ".*$($_.Regex).*" });

    # If cmdlet does not match, try the path.
    if($matchedRules.Count -eq 0) {
        $matchedRules += @($rules | Where-Object { $cmdletPath.FullName -cmatch ".*$($_.Regex).*" });
    }

    # Take note of unmatched cmdlets and write to outputs.
    if($matchedRules.Count -eq 0) {
        $warnings += $cmdlet;
        $results[$cmdlet] = "Other";
    } else {
        $results[$cmdlet] = $matchedRules.Get(0).Alias;
    }

    # Progress stuff.
    if($k % 100 -eq 0) {
        $percent = [math]::Floor($k / $cmdlets.Count * 100);
        Write-Progress -Activity "Processing cmdlets..." -Status "$($percent)%" -PercentComplete $percent;
    }
    $k++;
};

# Write to files.
$warnings | ConvertTo-Json | Out-File $WarningFile;
$results | ConvertTo-Json | Out-File $OutputFile;

# Print conclusion.
Write-Host ""
Write-Host "$($results.Count) cmdlets successfully mapped: $($OutputFile)." -ForegroundColor Green;
Write-Host "$($warnings.Count) cmdlets could not be mapped and were placed in 'Other': $($WarningFile)." -ForegroundColor Yellow;
Write-Host ""