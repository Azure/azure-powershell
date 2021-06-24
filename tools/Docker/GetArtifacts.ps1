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
param(
    [Parameter(Mandatory = $false, Position = 1)]
    [string]$Artifacts,

    [Parameter(Mandatory = $false, Position = 2)]
    [string]$Docker
)

$count = 0;
try {
    foreach ($artifact in (Get-ChildItem -Path $Artifacts -Filter "*.nupkg").FullName) {
        $count+=1;
        Write-Output "temporarily copy $artifact to $Docker"
        Copy-Item -Path $artifact -Destination $Docker
    }
} catch {
    $Errors = $_
    Write-Error ($_ | Out-String)
}

if ($count -eq 0) {
    Write-Output "No artifacts found, please execute publish step first"
}