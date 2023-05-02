# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
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

Param (
)

Class FileChangeIssue {
    [String]$Module
    [Int]$Severity
    [String]$Description
    [String]$Remediation
}
$ExceptionList = @()

$ArtifactsFolder = "$PSScriptRoot/../../../artifacts"
$FilesChangedPath = "$ArtifactsFolder/FilesChanged.txt"
$FilesChanged = Get-Content $FilesChangedPath
$ExceptionFilePath = "$ArtifactsFolder/StaticAnalysisResults/FileChangeIssue.csv"
$UpdatedChangeLogs = @{}

ForEach ($FilePath In ($FilesChanged | Where-Object { $_.EndsWith("ChangeLog.md") }))
{
    If ($FilePath -eq "ChangeLog.md") # Skip for the ChangeLog.md at root folder
    {
        continue
    }
    $ModuleName = $FilePath.Split("/")[1]
    $UpdatedChangeLogs.Add($ModuleName, $FilePath)
}

ForEach ($FilePath In $FilesChanged)
{
    If ($FilePath.StartsWith("src/"))
    {
        $ModuleName = $FilePath.Split("/")[1]

        $FileTypeArray = @(".cs", ".psd1", ".csproj", ".ps1xml", ".resx", ".ps1", ".psm1")
        $FileType = [System.IO.Path]::GetExtension($FilePath)
        If ($FileType -In $FileTypeArray)
        {
            If (-Not ($UpdatedChangeLogs.ContainsKey($ModuleName)))
            {
                $ExceptionList += [FileChangeIssue]@{
                    Module = "Az.$ModuleName";
                    Severity = 2;
                    Description = "It is required to update `ChangeLog.md` if you want to release a new version for Az.$ModuleName."
                    Remediation = "Add a changelog record under `Upcoming Release` section with past tense."
                }
            }
        }

        If ([System.IO.Path]::GetFileName($FilePath) -Eq "AssemblyInfo.cs")
        {
            $ExceptionList += [FileChangeIssue]@{
                Module = "Az.$ModuleName";
                Severity = 2;
                Description = "AssemblyInfo.cs will be updated automatically. Please do not update it manually."
                Remediation = "Revert AssemblyInfo.cs to its last version."
            }
        }
    }
}

If ($ExceptionList.Length -Ne 0)
{
    $ExceptionList | Sort-Object -Unique -Property Module,Description | Export-Csv $ExceptionFilePath -NoTypeInformation
}