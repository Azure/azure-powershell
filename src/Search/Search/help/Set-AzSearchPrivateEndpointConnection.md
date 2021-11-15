---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Search.dll-Help.xml
Module Name: Az.Search
online version: https://docs.microsoft.com/powershell/module/az.search/set-azsearchprivateendpointconnection
schema: 2.0.0
---

# Set-AzSearchPrivateEndpointConnection

## SYNOPSIS
Update the private endpoint connection to the Azure Cognitive Search service.

## SYNTAX

### ResourceNameParameterSet (Default)
```
Set-AzSearchPrivateEndpointConnection [-ResourceGroupName] <String> [-ServiceName] <String> [-Name] <String>
 -Status <PSPrivateLinkServiceConnectionStatus> [-Description <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ParentObjectParameterSet
```
Set-AzSearchPrivateEndpointConnection -ParentObject <PSSearchService> [-Name] <String>
 -Status <PSPrivateLinkServiceConnectionStatus> [-Description <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Set-AzSearchPrivateEndpointConnection [-ResourceId] <String> -Status <PSPrivateLinkServiceConnectionStatus>
 [-Description <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectParameterSet
```
Set-AzSearchPrivateEndpointConnection -Status <PSPrivateLinkServiceConnectionStatus> [-Description <String>]
 -InputObject <PSPrivateEndpointConnection> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzSearchPrivateEndpointConnection** updates the private endpoint connection to the Azure Cognitive Search service.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-AzSearchPrivateEndpointConnection -ResourceGroupName arjagann -ServiceName arjagann-test-cuseuap -Name arjagann-test-cuseuap-pe.4c74dd7c-7016-42ac-827a-8d5d1378f266 -Status Rejected  -Description "Rejected" | ConvertTo-Json

{
  "Name": "arjagann-test-cuseuap-pe.4c74dd7c-7016-42ac-827a-8d5d1378f266",
  "Id": "/subscriptions/a4337210-c6b0-4de4-907a-688f1c120d9a/resourceGroups/arjagann/providers/Microsoft.Search/searchServices/arjagann-test-cuseuap/privateEndpointConnections/arjagann-test-cuseuap-pe.4c74dd7c-7016-42ac-827a-8d5d1378f266",
  "PrivateEndpoint": {
    "Id": "/subscriptions/a4337210-c6b0-4de4-907a-688f1c120d9a/resourceGroups/arjagann2/providers/Microsoft.Network/privateEndpoints/arjagann-test-cuseuap-pe"
  },
  "PrivateLinkServiceConnectionState": {
    "Status": 2,
    "Description": "Rejected",
    "ActionsRequired": "None"
  }
}
```

This example updates a private endpoint connection's status of the Azure Cognitive Search service to be "Rejected".

## PARAMETERS

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

### -Description
Private endpoint connection description

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

### -InputObject
Private endpoint connection input object

```yaml
Type: Microsoft.Azure.Commands.Management.Search.Models.PSPrivateEndpointConnection
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Azure Cognitive Search Service private endpoint connection name

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet, ParentObjectParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
Azure Cognitive Search Service Input Object.

```yaml
Type: Microsoft.Azure.Commands.Management.Search.Models.PSSearchService
Parameter Sets: ParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Private link service resource id

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceName
Azure Cognitive Search Service name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Private link service connection status

```yaml
Type: Microsoft.Azure.Commands.Management.Search.Models.PSPrivateLinkServiceConnectionStatus
Parameter Sets: (All)
Aliases:
Accepted values: Pending, Approved, Rejected, Disconnected

Required: True
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.Search.Models.PSPrivateEndpointConnection

## NOTES

## RELATED LINKS

[Get-AzSearchPrivateEndpointConnection.md](./Get-AzSearchPrivateEndpointConnection.md)

[Remove-AzSearchPrivateEndpointConnection.md](./Remove-AzSearchPrivateEndpointConnection.md)
