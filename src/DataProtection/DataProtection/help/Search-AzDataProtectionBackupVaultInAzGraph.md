---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/search-azdataprotectionbackupvaultinazgraph
schema: 2.0.0
---

# Search-AzDataProtectionBackupVaultInAzGraph

## SYNOPSIS
Searches for Backup vaults in Azure Resource Graph and retrieves the expected entries

## SYNTAX

```
Search-AzDataProtectionBackupVaultInAzGraph -Subscription <String[]> [-ResourceGroup <String[]>]
 [-Vault <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Searches for Backup vaults in Azure Resource Graph and retrieves the expected entries

## EXAMPLES

### Example 1: Get a specific vault with its name.
```powershell
Search-AzDataProtectionBackupVaultInAzGraph -Subscription "xxxxxxxx-xxxx-xxxxxxxxxxxx" -ResourceGroup $resourceGroupName -Vault $vaultName
```

```output
ETag IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location      Name            Type
---- -------------------                  ----------------                     ------------   --------      ----            ----
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned centraluseuap sarath-vault    Microsoft.DataProtection/backupVaults
```

This command gets a specific vault by given vault name from ARG (Azure Resource Graph).

## PARAMETERS

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

### -ResourceGroup
Resource Group of Vault

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases: ResourceGroupName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subscription
Subscription of Vault

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases: SubscriptionId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Vault
Name of the vault

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases: VaultName

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

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS
