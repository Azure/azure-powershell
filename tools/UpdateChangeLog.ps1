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

<#
This function updates service change logs by changing "Current Release" to the release
date and version and adding a new "Current Release" section to the top.

This function also returns an array that contains all of the changes for the service this release.
#>
function UpdateServiceChangeLog([string]$PathToChangeLog)
{    
    # Get the content of the service change log
    $content = Get-Content $PathToChangeLog
    # Create a new object with enough space for the old content plus the new "Current Release" section
    $newContent = New-Object string[] ($content.Length + 2)
    
    $buffer = 0

    # This will keep track of whether or not we found the "Current Release" changes and are actively adding
    # them to the array we are returning
    $found = $False

    # This array will keep track of the changes made this release
    $changeLogContent = @()

    for ($idx = 0; $idx -lt $content.Length; $idx++)
    {
        # If we have found the "Current Release" section, update the section title,
        # add the new "Current Release" section, update the buffer, and switch the $found variable
        if ($content[$idx] -eq "## Current Release")
        {
            $content[$idx] = "## $ReleaseDate - Version $ReleaseVersion"
            $found = $True

            $newContent[$idx] = "## Current Release"
            $newContent[$idx + 1] = ""
            $buffer = 2
        }
        # If we have found the next section after "Current Release", stop adding notes
        elseif ($content[$idx] -like "##*")
        {
            $found = $False
        }
        # If we are currently looking at the changes for this release, add them to
        # the array that we will return at the end
        elseif ($found)
        {
            $changeLogContent += $content[$idx]
        }
        
        # Update the content
        $newContent[$idx + $buffer] = $content[$idx]
    }

    # Update the service change log file to include all of the changes we made
    $result = $newContent -join "`r`n"
    $tempFile = Get-Item $PathToChangeLog

    [System.IO.File]::WriteAllText($tempFile.FullName, $result)

    # Edge case: for the first release, if there are no changes made to the service,
    # then the array will be empty, so we need to add an empty line for future computation
    if ($changeLogContent.Length -eq 0)
    {
        $changeLogContent += ""
    }

    # Return the list of changes that were made by this service this release
    return $changeLogContent
}

<#
This function updates the "Release Notes" section in a service's psd1 file with
the changes that they made this release.

If no changes were made this release, the message "Updated for common code changes" will
be placed in the release notes instead.
#>
function UpdateModule([string]$PathToModule, [string[]]$ChangeLogContent)
{
    # Get the content of the service psd1 file
    $content = Get-Content $PathToModule

    # The size of the new file will be everything in the array we got from
    # UpdateServiceChangeLog, except we exclude the last line (which is assumed to be blank)
    $size = $content.Length + $ChangeLogContent.Length - 1

    # Create a new object with enough space for the old content plus the new changes made this release
    $newContent = New-Object string[] $size

    $buffer = 0

    for ($idx = 0; $idx -lt $content.Length; $idx++)
    {
        # Once we reach the release notes section, we need to update the information
        if ($content[$idx] -like "*ReleaseNotes =*")
        {
            $end = $content[$idx].IndexOf("'")
            $newContent[$idx] = $content[$idx].Substring(0, $end)

            # If there were no changes made this release, set the notes as the common code string
            if ($ChangeLogContent.Length -le 1)
            {
                $newContent[$idx] += "'Updated for common code changes'"
            }
            # If there were changes made this release, add the changes
            else
            {
                $newContent[$idx] += $ChangeLogContent[0]
                for ($tempBuffer = 1; $tempBuffer -lt $ChangeLogContent.Length - 1; $tempBuffer++)
                {
                    $newContent[$idx + $tempBuffer] = $ChangeLogContent[$tempBuffer]

                    # If we are on the last line, add the apostrophe to end the string
                    if (($tempBuffer + 1) -eq ($ChangeLogContent.Length -1))
                    {
                        $newContent[$idx + $tempBuffer] += "'"
                    }
                }

                # Update the buffer
                $buffer = $ChangeLogContent.Length - 1
            }
            
        }
        # For all other lines in the psd1 file, add them to the new content array
        else
        {
            $newContent[$idx + $buffer] = $content[$idx]
        }
    }

    # Update the service psd1 file to include all of the changes we made
    $result = $newContent -join "`r`n"
    $tempFile = Get-Item $PathToModule

    [System.IO.File]::WriteAllText($tempFile.FullName, $result)
}

<#
This function will update the master change log with all of the changes that were made by
services this release.
#>
function UpdateChangeLog([string]$PathToChangeLog, [string[]]$ServiceChangeLog)
{
    # Get the content of the change log
    $content = Get-Content $PathToChangeLog

    # Allocate enough space for all of the changes and the old content
    $size = $content.Length + $ServiceChangeLog.Length

    # Create a new object with enough space for the old content plus the new changes made this release
    $newContent = New-Object string[] $size

    # Add all of the new changes to the change log
    for ($idx = 0; $idx -lt $ServiceChangeLog.Length; $idx++)
    {
        $newContent[$idx] = $ServiceChangeLog[$idx]
    }

    # Update the buffer
    $buffer = $ServiceChangeLog.Length

    # Add all of the old content to the change log
    for ($idx = 0; $idx -lt $content.Length; $idx++)
    {
        $newContent[$idx + $buffer] = $content[$idx]
    }

    # Update the master change long to include all of the changes we made
    $result = $newContent -join "`r`n"
    $tempFile = Get-Item $PathToChangeLog

    [System.IO.File]::WriteAllText($tempFile.FullName, $result)
}

<#
This function will update all of the ResourceManager change logs.
#>
function UpdateARMLogs([string]$PathToServices)
{
    # Get all of the service change logs
    $logs = Get-ChildItem -Path $PathToServices -Filter ChangeLog.md -Recurse

    # This array will hold all of the changes that we will add to the master change log
    $result = @()

    # Add the release header for the master change log
    $result += "## $ReleaseDate - Version $ReleaseVersion"

    # For each service change log, we are going to update their content and check
    # for any changes that they made so we can add them to the master change log
    foreach ($log in $logs)
    {
        # Update the service change log and get the content of their changes
        $changeLogContent = UpdateServiceChangeLog -PathToChangeLog $log.FullName

        # Get the service folders (used to get the name of the service)
        $service = Get-Item -Path "$($log.FullName)\.."
        # Get the psd1 file
        $module = Get-Item -Path "$($service.FullName)\*.psd1"

        # Update the release notes of the psd1 file with the changes made this release
        UpdateModule -PathToModule $module.FullName -ChangeLogContent $changeLogContent

        # If there were changes for a given service, add them to the array that will be
        # added to the master change log
        if ($changeLogContent.Length -gt 1)
        {
            $result += "* $($service.Name)"
            for ($idx = 0; $idx -lt $changeLogContent.Length - 1; $idx++)
            {
                $result += "    $($changeLogContent[$idx])"
            }
        }
    }

    # Blank space added to separate this release and last release changes in change log
    $result += ""

    # Get the master change log file
    $ChangeLogFile = Get-Item -Path "$PathToRepo\ChangeLog.md"

    # Update the master change log file with all of the individual service changes
    UpdateChangeLog -PathToChangeLog $ChangeLogFile.FullName -ServiceChangeLog $result
}

# ----- START -----

# If there was no path to the Azure PowerShell repository provided, set it based on the location of this script
if (!$PathToRepo)
{
    $PathToRepo = "$PSScriptRoot\.." 
}

# Update all of the ResourceManager change logs
UpdateARMLogs -PathToServices $PathToRepo\src\ResourceManager