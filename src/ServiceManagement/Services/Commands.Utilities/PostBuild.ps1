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

$sourceDir = $args[0]
Write-Output $sourceDir

$sourcePath = $sourceDir + "Azure.psd1"
$destDir = $(Split-Path $sourceDir)

Write-Output "Copying '$sourcePath' to directory '$destDir'"
Copy-Item $sourcePath $destDir

Write-Output "Removing $sourcePath"
Remove-Item $sourcePath -Force