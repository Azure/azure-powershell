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
    [Parameter(Mandatory = $false)]
    [string] $BuildConfig = "Release",
    [Parameter(Mandatory = $false)]
    [string] $OutputFile = "outputtypes.json"
)

$ToolsRootPath = "$PSScriptRoot/.."
$AzPreviewPath = Get-Item $ToolsRootPath\AzPreview\AzPreview.psd1
Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $AzPreviewPath.DirectoryName -FileName $AzPreviewPath.Name
$ModulePath = ($env:PSModulePath -split ';')[0]
$outputTypes = New-Object System.Collections.Generic.HashSet[string]
$jsonData = @()
$ProjectPaths = @( "$ToolsRootPath/../src" )

$ModuleManifestFile = $ProjectPaths | ForEach-Object {
    Get-ChildItem -Path $_ -Filter "*.psd1" -Recurse | Where-Object {
        $_.FullName -notlike "*autorest*"
    }
}

foreach ($item in $jsonData) {
    $outputTypes.Add($item) | Out-Null
}

$ReleaseRepository = "ReleaseRP"
Register-PSRepository -Name $ReleaseRepository -SourceLocation "$ToolsRootPath/../artifacts" -PackageManagementProvider Nuget -InstallationPolicy Trusted
Install-Module -Scope CurrentUser -Name AzPreview -Repository $ReleaseRepository -Force -AllowClobber

$ModuleMetadata.RequiredModules | ForEach-Object {
    $ModuleName = $_.ModuleName
    $Version = $_.RequiredVersion
    if ($Version -eq $null)
    {
        $Version = $_.ModuleVersion
    }
    $srcFile = $ModuleManifestFile | Where-Object {$_.Name -eq "$ModuleName.psd1"}
    Import-LocalizedData -BindingVariable srcMetadata -BaseDirectory $srcFile.DirectoryName -FileName $srcFile.Name
    $containsPsd1 = $srcMetadata.NestedModules | Where-Object { $_ -like "*.dll" }
    $DestinationModulePath = [System.IO.Path]::Combine($ModulePath, $ModuleName, $Version)
    $psd1Path = Join-Path -Path $DestinationModulePath -ChildPath "$ModuleName.psd1"
    if (($containsPsd1.count -gt 0) -and (Test-Path $psd1Path)){
        Import-Module $Psd1Path -Force
        $Module = Get-Module $ModuleName
        foreach ($ModuleInfo in $Module.NestedModules){
            if ($srcMetadata.NestedModules -contains $ModuleInfo.Name+".dll") {
                foreach ($Cmdlet in $ModuleInfo.ExportedCmdlets.Values) {
                    $OutputAttributeList = $Cmdlet.ImplementingType.GetTypeInfo().GetCustomAttributes([System.Management.Automation.OutputTypeAttribute], $true)
                    foreach ($OutputAttribute in $OutputAttributeList)
                    {
                        foreach ($OutputType in $OutputAttribute.Type)
                        {
                            $outputTypes.Add($OutputType.Name) | Out-Null
                        }
                    }
                    foreach ($Parameter in $Cmdlet.Parameters.Values){
                            if ($Parameter.Attributes.TypeId.FullName -contains "System.Management.Automation.ParameterAttribute") {
                                if ($Parameter.ParameterType.FullName -like "*System.Nullable*``[``[*")
                                {
                                    $outputTypes.Add(($Parameter.ParameterType.BaseType.FullName -replace "[][]", "")) | Out-Null
                                }
                                elseif ($Parameter.ParameterType.FullName -notlike "*``[``[*")
                                {
                                    $outputTypes.Add(($Parameter.ParameterType.FullName -replace "[][]", "")) | Out-Null
                                }
                            }
                    }
                }
            }
        }
    }
}
$json = ConvertTo-Json $outputTypes
$json | Out-File "$OutputFile"