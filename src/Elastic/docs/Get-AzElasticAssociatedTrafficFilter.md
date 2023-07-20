---
external help file:
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/get-azelasticassociatedtrafficfilter
schema: 2.0.0
---

# Get-AzElasticAssociatedTrafficFilter

## SYNOPSIS
Get the list of all associated traffic filters for the given deployment.

## SYNTAX

### List (Default)
```
Get-AzElasticAssociatedTrafficFilter -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ListViaIdentityMonitor
```
Get-AzElasticAssociatedTrafficFilter -MonitorInputObject <IElasticIdentity> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Get the list of all associated traffic filters for the given deployment.

## EXAMPLES

### Example 1: Get the list of all associated traffic filters for the given deployment
```powershell
Get-AzElasticAssociatedTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01
```

```output
Description               IncludeByDefault Name       Region
-----------               ---------------- ----       ------
Created from Azure Portal                  IpFilter03 azure-eastus
Created from Azure Portal                  IpFilter02 azure-eastus
Created from Azure Portal                  IpFilter01 azure-eastus
```

Get the list of all associated traffic filters for the given deployment.

### Example 2: Get the list of all associated traffic filters for the given deployment via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor02 | Get-AzElasticAssociatedTrafficFilter
```

```output
Description               IncludeByDefault Name       Region
-----------               ---------------- ----       ------
Created from Azure Portal                  IpFilter02 azure-eastus
Created from Azure Portal                  IpFilter01 azure-eastus
```

Get the list of all associated traffic filters for the given deployment via pipeline

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

### -MonitorInputObject
Identity Parameter
To construct, see NOTES section for MONITORINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
Parameter Sets: ListViaIdentityMonitor
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group to which the Elastic resource belongs.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

```yaml
Type: System.String[]
Parameter Sets: List
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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticTrafficFilterResponse

## NOTES

## RELATED LINKS

