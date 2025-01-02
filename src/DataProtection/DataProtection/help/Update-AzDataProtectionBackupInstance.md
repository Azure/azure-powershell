---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/update-azdataprotectionbackupinstance
schema: 2.0.0
---

# Update-AzDataProtectionBackupInstance

## SYNOPSIS
Updates a given backup instance

## SYNTAX

```
Update-AzDataProtectionBackupInstance -ResourceGroupName <String> -VaultName <String>
 -BackupInstanceName <String> [-SubscriptionId <String>] [-PolicyId <String>]
 [-UseSystemAssignedIdentity <Boolean>] [-UserAssignedIdentityArmId <String>]
 [-VaultedBackupContainer <String[]>] [-ResourceGuardOperationRequest <String[]>] [-Token <String>]
 [-SecureToken <SecureString>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates a given backup instance

## EXAMPLES

### Example 1: Update blob backup instance vaulted policy and containers list
```powershell
$instance = Search-AzDataProtectionBackupInstanceInAzGraph -Subscription $subscriptionId -ResourceGroup $resourceGroupName -Vault $vaultName -DatasourceType AzureBlob
$updatePolicy = Get-AzDataProtectionBackupPolicy -SubscriptionId $subscriptionId -VaultName $vaultName -ResourceGroupName $resourceGroupName| Where-Object { $_.name -eq "vaulted-policy" }
$backedUpContainers = $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0].ContainersList
$updateBI = Update-AzDataProtectionBackupInstance -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name -SubscriptionId $subscriptionId -PolicyId $updatePolicy.Id -VaultedBackupContainer $backedUpContainers[0,2,4]
$updateBI.Property.PolicyInfo.PolicyId
$updateBI.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0].ContainersList
```

```output
/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/rgName/providers/Microsoft.DataProtection/backupVaults/vaultName/backupPolicies/vaulted-policy
updatedContainer1
updatedContainer2
updatedContainer3
```

First command fetch the backup instance which needs to be updated.
Second command gets the backup policy with name vaulted-policy which need to be updated in Backup Instance.
Third command fetches the list of vaulted containers which are currently backed up in the backup vault.
Fourth command update the backup instance with new policy and new list of container (which is currently a subset of the existing backed up containers).
Fifth and sixth command shows the updated policy and containers list in the backu instance.

### Example 2: Update UAMI in Backup Instance
```powershell
$bi = Get-AzDataProtectionBackupInstance -ResourceGroupName "myResourceGroup" -VaultName "myBackupVault" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"

$updateBI = Update-AzDataProtectionBackupInstance -ResourceGroupName "myResourceGroup" -VaultName "myBackupVault" -BackupInstanceName $bi.Name -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -UserAssignedIdentityArmId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myUami" -UseSystemAssignedIdentity $false
```

```output
Name                                                   BackupInstanceName
----                                                   ------------------
psDiskBI-psDiskBI-81234567-6171-4d88-ada3-ec1fc5e6c027 psDiskBI-psDiskBI-81234567-6171-4d88-ada3-ec1fc5e6c027
```

First command fetches the backup instance which needs to be updated.
Second command updates the backup instance with the new User Assigned Managed Identity (UAMI) and disables the use of System Assigned Identity.

## PARAMETERS

### -AsJob

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

### -BackupInstanceName
Unique Name of protected backup instance

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait

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

### -PolicyId
Id of the Policy to be associated with the backup instance

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group of the backup vault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGuardOperationRequest
Resource guard operation request in the format similar to \<ResourceGuard-ARMID\>/dppModifyPolicy/default.
Use this parameter when the operation is MUA protected.

```yaml
Type: System.String[]
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
Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -AsSecureString").Token to fetch authorization token for different tenant.

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

### -SubscriptionId
Subscription Id of the vault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Token
Parameter to authorize operations protected by cross tenant resource guard.
Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -AsSecureString").Token to fetch secure authorization token for different tenant and then convert to string using ConvertFrom-SecureString cmdlet.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityArmId
User assigned identity ARM Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AssignUserIdentity

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseSystemAssignedIdentity
Use system assigned identity

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultedBackupContainer
List of containers to be backed up inside the VaultStore.
Use this parameter for DatasourceType AzureBlob.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
Name of the backup vault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IBackupInstanceResource

## NOTES

## RELATED LINKS
