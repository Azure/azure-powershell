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
function UpdateServiceChangeLog([string]$PathToChangeLog, [string]$ModuleVersion)
{    
    # Get the content of the service change log
    $content = Get-Content $PathToChangeLog -Encoding UTF8
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
            $content[$idx] = "## Version $ModuleVersion"
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

    [System.IO.File]::WriteAllText($tempFile.FullName, $result, [Text.Encoding]::UTF8)

    # Edge case: for the first release, we need to add an empty line
    # that will be used for computation later
    if ($found)
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
    $content = Get-Content $PathToModule -Encoding UTF8

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
                $newContent[$idx] += "'$($ChangeLogContent[0])"
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
                $buffer = $ChangeLogContent.Length - 2
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

    [System.IO.File]::WriteAllText($tempFile.FullName, $result, [Text.Encoding]::UTF8)
}

<#
This function will update the master change log with all of the changes that were made by
services this release.
#>
function UpdateChangeLog([string]$PathToChangeLog, [string[]]$ServiceChangeLog)
{
    # Get the content of the change log
    $content = Get-Content $PathToChangeLog -Encoding UTF8

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

    # Update the master change log to include all of the changes we made
    $result = $newContent -join "`r`n"
    $tempFile = Get-Item $PathToChangeLog

    [System.IO.File]::WriteAllText($tempFile.FullName, $result, [Text.Encoding]::UTF8)
}

<#
This function will use the psd1 file to grab the module version.
#>
function GetModuleVersion([string]$PathToModule)
{
    # Get the content of the psd1 file
    $content = Get-Content $PathToModule -Encoding UTF8

    # For each line of the file, check if we have found the module version
    for ($idx = 0; $idx -lt $content.Length; $idx++)
    {
        # If we have found the module version, grab the value and return it
        if ($content[$idx] -like "ModuleVersion*")
        {
            $start = $content[$idx].IndexOf("'") + 1

            $end = $content[$idx].LastIndexOf("'")

            $length = $end - $start

            return $content[$idx].Substring($start, $length)
        }
    }

    # Throw if we are unable to find the module version
    throw "Could not find module version for file $PathToModule"
}

<#
This function will clear the release notes for a psd1 file.
#>
function ClearReleaseNotes([string]$PathToModule)
{
    # Get the contents of the psd1 file
    $content = Get-Content $PathToModule -Encoding UTF8

    # This will keep track of the size of the current release notes
    $length = 0
    # This will let us know if we are currently iterating over the release notes
    $found = $False

    # For each line of the file, look for the release notes and find the size
    for ($idx = 0; $idx -lt $content.Length; $idx++)
    {
        # If we have found the release notes section, switch the variable on
        if ($content[$idx] -like "*ReleaseNotes =*")
        {
            $found = $True
        }
        # If we have found the end of the release notes section, switch the variable off
        elseif ($content[$idx] -like "*End of PSData*")
        {
            $found = $false
        }
        # If we are currently iterating over release notes, increment the size
        elseif ($found)
        {
            $length++
        }
    }

    # Determine the size of the file without the release notes
    $size = $content.Length - $length + 1

    # Create a new object that will hold the contents of the new psd1 file
    $newContent = New-Object string[] $size

    $buffer = 0

    # For each line in the psd1 file, copy it over to the new psd1 file, but
    # make sure to skip the release notes
    for ($idx = 0; $idx -lt $newContent.Length; $idx++)
    {
        $newContent[$idx] = $content[$idx + $buffer]

        # If we have found the release notes, set the buffer so we do not copy
        # them over to the new psd1 file
        if ($content[$idx] -like "*ReleaseNotes =*")
        {
            $buffer =  $length - 1
        }
    }

    # Update the psd1 file to include all of the changes we made
    $result = $newContent -join "`r`n"
    $tempFile = Get-Item $PathToModule

    [System.IO.File]::WriteAllText($tempFile.FullName, $result, [Text.Encoding]::UTF8)
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
        # Get the service folder
        $Service = Get-Item -Path "$($log.FullName)\.."
        # Get the psd1 file
        $Module = Get-Item -Path "$($Service.FullName)\*.psd1"

        # Get the path to the change log
        $PathToChangeLog = "$($log.FullName)"
        # Get the path to the psd1 file
        $PathToModule = "$($module.FullName)"

        # Get the changes made to the current service
        $serviceResult = UpdateLog -PathToChangeLog $PathToChangeLog -PathToModule $PathToModule -Service $Service.Name
        
        # If there were any changes made, add them to the list that will be added to the master change log
        if ($serviceResult.Length -gt 0)
        {
            $result += $serviceResult
        }
    }

    # Return the list of changes
    return $result
}

<#
This function will update the change log of a service.

This function will also return an array containing the changes made this release.
#>
function UpdateLog([string]$PathToChangeLog, [string]$PathToModule, [string]$Service)
{
    # Get the ServiceManagement change log
    $log = Get-Item -Path $PathToChangeLog

    # Get the ServiceManagemenet psd1 file
    $module = Get-Item -Path $PathToModule

    # Get the module version for ServiceManagement
    $ModuleVersion = GetModuleVersion -PathToModule $module.FullName

    # Clear the release notes for ServiceManagement
    ClearReleaseNotes -PathToModule $module.FullName

    # Update the change log and get the contents of the change log for the current release
    $changeLogContent = UpdateServiceChangeLog -PathToChangeLog $log.FullName -ModuleVersion $ModuleVersion

    #Update the psd1 file to include the changes made this release
    UpdateModule -PathToModule $module.FullName -ChangeLogContent $changeLogContent

    $result = @()

    # If there were any changes made this release, add them to the array that will
    # be added to the master change log
    if ($changeLogContent.Length -gt 1)
    {
        $result += "* $Service"
        for ($idx = 0; $idx -lt $changeLogContent.Length - 1; $idx++)
        {
            $result += "    $($changeLogContent[$idx])"
        }
    }

    # Return the list of changes
    return $result
}

# ----- START -----

# If there was no path to the Azure PowerShell repository provided, set it based on the location of this script
if (!$PathToRepo)
{
    $PathToRepo = "$PSScriptRoot\.." 
}

# Update all of the ResourceManager change logs
$ResourceManagerResult = UpdateARMLogs -PathToServices $PathToRepo\src\ResourceManager

# Update the ServiceManagement change log
$PathToChangeLog = "$PathToRepo\src\ServiceManagement\Services\Commands.Utilities\ChangeLog.md"
$PathToModule = "$PathToRepo\src\ServiceManagement\Services\Commands.Utilities\Azure.psd1"

$ServiceManagementResult = UpdateLog -PathToChangeLog $PathToChangeLog -PathToModule $PathToModule -Service "ServiceManagement"

# Update the Storage change log
$PathToChangeLog = "$PathToRepo\src\Storage\ChangeLog.md"
$PathToModule = "$PathToRepo\src\Storage\Azure.Storage.psd1"

$StorageResult = UpdateLog -PathToChangeLog $PathToChangeLog -PathToModule $PathToModule -Service "Azure.Storage"

$result = @()

# If any changes were made to ARM services, add them to the list to be added to the master change log
# Also, we need to update AzureRM.psd1 with all of the changes made to ARM services
if ($ResourceManagerResult.Length -gt 0)
{
    $result += $ResourceManagerResult

    UpdateModule -PathToModule "$PathToRepo\tools\AzureRM\AzureRM.psd1" -ChangeLogContent $ResourceManagerResult
}

# If any changes were made to RDFE services, add them to the list to be added to the master change log
if ($ServiceManagementResult.Length -gt 0)
{
    $result += $ServiceManagementResult
}

# If any changes were made to Storage, add them to the list to be added to the master change log
if ($StorageResult.Length -gt 0)
{
    $result += $StorageResult
}

# Blank space added to separate this release and last release changes in change log
$result += ""

# Get the master change log file
$ChangeLogFile = Get-Item -Path "$PathToRepo\ChangeLog.md"

# Update the master change log file with all of the individual service changes
UpdateChangeLog -PathToChangeLog $ChangeLogFile.FullName -ServiceChangeLog $result