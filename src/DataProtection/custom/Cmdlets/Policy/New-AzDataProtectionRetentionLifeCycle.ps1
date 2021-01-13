function New-AzDataProtectionRetentionLifeCycle {
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ISourceLifeCycle')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Creates new Lifecycle object')]

    param (
        [Parameter(Mandatory, HelpMessage='Source Datastore')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreType]
        ${SourceDataStore},

        [Parameter(Mandatory, HelpMessage='Target Datastore')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreType]
        ${TargetDataStore},

        [Parameter(Mandatory, HelpMessage='Retention Duration Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DurationType]
        ${SourceRetentionDurationType},

        [Parameter(Mandatory, HelpMessage='Retention Duration Count')]
        [System.Int32]
        ${SourceRetentionDurationCount},

        [Parameter(Mandatory, HelpMessage='CopyOption')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CopyOption]
        ${CopyOption}
    )

    process {
        $lifeCycle = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.SourceLifeCycle]::new()
        $lifeCycle.SourceDataStoreObjectType = "DataStoreInfoBase"
        $lifeCycle.SourceDataStoreType = $SourceDataStore
        $lifeCycle.DeleteAfterObjectType = "AbsoluteDeleteOption"
        $lifeCycle.DeleteAfterDuration = "P" + $SourceRetentionDurationCount + $SourceRetentionDurationType.ToString()[0]

        $targetCopySetting = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.TargetCopySetting]::new()
        $targetCopySetting.DataStoreObjectType = "DataStoreInfoBase"
        $targetCopySetting.DataStoreType = $TargetDataStore
        $targetCopySetting.CopyAfterObjectType = $CopyOption

        $lifeCycle.TargetDataStoreCopySetting = @($targetCopySetting)

        return $lifeCycle
    }
}