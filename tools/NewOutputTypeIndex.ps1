param(
    [Parameter(Mandatory = $false)]
    [string] $BuildConfig = "Debug",
    [Parameter(Mandatory = $false)]
    [string] $OutputFile = "$PSScriptRoot/outputtypes.json"
)

# Get all psd1 files
$psd1Files = Get-Item $PSScriptRoot\..\artifacts\$BuildConfig\Az.*\Az.*.psd1

$profilePsd1 = $psd1Files | Where-Object {$_.Name -like "*Az.Accounts.psd1"}
Import-LocalizedData -BindingVariable "psd1File" -BaseDirectory $profilePsd1.DirectoryName -FileName $profilePsd1.Name
foreach ($nestedModule in $psd1File.RequiredAssemblies)
{
    $dllPath = Join-Path -Path $profilePsd1.DirectoryName -ChildPath $nestedModule
    $Assembly = [Reflection.Assembly]::LoadFrom($dllPath)
}

$outputTypes = New-Object System.Collections.Generic.HashSet[string]

$psd1Files | ForEach {
    Import-LocalizedData -BindingVariable "psd1File" -BaseDirectory $_.DirectoryName -FileName $_.Name
    foreach ($nestedModule in $psd1File.NestedModules)
    {
        if('.dll' -ne [System.IO.Path]::GetExtension($nestedModule)) 
        {
            continue;
        }
        $dllPath = Join-Path -Path $_.DirectoryName -ChildPath $nestedModule
        $Assembly = [Reflection.Assembly]::LoadFrom($dllPath)
        $exportedTypes = $Assembly.GetTypes()
        foreach ($exportedType in $exportedTypes)
        {
            foreach ($attribute in $exportedType.CustomAttributes)
            {
                if ($attribute.AttributeType.Name -eq "OutputTypeAttribute")
                {
                    $cmdletOutputTypes = $attribute.ConstructorArguments.Value.Value
                    foreach ($cmdletOutputType in $cmdletOutputTypes)
                    {
                        $outputTypes.Add($cmdletOutputType.FullName) | Out-Null
                    }
                }
            }

            foreach ($property in $exportedType.GetProperties() | Where-Object {$_.CustomAttributes.AttributeType.Name -contains "ParameterAttribute"})
            {
                if ($property.PropertyType.FullName -like "*System.Nullable*``[``[*")
                {
                    $outputTypes.Add(($property.PropertyType.BaseType.FullName -replace "[][]", "")) | Out-Null
                }
                elseif ($property.PropertyType.FullName -notlike "*``[``[*")
                {
                    $outputTypes.Add(($property.PropertyType.FullName -replace "[][]", "")) | Out-Null
                }
            }
        }
    }
}

$json = ConvertTo-Json $outputTypes
$json | Out-File "$OutputFile"