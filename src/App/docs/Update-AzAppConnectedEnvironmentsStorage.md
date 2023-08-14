---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/update-azappconnectedenvironmentsstorage
schema: 2.0.0
---

# Update-AzAppConnectedEnvironmentsStorage

## SYNOPSIS
Create storage for a connectedEnvironment.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAppConnectedEnvironmentsStorage -ConnectedEnvironmentName <String> -ResourceGroupName <String>
 -StorageName <String> [-SubscriptionId <String>] [-AzureFileAccessMode <String>]
 [-AzureFileAccountKey <String>] [-AzureFileAccountName <String>] [-AzureFileShareName <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzAppConnectedEnvironmentsStorage -ConnectedEnvironmentName <String> -ResourceGroupName <String>
 -StorageName <String> -StorageEnvelope <IConnectedEnvironmentStorage> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzAppConnectedEnvironmentsStorage -InputObject <IAppIdentity>
 -StorageEnvelope <IConnectedEnvironmentStorage> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityConnectedEnvironment
```
Update-AzAppConnectedEnvironmentsStorage -ConnectedEnvironmentInputObject <IAppIdentity> -StorageName <String>
 -StorageEnvelope <IConnectedEnvironmentStorage> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityConnectedEnvironmentExpanded
```
Update-AzAppConnectedEnvironmentsStorage -ConnectedEnvironmentInputObject <IAppIdentity> -StorageName <String>
 [-AzureFileAccessMode <String>] [-AzureFileAccountKey <String>] [-AzureFileAccountName <String>]
 [-AzureFileShareName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAppConnectedEnvironmentsStorage -InputObject <IAppIdentity> [-AzureFileAccessMode <String>]
 [-AzureFileAccountKey <String>] [-AzureFileAccountName <String>] [-AzureFileShareName <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create storage for a connectedEnvironment.

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
Parameter Sets: UpdateExpanded, UpdateViaIdentityConnectedEnvironmentExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityConnectedEnvironmentExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityConnectedEnvironmentExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityConnectedEnvironmentExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectedEnvironmentInputObject
Identity Parameter
To construct, see NOTES section for CONNECTEDENVIRONMENTINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: UpdateViaIdentityConnectedEnvironment, UpdateViaIdentityConnectedEnvironmentExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ConnectedEnvironmentName
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
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
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
Storage resource for connectedEnvironment.
To construct, see NOTES section for STORAGEENVELOPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IConnectedEnvironmentStorage
Parameter Sets: Update, UpdateViaIdentity, UpdateViaIdentityConnectedEnvironment
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
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityConnectedEnvironment, UpdateViaIdentityConnectedEnvironmentExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IConnectedEnvironmentStorage

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IConnectedEnvironmentStorage

## NOTES

## RELATED LINKS

