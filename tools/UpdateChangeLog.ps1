# .\UpdateChangeLog "2016.11.2" "3.1.0"
[CmdletBinding()]
Param(
    [Parameter(Mandatory = $True, Position = 0)]
    [string]$ReleaseDate,

    [Parameter(Mandatory = $True, Position = 1)]
    [string]$ReleaseVersion,

    [Parameter(Mandatory = $False, Position = 2)]
    [string]$PathToRepo
)

function UpdateServiceChangeLog([string]$PathToChangeLog)
{    
    $content = Get-Content $PathToChangeLog
    $newContent = New-Object string[] ($content.Length + 2)

    $buffer = 0

    $found = $False
    $changeLogContent = @()

    for ($idx = 0; $idx -lt $content.Length; $idx++)
    {
        if ($content[$idx] -eq "## Current Release")
        {
            $content[$idx] = "## $ReleaseDate - Version $ReleaseVersion"
            $found = $True

            $newContent[$idx] = "## Current Release"
            $newContent[$idx + 1] = ""
            $buffer = 2
        }
        elseif ($content[$idx] -like "##*")
        {
            $found = $False
        }
        elseif ($found)
        {
            $changeLogContent += $content[$idx]
        }
        
        $newContent[$idx + $buffer] = $content[$idx]
    }

    $result = $newContent -join "`r`n"
    $tempFile = Get-Item $PathToChangeLog

    [System.IO.File]::WriteAllText($tempFile.FullName, $result)

    if ($changeLogContent.Length -eq 0)
    {
        $changeLogContent += ""
    }

    return $changeLogContent
}

function UpdateModule([string]$PathToModule, [string[]]$ChangeLogContent)
{
    $content = Get-Content $PathToModule

    $size = $content.Length + $ChangeLogContent.Length - 1

    $newContent = New-Object string[] $size

    $buffer = 0

    for ($idx = 0; $idx -lt $content.Length; $idx++)
    {
        if ($content[$idx] -like "*ReleaseNotes =*")
        {
            $end = $content[$idx].IndexOf("'")
            $newContent[$idx] = $content[$idx].Substring(0, $end)

            if ($ChangeLogContent.Length -le 1)
            {
                $newContent[$idx] += "'Updated for common code changes'"
            }
            else
            {
                $newContent[$idx] += $ChangeLogContent[0]
                for ($tempBuffer = 1; $tempBuffer -lt $ChangeLogContent.Length - 1; $tempBuffer++)
                {
                    $newContent[$idx + $tempBuffer] = $ChangeLogContent[$tempBuffer]

                    if (($tempBuffer + 1) -eq ($ChangeLogContent.Length -1))
                    {
                        $newContent[$idx + $tempBuffer] += "'"
                    }
                }

                $buffer = $ChangeLogContent.Length - 1
            }
            
        }
        else
        {
            $newContent[$idx + $buffer] = $content[$idx]
        }
    }

    $result = $newContent -join "`r`n"
    $tempFile = Get-Item $PathToModule

    [System.IO.File]::WriteAllText($tempFile.FullName, $result)
}

function UpdateChangeLog([string]$PathToChangeLog, [string[]]$ServiceChangeLog)
{
    $content = Get-Content $PathToChangeLog

    $size = $content.Length + $ServiceChangeLog.Length + 1

    $newContent = New-Object string[] $size

    for ($idx = 0; $idx -lt $ServiceChangeLog.Length; $idx++)
    {
        $newContent[$idx] = $ServiceChangeLog[$idx]
    }

    $buffer = $ServiceChangeLog.Length

    for ($idx = 0; $idx -lt $content.Length; $idx++)
    {
        $newContent[$idx + $buffer] = $content[$idx]
    }

    $result = $newContent -join "`r`n"
    $tempFile = Get-Item $PathToChangeLog

    [System.IO.File]::WriteAllText($tempFile.FullName, $result)
}

function UpdateARMLogs([string]$PathToServices)
{
    $logs = Get-ChildItem -Path $PathToServices -Filter ChangeLog.md -Recurse

    $result = @()

    $result += "## $ReleaseDate - Version $ReleaseVersion"

    foreach ($log in $logs)
    {
        $changeLogContent = UpdateServiceChangeLog -PathToChangeLog $log.FullName

        $service = Get-Item -Path "$($log.FullName)\.."
        $module = Get-Item -Path "$($service.FullName)\*.psd1"

        UpdateModule -PathToModule $module.FullName -ChangeLogContent $changeLogContent

        if ($changeLogContent.Length -gt 1)
        {
            $result += "* $($service.Name)"
            for ($idx = 0; $idx -lt $changeLogContent.Length - 1; $idx++)
            {
                $result += "`t$($changeLogContent[$idx])"
            }
        }
    }

    $result += ""

    $PathToChangeLog = Get-Item -Path "$PathToRepo\ChangeLog.md"

    UpdateChangeLog -PathToChangeLog $PathToChangeLog.FullName -ServiceChangeLog $result
}

if (!$PathToRepo)
{
    $PathToRepo = "$PSScriptRoot\.." 
}

UpdateARMLogs -PathToServices $PathToRepo\src\ResourceManager