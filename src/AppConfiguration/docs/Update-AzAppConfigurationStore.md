---
external help file: Az.AppConfiguration-help.xml
Module Name: Az.AppConfiguration
online version: https://docs.microsoft.com/en-us/powershell/module/az.appconfiguration/update-azappconfigurationstore
schema: 2.0.0
---

# Update-AzAppConfigurationStore

## SYNOPSIS
Updates a configuration store with the specified parameters.

## SYNTAX

### UpdateSubscriptionIdViaHost (Default)
```
Update-AzAppConfigurationStore -Name <String> -ResourceGroupName <String>
 [-ConfigStoreUpdateParameter <IConfigurationStoreUpdateParameters>] [-DefaultProfile <PSObject>] [-AsJob]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzAppConfigurationStore -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Property <IConfigurationStorePropertiesUpdateParameters>] [-Tag <IConfigurationStoreUpdateParametersTags>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Update-AzAppConfigurationStore -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-ConfigStoreUpdateParameter <IConfigurationStoreUpdateParameters>] [-DefaultProfile <PSObject>] [-AsJob]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateSubscriptionIdViaHostExpanded
```
Update-AzAppConfigurationStore -Name <String> -ResourceGroupName <String>
 [-Property <IConfigurationStorePropertiesUpdateParameters>] [-Tag <IConfigurationStoreUpdateParametersTags>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates a configuration store with the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigStoreUpdateParameter
The parameters for updating a configuration store.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreUpdateParameters
Parameter Sets: UpdateSubscriptionIdViaHost, Update
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Name
The name of the configuration store.

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

### -Property
The properties for updating a configuration store.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesUpdateParameters
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group to which the container registry belongs.

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
The Microsoft Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The ARM resource tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreUpdateParametersTags
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStore
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.appconfiguration/update-azappconfigurationstore](https://docs.microsoft.com/en-us/powershell/module/az.appconfiguration/update-azappconfigurationstore)

