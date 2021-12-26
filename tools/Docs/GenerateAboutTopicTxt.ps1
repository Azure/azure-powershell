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
Usage: Converts markdown files under 'About' folder to txt files.
To run this script, please pre-install pandoc in advance. Please refer to: https://pandoc.org/installing.html
#>

param(
    [string]$AboutFolder = "$PSScriptRoot/../../src/Accounts/Accounts/help/About/",
    [string]$PandocExePath  = "C:\Program Files\Pandoc\pandoc.exe"
)

if (Test-Path $AboutFolder) {
    Get-ChildItem "$AboutFolder/about_*.md" | ForEach-Object {
        $aboutFileInputFullName = $_.FullName
        $aboutFileOutputName = "$($_.BaseName).help.txt"
        $aboutFileOutputFullName = Join-Path $AboutFolder $aboutFileOutputName
        $pandocArgs = @(
            "--from=gfm",
            "--to=plain+multiline_tables",
            "--columns=75",
            "--output=$aboutFileOutputFullName",
            "--quiet"
        )
        Write-Verbose -Verbose "Converting $aboutFileInputFullName to $aboutFileOutputFullName"
        Get-Content $aboutFileInputFullName | & $PandocExePath $pandocArgs
    }
  }