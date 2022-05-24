---
external help file:
Module Name: Az.App
online version: https://docs.microsoft.com/powershell/module/az.app/new-azcontainerappmanagedenvstorage
schema: 2.0.0
---

# New-AzContainerAppManagedEnvStorage

## SYNOPSIS
Create or update storage for a managedEnvironment.

## SYNTAX

```
New-AzContainerAppManagedEnvStorage -EnvName <String> -ResourceGroupName <String> -StorageName <String>
 [-SubscriptionId <String>] [-AzureFileAccessMode <AccessMode>] [-AzureFileAccountKey <String>]
 [-AzureFileAccountName <String>] [-AzureFileShareName <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update storage for a managedEnvironment.

## EXAMPLES

### Example 1: Create or update storage for a managedEnvironment.
```powershell
New-AzStorageAccount -ResourceGroupName azpstest_gp -AccountName azpstestsa -Location canadacentral -SkuName Standard_GRS
$storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName azpstest_gp -AccountName azpstestsa).Value[0]

New-AzContainerAppManagedEnvStorage -EnvName azps-env -ResourceGroupName azpstest_gp -StorageName azpstestsa -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName azpstestsa -AzureFileShareName azps-rw-sharename
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azpstest_gp
```

Create or update storage for a managedEnvironment.

## PARAMETERS

### -AzureFileAccessMode
Access mode for storage

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Support.AccessMode
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
Parameter Sets: (All)
Aliases:

Required: True
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageName
Name of the storage.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IManagedEnvironmentStorage

## NOTES

ALIASES

## RELATED LINKS

