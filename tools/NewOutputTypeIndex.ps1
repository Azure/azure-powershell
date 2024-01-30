param(
    [Parameter(Mandatory = $false)]
    [string] $BuildConfig = "Release",
    [Parameter(Mandatory = $false)]
    [string] $OutputFile = "outputtypes.json"
)
Install-Module Az.Accounts -Repository PSGallery -Force -Scope CurrentUser
$AzPreviewPath = Get-Item $PSScriptRoot\AzPreview\AzPreview.psd1
Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $AzPreviewPath.DirectoryName -FileName $AzPreviewPath.Name
$ModulePath = ($env:PSModulePath -split ';')[0]
$outputTypes = New-Object System.Collections.Generic.HashSet[string]
$jsonData = Get-Content $OutputFile | ConvertFrom-Json
$ProjectPaths = @( "$PSScriptRoot\..\src" )
$ModuleManifestFile = $ProjectPaths | % { Get-ChildItem -Path $_ -Filter "*.psd1" -Recurse | where {$_.FullName -notlike "*autorest*"}}   
foreach ($item in $jsonData) {
    $outputTypes.Add($item) | Out-Null
}
$ModuleMetadata.RequiredModules | ForEach {
        $ModuleName = $_.ModuleName
        $RequiredVersion = $_.RequiredVersion
        $srcFile = $ModuleManifestFile | Where-Object {$_.Name -eq "$ModuleName.psd1"}
        Import-LocalizedData -BindingVariable srcMetadata -BaseDirectory $srcFile.DirectoryName -FileName $srcFile.Name
        $containsPsd1 = $srcMetadata.NestedModules | Where-Object { $_ -like "*.dll" }
        $DestinationModulePath = [System.IO.Path]::Combine($ModulePath, $ModuleName, $RequiredVersion)
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