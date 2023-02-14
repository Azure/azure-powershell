
function New-AzDataProtectionBackupVaultStorageSettingObject{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Get Backup Vault storage setting object')]

    param(
        [Parameter(Mandatory, HelpMessage='Storage Type of the vault')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.StorageSettingType]
        ${Type},

        [Parameter(Mandatory, HelpMessage='DataStore Type of the vault')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreType]
        ${DataStoreType}
    )

    process {
<<<<<<< HEAD
        $storageSetting = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.StorageSetting]::new()
=======
        $storageSetting = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201.StorageSetting]::new()
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
        $storageSetting.Type = $Type
        $storageSetting.DataStoreType = $DataStoreType

        $storageSetting
    }
}