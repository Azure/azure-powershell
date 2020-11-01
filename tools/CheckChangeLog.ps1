[CmdletBinding()]
Param
(
    [Parameter()]
    [string]$FilesChanged
)

$PathsToCheck = @("src")

$PathStringsToIgnore = @(
    "Test",
    ".sln",
    "Nuget.config",
    ".psd1",
    "Netcore",
    "Stack"
)
Write-Host "Files changed: $FilesChanged"
$FilesChangedList = @()
while ($true)
{
    $Idx = $FilesChanged.IndexOf(";")
    if ($Idx -lt 0)
    {
        $FilesChangedList += $FilesChanged
        break
    }

    $TempFile = $FilesChanged.Substring(0, $Idx)
    Write-Host "Adding '$TempFile' to 'FilesChangedList'"
    $FilesChangedList += $TempFile
    $FilesChanged = $FilesChanged.Substring($Idx + 1)
}

if ([string]::IsNullOrEmpty($FilesChanged) -or ($FilesChangedList.Count -eq 300))
{
    Write-Host "The list of files changed is empty or is past the 300 file limit; skipping check for change log entry"
    return
}

$ChangeLogs = $FilesChangedList | where { $_ -like "*ChangeLog.md*" }
$UpdatedServicePaths = New-Object System.Collections.Generic.HashSet[string]
foreach ($ChangeLog in $ChangeLogs)
{
    if ($ChangeLog -eq "ChangeLog.md")
    {
        continue
    }
    elseif ($ChangeLog -like "src/ServiceManagement*")
    {
        $UpdatedServicePaths.Add("src/ServiceManagement") | Out-Null
    }
    elseif ($ChangeLog -like "src/Storage*")
    {
        $UpdatedServicePaths.Add("src/Storage") | Out-Null
    }
    else
    {
        # Handle to construct a string like "src/{{service}}"
        $SplitPath = @()
        while ($true)
        {
            $Idx = $ChangeLog.IndexOf("/")
            if ($Idx -lt 0)
            {
                $SplitPath += $ChangeLog
                break
            }

            $TempPath = $ChangeLog.Substring(0, $Idx)
            Write-Host "Adding '$TempPath' to 'SplitPath'"
            $SplitPath += $TempPath
            $ChangeLog = $ChangeLog.Substring($Idx + 1)
        }

        $BasePath = $SplitPath[0],$SplitPath[1],$SplitPath[2] -join "/"
        Write-Host "Change log '$ChangeLog' processed to base path '$BasePath'"
        $UpdatedServicePaths.Add($BasePath) | Out-Null
    }
}

$message = "The following services were found to have a change log update:`n"
$UpdatedServicePaths | % { $message += "`t- $_`n" }
Write-Host "$message`n"

$FlaggedFiles = @()
foreach ($File in $FilesChangedList)
{
    if ($File -like "*ChangeLog.md*" -or $File -like "*.psd1*" -or $File -like "*.sln")
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
    $message = "The following files were flagged for not having a change log entry:`n"
    $FlaggedFiles | % { $message += "`t- $_`n" }
    Write-Host $message
    throw "Modified files were found with no update to their change log. Please add a snippet to the affected modules' change log."
}
