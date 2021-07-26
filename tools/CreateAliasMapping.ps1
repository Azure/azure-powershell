$mapping = [ordered]@{}


.($PSScriptRoot + "\PreloadToolDll.ps1")
$psd1s = Get-ChildItem -Path $PSScriptRoot/../src -Recurse | `
    Where-Object {($_.Name -like "*AzureRM*psd1"  -or $_.Name -eq "Azure.AnalysisServices.psd1" -or $_.Name -eq "Azure.Storage.psd1") `
    -and (-not [Tools.Common.Utilities.ModuleFilter]::IsAzureStackModule($_.FullName)) -and $_.FullName -notlike "*`\Package`\*" -and $_.FullName -notlike "*Test*" -and $_.FullName -notlike "*`\bin`\*" -and $_.FullName -notlike "*`\obj`\*"}


$psd1s | ForEach-Object {
    $name = (($_.Name -replace "AzureRM", "Az") -replace "Azure", "Az") -replace ".psd1", "" -replace "RecoveryServices.SiteRecovery", "RecoveryServices" -replace "RecoveryServices.Backup", "RecoveryServices"
    if (!($mapping.Contains($name)))
    {
        $mapping.Add($name, [ordered]@{})
    }
    Import-LocalizedData -BindingVariable psd1info -BaseDirectory $_.DirectoryName -FileName $_.Name
    $psd1info.CmdletsToExport | ForEach-Object {
        if ($_ -like "*AzureRmStorageContainer*")
        {
            $cmdletalias = $_ -replace "-AzureRM", "-AzRm"
            $mapping[$name].Add($cmdletalias, $_)
        }
        elseif ($_ -like "*Azure*")
        {
            $cmdletalias = ($_ -replace "-AzureRM", "-Azure") -replace "-Azure", "-Az"
            $mapping[$name].Add($cmdletalias, $_)
        }
        else
        {
            Write-Warning $_
        }
    }
    $psd1info.AliasesToExport | ForEach-Object {
        if ($_ -like "*Azure*")
        {
            $cmdletalias = ($_ -replace "-AzureRM", "-Azure") -replace "-Azure", "-Az"
            $mapping[$name].Add($cmdletalias, $_)
        }
        else
        {
            Write-Warning $_
        }
    }
}

ConvertTo-Json $mapping | Set-Content -Path $PSScriptRoot/../src/Accounts/Accounts/AzureRmAlias/Mappings.json