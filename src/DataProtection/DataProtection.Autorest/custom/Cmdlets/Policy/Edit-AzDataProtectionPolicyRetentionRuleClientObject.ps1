

function Edit-AzDataProtectionPolicyRetentionRuleClientObject {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.ModelCmdletAttribute()]
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupPolicy')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Adds or removes Retention Rule to an existing backup policy. For AzureBlob hybrid policies, OperationalStore lifecycles must use -Name Default_OperationalStore; -Name Default is reserved for VaultStore. Mixing these (or attaching an OperationalStore lifecycle to Weekly/Monthly/Yearly) will throw a validation error.')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PreviewMessage("**********************************************************************************************`n
    * This cmdlet will undergo a breaking change in Az v16.0.0, to be released on May 2026.            *`n
    * At least one change applies to this cmdlet.                                                      *`n
    * See all possible breaking changes at https://go.microsoft.com/fwlink/?linkid=2333486             *`n
    ***************************************************************************************************")]

    param(
        [Parameter(ParameterSetName='AddRetention',Mandatory, HelpMessage='Backup Policy Object')]
        [Parameter(ParameterSetName='RemoveRetention',Mandatory, HelpMessage='Backup Policy Object')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupPolicy]
        ${Policy},

        [Parameter(ParameterSetName='AddRetention',Mandatory, HelpMessage='Retention Rule Name.')]
        [Parameter(ParameterSetName='RemoveRetention',Mandatory, HelpMessage='Retention Rule Name. Note: Default retention rules cannot be removed.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RetentionRuleName]
        ${Name},

        [Parameter(ParameterSetName='AddRetention',Mandatory, HelpMessage='Specifies if retention rule is default retention rule.')]
        [System.Boolean]
        ${IsDefault},

        [Parameter(ParameterSetName='RemoveRetention',Mandatory, HelpMessage='Specifies whether to remove the retention rule.')]
        [System.Management.Automation.SwitchParameter]
        ${RemoveRule},
        
        [Parameter(ParameterSetName='AddRetention',Mandatory=$false, HelpMessage='Specifies whether to modify an existing LifeCycle.')]
        [Nullable[System.Boolean]]
        ${OverwriteLifeCycle},

        [Parameter(ParameterSetName='AddRetention',Mandatory, HelpMessage='Life cycles associated with the retention rule.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ISourceLifeCycle[]]
        ${LifeCycles}
    )

    process {
        $parameterSetName = $PsCmdlet.ParameterSetName
        
        if($parameterSetName -eq "RemoveRetention"){
            if($Name -eq "Default")
            {
                throw  "Removing Default Retention Rule is not allowed. Please try again with different rule name."
            }
            $filteredRules = $Policy.PolicyRule | Where-Object { $_.Name -ne $Name }
            $Policy.PolicyRule = $filteredRules
            return $Policy
        }

        if($parameterSetName -eq "AddRetention"){
            $DatasourceType = GetClientDatasourceType -ServiceDatasourceType $Policy.DatasourceType[0]
            $manifest = LoadManifest -DatasourceType $DatasourceType

            $defaultRetentionMapping = $null
            if($null -ne $manifest.policySettings -and ($manifest.policySettings.PSObject.Properties.Name -contains "defaultRetentionRuleNames")){
                $defaultRetentionMapping = $manifest.policySettings.defaultRetentionRuleNames
            }
            $mappedDefaultNames = @()
            if($null -ne $defaultRetentionMapping){
                $mappedDefaultNames = ValidateRetentionRuleMatchesMappedStore -Name $Name.ToString() -DefaultRetentionMapping $defaultRetentionMapping -LifeCycles $LifeCycles -DatasourceType $DatasourceType

                ValidateExclusiveSourceStoreAssignment -Name $Name.ToString() -Manifest $manifest -DefaultRetentionMapping $defaultRetentionMapping -LifeCycles $LifeCycles -DatasourceType $DatasourceType
            }

            $retentionPolicyIndex = -1
            $policyRuleCount = @($Policy.PolicyRule).Count
            Foreach($index in (0..($policyRuleCount - 1))){
                if($Policy.PolicyRule[$index].Name -eq $Name){
                    $retentionPolicyIndex = $index
                }
            }

            if($retentionPolicyIndex -eq -1){
                if($manifest.policySettings.disableAddRetentionRule -eq $true)
                {
                    $message = "Adding New Retention Rule is not supported for " + $DatasourceType + " datasource type."
                    throw $message
                }

                $isMappedDefault = ($mappedDefaultNames -contains $Name.ToString())
                if(($manifest.policySettings.supportedRetentionTags.Contains($Name.ToString()) -eq $false) -and (-not $isMappedDefault))
                {
                    throw "Selected Retention Rule " + $Name  + " is not applicable for datasource type " + $DatasourceType
                }

                $newRetentionRule = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.AzureRetentionRule]::new()
                $newRetentionRule.ObjectType = "AzureRetentionRule"
                $newRetentionRule.IsDefault = $IsDefault
                $newRetentionRule.Name = $Name
                $newRetentionRule.LifeCycle = $LifeCycles
                $Policy.PolicyRule += $newRetentionRule

                return $Policy
            }

            if($retentionPolicyIndex -ne -1){

                if($OverwriteLifeCycle -eq $false){
                    throw "Retention rule '$Name' already exists. Use -OverwriteLifeCycle `$true to update it."
                }
                else {
                    $Policy.PolicyRule[$retentionPolicyIndex].LifeCycle = $LifeCycles
                }
                
                return $Policy
            }
        }
    }
}