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

param(
    [Parameter(Mandatory)]
    [string] $rootPath = "src",
    [Parameter(Mandatory=$True)]
    [string] $outputFile = "artifacts"
)
$changelogFiles = Get-ChildItem -Path $rootPath -Filter changelog.md -Recurse -File

$modifiedDirectories = New-Object System.Collections.Generic.List[System.String]

foreach ($file in $changelogFiles) {
    $lines = Get-Content $file.FullName
    $isUpcomingSection = $false
    $hasChanges = $false

    foreach ($line in $lines) {
        if ($line -eq "## Upcoming Release") {
            $isUpcomingSection = $true 
        }
        elseif ($isUpcomingSection -and $line.StartsWith("## ")) {
            $isUpcomingSection = $false 
        }
        elseif ($isUpcomingSection -and -not [string]::IsNullOrWhiteSpace($line)) {
            $hasChanges = $true 
            break
        }
    }

    if ($hasChanges) {
        $modifiedDirectories.Add((Get-Item $file.DirectoryName).Name)
    }
}

if ($modifiedDirectories.Count -gt 0) {
    [System.IO.File]::WriteAllText($outputFile, ($modifiedDirectories -join [Environment]::NewLine))
} else {
    [System.IO.File]::WriteAllText($outputFile, "No changes found.")
}
