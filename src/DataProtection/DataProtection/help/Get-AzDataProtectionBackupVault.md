---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionbackupvault
schema: 2.0.0
---

# Get-AzDataProtectionBackupVault

## SYNOPSIS
Returns resource collection belonging to a subscription.

## SYNTAX

### Get (Default)
```
Get-AzDataProtectionBackupVault [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get2
```
Get-AzDataProtectionBackupVault [-SubscriptionId <String[]>] -ResourceGroupName <String> -VaultName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get1
```
Get-AzDataProtectionBackupVault [-SubscriptionId <String[]>] -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataProtectionBackupVault -InputObject <IDataProtectionIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Returns resource collection belonging to a subscription.

## EXAMPLES

### Example 1: Get all backup vaults in a given subscription
```powershell
Get-AzDataProtectionBackupVault
```

```output
ETag IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location      Name                          Type
---- -------------------                  ----------------                     ------------   --------      ----                          ----
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned westus        adigupt-backupcenter-ga-Vault Microsoft.DataProtection/backupVault
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned westcentralus BC-Usability-Vault-WCUS       Microsoft.DataProtection/backupVault
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned centraluseuap NilayBackupVault              Microsoft.DataProtection/backupVault
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned centraluseuap dpprunnervaultus              Microsoft.DataProtection/backupVault
```

This command gets all backup vaults in current subscription context.
Provide SubscriptionId parameter to retrieve backup vaults in a different subscription.

### Example 2: Get all backup vaults in a given resource Group.
```powershell
Get-AzDataProtectionBackupVault -SubscriptionId "xxxx-xxx-xxxx" -ResourceGroupName sarath-rg
```

```output
ETag IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location      Name            Type
---- -------------------                  ----------------                     ------------   --------      ----            ----
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned centraluseuap sarath-dppvault Microsoft.DataProtection/backupVaults
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned centraluseuap sarath-vault    Microsoft.DataProtection/backupVaults
```

This command gets all backup vaults in a given resource group.

### Example 3: Get a specific vault.
```powershell
Get-AzDataProtectionBackupVault -SubscriptionId "xxxx-xxx-xxxx" -ResourceGroupName sarath-rg -VaultName sarath-vault
```

```output
ETag IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location      Name            Type
---- -------------------                  ----------------                     ------------   --------      ----            ----
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned centraluseuap sarath-vault    Microsoft.DataProtection/backupVaults
```

This command gets a specific vault by given vault name.

### Example 4: Get secure score of backup vault.
```powershell
$vault = Get-AzDataProtectionBackupVault -SubscriptionId "xxxx-xxx-xxxx" -ResourceGroupName hiaga-rg -VaultName hiaga-vault
$vault.SecureScore
```

```output
Adequate
```

First command gets a specific vault by given vault name, then we fetch the secure score of the vault which shows Adequate.

### Example 4: Get encryption settings of backup vault.
```powershell
$vault = Get-AzDataProtectionBackupVault -SubscriptionId "xxxx-xxx-xxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
$vault.EncryptionSetting |fl
$vault.EncryptionSetting.CmkIdentity |fl
$vault.EncryptionSetting.CmkKeyVaultProperty |fl
```

```output
CmkIdentity                 : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.CmkKekIdentity
CmkInfrastructureEncryption : Enabled
CmkKeyVaultProperty         : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.CmkKeyVaultProperties
State                       : Enabled

IdentityId   : /subscriptions/191973cd-9c54-41e0-ac19-25dd9a92d5a8/resourcegroups/jeevan-wrk-vms/providers/Microsoft.ManagedIdentity/userAssignedIdentities
               /userMSIpstest
IdentityType : UserAssigned

KeyUri : https://jeevantestkeyvaultcmk.vault.azure.net/keys/pstest/3cd5235ad6ac4c11b40a6f35444bcbe1
```

First command gets a specific vault by given vault name, subsequent three commands fetch the specity properites of encryption settings.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get2, Get1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, Get2, Get1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the backup vault.

```yaml
Type: System.String
Parameter Sets: Get2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IBackupVaultResource

## NOTES

## RELATED LINKS
