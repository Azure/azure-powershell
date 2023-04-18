function New-AzDataProtectionRetentionLifeCycleClientObject {
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ISourceLifeCycle')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Creates new Lifecycle object')]

    param (
        [Parameter(Mandatory, HelpMessage='Source Datastore')]
        [System.String]
        ${SourceDataStore},

        [Parameter(Mandatory=$false, HelpMessage='Target Datastore')]
        [System.String]
        ${TargetDataStore},

        [Parameter(Mandatory, HelpMessage='Retention Duration Type')]
        [System.String]
        ${SourceRetentionDurationType},

        [Parameter(Mandatory, HelpMessage='Retention Duration Count')]
        [System.Int32]
        ${SourceRetentionDurationCount},

        [Parameter(Mandatory=$false, HelpMessage='CopyOption')]
        [System.String]
        ${CopyOption}
    )

    process {
        $lifeCycle = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.SourceLifeCycle]::new()
        $lifeCycle.SourceDataStoreObjectType = "DataStoreInfoBase"
        $lifeCycle.SourceDataStoreType = $SourceDataStore
        $lifeCycle.DeleteAfterObjectType = "AbsoluteDeleteOption"
        $lifeCycle.DeleteAfterDuration = "P" + $SourceRetentionDurationCount + $SourceRetentionDurationType.ToString()[0]

        if(($TargetDataStore -ne $null) -and ($CopyOption -ne $null))
        {
            $targetCopySetting = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.TargetCopySetting]::new()
            $targetCopySetting.DataStoreObjectType = "DataStoreInfoBase"
            $targetCopySetting.DataStoreType = $TargetDataStore
            $targetCopySetting.CopyAfterObjectType = $CopyOption

            $lifeCycle.TargetDataStoreCopySetting = @($targetCopySetting)
        }
        return $lifeCycle
    }
}