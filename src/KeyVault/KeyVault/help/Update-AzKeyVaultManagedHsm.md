---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/update-azkeyvaultmanagedhsm
schema: 2.0.0
---

# Update-AzKeyVaultManagedHsm

## SYNOPSIS
Update the state of an Azure managed HSM.

## SYNTAX

### UpdateByNameParameterSet (Default)
```
Update-AzKeyVaultManagedHsm -Name <String> -ResourceGroupName <String> [-EnablePurgeProtection]
 [-PublicNetworkAccess <String>] [-UserAssignedIdentity <String[]>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [-SubscriptionId <String>]
 [<CommonParameters>]
```

### UpdateByInputObjectParameterSet
```
Update-AzKeyVaultManagedHsm -InputObject <PSManagedHsm> [-EnablePurgeProtection]
 [-PublicNetworkAccess <String>] [-UserAssignedIdentity <String[]>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [-SubscriptionId <String>]
 [<CommonParameters>]
```

### UpdateByResourceIdParameterSet
```
Update-AzKeyVaultManagedHsm -ResourceId <String> [-EnablePurgeProtection] [-PublicNetworkAccess <String>]
 [-UserAssignedIdentity <String[]>] [-Tag <Hashtable>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet updates the state of an Azure managed HSM.

## EXAMPLES

### Example 1: Update a managed Hsm directly
```powershell
Update-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $resourceGroupName -Tag @{testKey="testValue"} | Format-List
```

```output
Managed HSM Name                    : testmhsm
Resource Group Name                 : testmhsm
Location                            : eastus2euap
Resource ID                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/testmhsm/provid
                                      ers/Microsoft.KeyVault/managedHSMs/testmhsm
HSM Pool URI                        :
Tenant ID                           : xxxxxx-xxxx-xxxx-xxxxxxxxxxxx
Initial Admin Object Ids            : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SKU                                 : StandardB1
Soft Delete Enabled?                : True
Enabled Purge Protection?           : False
Soft Delete Retention Period (days) : 90
Provisioning State                  : Provisioning
Status Message                      : Resource creation in progress. Starting service...
Tags                                :
                                      Name        Value
                                      ====        =====
                                      testKey     testValued
```

Updates tags for the managed Hsm named `$hsmName` in resource group `$resourceGroupName`.

### Example 2: Update a managed Hsm using piping
```powershell
Get-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $resourceGroupName | Update-AzKeyVaultManagedHsm -Tag @{testKey="testValue"}
```

Updates tags for the managed Hsm using piping syntax.

### Example 3: Enable purge protection for a managed Hsm
```powershell
Update-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $resourceGroupName -EnablePurgeProtection | Format-List
```

```output
Managed HSM Name                    : testmhsm
Resource Group Name                 : test-rg
Location                            : eastus
Resource ID                         : /subscriptions/xxxxxx71-1bf0-4dda-aec3-xxxxxxxxxxxx/resourceGroups/test-rg/provide
                                      rs/Microsoft.KeyVault/managedHSMs/testmhsm
HSM Pool URI                        :
Tenant ID                           : 54xxxxxx-38d6-4fb2-bad9-xxxxxxxxxxxx
Initial Admin Object Ids            : {xxxxxx9e-5be9-4f43-abd2-xxxxxxxxxxxx}
SKU                                 : StandardB1
Soft Delete Enabled?                : True
Enabled Purge Protection?           : True
Soft Delete Retention Period (days) : 70
Provisioning State                  : Succeeded
Status Message                      : The Managed HSM is provisioned and ready to use.
Tags                                :
```

Enables purge protection for the managed Hsm named `$hsmName` in resource group `$resourceGroupName`.

### Example 4: Update user assigned identity for a managed Hsm
```powershell
Update-AzKeyVaultManagedHsm -Name testmhsm -ResourceGroupName test-rg -UserAssignedIdentity /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/bez-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/bez-id02 | Format-List
```

```output
Managed HSM Name                        : testmshm
Resource Group Name                     : test-rg
Location                                : eastus2euap
Resource ID                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/pro
                                          viders/Microsoft.KeyVault/managedHSMs/testmhsm
HSM Pool URI                            :
Tenant ID                               : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Initial Admin Object Ids                : {xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}
SKU                                     : StandardB1
Soft Delete Enabled?                    : True
Enabled Purge Protection?               : False
Soft Delete Retention Period (days)     : 70
Public Network Access                   : Enabled
IdentityType                            : UserAssigned
UserAssignedIdentities                  : /subscriptions/xxxx/resourceGroups/xxxx/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName
Provisioning State                      : Succeeded
Status Message                          : The Managed HSM is provisioned and ready to use.
Security Domain ActivationStatus        : Active
Security Domain ActivationStatusMessage : Your HSM has been activated and can be used for cryptographic operations.
Regions                                 : 
Tags
```

This command adds an user assigned identity for the managed Hsm named `testmshm` in resource group `test-rg`.

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

### -EnablePurgeProtection
specifying whether protection against purge is enabled for this managed HSM pool. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible.

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

### -InputObject
Managed HSM object.

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm
Parameter Sets: UpdateByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the managed HSM.

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet
Aliases: HsmName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccess
Controls permission for data plane traffic coming from public networks while private endpoint is enabled.

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

### -ResourceGroupName
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource ID of the managed HSM.

```yaml
Type: System.String
Parameter Sets: UpdateByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the subscription.
By default, cmdlets are executed in the subscription that is set in the current context. If the user specifies another subscription, the current cmdlet is executed in the subscription specified by the user.
Overriding subscriptions only take effect during the lifecycle of the current cmdlet. It does not change the subscription in the context, and does not affect subsequent cmdlets.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
A hash table which represents resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases: Tags

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UserAssignedIdentity
The set of user assigned identities associated with the managed HSM. Its value will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

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

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm

### System.String

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm

## NOTES

## RELATED LINKS

[New-AzKeyVaultManagedHsm](./New-AzKeyVaultManagedHsm.md)

[Remove-AzKeyVaultManagedHsm](./Remove-AzKeyVaultManagedHsm.md)

[Get-AzKeyVaultManagedHsm](./Get-AzKeyVaultManagedHsm.md)

[Undo-AzKeyVaultManagedHsmRemoval](./Undo-AzKeyVaultManagedHsmRemoval.md)