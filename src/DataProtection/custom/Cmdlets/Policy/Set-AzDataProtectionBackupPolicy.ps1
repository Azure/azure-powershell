function Set-AzDataProtectionBackupPolicy
{
	param(
        [Parameter(Mandatory=$false, HelpMessage='SubscriptionId Id')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='Resource Group Name')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='Vault Name')]
        [System.String]
        ${VaultName},

        [Parameter(Mandatory, HelpMessage='Policy Name')]
        [System.String]
        ${Name},

        [Parameter(Mandatory, HelpMessage='Policy Object')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupPolicy]
        ${Policy}
    )

    process
    {
        # Do Validation
        $policyObject = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.BaseBackupPolicyResource]::new()
        $policyObject.Property = $Policy

        $null = $PSBoundParameters.Remove("Policy")
        $null = $PSBoundParameters.Add("Parameter", $policyObject)

        Az.DataProtection.Internal\Set-AzDataProtectionBackupPolicy @PSBoundParameters
    }
}