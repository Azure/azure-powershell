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

<#
.SYNOPSIS
Collects test powershell scripts from the solution
and ZIPs them
.PARAMETER srcPath
Path to the solution src folder
.PARAMETER targetPath
Path to a working directory
.PARAMETER moduleName
Name of the resulting ZIP archive. 
.PARAMETER projectList
List of the projects to coolect test scripts from. 
Projects are azure-powershell\src\ResourceManager subfolders.
.EXAMPLE
GenerateTestsModule `
    -srcPath "e:\git\azure-powershell\src\" `
    -targetPath ""e:\tmp `
    -moduleName 'AutomationTests' `
    -projectList @('Compute', 'Storage','Network', 'KeyVault', 'Sql', 'Websites')
#>
function GenerateTestsModule (
     [string] $srcPath 
    ,[string] $targetPath
    ,[string] $moduleName
    ,[string[]]$projectList) {
        
    if (-not (Test-Path $targetPath)) {
        $null = New-Item -ItemType directory -Path $targetPath  -ErrorAction Stop
    } else { 
        Write-Verbose "Cleaning up the target folder..."
        Remove-Item "$targetPath\*" -ErrorAction Stop
    }
    Write-Verbose "Scanning project folders for .ps1 tests files..."
    if (!$projectList -or $projectList.Count -eq 0) {
        $projectList = @('Compute', 'Storage','Network', 'KeyVault', 'Sql', 'Websites');
    }
    $projectsToTest = New-Object System.Collections.Generic.HashSet[string] ( , $projectList );
    # test location pattern: ResourceModule/{ServiseName}/Commands.{ServiseName}.Test/ScenarioTests/{*}Tests.ps1
    $patternExeptions = @{
        "AzureBatch"="Batch";
        "Storage" = "Management.Storage";
        "TrafficManager" = "TrafficManager2"
    }
    $resourceManagerPath = Join-Path $srcPath "ResourceManager"
    #Write-Verbose $resourceManagerPath
    Write-Verbose "Collecting .ps1 tests files..."
    $resourceManagerFolders = Get-ChildItem -Path $resourceManagerPath -ErrorAction Stop
    foreach ($folder in $resourceManagerFolders) {
        if (-not ($projectsToTest.Contains($folder.Name))) { 
            continue
        }
        if ($patternExeptions.ContainsKey($folder.Name)) {
            $substitution = $patternExeptions.Get_Item($folder.Name)
            $testFolderPath = "$resourceManagerPath\$folder\Commands.$substitution.Test\ScenarioTests"            
        } else {
            $testFolderPath = "$resourceManagerPath\$folder\Commands.$folder.Test\ScenarioTests"
        }
        if (Test-Path $testFolderPath) {
            $testFiles = Get-ChildItem -Path $testFolderPath -Filter "*Tests.ps1"  -ErrorAction Stop
            #copy to the target folder
            foreach ($file in $testFiles) {
                Copy-Item "$testFolderPath\$file" $targetPath;
            }
            $commonFiles = Get-ChildItem -Path $testFolderPath -Filter "*Common.ps1" -ErrorAction Stop
            foreach ($file in $commonFiles) {
                if ($file.Name.ToLower() -eq "common.ps1") {
                    Copy-Item "$testFolderPath\$file" "$targetPath\$folder$file"  -ErrorAction Stop                     
                } else {
                    Copy-Item "$testFolderPath\$file" $targetPath -ErrorAction Stop
                }
            }
        } else {
            Write-Verbose "folder '$testFolderPath' doesn't exist"
        }
    }

    # copy the very coommon files @(Assert.ps1, Common.ps1) from the folder: src\ResourceManager\Common\Commands.ScenarioTests.ResourceManager.Common\
    $veryCommonPath = Join-Path $resourceManagerPath "Common\Commands.ScenarioTests.ResourceManager.Common"
    Copy-Item "$veryCommonPath\Assert.ps1" $targetPath -ErrorAction Stop 
    Copy-Item "$veryCommonPath\Common.ps1" "$targetPath\VeryCommon.ps1" -ErrorAction Stop 

    $testFiles =  Get-ChildItem -Path $targetPath
    $null = New-Item "$targetPath\$moduleName.psm1" -type file
    foreach ($testFile in $testFiles) {
        (". ""{0}\{1}""" -f '$PSScriptRoot', $testFile) | Add-Content "$targetPath\$moduleName.psm1" -ErrorAction Stop
    }

    Write-Verbose "Adding test files to Powershell ZIP module..."
    Compress-Archive -Path "$targetPath\*" -CompressionLevel Fastest -DestinationPath "$targetPath\$moduleName.zip" -ErrorAction Stop
}