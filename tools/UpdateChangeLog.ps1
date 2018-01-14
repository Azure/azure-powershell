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
        if (($content[$idx] -ne $null) -and ($content[$idx].StartsWith("## Current Release")))
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
    $releaseNotes = @()

    if ($ChangeLogContent.Length -le 1)
    {
        $releaseNotes += "Updated for common code changes"
    }
    else
    {
        $releaseNotes += $ChangeLogContent
    }


    Update-ModuleManifest -Path $PathToModule -ReleaseNotes $releaseNotes
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
    $file = Get-Item $PathToModule
    Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $file.DirectoryName -FileName $file.Name
    return $ModuleMetadata.ModuleVersion.ToString()
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

        $serviceName = $Service.Name

        if ($serviceName -eq "AzureBackup") { $serviceName = "Backup" }
        if ($serviceName -eq "AzureBatch") { $serviceName = "Batch" }

        if (!(Test-Path "$PathToRepo\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.$serviceName\AzureRM.$serviceName.psd1"))
        {
            continue
        }

        # Get the psd1 file
        $Module = Get-Item -Path "$PathToRepo\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.$serviceName\AzureRM.$serviceName.psd1"

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

        Copy-Item -Path $PathToModule -Destination "$($Service.FullName)\AzureRM.$serviceName.psd1" -Force
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

Import-Module PowerShellGet

# Update all of the ResourceManager change logs
$ResourceManagerResult = UpdateARMLogs -PathToServices $PathToRepo\src\ResourceManager

# Update the ServiceManagement change log
$PathToChangeLog = "$PathToRepo\src\ServiceManagement\Services\Commands.Utilities\ChangeLog.md"
$PathToModule = "$PathToRepo\src\Package\Debug\ServiceManagement\Azure\Azure.psd1"

$ServiceManagementResult = UpdateLog -PathToChangeLog $PathToChangeLog -PathToModule $PathToModule -Service "ServiceManagement"
Copy-Item -Path $PathToModule -Destination "$PathToRepo\src\ServiceManagement\Services\Commands.Utilities\Azure.psd1" -Force

# Update the Storage change log
$PathToChangeLog = "$PathToRepo\src\Storage\ChangeLog.md"
$PathToModule = "$PathToRepo\src\Package\Debug\Storage\Azure.Storage\Azure.Storage.psd1"

$StorageResult = UpdateLog -PathToChangeLog $PathToChangeLog -PathToModule $PathToModule -Service "Azure.Storage"
Copy-Item -Path $PathToModule -Destination "$PathToRepo\src\Storage\Azure.Storage.psd1" -Force

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