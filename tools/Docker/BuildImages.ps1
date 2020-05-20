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
    [Parameter(Mandatory = $true)]
    [string]$DOCKER,

    [Parameter(Mandatory = $true)]
    [string]$DockerImageName
)

Import-LocalizedData -BaseDirectory $PSScriptRoot"\..\Az" -FileName "Az.psd1" -BindingVariable AzMetaData 
$version = $AzMetaData.ModuleVersion
Write-Output "Az version: "$version" retrieved, from Az.psd1"
$date = date -u +'%Y-%m-%dT%H:%M:%SZ'

try {
    foreach ($dockerfile in (Get-ChildItem -Path $DOCKER -Filter "Dockerfile-*").FullName) {
        $os = $dockerfile.split("Dockerfile-")[1]
        Write-Output $os
        if ($os -eq "ubuntu-18.04") {
            docker build --build-arg VERSION=$version `
                     --build-arg BUILD_DATE=$date `
                     --tag $DockerImageName':'$version"-"$os `
                     --tag $DockerImageName':latest' `
                     -f $dockerfile $DOCKER
        }else {
            docker build --build-arg VERSION=$version `
                     --build-arg BUILD_DATE=$date `
                     --tag $DockerImageName':'$version"-"$os `
                     -f $dockerfile $DOCKER
        }
        
    }
} catch {
    $Errors = $_
    Write-Error ($Errors | Out-String)
}
