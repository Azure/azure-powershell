---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/get-azsignalrreplica
schema: 2.0.0
---

# Get-AzSignalRReplica

## SYNOPSIS
Get SignalR replica resources for a SignalR service or a specific replica by name or resource ID.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Get-AzSignalRReplica [-ResourceGroupName <String>] -SignalRName <String> [-Name <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### InputSignalRObjectParameterSet
```
Get-AzSignalRReplica [-Name <String>] -SignalRObject <PSSignalRResource> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzSignalRReplica -ResourceId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Retrieves replica resources that belong to a SignalR service. You can:
- List all replicas of a SignalR primary resource
- Get a specific replica by name
- Get a replica directly by providing its full resource ID

If no replica name is provided, all replicas for the specified SignalR service are returned.

## EXAMPLES

### Example 1: List all replicas for a SignalR service
```powershell
Get-AzSignalRReplica -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR"
```

Lists every replica created for the primary SignalR resource "mySignalR".

### Example 2: Get a specific replica by name
```powershell
Get-AzSignalRReplica -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "replica-westus2"
```

Gets the replica named "replica-westus2".

### Example 3: Use pipeline from a SignalR resource object
```powershell
$signalr = Get-AzSignalR -ResourceGroupName "myResourceGroup" -Name "mySignalR"
$signalr | Get-AzSignalRReplica
```

Lists all replicas for the SignalR resource represented by `$signalr`.

### Example 4: Get a replica by resource ID
```powershell
Get-AzSignalRReplica -ResourceId "/subscriptions/{subId}/resourceGroups/{resourceGroup}/providers/Microsoft.SignalRService/SignalR/{signalRName}/replicas/{replicaName}"
```

Gets the replica using its full ARM resource ID.

## PARAMETERS

### -AsJob
Run the cmdlet in background job.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the replica

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet, InputSignalRObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.
The default one will be used if not specified.

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource ID of a replica

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SignalRName
The SignalR service name.

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SignalRObject
The SignalR resource object.

```yaml
Type: Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource
Parameter Sets: InputSignalRObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource

## OUTPUTS

### Microsoft.Azure.Commands.SignalR.Models.PSReplicaResource

## NOTES

## RELATED LINKS
