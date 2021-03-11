function Initialize-AzDataProtectionRestoreRequest
{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequest')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Initializes Restore Request object for triggering restore on a protected backup instance.')]

    param(
        [Parameter(ParameterSetName="RecoveryPointBased", Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        ${DatasourceType},

        [Parameter(ParameterSetName="RecoveryPointBased", Mandatory, HelpMessage='DataStore Type of the Recovery point')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreType]
        ${SourceDataStore},

        [Parameter(ParameterSetName="RecoveryPointBased", Mandatory, HelpMessage='Target Restore Location')]
        [System.String]
        ${RestoreLocation},

        [Parameter(ParameterSetName="RecoveryPointBased", Mandatory, HelpMessage='Restore Target Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreTargetType]
        ${RestoreType},

        [Parameter(ParameterSetName="RecoveryPointBased", Mandatory=$false, HelpMessage='Target resource Id to which backup data will be restored.')]
        [System.String]
        ${TargetResourceId},

        [Parameter(ParameterSetName="RecoveryPointBased", Mandatory, HelpMessage='Id of the recovery point to be restored.')]
        [System.String]
        ${RecoveryPoint}
    )

    process
    {
        # Validations
        $parameterSetName = $PsCmdlet.ParameterSetName
        ValidateRestoreOptions -DatasourceType $DatasourceType -RestoreMode $parameterSetName -RestoreTargetType $RestoreType

        $restoreRequest = $null
        # Choose Restore Request Type Based on Mode
        if($parameterSetName -eq "RecoveryPointBased")
        {
            $restoreRequest = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.AzureBackupRecoveryPointBasedRestoreRequest]::new()
            $restoreRequest.ObjectType = "AzureBackupRecoveryPointBasedRestoreRequest"
            $restoreRequest.RecoveryPointId = $RecoveryPoint
        }

        # Initialize Restore Target Info based on Type provided
        if($RestoreType -eq "AlternateLocation")
        {
            $restoreRequest.RestoreTargetInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.RestoreTargetInfo]::new()
            $restoreRequest.RestoreTargetInfo.ObjectType = "RestoreTargetInfo"
        }
        if($RestoreType -eq "RestoreAsFiles")
        {
            $restoreRequest.RestoreTargetInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.RestoreFilesTargetInfo]::new()
            $restoreRequest.RestoreTargetInfo.ObjectType = "RestoreFilesTargetInfo"
        }

        # Fill other fields of Restore Object based on inputs given
        $restoreRequest.SourceDataStoreType = $SourceDataStore
        $restoreRequest.RestoreTargetInfo.RestoreLocation = $RestoreLocation

        if( ($TargetResourceId -ne $null) -and ($TargetResourceId -ne "") )
        {
            if($RestoreType -eq "AlternateLocation")
            {
                $restoreRequest.RestoreTargetInfo.DatasourceInfo = GetDatasourceInfo -ResourceId $TargetResourceId -ResourceLocation $RestoreLocation -DatasourceType $DatasourceType
                $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
                if($manifest.isProxyResource -eq $true)
                {
                    $restoreRequest.RestoreTargetInfo.DatasourceSetInfo = GetDatasourceSetInfo -DatasourceInfo $restoreRequest.RestoreTargetInfo.DatasourceInfo
                }
            }
        }

        return $restoreRequest
    }
}
