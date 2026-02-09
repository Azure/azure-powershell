param(
    [Parameter(Mandatory=$false)]
    [string]$AzPreviewPsd1Path = (Join-Path $PSScriptRoot ".." "AzPreview" "AzPreview.psd1"),
    
    [Parameter(Mandatory=$false)]
    [switch]$GAOnly = $false
)

function Get-LastReleaseTag {
    param([string]$Psd1Path)
    
    $repoDir = Split-Path -Parent $Psd1Path
    
    # Get git log with decorations to find the last release tag
    $gitLogOutput = git -C $repoDir log --oneline --decorate --pretty=format:"%H|%D" -- (Split-Path -Leaf $Psd1Path) 2>&1
    
    if ($LASTEXITCODE -ne 0) {
        Write-Warning "Failed to get git log for AzPreview.psd1"
        return $null
    }
    
    foreach ($line in $gitLogOutput) {
        if ([string]::IsNullOrWhiteSpace($line)) {
            continue
        }
        
        $parts = $line -split '\|', 2
        $commitHash = $parts[0].Trim()
        $decoration = if ($parts.Count -gt 1) { $parts[1].Trim() } else { "" }
        
        # Check if this commit has a version tag (e.g., v15.1.0-December2025)
        if ($decoration -match 'tag:\s*(v\d+\.\d+\.\d+[^,\s]*)') {
            $tagName = $matches[1]
            Write-Host "Found last release tag: $tagName at commit $commitHash"
            return @{
                Tag = $tagName
                CommitHash = $commitHash
            }
        }
    }
    
    Write-Warning "No release tag found in git history"
    return $null
}

function Get-Psd1ContentAtTag {
    param(
        [string]$Psd1Path,
        [string]$Tag
    )
    
    $repoDir = Split-Path -Parent $Psd1Path
    $fileName = Split-Path -Leaf $Psd1Path
    
    # Get the file content at the specified tag
    $content = git -C $repoDir show "${Tag}:$fileName" 2>&1
    
    if ($LASTEXITCODE -ne 0) {
        # Try with relative path from repo root
        $relativePath = "tools/AzPreview/$fileName"
        $content = git -C $repoDir show "${Tag}:$relativePath" 2>&1
        
        if ($LASTEXITCODE -ne 0) {
            Write-Warning "Failed to get content of $fileName at tag $Tag"
            return $null
        }
    }
    
    return $content -join "`n"
}

function Parse-Psd1Content {
    param([string]$Content)
    
    $result = @{
        Version = $null
        Dependencies = @()
    }
    
    # Extract ModuleVersion
    if ($Content -match "ModuleVersion\s*=\s*'([^']+)'") {
        $result.Version = [version]$matches[1]
    }
    
    # Extract RequiredModules
    # Match patterns like: @{ModuleName = 'Az.Accounts'; ModuleVersion = '5.3.2'; }
    # or @{ModuleName = 'Az.ADDomainServices'; RequiredVersion = '0.3.0'; }
    $modulePattern = "@\{ModuleName\s*=\s*'(Az\.[^']+)';\s*(?:ModuleVersion|RequiredVersion)\s*=\s*'([^']+)';"
    $regexMatches = [regex]::Matches($Content, $modulePattern)
    
    $dependencyList = @()
    foreach ($match in $regexMatches) {
        $moduleName = $match.Groups[1].Value
        $moduleVersion = $match.Groups[2].Value
        
        # Create VersionRange-like object structure
        $versionRange = [PSCustomObject]@{
            MinVersion = [PSCustomObject]@{
                OriginalVersion = $moduleVersion
            }
        }
        
        $dependency = [PSCustomObject]@{
            Name = $moduleName
            VersionRange = $versionRange
        }
        $dependencyList += $dependency
    }
    $result.Dependencies = $dependencyList
    
    return $result
}

# Main logic
$startTime = Get-Date
Write-Host "Starting to collect last release modules from AzPreview.psd1..."

# Verify AzPreview.psd1 exists
if (-not (Test-Path -Path $AzPreviewPsd1Path)) {
    Write-Error "AzPreview.psd1 does not exist: $AzPreviewPsd1Path"
    exit 1
}

$resolvedPath = Resolve-Path -Path $AzPreviewPsd1Path
Write-Host "Resolved AzPreview.psd1 path: $resolvedPath"

# Get the last release tag
$tagInfo = Get-LastReleaseTag -Psd1Path $resolvedPath

if ($null -eq $tagInfo) {
    Write-Error "Failed to find last release tag"
    exit 1
}

Write-Host "Last release tag: $($tagInfo.Tag)"

# Get psd1 content at the last release tag
$psd1Content = Get-Psd1ContentAtTag -Psd1Path $resolvedPath -Tag $tagInfo.Tag

if ($null -eq $psd1Content) {
    Write-Error "Failed to get AzPreview.psd1 content at tag $($tagInfo.Tag)"
    exit 1
}

# Parse the psd1 content
$moduleInfo = Parse-Psd1Content -Content $psd1Content

# Filter GA modules if requested
if ($GAOnly) {
    Write-Host "`nFiltering for GA modules only (version >= 1.0.0)..."
    $filteredDependencies = @()
    foreach ($dependency in $moduleInfo.Dependencies) {
        $version = $dependency.VersionRange.MinVersion.OriginalVersion
        # Skip modules with version < 1.0.0
        if ([version]$version -ge [version]"1.0.0") {
            $filteredDependencies += $dependency
        }
        else {
            Write-Host "  Filtered out: $($dependency.Name) (version: $version)" -ForegroundColor Yellow
        }
    }
    $moduleInfo.Dependencies = $filteredDependencies
    Write-Host "After filtering: $($moduleInfo.Dependencies.Count) GA modules remaining"
}

Write-Host "`nLast Release Module Information:"
Write-Host "  Version: $($moduleInfo.Version)"
Write-Host "  Dependencies count: $($moduleInfo.Dependencies.Count)"

# Print all Dependencies
Write-Host "`nDependencies:"
foreach ($dependency in ($moduleInfo.Dependencies | Sort-Object -Property Name)) {
    Write-Host "  - $($dependency.Name) : $($dependency.VersionRange.MinVersion.OriginalVersion)"
}

# Calculate and print execution time
$endTime = Get-Date
$executionTime = $endTime - $startTime
Write-Host "`nScript execution time: $($executionTime.TotalSeconds.ToString('F2')) seconds"

# Return the result as a hashtable
return $moduleInfo
