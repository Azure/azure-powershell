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

Class NecessaryChangeIssue {
    [String]$Module
    [Int]$Severity
    [String]$Description
    [String]$Remediation
}
$ExceptionList = @()

$FilesChangedPath = "$PSScriptRoot/../../../artifacts/FilesChanged.txt"
$FilesChanged = Get-Content $FilesChangedPath
$ExceptionFilePath = "$PSScriptRoot/../../../artifacts/StaticAnalysisResults/NecessaryChangeIssue.csv"
$UpdatedChangeLogs = @{}

ForEach ($FilePath In ($FilesChanged | Where-Object { $_.EndsWith("ChangeLog.md") }))
{
    $ModuleName = $FilePath.Split("/")[1]
    $UpdatedChangeLogs.Add($ModuleName, $FilePath)
}

ForEach ($FilePath In $FilesChanged)
{
    If ($FilePath.StartsWith("src/"))
    {
        $ModuleName = $FilePath.Split("/")[1]
        $FileTypeArray = @(".cs", ".psd1", ".csproj", ".json")
        ForEach ($FileType In $FileTypeArray)
        {
            If ($FilePath.EndsWith($FileType))
            {
                If (-Not ($UpdatedChangeLogs.ContainsKey($ModuleName)))
                {
                    $ExceptionList += [NecessaryChangeIssue]@{
                        Module = "Az.$ModuleName";
                        Severity = 2;
                        Description = "A update of `ChangeLog.md` is necessary if you want a new version of Az.$ModuleName."
                        Remediation = "Add a changelog record under `Upcoming Release` section with past tense."
                    }
                }
            }
        }

        If ($FilePath.EndsWith("AssemblyInfo.cs"))
        {
            $ModuleName = $FilePath.Split("/")[1]
            $ExceptionList += [NecessaryChangeIssue]@{
                Module = "Az.$ModuleName";
                Severity = 2;
                Description = "We will update AssemblyInfo.cs automaticlly. Please donot update it manually."
                Remediation = "Revert AssemblyInfo.cs to last version."
            }
        }
    }
}

If ($ExceptionList.Length -Ne 0)
{
    $ExceptionList | Sort-Object -Unique -Property Module,Description | Export-Csv $ExceptionFilePath -NoTypeInformation
}