function New-AzDataProtectionRetentionLifeCycleClientObject {
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.ISourceLifeCycle')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Creates new Lifecycle object')]

    param (
        [Parameter(Mandatory, HelpMessage='Source Datastore')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreType]
        ${SourceDataStore},

        [Parameter(Mandatory=$false, HelpMessage='Target Datastore')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreType]
        ${TargetDataStore},

        [Parameter(Mandatory, HelpMessage='Retention Duration Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DurationType]
        ${SourceRetentionDurationType},

        [Parameter(Mandatory, HelpMessage='Retention Duration Count')]
        [System.Int32]
        ${SourceRetentionDurationCount},

        [Parameter(Mandatory=$false, HelpMessage='CopyOption')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CopyOption]
        ${CopyOption}
    )

    process {
        $lifeCycle = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.SourceLifeCycle]::new()
        $lifeCycle.SourceDataStoreObjectType = "DataStoreInfoBase"
        $lifeCycle.SourceDataStoreType = $SourceDataStore
        $lifeCycle.DeleteAfterObjectType = "AbsoluteDeleteOption"
        $lifeCycle.DeleteAfterDuration = "P" + $SourceRetentionDurationCount + $SourceRetentionDurationType.ToString()[0]

        if(($TargetDataStore -ne $null) -and ($CopyOption -ne $null))
        {
            $targetCopySetting = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.TargetCopySetting]::new()
            $targetCopySetting.DataStoreObjectType = "DataStoreInfoBase"
            $targetCopySetting.DataStoreType = $TargetDataStore
            $targetCopySetting.CopyAfterObjectType = $CopyOption

            $lifeCycle.TargetDataStoreCopySetting = @($targetCopySetting)
        }
        return $lifeCycle
    }
}