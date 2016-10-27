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
This function updates the current-breaking-changes.md file with the version of the
released module and creates a new section for current breaking changes.

This function also returns the list of breaking changes made by this module for the release.
#>
function UpdateCurrentDoc([string]$PathToCurrentDoc, [string]$ModuleVersion)
{
    # Get the name of the service
    $service = (Get-Item -Path "$PathToCurrentDoc\..\..").Name

    # Get the contents of the breaking changes doc
    $content = Get-Content $PathToCurrentDoc -Encoding UTF8

    # This will keep track of whether or not we are looking at the current breaking changes
    $found = $False

    # This will keep track of the current breaking changes
    $changes = @()

    # Iterate over the contents of the file and add the necessary changes to the list above
    for ($idx = 1; $idx -lt $content.Length; $idx++)
    {
        # If we are currently looking for the current breaking changes, but
        # we find the previous release section, stop looking
        if ($found -and $content[$idx] -like "## Release*")
        {
            $found = $False
        }
        # If we are currently looking for the current breaking changes, but
        # we have nothing currently in our list, we add a header that will
        # display the service name (used in the master breaking changes doc)
        elseif ($found -and $changes.Length -eq 0)
        {
            $changes += "### $service"
            $changes += ""
            $changes += $content[$idx]
        }
        # If we are currently looking for the current breaking changes, add
        # them to the list
        elseif ($found)
        {
            $changes += $content[$idx]
        }
        
        # If we have found the current breaking changes section, mark
        # $found as true so we can start adding the changes to the list
        # Note: we look at $idx-1 so we can ignore the blank line after the section header
        if ($content[$idx - 1] -eq "## Current Breaking Changes")
        {
            $found = $True
        }
    }

    # If we have found any changes, we are going to create a section header that
    # displays the release version and create a new current breaking changes section
    if ($changes.Length -gt 0)
    {
        # Get the major version of the module to display
        $end = $ModuleVersion.IndexOf(".")
        $ModuleVersion = "$($ModuleVersion.Substring(0, $end)).0.0"

        # Create a new object that will contain the contents of the new file
        $newContent = New-Object string[] ($content.Length + 2)

        $buffer = 0

        # For each line in the file, check if we have found the current breaking
        # changes header, and if so, create a new header for the release
        for ($idx = 0; $idx -lt $content.Length; $idx++)
        {
            if ($content[$idx] -eq "## Current Breaking Changes")
            {
                $newContent[$idx] = "## Current Breaking Changes"
                $newContent[$idx + 1] = ""
                $newContent[$idx + 2] = "## Release $ModuleVersion"
                 
                $buffer = 2
                $idx++
            }

            $newContent[$idx + $buffer] = $content[$idx]
        }

        # Update the current breaking changes file to include these changes
        $result = $newContent -join "`r`n"
        $tempFile = Get-Item $PathToCurrentDoc

        [System.IO.File]::WriteAllText($tempFile.FullName, $result, [Text.Encoding]::UTF8)
    }

    return $changes
}

<#
This function will use the given psd1 file to grab the module version.
#>
function GetModuleVersion([string]$PathToModule)
{
    return (Test-ModuleManifest -Path $PathToModule).Version.ToString()
}

<#
This function will iterate over all of the ARM services and update their breaking changes doc.
#>
function UpdateARMBreakingChangeDocs([string]$PathToServices)
{
    # Get all of the documentation folders for the ARM services
    $docs = Get-ChildItem -Path $PathToServices -Recurse | Where { $_.Attributes -match "Directory" } | Where { $_.Name -eq "documentation" }
    
    # This will keep track of all of the breaking changes that will be added to the master docs
    $allChanges = @()

    # Iterate over each documentation folder and see if there are any changes
    foreach ($doc in $docs)
    {
        $currentDocPath = "$($doc.FullName)\current-breaking-changes.md"
        $upcomingDocPath = "$($doc.FullName)\upcoming-breaking-changes.md"

        $Service = Get-Item -Path "$($doc.FullName)\.."

        $serviceName = $Service.Name

        if ($serviceName -eq "AzureBackup") { $serviceName = "Backup" }
        if ($serviceName -eq "AzureBatch") { $serviceName = "Batch" }

        $modulePath = "$PathToRepo\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.$serviceName\AzureRM.$serviceName.psd1"

        $moduleVersion = GetModuleVersion -PathToModule $modulePath

        # Update the current breaking changes doc and grab the changes if there are any
        $changes = UpdateCurrentDoc -PathToCurrentDoc $currentDocPath -ModuleVersion $moduleVersion

        # If there are any breaking changes, add them to the list
        if ($changes.Length -gt 0)
        {
            $allChanges += $changes
        }
    }

    # Return the list of breaking changes for ARM services
    return $allChanges
}

<#
This function will update the master breaking change doc with all of the changes that
have been made to ARM, RDFE, and Storage cmdlets.
#>
function UpdateBreakingChangeDoc([string]$PathToDoc, [string[]]$ChangesToAdd)
{
    # Get the contents of the doc
    $content = Get-Content -Path $PathToDoc -Encoding UTF8

    # The new doc will consist of all of the old changes, all of the
    # new changes, and then a header consisting of two lines
    $size = $content.Length + $ChangesToAdd.Length + 2

    # Create an object that will contain the contents of the new doc
    $newContent = New-Object string[] $size

    # The first two lines will consist of the release header
    $newContent[0] = "## $ReleaseDate - Version $ReleaseVersion"
    $newContent[1] = ""

    $buffer = 2

    # Add all of the new content to the doc
    for ($idx = 0; $idx -lt $ChangesToAdd.Length; $idx++)
    {
        $newContent[$idx + $buffer] = $ChangesToAdd[$idx]
    }

    $buffer += $ChangesToAdd.Length

    # Add all of the old content to the doc
    for ($idx = 0; $idx -lt $content.Length; $idx++)
    {
        $newContent[$idx + $buffer] = $content[$idx]
    }

    # Update the master doc to include all of the breaking changes
    $result = $newContent -join "`r`n"
    $tempFile = Get-Item $PathToDoc

    [System.IO.File]::WriteAllText($tempFile.FullName, $result, [Text.Encoding]::UTF8)
}

# ----- START -----

# If there was no path to the Azure PowerShell repository provided, set it based on the location of this script
if (!$PathToRepo)
{
    $PathToRepo = "$PSScriptRoot\.."
}

#Requires -Module PowerShellGet

# Update all of the ResourceManager breaking change docs
$ResourceManagerChanges = UpdateARMBreakingChangeDocs -PathToServices $PathToRepo\src\ResourceManager

# Update the ServiceManagement breaking change doc
$PathToCurrentDoc = "$PathToRepo\src\ServiceManagement\Services\Commands.Utilities\documentation\current-breaking-changes.md"
$ModuleVersion = GetModuleVersion -PathToModule $PathToRepo\src\Package\Debug\ServiceManagement\Azure\Azure.psd1

$ServiceManagementChanges = UpdateCurrentDoc -PathToCurrentDoc $PathToCurrentDoc -ModuleVersion $ModuleVersion

# Update the Storage breaking change doc
$PathToCurrentDoc = "$PathToRepo\src\Storage\documentation\current-breaking-changes.md"
$ModuleVersion = GetModuleVersion -PathToModule $PathToRepo\src\Package\Debug\Storage\Azure.Storage\Azure.Storage.psd1

$StorageChanges = UpdateCurrentDoc -PathToCurrentDoc $PathToCurrentDoc -ModuleVersion $ModuleVersion

$allChanges = @()

# If there were any ARM breaking changes, add them to the list
if ($ResourceManagerChanges.Length -gt 0)
{
    $allChanges += $ResourceManagerChanges    
}

# If there were any RDFE breaking changes, add them to the list
if ($ServiceManagementChanges.Length -gt 0)
{
    $allChanges += $ServiceManagementChanges
}

# If there were any Storage breaking changes, add them to the list
if ($StorageChanges.Length -gt 0)
{
    $allChanges += $StorageChanges
}

# Update the master breaking change doc with all of the breaking changes
UpdateBreakingChangeDoc -PathToDoc $PathToDoc -ChangesToAdd $allChanges