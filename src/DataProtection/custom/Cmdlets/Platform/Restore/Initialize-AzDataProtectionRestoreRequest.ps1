function Initialize-AzDataProtectionRestoreRequest
{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupRestoreRequest')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Prepares Restore Request object for backup')]

    param(
        [Parameter( Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        ${DatasourceType},

        [Parameter(Mandatory, HelpMessage='DataStore Type of the RP')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreType]
        ${SourceDataStore},

        [Parameter(Mandatory, HelpMessage='Target Restore Location')]
        [System.String]
        ${RestoreLocation},

        [Parameter(Mandatory, HelpMessage='Restore Mode')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreMode]
        ${RestoreMode},

        [Parameter(Mandatory, HelpMessage='Restore Target Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreTargetType]
        ${RestoreTargetType},

        [Parameter(Mandatory=$false, HelpMessage='Target Restore Location')]
        [System.String]
        ${TargetResourceId},

        [Parameter(Mandatory=$false, HelpMessage='Recovery Point Name')]
        [System.String]
        ${RecoveryPoint}
    )

    process
    {
        # Validations
        ValidateRestoreOptions -DatasourceType $DatasourceType -RestoreMode $RestoreMode -RestoreTargetType $RestoreTargetType


        $restoreRequest = $null
        # Choose Restore Request Type Based on Mode
        if($RestoreMode -eq "RecoveryPointBased")
        {
            $restoreRequest = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.AzureBackupRecoveryPointBasedRestoreRequest]::new()
            $restoreRequest.ObjectType = "AzureBackupRecoveryPointBasedRestoreRequest"
            $restoreRequest.RecoveryPointId = $RecoveryPoint
        }

        # Initialize Restore Target Info based on Type provided
        if($RestoreTargetType -eq "AlternateLocation")
        {
            $restoreRequest.RestoreTargetInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.RestoreTargetInfo]::new()
            $restoreRequest.RestoreTargetInfo.ObjectType = "RestoreTargetInfo"
        }
        if($RestoreTargetType -eq "RestoreAsFiles")
        {
            $restoreRequest.RestoreTargetInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.RestoreFilesTargetInfo]::new()
            $restoreRequest.RestoreTargetInfo.ObjectType = "RestoreFilesTargetInfo"
        }

        # Fill other fields of Restore Object based on inputs given
        $restoreRequest.SourceDataStoreType = $SourceDataStore
        $restoreRequest.RestoreTargetInfo.RestoreLocation = $RestoreLocation

        if( ($TargetResourceId -ne $null) -and ($TargetResourceId -ne "") )
        {
            if($RestoreTargetType -eq "AlternateLocation")
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
