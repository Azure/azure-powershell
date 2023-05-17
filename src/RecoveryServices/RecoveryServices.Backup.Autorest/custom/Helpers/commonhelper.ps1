# takes bacvkupmanagement type and workload type as i/p & gives dataspurce type
function Get-DataSourceType {
    param(
        [string]$BackupManagementType,
        [string]$WorkloadType
    )

    if ($BackupManagementType -eq "AzureWorkload") {
        if ($WorkloadType -eq "SAPHanaDatabase") {
            return "SAPHANA"
        } elseif ($WorkloadType -eq "SQLDataBase") {
            return "MSSQL"
        }
    } elseif ($BackupManagementType -eq "AzureIaasVM") {
        return "AzureVM"
    }

    # Return null if no match found
    return $null
}