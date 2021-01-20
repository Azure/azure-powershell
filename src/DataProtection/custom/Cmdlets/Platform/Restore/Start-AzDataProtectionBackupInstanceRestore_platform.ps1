
function Start-AzDataProtectionBackupInstanceRestore_platform{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Get Backup Vault storage setting object')]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Storage Type of the vault')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupRecoveryPointResource]
        ${RecoveryPoint},

        [Parameter(Mandatory, HelpMessage='DataStore Type of the vault')]
        [System.String]
        [ValidateSet("AzureDatabaseForPostgreSQL", "AzureBlob", IgnoreCase = $true)]
        ${DataSourceType},

        [Parameter(Mandatory=$false, HelpMessage='DataStore Type of the vault')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreRequestType]
        ${RecoveryRequestType},

        [Parameter(Mandatory, HelpMessage='DataStore Type of the vault')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreType]
        ${SourceDataStore},

        [Parameter(Mandatory, HelpMessage='DataStore Type of the vault')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoBase]
        ${TargetInfo},

        [Parameter(Mandatory, HelpMessage='Subscription of Vault')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='Resource Group of Vault')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='Name of the vault')]
        [System.String]
        ${VaultName},

        [Parameter(Mandatory, HelpMessage='Name of the backup instance')]
        [System.String]
        ${BackupInstanceName}
    )

    process {
        $restoreRequestObjectType = GetRestoreType -RestoreType $RecoveryRequestType
        if($restoreRequestObjectType -eq "AzureBackupRecoveryPointBasedRestoreRequest")
        {
            $restoreRequest = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.AzureBackupRecoveryPointBasedRestoreRequest]::new()
            $restoreRequest.ObjectType = $restoreRequestObjectType
            $restoreRequest.RecoveryPointId = $RecoveryPoint.Name
            $restoreRequest.SourceDataStoreType = $SourceDataStore
            $restoreRequest.RestoreTargetInfo = $TargetInfo

            foreach($param in @("RecoveryPoint", "DataSourceType", "RecoveryRequestType", "SourceDataStore", "TargetInfo"))
            {
                if($PSBoundParameters.ContainsKey($param))
                {
                    $null = $PSBoundParameters.Remove($param)
                }
            }

            $PSBoundParameters.Add("Parameter", $restoreRequest)

            Az.DataProtection\Start-AzDataProtectionBackupInstanceRestore @PSBoundParameters
        }
    }

}