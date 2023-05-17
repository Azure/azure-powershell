function Get-SourceResourceId {
    [OutputType('string')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param (
        [Parameter(ParameterSetName='InitializeRestoreRequest', HelpMessage='Specifies the recovery point.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IRecoveryPointResource]
        ${RecoveryPoint}
    )

    process {
		$RecoveryPointId = $RecoveryPoint.Id
        
        $pattern = '/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft\.RecoveryServices/vaults/(?<vaultName>[^/]+)'
        $matches = [regex]::Match($RecoveryPointId, $pattern)
        $SourceSubscriptionId = $matches.Groups["subscriptionId"].Value
        $SourceResourceGroupName = $matches.Groups["resourceGroupName"].Value
        $SourceVaultName = $matches.Groups["vaultName"].Value
        
        $pattern = "/protectedItems/(?<ProtectedItemName>[^/]+)/recoveryPoints"
        $matches = [regex]::Match($RecoveryPointId, $pattern)
        $ProtectedItemName = $matches.Groups["ProtectedItemName"].Value

        $ProtectedItems = Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName $SourceResourceGroupName -VaultName $SourceVaultName -SubscriptionId $SourceSubscriptionId
        
        $SelectedProtectedItem = $ProtectedItems | Where-Object {$_.Name -eq $ProtectedItemName}

        $SelectedProtectedItem.SourceResourceId
	}
}

function ValidateRetentionConfig {
	[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]
	param (
        [Parameter(Mandatory)]
        [string]
        ${ObjectType},

        [Parameter(Mandatory)]
        [string]
        ${TargetContainerId},

        [Parameter(Mandatory)]
        [string]
        ${TargetVirtualMachineId},

        [Parameter(Mandatory)]
        [string]
        ${TargetDirectory},

        [Parameter(Mandatory)]
        [string]
        ${TargetResourceGroupId},

        [Parameter(Mandatory)]
        [string]
        ${DatabaseName},

        [Parameter(Mandatory)]
        [string]
        ${OverwriteOption},

        [Parameter(Mandatory)]
        [string]
        ${SourceResourceId},

        [Parameter(Mandatory)]
        [string]
        ${RecoveryType},

        [Parameter(Mandatory)]
        [string]
        ${RecoveryMode},

        # AzureVM specific parameters

        [Parameter(Mandatory)]
        [string]
        ${RecoveryPointId},

        [Parameter(Mandatory)]
        [string]
        ${StorageAccountId},

        [Parameter(Mandatory)]
        [string]
        ${VirtualNetworkId},

        [Parameter(Mandatory)]
        [string]
        ${SubnetId},

        [Parameter(Mandatory)]
        [string]
        ${Region},

        # SQL specific parameters

        [Parameter(Mandatory)]
        [bool]
        ${NonRecoverable},

        [Parameter(Mandatory)]
        [string]
        ${DataSourceLogicalName},

        [Parameter(Mandatory)]
        [string]
        ${DataSourcePath},

        [Parameter(Mandatory)]
        [string]
        ${DataTargetPath},

        [Parameter(Mandatory)]
        [string]
        ${LogSourceLogicalName},

        [Parameter(Mandatory)]
        [string]
        ${LogSourcePath},

        [Parameter(Mandatory)]
        [string]
        ${LogTargetPath}
    )

    process {
        Write-Debug "Validating retention config"

        # Log all the parameters
        Write-Debug -Message "ObjectType: $ObjectType"
        Write-Debug -Message "TargetContainerId: $TargetContainerId"
        Write-Debug -Message "TargetVirtualMachineId: $TargetVirtualMachineId"
        Write-Debug -Message "TargetDirectory: $TargetDirectory"
        Write-Debug -Message "TargetResourceGroupId: $TargetResourceGroupId"
        Write-Debug -Message "DatabaseName: $DatabaseName"
        Write-Debug -Message "OverwriteOption: $OverwriteOption"
        Write-Debug -Message "SourceResourceId: $SourceResourceId"
        Write-Debug -Message "RecoveryType: $RecoveryType"
        Write-Debug -Message "RecoveryMode: $RecoveryMode"
        Write-Debug -Message "RecoveryPointId: $RecoveryPointId"
        Write-Debug -Message "StorageAccountId: $StorageAccountId"
        Write-Debug -Message "VirtualNetworkId: $VirtualNetworkId"
        Write-Debug -Message "SubnetId: $SubnetId"
        Write-Debug -Message "Region: $Region"
        Write-Debug -Message "NonRecoverable: $NonRecoverable"
        Write-Debug -Message "DataSourceLogicalName: $DataSourceLogicalName"
        Write-Debug -Message "DataSourcePath: $DataSourcePath"
        Write-Debug -Message "DataTargetPath: $DataTargetPath"
        Write-Debug -Message "LogSourceLogicalName: $LogSourceLogicalName"
        Write-Debug -Message "LogSourcePath: $LogSourcePath"
        Write-Debug -Message "LogTargetPath: $LogTargetPath"

        # Validate the parameters
    }
}