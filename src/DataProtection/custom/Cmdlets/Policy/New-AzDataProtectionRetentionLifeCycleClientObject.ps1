function New-AzDataProtectionRetentionLifeCycleClientObject {
<<<<<<< HEAD
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.ISourceLifeCycle')]
=======
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201.ISourceLifeCycle')]
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
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
<<<<<<< HEAD
        $lifeCycle = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.SourceLifeCycle]::new()
=======
        $lifeCycle = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201.SourceLifeCycle]::new()
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
        $lifeCycle.SourceDataStoreObjectType = "DataStoreInfoBase"
        $lifeCycle.SourceDataStoreType = $SourceDataStore
        $lifeCycle.DeleteAfterObjectType = "AbsoluteDeleteOption"
        $lifeCycle.DeleteAfterDuration = "P" + $SourceRetentionDurationCount + $SourceRetentionDurationType.ToString()[0]

        if(($TargetDataStore -ne $null) -and ($CopyOption -ne $null))
        {
<<<<<<< HEAD
            $targetCopySetting = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.TargetCopySetting]::new()
=======
            $targetCopySetting = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201.TargetCopySetting]::new()
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
            $targetCopySetting.DataStoreObjectType = "DataStoreInfoBase"
            $targetCopySetting.DataStoreType = $TargetDataStore
            $targetCopySetting.CopyAfterObjectType = $CopyOption

            $lifeCycle.TargetDataStoreCopySetting = @($targetCopySetting)
        }
        return $lifeCycle
    }
}