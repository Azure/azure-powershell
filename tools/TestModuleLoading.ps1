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

param (
    [string] $configuration = 'Debug',
    [string] $pathDelimiter = ':'
)

$tempModulePath = $env:PSModulePath
$outputDir = "$PSScriptRoot/../artifacts/$configuration"
Write-Warning "Running Test-ModuleManfiest on .psd1 files in $outputDir"
$env:PSModulePath += "$pathDelimiter$outputDir/"
Write-Warning "PSModulePath: $env:PSModulePath"

$success = $true
foreach($psd1FilePath in Get-Item "$outputDir/Az.*/Az.*.psd1") {
    $manifestError = $null
    Test-ModuleManifest -Path $psd1FilePath.FullName -ErrorVariable manifestError
    if($manifestError){
        Write-Warning "$($psd1FilePath.Name) failed to load."
        $success = $false
    }
}

$env:PSModulePath = $tempModulePath
if(-not $success) {
    Write-Warning 'Failure: One or more module manifests failed to load.'
    exit 1
}