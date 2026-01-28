param(
    [Parameter(Mandatory=$false)]
    [string]$SrcDirectory = (Join-Path $PSScriptRoot ".." ".." "src"),
    
    [Parameter(Mandatory=$false)]
    [switch]$GAOnly = $false
)

function Test-SemanticVersion {
    param([string]$Version)
    return $Version -match '^\d+\.\d+\.\d+.*$'
}

function Get-UpcomingReleaseContent {
    param([string]$ChangeLogPath)
    
    $lines = Get-Content -Path $ChangeLogPath
    
    # Find start line: ## Upcoming Release (skip HTML comments)
    $startIndex = -1
    $endIndex = -1
    $inComment = $false
    
    for ($i = 0; $i -lt $lines.Count; $i++) {
        $line = $lines[$i]
        
        # Check if entering or exiting HTML comment
        if ($line -match '<!--') {
            $inComment = $true
        }
        if ($line -match '-->') {
            $inComment = $false
            continue
        }
        
        # Only match ## Upcoming Release outside of comments
        if (-not $inComment -and $line -match '^\s*##\s+Upcoming Release\s*$') {
            $startIndex = $i
            break
        }
    }
    
    if ($startIndex -eq -1) {
        return $null
    }
    
    # Find end line: next version heading
    for ($i = $startIndex + 1; $i -lt $lines.Count; $i++) {
        if ($lines[$i] -match '^\s*##\s+Version\s+(\S+)') {
            $version = $matches[1]
            if (Test-SemanticVersion -Version $version) {
                $endIndex = $i
                break
            }
        }
    }
    
    if ($endIndex -eq -1) {
        $endIndex = $lines.Count
    }
    
    # Extract content
    $upcomingLines = @()
    for ($i = $startIndex + 1; $i -lt $endIndex; $i++) {
        $upcomingLines += $lines[$i]
    }
    
    # Get next version if found
    $nextVersion = $null
    if ($endIndex -lt $lines.Count) {
        if ($lines[$endIndex] -match '^\s*##\s+Version\s+(\S+)') {
            $nextVersion = $matches[1]
        }
    }
    
    return @{
        Content = $upcomingLines
        NextVersion = $nextVersion
    }
}

function Test-HasModifications {
    param([string[]]$Lines)
    
    if ($null -eq $Lines) {
        return $false, $false
    }
    
    $hasNonEmptyContent = $false
    $hasValidBulletPoint = $false
    
    foreach ($line in $Lines) {
        $trimmedLine = $line.Trim()
        if ($trimmedLine -ne "") {
            $hasNonEmptyContent = $true
            if ($trimmedLine -match '^[-\*]\s+') {
                $hasValidBulletPoint = $true
            }
        }
    }
    
    return $hasNonEmptyContent, $hasValidBulletPoint
}

function Test-ModuleInAzPreview {
    param(
        [string]$ModuleName,
        [string]$Version
    )
    
    $azPreviewPath = Join-Path $PSScriptRoot ".." "AzPreview" "AzPreview.psd1"
    
    if (-not (Test-Path -Path $azPreviewPath)) {
        Write-Warning "AzPreview.psd1 not found at: $azPreviewPath"
        return $false
    }
    
    try {
        $content = Get-Content -Path $azPreviewPath -Raw
        $pattern = "@\{ModuleName\s*=\s*'Az\.$ModuleName';\s*RequiredVersion\s*=\s*'$Version';"
        return $content -match $pattern
    }
    catch {
        Write-Warning "Failed to read AzPreview.psd1: $_"
        return $false
    }
}

function Get-ModuleInfoFromPsd1 {
    param([string]$Psd1Path)
    
    try {
        $psd1Content = Invoke-Expression (Get-Content -Path $Psd1Path -Raw)
        $moduleVersion = $psd1Content.ModuleVersion
        $psd1FileName = [System.IO.Path]::GetFileNameWithoutExtension($Psd1Path)
        
        # Remove "Az." prefix
        $moduleName = $psd1FileName
        if ($moduleName.StartsWith("Az.")) {
            $moduleName = $moduleName.Substring(3)
        }
        
        return @{
            ModuleName = $moduleName
            ModuleVersion = $moduleVersion
        }
    }
    catch {
        Write-Warning "Failed to parse psd1 file: $Psd1Path. Error: $_"
        return $null
    }
}

function Get-ModuleChangesFromAzPreview {
    param([string]$AzPreviewPsd1Path)
    
    Write-Host "`nChecking for module changes in AzPreview.psd1..."
    
    if (-not (Test-Path -Path $AzPreviewPsd1Path)) {
        Write-Warning "AzPreview.psd1 not found at: $AzPreviewPsd1Path"
        return @{}
    }
    
    $oobModules = @{}
    
    try {
        # Get git log with decorations to see tags (SINGLE READ)
        $gitLogOutput = git -C (Split-Path -Parent $AzPreviewPsd1Path) log --oneline --decorate --pretty=format:"%H|%D" -- (Split-Path -Leaf $AzPreviewPsd1Path) 2>&1
        
        if ($LASTEXITCODE -ne 0) {
            Write-Warning "Failed to get git log for AzPreview.psd1"
            return @{}
        }
        
        $commits = @()
        foreach ($line in $gitLogOutput) {
            if ([string]::IsNullOrWhiteSpace($line)) {
                continue
            }
            
            $parts = $line -split '\|', 2
            $commitHash = $parts[0].Trim()
            $decoration = if ($parts.Count -gt 1) { $parts[1].Trim() } else { "" }
            
            # Check if this commit has a version tag (e.g., v15.1.0-December2025)
            if ($decoration -match 'tag:\s*v\d+\.\d+\.\d+') {
                Write-Host "  Found version tag at commit $commitHash, stopping."
                break
            }
            
            $commits += $commitHash
        }
        
        Write-Host "  Analyzing $($commits.Count) commits since last release..."
        
        # Analyze each commit for module additions
        foreach ($commitHash in $commits) {
            $diffOutput = git -C (Split-Path -Parent $AzPreviewPsd1Path) show $commitHash -- (Split-Path -Leaf $AzPreviewPsd1Path) 2>&1
            
            if ($LASTEXITCODE -ne 0) {
                continue
            }
            
            # Parse diff output to find added module lines
            foreach ($line in $diffOutput) {
                # Look for added modules: +            @{ModuleName = 'Az.StackHCI'; RequiredVersion = '2.6.5'; },
                if ($line -match '^\+\s*@\{ModuleName\s*=\s*''Az\.([^'']+)'';\s*RequiredVersion\s*=\s*''([^'']+)''') {
                    $moduleName = $matches[1]
                    $version = $matches[2]
                    
                    if (-not $oobModules.ContainsKey($moduleName)) {
                        Write-Host "  Found OOB module: $moduleName (version $version) in commit $commitHash"
                        $oobModules[$moduleName] = $version
                    }
                }
            }
        }
        
        return $oobModules
    }
    catch {
        Write-Warning "Error while checking module changes: $_"
        return @{}
    }
}

# Main logic
$startTime = Get-Date
Write-Host "Starting to collect modified modules from: $SrcDirectory"

# Verify src directory exists
if (-not (Test-Path -Path $SrcDirectory -PathType Container)) {
    Write-Error "Source directory does not exist: $SrcDirectory"
    exit 1
}

$resolvedSrcPath = Resolve-Path -Path $SrcDirectory
Write-Host "Resolved source path: $resolvedSrcPath"

$modifiedModules = @{}

# Iterate through first-level directories under src
$moduleDirectories = Get-ChildItem -Path $resolvedSrcPath -Directory

foreach ($moduleDir in $moduleDirectories) {
    Write-Host "Processing module directory: $($moduleDir.Name)"
    
    # Find ChangeLog.md
    $changeLogFiles = Get-ChildItem -Path $moduleDir.FullName -Filter "ChangeLog.md" -Recurse -File
    
    if ($changeLogFiles.Count -eq 0) {
        Write-Warning "No ChangeLog.md found in module directory: $($moduleDir.Name)"
        continue
    }
    
    if ($changeLogFiles.Count -gt 1) {
        Write-Warning "Multiple ChangeLog.md files found in module directory: $($moduleDir.Name). Skipping."
        continue
    }
    
    $changeLogFile = $changeLogFiles[0]
    $changeLogParentDir = $changeLogFile.Directory
    
    Write-Host "  Found ChangeLog.md at: $($changeLogFile.FullName)"
    
    # Find psd1 files in ChangeLog.md parent directory
    $psd1Files = Get-ChildItem -Path $changeLogParentDir.FullName -Filter "*.psd1" -File
    
    if ($psd1Files.Count -eq 0) {
        Write-Warning "No .psd1 file found in directory: $($changeLogParentDir.FullName)"
        continue
    }
    
    if ($psd1Files.Count -gt 1) {
        Write-Warning "Multiple .psd1 files found in directory: $($changeLogParentDir.FullName). Skipping."
        continue
    }
    
    $psd1File = $psd1Files[0]
    Write-Host "  Found psd1 file at: $($psd1File.FullName)"
    
    # Read ChangeLog.md content and check for modifications
    $upcomingReleaseInfo = Get-UpcomingReleaseContent -ChangeLogPath $changeLogFile.FullName
    $hasModifications, $hasValidBulletPoint = Test-HasModifications -Lines $upcomingReleaseInfo.Content
    
    if ($hasModifications) {
        Write-Host "  Modifications detected in ChangeLog.md"
        
        if (-not $hasValidBulletPoint) {
            Write-Warning "Modifications found but no lines start with '-' or '*' in module: $($moduleDir.Name)"
        }
        
        # Read psd1 file to get module information
        $moduleInfo = Get-ModuleInfoFromPsd1 -Psd1Path $psd1File.FullName
        
        if ($null -ne $moduleInfo) {
            $modifiedModules[$moduleInfo.ModuleName] = $moduleInfo.ModuleVersion
            Write-Host "  Added module: $($moduleInfo.ModuleName) version $($moduleInfo.ModuleVersion)"  -ForegroundColor Green
        }
    }
    else {
        Write-Host "  No modifications detected in ChangeLog.md"
        
        # Additional check: if next version is 0.1.0 and not in AzPreview, consider it modified
        if ($upcomingReleaseInfo.NextVersion -eq '0.1.0') {
            Write-Host "  Next version is 0.1.0, checking AzPreview.psd1..."
            
            $moduleInfo = Get-ModuleInfoFromPsd1 -Psd1Path $psd1File.FullName
            
            if ($null -ne $moduleInfo) {
                $inAzPreview = Test-ModuleInAzPreview -ModuleName $moduleInfo.ModuleName -Version '0.1.0'
                
                if (-not $inAzPreview) {
                    Write-Host "  Module Az.$($moduleInfo.ModuleName) with version 0.1.0 not found in AzPreview.psd1, marking as modified"
                    $modifiedModules[$moduleInfo.ModuleName] = $moduleInfo.ModuleVersion
                    Write-Host "  Added module: $($moduleInfo.ModuleName) version $($moduleInfo.ModuleVersion)" -ForegroundColor Green
                }
                else {
                    Write-Host "  Module Az.$($moduleInfo.ModuleName) with version 0.1.0 already exists in AzPreview.psd1"
                }
            }
        }
    }
}

# Get OOB modules from AzPreview.psd1 git history
$azPreviewPsd1Path = Join-Path $PSScriptRoot ".." "AzPreview" "AzPreview.psd1"
$oobModules = Get-ModuleChangesFromAzPreview -AzPreviewPsd1Path $azPreviewPsd1Path

# Add OOB modules to the result
foreach ($oobModule in $oobModules.Keys) {
    if (-not $modifiedModules.ContainsKey($oobModule)) {
        $modifiedModules[$oobModule] = $oobModules[$oobModule]
        Write-Host "Added OOB module: $oobModule (version $($oobModules[$oobModule]))" -ForegroundColor Green
    }
}

Write-Host "`nSuccessfully collected $($modifiedModules.Count) modified modules"
# Filter GA modules if requested
if ($GAOnly) {
    Write-Host "`nFiltering for GA modules only (version >= 1.0.0)..."
    $filteredModules = @{}
    foreach ($key in $modifiedModules.Keys) {
        $version = $modifiedModules[$key]
        # Skip modules with version < 1.0.0
        if ([version]$version -ge [version]"1.0.0") {
            $filteredModules[$key] = $version
        }
        else {
            Write-Host "  Filtered out: $key (version: $version)" -ForegroundColor Yellow
        }
    }
    $modifiedModules = $filteredModules
    Write-Host "After filtering: $($modifiedModules.Count) GA modules remaining"
}
# Return list of unique module names
$moduleNames = $modifiedModules.Keys | Sort-Object | Select-Object -Unique

# Print all modules before returning
Write-Host "`nModified Modules:"
foreach ($moduleName in $moduleNames) {
    Write-Host "  - $moduleName"
}

# Calculate and print execution time
$endTime = Get-Date
$executionTime = $endTime - $startTime
Write-Host "`nScript execution time: $($executionTime.TotalSeconds.ToString('F2')) seconds"

return $moduleNames
