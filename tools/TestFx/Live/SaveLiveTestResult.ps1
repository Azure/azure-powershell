$ltResults = Get-ChildItem -Path ${env:DATALOCATION} -Filter "LiveTestAnalysis" -Directory -Recurse -ErrorAction SilentlyContinue | Get-ChildItem -Filter "Raw" -Directory | Get-ChildItem -Filter "*.csv" -File | Select-Object -ExpandProperty FullName
if ($null -ne $ltResults) {
    Write-Host "##[group]Start uploading live test results."

    $localDate = [DateTime]::UtcNow.AddHours(8).ToString("yyyy-MM-dd")
    $context = New-AzStorageContext -StorageAccountName ${env:STORAGEACCOUNTNAME}
    $ltResults | ForEach-Object {
        $ltCsv = $_
        $ltCsvCore = Split-Path -Path $ltCsv -Parent | Split-Path -Parent | Split-Path -Parent | Split-Path -Leaf
        $ltCsvName = Split-Path -Path $ltCsv -Leaf
        Set-AzStorageBlobContent -Container ${env:STORAGEBLOBCONTAINERNAME} -Blob "$localDate/$ltCsvCore/$ltCsvName" -File $ltCsv -Context $context -Force

        Write-Host "##[section]Uploaded live test result $ltCsv."
    }

    Write-Host "##[endgroup]"
}
