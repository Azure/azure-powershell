param(
    [Parameter(Mandatory = $false)]
    [string] $BuildConfig = "Release",
    [Parameter(Mandatory = $false)]
    [string] $OutputFile = "outputtypes.json"
)
$AzPreviewPath = Get-Item $PSScriptRoot\AzPreview\AzPreview.psd1
Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $AzPreviewPath.DirectoryName -FileName $AzPreviewPath.Name
$ModulePath = ($env:PSModulePath -split ';')[0]
$outputTypes = New-Object System.Collections.Generic.HashSet[string]
$jsonData = @()
$ProjectPaths = @( "$PSScriptRoot\..\src" )

$ModuleManifestFile = $ProjectPaths | ForEach-Object {
    Get-ChildItem -Path $_ -Filter "*.psd1" -Recurse | Where-Object {
        $_.FullName -notlike "*autorest*"
    }
}

foreach ($item in $jsonData) {
    $outputTypes.Add($item) | Out-Null
}

$ReleaseRepository = "ReleaseRP"
Register-PSRepository -Name $ReleaseRepository -SourceLocation "$PSScriptRoot/../artifacts" -PackageManagementProvider Nuget -InstallationPolicy Trusted
Install-Module -Scope CurrentUser -Name Az -Repository $ReleaseRepository -Force -AllowClobber

$ModuleMetadata.RequiredModules | ForEach-Object {
    $ModuleName = $_.ModuleName
    $RequiredVersion = $_.RequiredVersion
    $srcFile = $ModuleManifestFile | Where-Object {$_.Name -eq "$ModuleName.psd1"}
    Import-LocalizedData -BindingVariable srcMetadata -BaseDirectory $srcFile.DirectoryName -FileName $srcFile.Name
    $DestinationModulePath = [System.IO.Path]::Combine($ModulePath, $ModuleName, $RequiredVersion)
    $psd1Path = Join-Path -Path $DestinationModulePath -ChildPath "$ModuleName.psd1"
    Write-Host $Psd1Path
    if (-not (Test-Path $Psd1Path))
    {
        Write-Warning "Module $ModuleName not found in $DestinationModulePath"
    }
    # Import-Module $Psd1Path -Force
    Import-Module $ModuleName
    $Module = Get-Module $ModuleName
    foreach ($Cmdlet in $Module.ExportedCmdlets.Values) {
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
gmo -l
$json = ConvertTo-Json $outputTypes
$json | Out-File "$OutputFile"