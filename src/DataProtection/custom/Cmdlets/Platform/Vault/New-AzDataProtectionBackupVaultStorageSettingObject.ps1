
function New-AzDataProtectionBackupVaultStorageSettingObject{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Get Backup Vault storage setting object')]

    param(
        [Parameter(Mandatory, HelpMessage='Storage Type of the vault')]
        [System.String]
        ${Type},

        [Parameter(Mandatory, HelpMessage='DataStore Type of the vault')]
        [System.String]
        ${DataStoreType}
    )

    process {
        $storageSetting = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.StorageSetting]::new()
        $storageSetting.Type = $Type
        $storageSetting.DataStoreType = $DataStoreType

        $storageSetting
    }
}