# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

. "$PSScriptRoot\DeliverModuleToAutomationAccount.ps1"

<#
.SYNOPSIS
Copies files to the $outputFolderName directory removing version and changing extension from .nupkg to .zip
.DESCRIPTION
Azure Automation Account allows only to upload module as ZIP archive, 
where at least one file in the archive has the same name as the archive name. 
Since signed modules are nuget packeges (zip archive with .nupkg extension), 
it sufficient to remove version from the package name and change the extension to .zip
.PARAMETER path
Path to the directory where .nupkg files are located
.PARAMETER moduleList
Parameter description
List of modules (*.nupkg) to copy and rename
.PARAMETER outputFolderName
Directory name to copy renamed files to. If not specified the default name will be 'ToUpload'
#>
function ConvertToProperZip (
     [string] $path
    ,[string[]] $moduleList
    ,[string] $outputFolderName) {

    # remove version and rename extension .nupkg -> .zip
    # exapmle: AzureRM.Compute.3.3.2.nupkg -> AzureRM.Compute.zip

    if (!$outputFolderName) {
        $outputFolderName = 'ToUpload'
    }

    $outputPath = Join-Path $path $outputFolderName
    if (-not (Test-Path $outputPath)) {
        $null = New-Item -ItemType directory -Path $outputPath  -ErrorAction Stop
    } else { 
        Write-Verbose "Cleaning up the target folder..."
        Remove-Item "$outputPath\*" -ErrorAction Stop
    }

    $foundMap = @{}
    $moduleList | ForEach-Object {
       $foundMap.Set_Item($_, $false) 
    }

    $packages = Get-ChildItem $path -Filter "*.nupkg" | Where-Object {
        $name = $_.BaseName -replace "\.\d+\.\d+\.\d+$", "";
        $moduleList.Contains($name)
    } | ForEach-Object {
        $foundMap.Set_Item($name, $true)
        $_
    }
    #$packages

    $unfound = $foundMap.GetEnumerator() | Where-Object { $_.Value -eq $false } | ForEach-Object { $_.Key }

    if ($unfound.Count -gt 0) {
        throw "Can't find modules $unfound in the directory '$path'"
    }
    
    $packages | ForEach-Object { 
        $from = Join-Path $path -ChildPath $_
        $nameWithoutVersion =  $_.BaseName -Replace "\.\d+\.\d+\.\d+$", ""
        $to = Join-Path $outputPath "$nameWithoutVersion.zip"
        Copy-Item  $from -Destination $to
    }
}

<#
.SYNOPSIS
Reorders modules list based on dependecies.
.DESCRIPTION
According to the AzureRM.nuspec dependecy order every module depends on AzureRM.Profile,
so this module should be the first in the list to get uploaded first.
AzureRM.Storage depends on Azure.Storage, so Azure.Storage should be before AzureRM.Storage in the list.
.PARAMETER modules
list of modules to reorder
#>
function OrderModules([string[]] $moduleList) {

    [System.Collections.ArrayList]$moduleList = $moduleList
    [System.Collections.ArrayList]$modulesOrdered = @(@())

    # Wave 1
    $profileModule = "AzureRM.Profile"
    $null = $modulesOrdered.Add( @($profileModule) )
    if ($moduleList.Contains($profileModule)) {
        $moduleList.Remove($profileModule)
    }

    # Wave 2
    $storageModule = "Azure.Storage"
    $storageRmModule = "AzureRM.Storage"
    if ($moduleList.Contains($storageModule) -or $moduleList.Contains($storageRmModule)) {
        $null = $modulesOrdered.Add( @($storageModule))
        if ($moduleList.Contains($storageModule)) {
            $moduleList.Remove($storageModule)
        }
    }

    #Wave 3
    $thirdWave = @()
    $moduleList | Where-Object { 
        $_.ToLower() -ne "AzureRm".ToLower() 
    } | ForEach-Object {
        $thirdWave += $_    
    }

    $null = $modulesOrdered.Add($thirdWave)
   
    $modulesOrdered
}

<#
.SYNOPSIS
Uploads signed modules to Azure Automation Account
.DESCRIPTION
Long description
.PARAMETER path
Path to the directory where .nupkg files are located
.PARAMETER moduleList
User module list to upload. If not specified, all .nupkg files in the $path directory will be uploaded
.EXAMPLE
UploadSignedModules -path "D:\pkgs" -moduleList @('AzureRM.Resources', 'AzureRM.Compute', 'AzureRM.Network', 'AzureRM.Storage', 'AzureRM.Websites',  'AzureRM.KeyVault', 'AzureRM.Sql')
.EXAMPLE
UploadSignedModules -path "D:\pkgs"
.NOTES
Known issue: uploading all bunch of modules failes constantly with internal server error.
My guess - disk quota
#>
function UploadSignedModules ([string] $path, [string[]] $moduleList) {

    $outputFolderName = 'ToUpload'

    if (!$moduleList -or $moduleList.Count -eq 0) { 
        Write-Verbose "Uploading all the modules in the path"
        # use all the '.nupkg' files in the path
        $moduleList = Get-ChildItem $path -Filter "*.nupkg" | ForEach-Object {
            $_.BaseName -replace "\.\d+\.\d+\.\d+$", "";   
        }
    }

    [System.Collections.ArrayList] $modulesOrdered = OrderModules $moduleList


    $modulesOrderedFlat = @()
    $modulesOrdered | ForEach-Object {
        $modulesOrderedFlat += $_
    }
    #$modulesOrderedFlat

    ConvertToProperZip -path $path -moduleList $modulesOrderedFlat -outputFolderName $outputFolderName

    $modulePath = Join-Path $path $outputFolderName

    $modulesOrdered | ForEach-Object {
        $_ | ForEach-Object {

            DeliverModuleToAutomationAccount `
                -modulePath $modulePath `
                -moduleName $_
        }

        $statusMap = CheckModuleProvisionState -moduleList $_
        $failed = $statusMap.GetEnumerator() | Where-Object {$_.Value -eq $false} | ForEach-Object { $_.Key }
        if ($failed.Count -gt 0) {
            throw "Modules $failed failed to upload"
        }
    }    
    Write-Verbose "Modules have been uploaded successfully."     
}

function GetLatestBitsPath([string]$searchPath) {
    $dirList = Get-ChildItem $searchPath -Directory -Filter "*_PowerShell"
    $pattern = '(\d{4}_\d{2}_\d{2})_PowerShell'
    $zeroDate = '0000_00_00'
    $latestDate = $zeroDate
    $dirList | ForEach-Object {
        #$_.Name
        $match = [regex]::Match($_.Name, $pattern)
        if ($match) {
            $d = $match.Groups[1].Value
            if ($d -gt $latestDate) {
                $latestDate = $d
            }
        } else {
            Write-Error "$_ directory doesn't follow the pattern $pattern"
        }
    }

    if ($latestDate -eq $zeroDate) {
        throw "No directories found that follow the pattern $pattern in the $searchPath"
    }

    Join-Path $searchPath "${latestDate}_PowerShell"
}