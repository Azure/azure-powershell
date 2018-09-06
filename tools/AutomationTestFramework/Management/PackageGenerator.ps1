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

. "$PSScriptRoot\TestExplorer.ps1"

function Create-HelperModule(
    [string] $moduleDir,
    [string] $moduleName,
    [string] $archiveDir) {

    if(-not (Test-Path $archiveDir)) {
        $null = New-Item -ItemType directory -Path $archiveDir -ErrorAction Stop
    }
    $archivePath =  Join-Path $archiveDir "$moduleName.zip"
    if (Test-Path $archivePath) {
        $null = Remove-Item $archivePath -ErrorAction Stop
    }
    $moduleFilePath = Join-Path $moduleDir "$moduleName.psm1"
    Write-Verbose "Creating $archivePath..."
    $null = Compress-Archive -LiteralPath $moduleFilePath -DestinationPath $archivePath -ErrorAction Stop
    Write-Verbose "$archivePath created."
}

function Create-SmokeTestModule(
    [string] $srcPath,
    [string] $archiveDir,
    [string] $moduleName,
    [string[]] $projectList) {

    if (-not (Test-Path $archiveDir)) {
        $null = New-Item -ItemType directory -Path $archiveDir -ErrorAction Stop
    }

    Write-Verbose "Gathering .ps1 test file list from $srcPath..."
    $commonFileName = 'Common.ps1'
    $files = New-Object System.Collections.ArrayList
    foreach($folder in Get-TestFolders $srcPath $projectList) {
        $null = $files.AddRange(@(Filter-TestFiles $folder.Path))
        $commonFilePath = Join-Path $folder.Path $commonFileName
        if(Test-Path $commonFilePath){
            # Copy the file and change the name of it, since we can't have multiple Common.ps1 files in the same module.
            $null = $files.Add((Copy-Item $commonFilePath "$archiveDir\$($folder.Name)$commonFileName" -PassThru -ErrorAction Stop))
        }
        # Get any other common files that aren't specifically Common.ps1.
        $null = $files.AddRange(@(Get-ChildItem -Path $folder.Path -Filter "*$commonFileName" -ErrorAction Stop | Where-Object { $_.Name -ine $commonFileName }))
        if($folder.Name -eq 'Resources') {
            $null = $files.AddRange(@(Get-ChildItem "$($folder.Path)\..\" -Filter "*.json" -ErrorAction Stop))
        }
    }
    # copy the very common files @(Assert.ps1, Common.ps1) from the folder: src\ResourceManager\Common\Commands.ScenarioTests.ResourceManager.Common\
    $rmCommonDir = Join-Path $srcPath 'ResourceManager\Common\Commands.ScenarioTests.ResourceManager.Common'
    $null = $files.Add((Get-Item "$rmCommonDir\Assert.ps1"))
    # Rename the 'common Common.ps1' as to maximize filename clash avoidance.
    $null = $files.Add((Copy-Item "$rmCommonDir\$commonFileName" "$archiveDir\Very$commonFileName" -PassThru -ErrorAction Stop))

    # Create the module file
    $moduleFile = New-Item "$archiveDir\$moduleName.psm1" -type file
    $files | Where-Object { $_.Name -like '*.ps1' } `
        | ForEach-Object {'. "$PSScriptRoot\' + $_.Name + '"'} `
        | Add-Content $moduleFile.FullName -ErrorAction Stop
    $null = $files.Add($moduleFile)

    $zipPath = "$archiveDir\$moduleName.zip"
    if(Test-Path $zipPath) {
        Remove-Item $zipPath -Force -ErrorAction Stop
    }
    Write-Verbose "Creating $zipPath..."
    $files | Compress-Archive -CompressionLevel Fastest -DestinationPath $zipPath -ErrorAction Stop
    Write-Verbose "$zipPath created."

    Get-ChildItem -Path $archiveDir -Filter "*.ps*" | Remove-Item -Force -ErrorAction Stop
}

# Remove version and rename extension .nupkg -> .zip
# Example: AzureRM.Compute.3.3.2.nupkg -> AzureRM.Compute.zip
function Convert-NupkgToZip (
    [string] $path,
    [string[]] $moduleList,
    [string] $outputPath) {
   
    if (-not (Test-Path $outputPath)) {
        $null = New-Item -ItemType directory -Path $outputPath -ErrorAction Stop
    }

    $modulePathFilters = $moduleList | ForEach-Object {
        # https://msdn.microsoft.com/en-us/library/aa717088(v=vs.85).aspx
        $nupkgPath = Join-Path $path "${_}.[0-9]*.nupkg"
        @{Name = $_; Path = $nupkgPath; Exists = Test-Path $nupkgPath}
    }
    # https://stackoverflow.com/a/26559478/294804
    $notFound = ($modulePathFilters | ForEach-Object { $_.Exists }) -contains $false
    if ($notFound) {
        $missingModules = $modulePathFilters | Where-Object { -not $_.Exists } | ForEach-Object { $_.Name }
        throw "Cannot find modules ($missingModules) in the directory '$path'"
    }

    $packages = $modulePathFilters | ForEach-Object { @{Name = $_.Name; File = (Get-ChildItem $_.Path | Select-Object -Last 1)} }
    foreach ($package in $packages) {
        $zipPath = Join-Path $outputPath "$($package.Name).zip"
        if(Test-Path $zipPath) {
            Remove-Item $zipPath -Force -ErrorAction Stop
        }
        Copy-Item $package.File.FullName $zipPath
    }
}

function Get-LatestBuildPath([string] $searchPath) {
    $folderSuffix = '_PowerShell'
    # https://stackoverflow.com/a/25165057/294804
    Get-ChildItem $searchPath -Directory -Filter "*$folderSuffix" `
        | ForEach-Object -Begin { 
            $date = [DateTime]::MinValue.ToString('yyyy_MM_dd')
            $path = $null
        } -Process { 
            $folderDateText = $_.Name -ireplace "$folderSuffix`$", ''
            if($folderDateText -gt $date) { 
                $date = $folderDateText
                $path = $_
            }
        } -End { $path }
}

function Create-SignedModules([hashtable] $signedModules, [string] $modulesDir, [string] $archiveDir) {
    if([string]::IsNullOrEmpty($modulesDir)) {
        $latestBuildPath = Get-LatestBuildPath -searchPath '\\aaptfile01\ADXSDK\PowerShell'
        Write-Verbose "Latest drop path found: $($latestBuildPath.FullName)"
        $modulesDir = Join-Path $latestBuildPath.FullName 'pkgs'
    }
    Convert-NupkgToZip `
        -path $modulesDir `
        -moduleList ($signedModules.Profile + $signedModules.Storage + $signedModules.Other) `
        -outputPath $archiveDir
    Write-Verbose "Signed module zips created in '$archiveDir'."
}