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

# Move the UX metadata files under modules to the artifacts folder for veridation. Merge the metadata file if the module is hybrid and both have metadata for the same sub resource type.

Param(
    [String]
    $RepoArtifacts='artifacts',

    [String]
    $Configuration='Debug'
)

$ConfigurationFolderPath = "$RepoArtifacts/$Configuration"
$Modules = Get-ChildItem -Path $ConfigurationFolderPath | % { $_.BaseName }
Write-Host $Modules
ForEach ($ModuleName In $Modules)
{
    $RPName = $ModuleName.Replace("Az.", "")
    $SourceFolder = "$PSScriptRoot/../../../src/$RPName"
    $UXFolderPath = "$ConfigurationFolderPath/$ModuleName/UX"
    $MetadataFileArray = Get-ChildItem -Path $SourceFolder -Recurse -Filter UX | Get-ChildItem -Recurse -Filter *.json | % { $_.FullName }
    If ($MetadataFileArray.Length -Eq 0)
    {
        Continue
    }

    If (-Not (Test-Path -Path $UXFolderPath))
    {
        New-Item -ItemType Directory -Path $UXFolderPath
    }
    ForEach ($MetadataFile In $MetadataFileArray)
    {
        $ResourceType = [System.IO.Path]::GetFileName([System.IO.Path]::GetDirectoryName($MetadataFile))
        $ResourceTypeFolder = "$UXFolderPath/$ResourceType"
        If (-Not (Test-Path -Path $ResourceTypeFolder))
        {
            New-Item -ItemType Directory -Path $ResourceTypeFolder
        }
        $FileName = [System.IO.Path]::GetFileName($MetadataFile)
        $TargetPath = "$ResourceTypeFolder/$FileName"
        If (-Not (Test-Path -Path $TargetPath))
        {
            Copy-Item -Path $MetadataFile -Destination $TargetPath
        }
        Else
        {
            #Merge the json files for the same sub resource type in hybrid module
            $Metadata1 = Get-Content -Path $TargetPath | ConvertFrom-Json
            $Metadata2 = Get-Content -Path $MetadataFile | ConvertFrom-Json
            $Metadata1.commands += $Metadata2.commands

            ConvertTo-Json -Depth 10 -InputObject $Metadata1 | Out-File -FilePath $TargetPath
        }
    }
}
