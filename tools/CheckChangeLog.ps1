[CmdletBinding()]
Param
(
    [Parameter()]
    [string]$FilesChanged
)

if ([string]::IsNullOrEmpty($FilesChanged))
{
    Write-Host "The list of files changed is empty; skipping check for change log entry"
    return
}

$PathsToCheck = @(
    "src/Common",
    "src/ResourceManager",
    "src/ServiceManagement",
    "src/Storage"
)

$PathStringsToIgnore = @(
    "Test"
)

$FilesChangedList = $FilesChanged -split ';'
$ChangeLogs = $FilesChangedList | where { $_ -like "*ChangeLog.md*" }
$UpdatedServicePaths = New-Object System.Collections.Generic.HashSet[string]
foreach ($ChangeLog in $ChangeLogs)
{
    if ($ChangeLog -like "src/ServiceManagement*")
    {
        $UpdatedServicePaths.Add("src/ServiceManagement") | Out-Null
    }
    elseif ($ChangeLog -like "src/Storage*")
    {
        $UpdatedServicePaths.Add("src/Storage") | Out-Null
    }
    else
    {
        # Handle ResourceManager to construct a string like "src/ResourceManager/{{service}}"
        $SplitPath = $ChangeLog -split '/'
        $BasePath = $SplitPath[0],$SplitPath[1],$SplitPath[2] -join "/"
        $UpdatedServicePaths.Add($BasePath) | Out-Null
    }
}

foreach ($File in $FilesChangedList)
{
    if ($File -like "*ChangeLog.md*")
    {
        continue
    }

    # If a file in src/Common is updated, check for change log entry in Profile
    if (($File.StartsWith("src/Common") -or $File.StartsWith("src/ResourceManager/Common")) -and ($UpdatedServicePaths | where { $_ -like "*Profile*" } | Measure-Object).Count -gt 0)
    {
        continue
    }

    if (($PathsToCheck | where { $File.StartsWith($_) } | Measure-Object).Count -gt 0 -and `
        ($PathStringsToIgnore | where { $File -like "*$_*" } | Measure-Object).Count -eq 0 -and `
        ($UpdatedServicePaths | where { $File.StartsWith($_) } | Measure-Object).Count -eq 0)
    {
        $FlaggedFiles += $File
    }
}

if ($FlaggedFiles.Count -gt 0)
{
    throw "Modified files were found with no update to their change log. Please add a snippet to the affected modules' change log."
}