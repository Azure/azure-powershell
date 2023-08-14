---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/update-azappcontainerappmanagedenvstorage
schema: 2.0.0
---

# Update-AzAppContainerAppManagedEnvStorage

## SYNOPSIS
Create storage for a managedEnvironment.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAppContainerAppManagedEnvStorage -EnvName <String> -ResourceGroupName <String> -StorageName <String>
 [-SubscriptionId <String>] [-AzureFileAccessMode <String>] [-AzureFileAccountKey <String>]
 [-AzureFileAccountName <String>] [-AzureFileShareName <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzAppContainerAppManagedEnvStorage -EnvName <String> -ResourceGroupName <String> -StorageName <String>
 -StorageEnvelope <IManagedEnvironmentStorage> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzAppContainerAppManagedEnvStorage -InputObject <IAppIdentity>
 -StorageEnvelope <IManagedEnvironmentStorage> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAppContainerAppManagedEnvStorage -InputObject <IAppIdentity> [-AzureFileAccessMode <String>]
 [-AzureFileAccountKey <String>] [-AzureFileAccountName <String>] [-AzureFileShareName <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityManagedEnvironment
```
Update-AzAppContainerAppManagedEnvStorage -ManagedEnvironmentInputObject <IAppIdentity> -StorageName <String>
 -StorageEnvelope <IManagedEnvironmentStorage> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityManagedEnvironmentExpanded
```
Update-AzAppContainerAppManagedEnvStorage -ManagedEnvironmentInputObject <IAppIdentity> -StorageName <String>
 [-AzureFileAccessMode <String>] [-AzureFileAccountKey <String>] [-AzureFileAccountName <String>]
 [-AzureFileShareName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create storage for a managedEnvironment.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AzureFileAccessMode
Access mode for storage

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityManagedEnvironmentExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureFileAccountKey
Storage account key for azure file.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityManagedEnvironmentExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureFileAccountName
Storage account name for azure file.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityManagedEnvironmentExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureFileShareName
Azure file share name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityManagedEnvironmentExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -EnvName
Name of the Environment.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedEnvironmentInputObject
Identity Parameter
To construct, see NOTES section for MANAGEDENVIRONMENTINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: UpdateViaIdentityManagedEnvironment, UpdateViaIdentityManagedEnvironmentExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageEnvelope
Storage resource for managedEnvironment.
To construct, see NOTES section for STORAGEENVELOPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IManagedEnvironmentStorage
Parameter Sets: Update, UpdateViaIdentity, UpdateViaIdentityManagedEnvironment
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StorageName
Name of the storage.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityManagedEnvironment, UpdateViaIdentityManagedEnvironmentExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IManagedEnvironmentStorage

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IManagedEnvironmentStorage

## NOTES

## RELATED LINKS

