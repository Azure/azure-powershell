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

# Move the UX metadata files under modules to the artifacts folder and compress them into a zip file.

$RootPath = "$PSScriptRoot/.."
$RepoArtifacts = 'artifacts'
$UXMetadataFolder = "$RootPath/$RepoArtifacts/UX"
If (-Not (Test-Path -Path $UXMetadataFolder))
{
    New-Item -ItemType Directory -Path $UXMetadataFolder
}
Else
{
    Get-ChildItem $UXMetadataFolder | Remove-Item -Force -Recurse
}

$Modules = Get-ChildItem -Path "$RootPath/src" -Directory | ForEach-Object { $_.BaseName }
ForEach ($ModuleName In $Modules)
{
    $SourceFolder = "$RootPath/src/$ModuleName"
    $MetadataFileArray = Get-ChildItem -Path $SourceFolder -Recurse -Filter UX | Get-ChildItem -Recurse -Filter *.json | ForEach-Object { $_.FullName }
    If ($MetadataFileArray.Length -Eq 0)
    {
        Continue
    }

    ForEach ($MetadataFile In $MetadataFileArray)
    {
        $ResourceType = [System.IO.Path]::GetFileName([System.IO.Path]::GetDirectoryName($MetadataFile))
        $ResourceTypeFolder = "$UXMetadataFolder/$ResourceType"
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
            #Merge the json files for the same resource type in hybrid module
            $Metadata1 = Get-Content -Path $TargetPath | ConvertFrom-Json
            $Metadata2 = Get-Content -Path $MetadataFile | ConvertFrom-Json
            $Metadata1.commands += $Metadata2.commands

            ConvertTo-Json -Depth 10 -InputObject $Metadata1 | Out-File -FilePath $TargetPath
        }
    }
}

$ArchivePath = "$RootPath/$RepoArtifacts/UX.zip"
If (Test-Path -Path $ArchivePath)
{
    Remove-Item -Path $ArchivePath -Force
}
Compress-Archive -Path $UXMetadataFolder/* -DestinationPath $ArchivePath
