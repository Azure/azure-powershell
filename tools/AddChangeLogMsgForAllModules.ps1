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

$updatedModuleList = (find-module AzureRM.* -Repository PSGallery |
                    Where-Object {'azure-sdk' -eq $_.CompanyName -and ('Microsoft Corporation' -eq $_.Author -or 'Microsoft' -eq $_.Author)} |
                    Select-Object -Property Name ).Name
$srcFolder = "$PSScriptRoot\..\src\ResourceManager"
$moduleFolders = Get-ChildItem -Path $srcFolder -Directory -Name

$moduleMappingTable = @{Profile = "Acounts"; Insights="Monitor"; Consumption = "Billing";
                DataFactories = "DataFactory"; DataFactoryV2 = "DataFactory"; SiteRecovery = "RecoveryServices"
                RecoveryServicesBackup = "RecoveryServices"; RecoveryServicesSiteRecovery = "RecoveryServices"}

$folderMappingTable = @{AzureBackup = "Backup"; AzureBatch ="Batch"}

$retiredModules = @("AzureRM.Backup", "AzureRM.Scheduler", "AzureRM.SiteRecovery", "AzureRM.ServerManagement", "AzureRM.Compute.ManagedService")

foreach($moduleFolder in $moduleFolders){
    $moduleName = $moduleFolder
    if($moduleName -in $folderMappingTable.keys)
    {
        $moduleName = $folderMappingTable["$moduleName"]
    }

    $moduleFullName = "AzureRM." + $moduleName

    if($moduleFullName -in $retiredModules)
    {
        Write-Host "Skipping $moduleFullName because it retired"
        continue; 
    }

    if($moduleFullName -notin $updatedModuleList)
    {
        Write-Host "Skipping $moduleFullName because it's a preview version"
        continue;
    }

    $exclude = "*Dataplane*"
    $pathToChangeLogs = (Get-ChildItem -Path "$srcFolder\$moduleFolder\*\ChangeLog.md" -Exclude $exclude |
                    Select-Object -Property FullName).FullName

    foreach($pathToChangeLog in $pathToChangeLogs){  
        # Write-Host "Updating $pathToChangeLog"

        $dirPath = [System.IO.Path]::GetDirectoryName($pathToChangeLog)
        $ps1Path = Get-ChildItem -Path "$dirpath\AzureRM.*.psd1"
        $actualModuleName = ([System.IO.Path]::GetFileNameWithoutExtension($ps1Path)).Substring(8)
        $mappingModuleName = $actualModuleName

        $key = -join $actualModuleName.Split('.')
        if($key -in $moduleMappingTable.keys)
        {
            $mappingModuleName = $moduleMappingTable["$key"]
        }
        Write-Host "Mapping AzureRM.$actualModuleName to Az.$mappingModuleName"

        $content = Get-Content $PathToChangeLog -Encoding UTF8
        $newContent = New-Object string[] ($content.Length + 9)
        $buffer = 0

        for ($idx = 0; $idx -lt $content.Length; $idx++)
        {
            # If we have found the "Current Release" section, update the section content
            if (($content[$idx] -ne $null) -and ($content[$idx].StartsWith("## Current Release")))
            {
                $newContent[$idx] = "## Current Release"
                $newContent[$idx + 1] = "* This module is outdated and will go out of support on 29 February 2024." 
                $newContent[$idx + 2] = "* The Az." + $mappingModuleName + " module has all the capabilities of AzureRM." + $actualModuleName + " and provides the following improvements:"
                $newContent[$idx + 3] = "    - Greater security with token cache encryption and improved authentication."
                $newContent[$idx + 4] = "    - Availability in Azure Cloud Shell and on Linux and macOS."
                $newContent[$idx + 5] = "    - Support for all Azure services."
                $newContent[$idx + 6] = "    - Allows use of Azure access tokens."
                $newContent[$idx + 7] = "* We encourage you to start using the Az module as soon as possible to take advantage of these improvements."
                $newContent[$idx + 8] = "* [Update your scripts](https://aka.ms/azpsmigrate) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024."
                $newContent[$idx + 9] = "* To automatically update your scripts, follow the [quickstart guide](https://aka.ms/azpsmigratequick)."
                $buffer = 9
                $idx++
            }
            # Update the content
            $newContent[$idx + $buffer] = $content[$idx]
        }

        # Update the service change log file to include all of the changes we made
        $result = $newContent -join "`r`n"
        $tempFile = Get-Item $PathToChangeLog
        [System.IO.File]::WriteAllText($tempFile.FullName, $result, [Text.Encoding]::UTF8)
    }
}