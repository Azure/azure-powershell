---
external help file: Az.AppConfiguration-help.xml
Module Name: Az.AppConfiguration
online version: https://learn.microsoft.com/powershell/module/az.appconfiguration/get-azappconfigurationstorekey
schema: 2.0.0
---

# Get-AzAppConfigurationStoreKey

## SYNOPSIS
Lists the access key for the specified configuration store.

## SYNTAX

```
Get-AzAppConfigurationStoreKey -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Lists the access key for the specified configuration store.

## EXAMPLES

### Example 1: List all store keys of an app configuration store
```powershell
Get-AzAppConfigurationStoreKey -Name azpstest-appstore -ResourceGroupName azpstest_gp
```

```output
ConnectionString                                                                                                                      LastModified           Name                ReadOnly ResourceGroupName Value
----------------                                                                                                                      ------------           ----                -------- ----------------- ---
Endpoint=https://azpstest-appstore.azconfig.io;Id=SXvQ-l0-s0:1EG/TDfXP30kHZoLxGxb;Secret=GknYAPIAFixLJw5wfGOGt0dgwj0hr2eGoRnusIgkNdc= 2022-08-24 AM 06:11:51 Secondary           False                       Gk…
Endpoint=https://azpstest-appstore.azconfig.io;Id=WCoZ-l0-s0:OY71pf8vbFCZTtDpuIfE;Secret=06+woMjMn4iQNhpvmpCuLQys0qjGXbal3UFgQxAipas= 2022-08-24 AM 06:11:51 Primary Read Only   True                        06…
Endpoint=https://azpstest-appstore.azconfig.io;Id=7sDt-l0-s0:1tEtn3TApcmgJjk0PlqM;Secret=jZDAxcgFtEhj5ug2VYjUvdImaHybGwRSvkq45dvnVFk= 2022-08-24 AM 06:11:51 Secondary Read Only True                        jZ…
Endpoint=https://azpstest-appstore.azconfig.io;Id=m6TW-l0-s0:g302jTPLEpvmI0AahitF;Secret=vt5aKm6ezq2iVKNjQo+dQpA8QyuH1UhH9Jv8N3jfZdE= 2022-08-24 AM 06:13:21 Primary             False                       vt…
```

This command lists all store keys of an app configuration store.

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
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20220501.IApiKey

## NOTES

## RELATED LINKS
