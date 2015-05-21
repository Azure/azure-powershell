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

Write-Output -InputObject 'Starting post-build script';

$sourceDir = $args[0];
Write-Output -InputObject $sourceDir;

$sourcePath = $sourceDir + "AzureResourceManager.psd1"
$destDir = Split-Path -Path $sourceDir

if (Test-Path -Path $sourcePath) {
    Write-Output -InputObject "Copying '$sourcePath' to directory '$destDir'";
    Copy-Item -Path $sourcePath -Destination $destDir;
}

if (Test-Path -Path $sourcePath) {
    Write-Output "Removing $sourcePath";
    Remove-Item -Path $sourcePath -Force;
}

Write-Output -InputObject 'Finished post-build script';