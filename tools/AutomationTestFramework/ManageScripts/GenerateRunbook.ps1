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

. "$PSScriptRoot\ListTestFunctions.ps1"

<#
.SYNOPSIS
Generate a powershell file with basic script to run tests.
.DESCRIPTION
Collects list of test function names that marked as AzureAutomation in dot Description section and adds them to powershell script.
.PARAMETER srcPath
Path to the solution src folder.
.PARAMETER bookName
Name of the book on Automation Account.
.PARAMETER connectionName
Name of connection to use in the runbook.
.PARAMETER outputPath
Folder path to put generated runbook to.
.EXAMPLE
GenerateRunbook "e:\git\azure-powershell\src\ResourceManager\Storage\Commands.Management.Storage.Test\ScenarioTests\" "ShchBook" "ShchConn".
#>
function GenerateRunbook {
    param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$srcPath,
        [Parameter(Mandatory = $true, Position = 1)]
        [string]$bookName,
        [Parameter(Mandatory = $false, Position = 2)]
        [string]$connectionName,
        [Parameter(Mandatory = $true, Position = 3)]
        [string]$outputPath
    )
        
    $bookPath = Join-Path $outputPath "$bookName.ps1"
    # $bookPath
    $null = New-Item $bookPath -type file -Force

    $runbookTemplate = Get-Content (Join-Path $PSScriptRoot "RunbookTemplate.ps1")
    $connectionNameTemplate = '%CONNECTION-NAME%'
    $testListTemplate = '%TEST-LIST%'
    $runbookTemplate | ForEach-Object {
        $line = $_
        switch -wildcard ($line) {
            "*$connectionNameTemplate" {
                $line -replace $connectionNameTemplate, "`"$connectionName`"" | Add-Content $bookPath
            } $testListTemplate {
                ListTestFunctions $srcPath | ForEach-Object {
                    $_ | Add-Content $bookPath
                }  
            } default {
                $line | Add-Content $bookPath    
            }
        }
    }
}

<#
.SYNOPSIS
Generate runbook to specified projects
.PARAMETER srcPath
Path to the solution src folder
.PARAMETER connectionName
Name of connection to use in the runbook
.PARAMETER projectList
Specifies which subfolders parse for the runbook.
Projests are azure-powershell\src\ResourceManager subfolders 
.EXAMPLE
GenerateRunbooksForProject  `
    -srcPath "e:\git\azure-powershell\src\" `
    -connectionName "AzPoshTestSpn" `
    -projectList @('Compute', 'Storage','Network', 'KeyVault', 'Sql', 'Websites')
#>
function GenerateRunbooksForProject (
    [string] $srcPath
   ,[string] $connectionName
   ,[string[]]$projectList
   ) {
    #$projectList
    # test location pattern: ResourceModule/{ServiseName}/Commands.{ServiseName}.Test/ScenarioTests/{*}Tests.ps1
    $patternExceptions = @{
        "AzureBatch"="Batch";
        "Storage" = "Management.Storage";
        "TrafficManager" = "TrafficManager2"
    }

    $resourceManagerPath = Join-Path $srcPath "ResourceManager"

    #Write-Verbose $resourceManagerPath
    Write-Verbose "Collecting .ps1 tests files..."

    $resourceManagerFolders = Get-ChildItem -Path $resourceManagerPath -ErrorAction Stop

    $outputPath = Join-Path "$PSScriptRoot\..\" "RunBooks" 

    if (-not (Test-Path $outputPath)) {
        $null = New-Item -ItemType directory -Path $outputPath  -ErrorAction Stop
    } else { 
        Write-Verbose "Cleaning up the $outputPath folder..."
        Remove-Item "$outputPath\*" -ErrorAction Stop
    }

    foreach ($folder in $resourceManagerFolders) {
       if (-not ($projectList.Contains($folder.Name))) { 
           continue
       }

       if ($patternExceptions.ContainsKey($folder.Name)) {
           $substitution = $patternExceptions.Get_Item($folder.Name)
           $testFolderPath = "$resourceManagerPath\$folder\Commands.$substitution.Test\ScenarioTests"            
       } else {
           $testFolderPath = "$resourceManagerPath\$folder\Commands.$folder.Test\ScenarioTests"
       }

       if (Test-Path $testFolderPath) {
            $bookName = "Live{0}Tests" -f $folder.Name
            #$bookName
            GenerateRunbook $testFolderPath  $bookName $connectionName $outputPath

       } else {
           Write-Verbose "folder '$testFolderPath' doesn't exist"
       }
    }
}