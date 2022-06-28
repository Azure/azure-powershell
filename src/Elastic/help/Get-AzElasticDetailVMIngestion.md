---
external help file:
Module Name: Az.Elastic
online version: https://docs.microsoft.com/powershell/module/az.elastic/get-azelasticdetailvmingestion
schema: 2.0.0
---

# Get-AzElasticDetailVMIngestion

## SYNOPSIS
List the vm ingestion details that will be monitored by the Elastic monitor resource.

## SYNTAX

### Details (Default)
```
Get-AzElasticDetailVMIngestion -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DetailsViaIdentity
```
Get-AzElasticDetailVMIngestion -InputObject <IElasticIdentity> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
List the vm ingestion details that will be monitored by the Elastic monitor resource.

## EXAMPLES

### Example 1: List the vm ingestion details that will be monitored by the Elastic monitor resource
```powershell
Get-AzElasticDetailVMIngestion -ResourceGroupName elastic-rg-3eytki -Name elastic-rhqz1v
```

```output
CloudId                                  IngestionKey
-------                                  ------------
elastic-rhqz1v:xxxxxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxx
```

This command lists the vm ingestion details that will be monitored by the Elastic monitor resource.

### Example 2: List the vm ingestion details that will be monitored by the Elastic monitor resource by pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName elastic-rg-3eytki -Name elastic-rhqz1v | Get-AzElasticDetailVMIngestion
```

```output
CloudId                                  IngestionKey
-------                                  ------------
elastic-rhqz1v:xxxxxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxx
```

This command lists the vm ingestion details that will be monitored by the Elastic monitor resource by pipeline.

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
Parameter Sets: DetailsViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Monitor resource name

```yaml
Type: System.String
Parameter Sets: Details
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
Parameter Sets: Details
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
Parameter Sets: Details
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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.IVMIngestionDetailsResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IElasticIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[MonitorName <String>]`: Monitor resource name
  - `[ResourceGroupName <String>]`: The name of the resource group to which the Elastic resource belongs.
  - `[RuleSetName <String>]`: Tag Rule Set resource name
  - `[SubscriptionId <String>]`: The Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000)

## RELATED LINKS

