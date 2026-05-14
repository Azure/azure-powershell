---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/redo-azrecoveryservicesbackupprotection
schema: 2.0.0
---

# Redo-AzRecoveryServicesBackupProtection

## SYNOPSIS
Reconfigures backup protection for a protected item to another Recovery Services vault.

## SYNTAX

```
Redo-AzRecoveryServicesBackupProtection [-Item] <ItemBase> [-TargetVaultId] <String>
 [-TargetPolicy] <PolicyBase> [-RetainRecoveryPointsAsPerPolicy] [-Force] [-VaultId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-SecureToken <SecureString>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Redo-AzRecoveryServicesBackupProtection cmdlet reconfigures backup protection for a supported workload (such as AzureVM, MSSQL, or AzureFiles) by stopping protection, optionally unregistering the container, and enabling protection in a target Recovery Services vault with a specified backup policy. This cmdlet is useful for scenarios where you need to move backup protection between vaults for a single backup item.

## EXAMPLES




### Example 1: Reconfigure protection for an AzureVM workload
```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName rgName -Name srcVaultName
$items = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM -VaultId $vault.ID | Where-Object { $_.ContainerName.EndsWith("vmContainerSuffix") }
$targetVault = Get-AzRecoveryServicesVault -ResourceGroupName rgName -Name trgVaultName
$policy = Get-AzRecoveryServicesBackupProtectionPolicy -Name policyName -VaultId $targetVault.ID
$redo = Redo-AzRecoveryServicesBackupProtection -Item $items[-1] -TargetVaultId $targetVault.ID -TargetPolicy $policy -VaultId $vault.ID -Force -Confirm:$false
```
This example moves backup protection for an Azure VM from one vault to another and applies a new policy.

### Example 2: Reconfigure protection for a SQL workload (AzureWorkload)
```powershell
Connect-AzAccount -TenantId resourceGuardTenantId
$secureToken = (Get-AzAccessToken -TenantId "resourceGuardTenantId" -AsSecureString).Token
Set-AzContext -SubscriptionId subscriptionId
$vault = Get-AzRecoveryServicesVault -ResourceGroupName rgName -Name srcVaultName
$items = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureWorkload -WorkloadType MSSQL -VaultId $vault.ID | Where-Object { $_.ContainerName.EndsWith("sqlContainerSuffix") -and ($_.ProtectionState -eq "Protected" -or $_.ProtectionState  -eq "IRPending")}
$targetVault = Get-AzRecoveryServicesVault -ResourceGroupName rgName -Name trgVaultName
$policy = Get-AzRecoveryServicesBackupProtectionPolicy -Name policyName -VaultId $targetVault.ID
$redo = Redo-AzRecoveryServicesBackupProtection -Item $items[-1] -TargetVaultId $targetVault.ID -TargetPolicy $policy -VaultId $vault.ID -SecureToken $secureToken -Force -Confirm:$false
```
This example moves backup protection for a SQL workload from one vault to another and applies a new policy, using a secure token for cross-tenant authorization.

### Example 3: Reconfigure protection for an AzureFiles workload
```powershell
Connect-AzAccount -TenantId resourceGuardTenantId
$secureToken = (Get-AzAccessToken -TenantId "resourceGuardTenantId" -AsSecureString).Token
Set-AzContext -SubscriptionId subscriptionId
$vault = Get-AzRecoveryServicesVault -ResourceGroupName rgName -Name srcVaultName
$items = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureStorage -WorkloadType AzureFiles -VaultId $vault.ID | Where-Object { $_.ContainerName.EndsWith("fileShareContainerSuffix") }
$targetVault = Get-AzRecoveryServicesVault -ResourceGroupName rgName -Name trgVaultName
$policy = Get-AzRecoveryServicesBackupProtectionPolicy -Name policyName -VaultId $targetVault.ID -PolicySubType Standard
$redo = Redo-AzRecoveryServicesBackupProtection -Item $items[-1] -TargetVaultId $targetVault.ID -TargetPolicy $policy -VaultId $vault.ID -SecureToken $secureToken -Force -Confirm:$false
```
This example moves backup protection for an Azure File Share from one vault to another and applies a new policy, using a secure token for cross-tenant authorization.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Force disables backup protection (prevents confirmation dialog).
This parameter is optional.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Item
Specifies the item to be protected with the given policy.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ItemBase
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RetainRecoveryPointsAsPerPolicy
If this option is used, all the recovery points for this item will expire as per the retention policy.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecureToken
Parameter to authorize operations protected by cross tenant resource guard.
Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").Token to fetch authorization token for different tenant

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetPolicy
Backup policy to be applied in the target vault

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.PolicyBase
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVaultId
Target Recovery Services vault ID where the item will be reconfigured

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultId
ARM ID of the Recovery Services Vault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ItemBase

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.JobBase

## NOTES

## RELATED LINKS
