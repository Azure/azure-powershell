---
external help file:
Module Name: Az.EnterpriseKnowledgeGraphService
online version: https://docs.microsoft.com/en-us/powershell/module/az.enterpriseknowledgegraphservice/get-azenterpriseknowledgegraphserviceenterpriseknowledgegraph
schema: 2.0.0
---

# Get-AzEnterpriseKnowledgeGraphServiceEnterpriseKnowledgeGraph

## SYNOPSIS
Returns a EnterpriseKnowledgeGraph service specified by the parameters.

## SYNTAX

### List1 (Default)
```
Get-AzEnterpriseKnowledgeGraphServiceEnterpriseKnowledgeGraph [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzEnterpriseKnowledgeGraphServiceEnterpriseKnowledgeGraph -ResourceGroupName <String>
 -ResourceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEnterpriseKnowledgeGraphServiceEnterpriseKnowledgeGraph
 -InputObject <IEnterpriseKnowledgeGraphServiceIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzEnterpriseKnowledgeGraphServiceEnterpriseKnowledgeGraph -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns a EnterpriseKnowledgeGraph service specified by the parameters.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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
Type: Microsoft.Azure.PowerShell.Cmdlets.EnterpriseKnowledgeGraphService.Models.IEnterpriseKnowledgeGraphServiceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the EnterpriseKnowledgeGraph resource group in the user subscription.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the EnterpriseKnowledgeGraph resource.

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
Azure Subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.EnterpriseKnowledgeGraphService.Models.IEnterpriseKnowledgeGraphServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EnterpriseKnowledgeGraphService.Models.Api20181203.IEnterpriseKnowledgeGraph

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IEnterpriseKnowledgeGraphServiceIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the EnterpriseKnowledgeGraph resource group in the user subscription.
  - `[ResourceName <String>]`: The name of the EnterpriseKnowledgeGraph resource.
  - `[SubscriptionId <String>]`: Azure Subscription ID.

## RELATED LINKS

