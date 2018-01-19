# ----------------------------------------------------------------------------------
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

function Get-TestFolders([string] $srcPath, [string[]] $projectList) {
    # Paths to their scenario tests that do not follow the standard folder hierarchy
    $specialPaths = @{
        'AzureBatch'        = 'Batch.Test\ScenarioTests';
        'Storage'           = 'Management.Storage.Test\ScenarioTests';
        'TrafficManager'    = 'TrafficManager2.Test\ScenarioTests';
        'KeyVault'          = 'KeyVault.Test\Scripts';
        'Profile'           = 'Profile.Test'
    }

    $resourceManagerPath = Join-Path $srcPath 'ResourceManager'
    $resourceManagerFolders = Get-ChildItem -Path $resourceManagerPath -ErrorAction Stop
    $testFolderPairs = New-Object System.Collections.ArrayList
    foreach ($folder in $resourceManagerFolders) {
        if (-not ($projectList.Contains($folder.Name))) { 
            continue
        }

        $testFolderPathPrefix = "$resourceManagerPath\$folder\Commands."
        $testFolderPathSuffix = "$folder.Test\ScenarioTests"
        if ($specialPaths.ContainsKey($folder.Name)) {
            $testFolderPathSuffix = $specialPaths.Get_Item($folder.Name)
        }
        $testFolderPath = "$testFolderPathPrefix$testFolderPathSuffix"

        if (Test-Path $testFolderPath) {
            $null = $testFolderPairs.Add(@{Name = $folder.Name; Path = $testFolderPath})
        } else {
            Write-Verbose "Folder '$testFolderPath' doesn't exist!"
        }
    }
    $testFolderPairs
}

function Filter-TestFiles([string] $path) { Get-ChildItem -Path $path -ErrorAction Stop | Where-Object {$_.Name -match "^(?!Run).*Tests\.ps1$"} }