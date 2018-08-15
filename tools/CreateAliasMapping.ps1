$mapping = @{}

$psd1s = Get-ChildItem -Path $PSScriptRoot/../src -Recurse | `
    Where-Object {($_.Name -like "*AzureRM*psd1"  -or $_.Name -eq "Azure.AnalysisServices.psd1" -or $_.Name -eq "Azure.Storage.psd1") `
    -and $_.FullName -notlike "*Stack*" -and $_.FullName -notlike "*`\Package`\*" -and $_.FullName -notlike "*Test*" -and $_.FullName -notlike "*`\bin`\*" -and $_.FullName -notlike "*`\obj`\*"}

$psd1s | ForEach-Object {
    <# Will be added back for Storage name class in Storage preview 
    if ($_.Name -eq "AzureRM.Storage.psd1")
    {
        $name = ($_.Name -replace "AzureRM", "Az") -replace "Azure", "Az"
        if (!($mapping.Contains($name)))
        {
            $mapping.Add($name, @{})
        }
        Import-LocalizedData -BindingVariable psd1info -BaseDirectory $_.DirectoryName -FileName $_.Name
        $psd1info.CmdletsToExport | ForEach-Object {
            if ($_ -like "*Azure*")
            {
                $cmdletalias = ($_ -replace "AzureRM", "Azure") -replace "Azure", "AzRm"
                $mapping[$name].Add($cmdletalias, $_)
            }
            else
            {
                Write-Warning $_
            }
        }
    } 
    else
    { #>
        $name = ($_.Name -replace "AzureRM", "Az") -replace "Azure", "Az"
        if (!($mapping.Contains($name)))
        {
            $mapping.Add($name, @{})
        }
        Import-LocalizedData -BindingVariable psd1info -BaseDirectory $_.DirectoryName -FileName $_.Name
        $psd1info.CmdletsToExport | ForEach-Object {
            if ($_ -like "*Azure*")
            {
                $cmdletalias = ($_ -replace "AzureRM", "Azure") -replace "Azure", "Az"
                $mapping[$name].Add($cmdletalias, $_)
            }
            else
            {
                Write-Warning $_
            }
        }
    #}
    
}

$json = ConvertTo-Json $mapping
$json | Out-File $PSScriptRoot/AliasMapping.json