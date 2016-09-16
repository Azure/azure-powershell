# .\BuildDrop.ps1 -BuildArtifactsPath "SAMPLE_PATH\archive" -PSVersion "2.1.0" -CodePlexUsername "cormacpayne" -CodePlexFork "ps0901" -ReleaseDate "2016-09-08" -PathToShared "SAMPLE_PATH\PowerShell"

[CmdletBinding()]
Param(
    [Parameter(Mandatory=$True, Position=0)]
    [String]$BuildArtifactsPath,
    [Parameter(Mandatory=$True, Position=1)]
    [String]$PSVersion,
    [Parameter(Mandatory=$True, Position=2)]
    [String]$CodePlexUsername,
    [Parameter(Mandatory=$True, Position=3)]
    [String]$CodePlexFork,
    [Parameter(Mandatory=$True, Position=4)]
    [String]$ReleaseDate,
    [Parameter(Mandatory=$True, Position=5)]
    [String]$PathToShared
)

# This function will get the ProductCode from a given msi file
function Get-ProductCode
{
    param(
        [Parameter(Mandatory=$True)]
        [System.IO.FileInfo]$Path
    )

    try
    {
        # Read property from MSI database
        $WindowsInstaller = New-Object -ComObject WindowsInstaller.Installer
        $MSIDatabase = $WindowsInstaller.GetType().InvokeMember("OpenDatabase", "InvokeMethod", $null, $WindowsInstaller, @($Path.FullName, 0))
        $Query = "SELECT Value FROM Property WHERE Property = 'ProductCode'"
        $View = $MSIDatabase.GetType().InvokeMember("OpenView", "InvokeMethod", $null, $MSIDatabase, ($Query))
        $View.GetType().InvokeMember("Execute", "InvokeMethod", $null, $View, $null)
        $Record = $View.GetType().InvokeMember("Fetch", "InvokeMethod", $null, $View, $null)
        $Value = $Record.GetType().InvokeMember("StringData", "GetProperty", $null, $Record, 1)
 
        # Commit database and close view
        $MSIDatabase.GetType().InvokeMember("Commit", "InvokeMethod", $null, $MSIDatabase, $null)
        $View.GetType().InvokeMember("Close", "InvokeMethod", $null, $View, $null)           
        $MSIDatabase = $null
        $View = $null
 
        # Return the value
        return $Value
    } 
    catch
    {
        Write-Warning -Message $_.Exception.Message ; break
    }
}

# ==================================================================================================
# Getting the ProductCode from the msi
# ==================================================================================================

Rename-Item "$BuildArtifactsPath\signed\AzurePowerShell.msi" "azure-powershell.$PSVersion.msi"

# Get the ProductCode of the msi
$msiFile = Get-Item "$BuildArtifactsPath\signed\azure-powershell.$PSVersion.msi"
$ProductCode = ([string](Get-ProductCode $msiFile)).Trim()

# ==================================================================================================
# Cloning CodePlex WebPI feed and creating the new branch
# ==================================================================================================

# Clone your fork of the CodePlex WebPI repository
$fork = "https://git01.codeplex.com/forks/$CodePlexUsername/$CodePlexFork"
git clone $fork $CodePlexFork

cd $CodePlexFork

# Create a branch that's in the format of YYYY-MM-DDTHH-MM
$date = Get-Date -Format u
$branch = $date.Substring(0, $date.Length - 4).Replace(":", "-").Replace(" ", "T");
git checkout -b $branch

# ==================================================================================================
# Update the DH_AzurePS.xml file
# ==================================================================================================

cd "Src\azuresdk\AzurePS"

# Get the text for DH_AzurePS.xml
$content = Get-Content "DH_AzurePS.xml"

# $newContent will be the text for the updated DH_AzurePS.xml
$newContentLength = $content.Length + 3
$newContent = New-Object string[] $newContentLength

$VSFeedSeen = $False
$PSGetSeen = $False
$buffer = 0

for ($idx = 0; $idx -lt $content.Length; $idx++)
{
    # Flag that we will be looking at the entries for DH_WindowsAzurePowerShellVSFeed next
    if ($content[$idx] -like "*VSFeed*")
    {
        $VSFeedSeen = $True
    }

    # Flag that we will be looking at the entry for DH_WindowsAzurePowerShellGet next
    if ($content[$idx] -like "*PowerShellGet*")
    {
        $PSGetSeen = $True
    }

    # Check if we are looking at the DiscoveryHints for DH_WindowsAzurePowerShellVSFeed
    # and if we have reached the end of the entry so we can add the new msi Product Code
    if ($VSFeedSeen -and $content[$idx] -like "*</or>*")
    {
        $newContent[$idx] =     "      <discoveryHint>"
        $newContent[$idx + 1] = "        <msiProductCode>$ProductCode</msiProductCode>"
        $newContent[$idx + 2] = "      </discoveryHint>"        

        # Change the buffer size to include the three lines just added
        $buffer = 3
    }

    # Check if we are looking at the entry for DH_WindowsAzurePowerShellGet
    if ($PSGetSeen -and $content[$idx] -like "*msiProductCode*")
    {
        $content[$idx] = "   <msiProductCode>$ProductCode</msiProductCode>"
    }

    $newContent[$idx + $buffer] = $content[$idx]
}

# Replace the contents of the current file with the updated content
$result = $newContent -join "`r`n"
$tempFile = Get-Item "DH_AzurePS.xml"

[System.IO.File]::WriteAllText($tempFile.FullName, $result)

# ==================================================================================================
# Update the WebProductList_AzurePS.xml file
# ==================================================================================================

# Get the text for WebProductList_AzurePS.xml
$content = Get-Content "WebProductList_AzurePS.xml"

$PSGetSeen = $false

for ($idx = 0; $idx -lt $content.Length; $idx++)
{
    # Flag that we will be looking at the entry for WindowsAzurePowerShellGet next
    if ($content[$idx] -contains "  <productId>WindowsAzurePowershellGet</productId>")
    {
        $PSGetSeen = $true
    }

    # If we are in the WindowsAzurePowerShellGet entry, replace the necessary lines
    if ($PSGetSeen)
    {
        if ($content[$idx] -like "*<version>*")
        {
            $content[$idx] = "  <version>$PSVersion</version>"
        }

        if ($content[$idx] -like "*<published>*")
        {
            $content[$idx] = "  <published>$($ReleaseDate)T12:00:00Z</published>"
        }

        if ($content[$idx] -like "*<updated>*")
        {
            $content[$idx] = "  <updated>$($ReleaseDate)T12:00:00Z</updated>"
        }

        if ($content[$idx] -like "*<trackingURL>*")
        {
            $content[$idx] = "        <trackingURL>http://www.microsoft.com/web/handlers/webpi.ashx?command=incrementproddownloadcount&amp;prodid=WindowsAzurePowershell&amp;version=$PSVersion&amp;prodlang=en</trackingURL>"
        }
    }

}

# Replace the contents of the current file with the updated content
$result = $content -join "`r`n"
$tempFile = Get-Item "WebProductList_AzurePS.xml"

[System.IO.File]::WriteAllText($tempFile.FullName, $result)

# ==================================================================================================
# Create registry entry, and rename any prior release candidates
# ==================================================================================================

# Get the name of the folder - YYYY_MM_DD_PowerShell
$entryName = "$($ReleaseDate.Replace("-", "_"))_PowerShell"

# If the folder already exists, we need to rename it to what RC version it is
if (Test-Path "$PathToShared\$entryName")
{
    $id = 1
    
    # Keep incrementing the RC verison until we find the version we are on
    while (Test-Path "$PathToShared\$($entryName)_RC$id")
    {
        $id++
    }

    # Rename the folder to include the RC version
    Rename-Item "$PathToShared\$entryName" "$($entryName)_RC$id"
}

# Create the new folder
New-Item "$PathToShared\$entryName" -Type Directory > $null
New-Item "$PathToShared\$entryName\pkgs" -Type Directory > $null

# Copy all of the scripts and WebPI items into the new folder
Copy-Item "$PathToShared\PSReleaseDrop\*" "$PathToShared\$entryName" -Recurse

# Copy the msi and packages into the new folder
Copy-Item $msiFile.FullName "$PathToShared\$entryName"
Copy-Item "$BuildArtifactsPath\src\Package\*.nupkg" "$PathToShared\$entryName\pkgs"

# ==================================================================================================
# Update other xml files using Build.sh and copy them to entry
# ==================================================================================================

cd ../../../Tools

.\Build.cmd

cd ../bin

Copy-Item .\* $PathToShared\$entryName

# ==================================================================================================
# Commit and push changes to CodePlex
# ==================================================================================================

cd ..

git add .

git commit -m "Update DH_AzurePS.xml and WebProductList_AzurePS.xml"

git push origin $branch