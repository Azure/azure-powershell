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

# This will resolve all the solution files under the src folder
# ```powershell
# ./tools/ResolveTools/Resolve-SolutionFile.ps1
# ```

function Resolve($solutionFilePath) {
    $saveLocation = Get-Location
    Write-Host "===== Resolving $solutionFilePath ====="
    $moduleName = [System.IO.Path]::GetFileNameWithoutExtension($solutionFilePath)
    $projectLines = Get-Content -Path $solutionFilePath | Where-Object { $_ -match "Project\(" }

    $moduleFolderPath = [System.IO.Path]::GetDirectoryName($solutionFilePath)
    Set-Location -Path $moduleFolderPath

    # Parse current sln file and resolve the dependent modules
    $dependentModuleFolderPath = @()
    foreach ($line in $projectLines) {
        $csprojPath = ($line -split ",")[1].Trim(' ').Trim('"')
        if (-not $csprojPath.endswith('.csproj')) {
            continue
        }
        if (-Not (Test-Path $csprojPath)) {
            Write-Warning "Cannot find $csprojPath, remove it from $solutionFilePath"
            dotnet sln $moduleName.sln remove $csprojPath
            continue
        }
        $csprojPath = (Resolve-Path $csprojPath).Path.Replace('\', '/')
        if ($csprojPath -match "/tools/") {
            $dependentModuleFolderPath += (Get-Item (Resolve-Path $csprojPath)).Directory.FullName
        }
        else {
            $dependentModuleName = $csprojPath.Split("/src/")[1].Split("/")[0]
            $dependentModuleFolderPath += "../$dependentModuleName"
        }
    }
    $dependentModuleFolderPath = $dependentModuleFolderPath | Select-Object -Unique | Sort-Object

    # Resolve all the csproj files that may reference
    $csprojFiles = @()
    foreach ($folder in $dependentModuleFolderPath) {
        if (Test-Path $folder) {
            $csprojFiles += Get-ChildItem -Path $folder -Filter "*.csproj" -File -Recurse
        }
    }

    # Exclude the test projects under dependent modules
    $resolvedCsprojFilePathList = @()
    foreach ($csproj in $csprojFiles) {
        $csproj = $csproj.FullName.Replace('\', '/')
        if ($csproj -match "\.Test\.csproj" -and $csproj -notmatch $moduleName) {
            continue
        } else {
            $resolvedCsprojFilePathList += $csproj
        }
    }
    $resolvedCsprojFilePathList = $resolvedCsprojFilePathList | Select-Object -Unique | Sort-Object

    #Add the csproj files to sln file with solution folder
    foreach ($csproj in $resolvedCsprojFilePathList) {
        if ($csproj -match "Accounts") {
            dotnet sln $moduleName.sln add $csproj --solution-folder Accounts
        } elseif ($csproj -match "Test") {
            dotnet sln $moduleName.sln add $csproj --solution-folder Test
        } elseif ($csproj -notmatch $moduleName) {
            dotnet sln $moduleName.sln add $csproj --solution-folder Test/DependentModules
        } else {
            dotnet sln $moduleName.sln add $csproj
        }
    }
    Set-Location $saveLocation
}

$srcFolder = "$PSScriptRoot/../../src"
Get-ChildItem -Recurse -Filter *.sln -Path $srcFolder -Exclude Accounts.sln -Depth 2 | Foreach-Object { Resolve $_.FullName }