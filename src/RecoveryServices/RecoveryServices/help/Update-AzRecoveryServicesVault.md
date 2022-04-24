---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/update-azrecoveryservicesvault
schema: 2.0.0
---

# Update-AzRecoveryServicesVault

## SYNOPSIS
Updates MSIdentity to the recovery services vault.

## SYNTAX

### AzureRSVaultAddMSIdentity (Default)
```
Update-AzRecoveryServicesVault [-ResourceGroupName] <String> [-Name] <String> -IdentityType <MSIdentity>
 [-IdentityId <String[]>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AzureRSVaultRemoveMSIdentity
```
Update-AzRecoveryServicesVault [-ResourceGroupName] <String> [-Name] <String> [-IdentityId <String[]>]
 [-RemoveUserAssigned] [-RemoveSystemAssigned] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
This cmdlet is used to add or remove the MSI from the recovery services vault. Use -IdentityType param to add a SystemAssigned/UserAssigned identity to the RSVault. Use RemoveSystemAssigned/RemoveUserAssigned switch to remove the MSI from the vault.

## EXAMPLES

### Example 1: Add SystemAssigned identity to the recovery services vault
```powershell
Update-AzRecoveryServicesVault -ResourceGroupName "rgName" -Name "vaultName" -IdentityType SystemAssigned
```

This cmdlet is used to add a SystemAssigned identity to a recovery services vault.

### Example 2: Add UserAssigned identity to the recovery services vault
```powershell
$vault = Get-AzRecoveryServicesVault -Name "vaultName" -ResourceGroupName "resourceGroupName"
$identity1 = Get-AzUserAssignedIdentity -ResourceGroupName "resourceGroupName" -Name "UserIdentity1"
$identity2 = Get-AzUserAssignedIdentity -ResourceGroupName "resourceGroupName" -Name "UserIdentity2"
$updatedVault = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -IdentityType UserAssigned -IdentityId $identity1.Id, $identity2.Id
$updatedVault.Identity | Format-List
```

```output
PrincipalId            :
TenantId               : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Type                   : UserAssigned
UserAssignedIdentities : {[/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/UserIdentity1,
                         Microsoft.Azure.Management.RecoveryServices.Models.UserIdentity],
                         [/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/UserIdentity2,
                         Microsoft.Azure.Management.RecoveryServices.Models.UserIdentity]}
```

The first cmdlet fetches the recovery services vault.
The second and third cmdlet fetches the user created MSIs.
The fourth cmdlet adds the user MSIs to the vault.
The fifth cmdlet shows the Identities added to the vault.

### Example 3: Remove SystemAssigned and UserAssigned identities from the vault
```powershell
$vault = Get-AzRecoveryServicesVault -Name "vaultName" -ResourceGroupName "resourceGroupName"
$updatedVault = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -RemoveSystemAssigned
$AllUserIdentities =  $vault.Identity.UserAssignedIdentities.Keys | ForEach-Object {$_} 
$updatedVault = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -RemoveUserAssigned -IdentityId $AllUserIdentities
$updatedVault.Identity | Format-List
```

```output
PrincipalId            :
TenantId               :
Type                   : None
UserAssignedIdentities :
```

The first cmdlet fetches the recovery services vault.
The second cmdlet removes the SystemAssigned identity from the vault.
The third cmdlet fetches all the user MSIs as a list from the vault.
The fourth cmdlet removes all the user MSIs from the vault. In case you want, you can provide selected user identities to be removed as comma separated, like in previous example.
The fifth cmdlet shows the identities in the vault, as we removed all the identites, Type is displayed as None.

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

### -IdentityId
ARM Ids of the UserAssigned Identity to be added/removed. This is a comma separated list of Identity Ids.

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

### -IdentityType
The MSI type assigned to Recovery Services Vault.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.MSIdentity
Parameter Sets: AzureRSVaultAddMSIdentity
Aliases:
Accepted values: SystemAssigned, None, UserAssigned

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name

Specifies the name of the recovery services vault to update.

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

### -RemoveSystemAssigned
Provide this switch to remove SystemAssigned Identity from the vault.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AzureRSVaultRemoveMSIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoveUserAssigned
Provide this switch to remove UserAssigned Identity from the vault. Also, provide IdenityId parameter along with this switch.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AzureRSVaultRemoveMSIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName

Specifies the name of the Azure resource group where recovery services vault is present.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
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

### System.String

## OUTPUTS

### Microsoft.Azure.Management.RecoveryServices.Models.Vault

## NOTES

## RELATED LINKS
