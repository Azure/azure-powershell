function Initialize-AzDataProtectionRestoreRequest
{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequest')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Initializes Restore Request object for triggering restore on a protected backup instance.')]

    param(
        [Parameter(ParameterSetName="OriginalLocationFullRecovery", Mandatory, HelpMessage='Datasource Type')]
        [Parameter(ParameterSetName="AlternateLocationFullRecovery", Mandatory, HelpMessage='Datasource Type')]
        [Parameter(ParameterSetName="OriginalLocationILR", Mandatory, HelpMessage='Datasource Type')]
        # [Parameter(ParameterSetName="AlternateLocationILR", Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        ${DatasourceType},

        [Parameter(ParameterSetName="OriginalLocationFullRecovery", Mandatory, HelpMessage='DataStore Type of the Recovery point')]
        [Parameter(ParameterSetName="AlternateLocationFullRecovery", Mandatory, HelpMessage='DataStore Type of the Recovery point')]
        [Parameter(ParameterSetName="OriginalLocationILR", Mandatory, HelpMessage='DataStore Type of the Recovery point')]
        # [Parameter(ParameterSetName="AlternateLocationILR", Mandatory, HelpMessage='DataStore Type of the Recovery point')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreType]
        ${SourceDataStore},

        [Parameter(ParameterSetName="OriginalLocationFullRecovery", Mandatory=$false, HelpMessage='Id of the recovery point to be restored.')]
        [Parameter(ParameterSetName="AlternateLocationFullRecovery", Mandatory=$false, HelpMessage='Id of the recovery point to be restored.')]
        [Parameter(ParameterSetName="OriginalLocationILR", Mandatory=$false, HelpMessage='Id of the recovery point to be restored.')]
        # [Parameter(ParameterSetName="AlternateLocationILR", Mandatory=$false, HelpMessage='Id of the recovery point to be restored.')]
        [System.String]
        ${RecoveryPoint},
        
        [Parameter(ParameterSetName="OriginalLocationFullRecovery", Mandatory=$false, HelpMessage='Point In Time for restore.')]
        [Parameter(ParameterSetName="AlternateLocationFullRecovery", Mandatory=$false, HelpMessage='Point In Time for restore.')]
        [Parameter(ParameterSetName="OriginalLocationILR", Mandatory=$false, HelpMessage='Point In Time for restore.')]
        # [Parameter(ParameterSetName="AlternateLocationILR", Mandatory=$false, HelpMessage='Point In Time for restore.')]
        [System.DateTime]
        ${PointInTime},

        [Parameter(ParameterSetName="OriginalLocationFullRecovery", Mandatory, HelpMessage='Target Restore Location')]
        [Parameter(ParameterSetName="AlternateLocationFullRecovery", Mandatory, HelpMessage='Target Restore Location')]
        [Parameter(ParameterSetName="OriginalLocationILR", Mandatory, HelpMessage='Target Restore Location')]
        # [Parameter(ParameterSetName="AlternateLocationILR", Mandatory, HelpMessage='Target Restore Location')]
        [System.String]
        ${RestoreLocation},

        [Parameter(ParameterSetName="OriginalLocationFullRecovery", Mandatory, HelpMessage='Restore Target Type')]
        [Parameter(ParameterSetName="AlternateLocationFullRecovery", Mandatory, HelpMessage='Restore Target Type')]
        [Parameter(ParameterSetName="OriginalLocationILR", Mandatory, HelpMessage='Restore Target Type')]
        # [Parameter(ParameterSetName="AlternateLocationILR", Mandatory, HelpMessage='Restore Target Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreTargetType]
        ${RestoreType},

        #[Parameter(ParameterSetName="OriginalLocationFullRecovery", Mandatory, HelpMessage='Switch Parameter to restore to original location.')]
        #[Parameter(ParameterSetName="OriginalLocationILR", Mandatory, HelpMessage='Switch Parameter to restore to original location.')]
        #[Switch]
        #${OriginialLocationRestore},

        #[Parameter(ParameterSetName="AlternateLocationFullRecovery", Mandatory, HelpMessage='Switch Parameter to restore to alternate location.')]
        # [Parameter(ParameterSetName="AlternateLocationILR", Mandatory, HelpMessage='Switch Parameter to restore to alternate location.')]
        #[Switch]
        #${AlternateLocationRestore},        

        [Parameter(ParameterSetName="OriginalLocationFullRecovery", Mandatory, HelpMessage='Backup Instance object to trigger original localtion restore.')]
        [Parameter(ParameterSetName="OriginalLocationILR", Mandatory, HelpMessage='Backup Instance object to trigger original localtion restore.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.BackupInstanceResource]
        ${BackupInstance},

        [Parameter(ParameterSetName="AlternateLocationFullRecovery", Mandatory, HelpMessage='Target resource Id to which backup data will be restored.')]
        # [Parameter(ParameterSetName="AlternateLocationILR", Mandatory, HelpMessage='Target resource Id to which backup data will be restored.')]
        [System.String]
        ${TargetResourceId},

        [Parameter(ParameterSetName="OriginalLocationILR", Mandatory, HelpMessage='Switch Parameter to enable item level recovery.')]
        # [Parameter(ParameterSetName="AlternateLocationILR", Mandatory, HelpMessage='Switch parameter to enable item level recovery.')]
        [Switch]
        ${ItemLevelRecovery},

        [Parameter(ParameterSetName="OriginalLocationILR", Mandatory=$false, HelpMessage='Container names for Item Level Recovery.')]
        # [Parameter(ParameterSetName="AlternateLocationILR", Mandatory=$false, HelpMessage='Container names for Item Level Recovery.')]
        [System.String[]]
        ${ContainersList},

        [Parameter(ParameterSetName="OriginalLocationILR", Mandatory=$false, HelpMessage='Minimum matching value for Item Level Recovery.')]
        # [Parameter(ParameterSetName="AlternateLocationILR", Mandatory=$false, HelpMessage='Minimum matching value for Item Level Recovery.')]
        [System.String[]]
        ${FromPrefixPattern},

        [Parameter(ParameterSetName="OriginalLocationILR", Mandatory=$false, HelpMessage='Maximum matching value for Item Level Recovery.')]
        # [Parameter(ParameterSetName="AlternateLocationILR", Mandatory=$false, HelpMessage='Maximum matching value for Item Level Recovery.')]
        [System.String[]]
        ${ToPrefixPattern}    
    )

    process
    {         
        # Validations
        $parameterSetName = $PsCmdlet.ParameterSetName

        $restoreRequest = $null
        $restoreMode = $null

        # Choose Restore Request Type Based on Recovery Point ID/ Time
        if(($RecoveryPoint -ne $null) -and ($RecoveryPoint -ne ""))
        {   Write-Debug -Message $RecoveryPoint
            $restoreRequest = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupRecoveryPointBasedRestoreRequest]::new()
            $restoreRequest.ObjectType = "AzureBackupRecoveryPointBasedRestoreRequest"
            $restoreRequest.RecoveryPointId = $RecoveryPoint
            $restoreMode = "RecoveryPointBased"
        }
        elseif(($PointInTime -ne $null)  -and ($PointInTime -ne "")) # RecoveryPointInTimeBasedRestore
        {
            $utcTime = $PointInTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
            Write-Debug -Message $utcTime
            $restoreRequest = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupRecoveryTimeBasedRestoreRequest]::new()
            $restoreRequest.ObjectType = "AzureBackupRecoveryTimeBasedRestoreRequest"
            $restoreRequest.RecoveryPointTime = $utcTime
            $restoreMode = "PointInTimeBased"
        }
        else{
            $errormsg = "Please input either RecoveryPoint or PointInTime parameter"
    		throw $errormsg
        }
        
        #Validate Restore Options = recoverypoint, ALR,OLR,ILR
        ValidateRestoreOptions -DatasourceType $DatasourceType -RestoreMode $restoreMode -RestoreTargetType $RestoreType -ItemLevelRecovery $ItemLevelRecovery

        # Initialize Restore Target Info based on Type provided
        if(!($ItemLevelRecovery))
        {   
            # RestoreTargetInfo for OLR ALR Full recovery
            $restoreRequest.RestoreTargetInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.RestoreTargetInfo]::new()
            $restoreRequest.RestoreTargetInfo.ObjectType = "restoreTargetInfo"
        }
        # if($RestoreType -eq "RestoreAsFiles") 
        # {
        #    $restoreRequest.RestoreTargetInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.RestoreFilesTargetInfo]::new()
        #    $restoreRequest.RestoreTargetInfo.ObjectType = "RestoreFilesTargetInfo"
        # }
        else 
        {
            # ILR: ItemLevelRestoreTargetInfo
            $restoreRequest.RestoreTargetInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ItemLevelRestoreTargetInfo]::new()
            $restoreRequest.RestoreTargetInfo.ObjectType = "itemLevelRestoreTargetInfo"

            $restoreCriteriaList = @()
            
            if($ContainersList.length -gt 0){                
                for($i = 0; $i -lt $ContainersList.length; $i++){
                                
                    $restoreCriteria =  [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.RangeBasedItemLevelRestoreCriteria]::new()

                    $restoreCriteria.ObjectType = "RangeBasedItemLevelRestoreCriteria"
                    $restoreCriteria.MinMatchingValue = $ContainersList[$i]
                    $restoreCriteria.MaxMatchingValue = $ContainersList[$i] + "-0"

                    # adding a criteria for each container given
                    $restoreCriteriaList += ($restoreCriteria)
                }
            }
            elseif($FromPrefixPattern.length -gt 0){
                
                if(($FromPrefixPattern.length -ne $ToPrefixPattern.length) -or ($FromPrefixPattern.length -gt 10) -or ($ToPrefixPattern.length -gt 10)){
                    $errormsg = "FromPrefixPattern and ToPrefixPattern parameters maximum length can be 10 and must be equal "
    			    throw $errormsg
                }
                
                for($i = 0; $i -lt $FromPrefixPattern.length; $i++){
                                
                    $restoreCriteria =  [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.RangeBasedItemLevelRestoreCriteria]::new()

                    $restoreCriteria.ObjectType = "RangeBasedItemLevelRestoreCriteria"
                    $restoreCriteria.MinMatchingValue = $FromPrefixPattern[$i]
                    $restoreCriteria.MaxMatchingValue = $ToPrefixPattern[$i]

                    # adding a criteria for each container given
                    $restoreCriteriaList += ($restoreCriteria)
                }                
            }    
            else{
                 $errormsg = "Provide ContainersList or Prefixes for Item Level Recovery"
    			 throw $errormsg            
            }

            $restoreRequest.RestoreTargetInfo.RestoreCriterion = $restoreCriteriaList
        }

        # Fill other fields of Restore Object based on inputs given        
        $restoreRequest.SourceDataStoreType = $SourceDataStore
        $restoreRequest.RestoreTargetInfo.RestoreLocation = $RestoreLocation

        if($RestoreType -eq "AlternateLocation"){
            $resourceId = $TargetResourceId
        }
        elseif($RestoreType -eq "OriginalLocation"){
            $resourceId = $BackupInstance.Property.DataSourceInfo.ResourceId
        }

        if( ($resourceId -ne $null) -and ($resourceId -ne "") )
        {            
            # set DatasourceInfo for OLR, ALR, OriginalLocationILR
            $restoreRequest.RestoreTargetInfo.DatasourceInfo = GetDatasourceInfo -ResourceId $resourceId -ResourceLocation $RestoreLocation -DatasourceType $DatasourceType
            $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
            if($manifest.isProxyResource -eq $true)  
            {
                $restoreRequest.RestoreTargetInfo.DatasourceSetInfo = GetDatasourceSetInfo -DatasourceInfo $restoreRequest.RestoreTargetInfo.DatasourceInfo
            }
        }        

        return $restoreRequest
    }
}