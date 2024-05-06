---
external help file: Az.Synapse-help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/get-azsynapsekustopool
schema: 2.0.0
---

# Get-AzSynapseKustoPool

## SYNOPSIS
Gets a Kusto pool.

## SYNTAX

### List (Default)
```
Get-AzSynapseKustoPool -ResourceGroupName <String> [-SubscriptionId <String[]>] -WorkspaceName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSynapseKustoPool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSynapseKustoPool -InputObject <ISynapseIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a Kusto pool.

## EXAMPLES

### Example 1: List all Kusto pools in a workspace
```powershell
Get-AzSynapseKustoPool -ResourceGroupName testrg -WorkspaceName testws
```

```output
Location  Name                     Type                                    Etag
--------  ----                     ----                                    ----
East US 2 testws/testnewkustopool  Microsoft.Synapse/workspaces/kustoPools 
East US 2 testws/testnewkustopool1 Microsoft.Synapse/workspaces/kustoPools
```

The above command lists all Kusto pools in the resource group "testrg".

### Example 2: Get a specific Kusto pool by name
```powershell
Get-AzSynapseKustoPool -ResourceGroupName testrg -WorkspaceName testws -Name testnewkustopool
```

```output
Location  Name                    Type                                    Etag
--------  ----                    ----                                    ----
East US 2 testws/testnewkustopool Microsoft.Synapse/workspaces/kustoPools
```

The above command returns the Kusto pool named "testnewkustopool" in the resource group "testrg".

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.ISynapseIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Kusto pool.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: KustoPoolName

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
Parameter Sets: List, Get
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
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.ISynapseIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPool

## NOTES

## RELATED LINKS
