---
external help file:
Module Name: Az.Elastic
online version: https://docs.microsoft.com/powershell/module/az.elastic/get-azelastictagrule
schema: 2.0.0
---

# Get-AzElasticTagRule

## SYNOPSIS
Get a tag rule set for a given monitor resource.

## SYNTAX

### Get (Default)
```
Get-AzElasticTagRule -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzElasticTagRule -InputObject <IElasticIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a tag rule set for a given monitor resource.

## EXAMPLES

### Example 1: Get a tag rule set for a given monitor resource
```powershell
Get-AzElasticTagRule -ResourceGroupName azure-elastic-test -MonitorName elastic-pwsh02
```

```output
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         azure-elastic-test
```

This command gets a tag rule set for a given monitor resource.

### Example 2: Get a tag rule set for a given monitor resource by pipeline
```powershell
New-AzElasticTagRule -ResourceGroupName azps-elastic-test -MonitorName elastic-pwsh02 | Get-AzElasticTagRule
```

```output
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         azure-elastic-test
```

This command gets a tag rule set for a given monitor resource by pipeline.

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
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get
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
Parameter Sets: Get
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
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.IMonitoringTagRules

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

