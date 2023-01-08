
function New-AzDataProtectionSoftDeleteSettingObject{
    [OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Get Backup Vault soft delete setting object')]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Retention duration in Days')]
        [System.Int32]
        ${RetentionDurationInDay},

        [Parameter(Mandatory=$false, HelpMessage='Soft delete state of the vault')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SoftDeleteState]
        [ValidateSet('Off', 'On', 'AlwaysOn')]
        ${State}
    )

    process {
        
        if ($RetentionDurationInDay -eq 0 -and $State -eq $null) 
        {
            $errormsg = "Please input either RetentionDurationInDay or State parameter"
            throw $errormsg
        }

        $softDeleteSetting = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201.SoftDeleteSettings]::new()
        
        if ($RetentionDurationInDay -ne $null){
            $softDeleteSetting.RetentionDurationInDay = $RetentionDurationInDay
        }

        if ($State -ne $null){
             $softDeleteSetting.State = $State
        }
        
        $softDeleteSetting
    }
}