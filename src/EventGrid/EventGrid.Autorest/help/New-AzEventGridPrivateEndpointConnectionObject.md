---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridprivateendpointconnectionobject
schema: 2.0.0
---

# New-AzEventGridPrivateEndpointConnectionObject

## SYNOPSIS
Create an in-memory object for PrivateEndpointConnection.

## SYNTAX

```
New-AzEventGridPrivateEndpointConnectionObject [-GroupId <String[]>] [-PrivateEndpointId <String>]
 [-PrivateLinkServiceConnectionStateActionsRequired <String>]
 [-PrivateLinkServiceConnectionStateDescription <String>] [-PrivateLinkServiceConnectionStateStatus <String>]
 [-ProvisioningState <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PrivateEndpointConnection.

## EXAMPLES

### Example 1: Create an in-memory object for PrivateEndpointConnection.
```powershell
New-AzEventGridPrivateEndpointConnectionObject -GroupId "TestId" -PrivateEndpointId "TestPrivateEndpointId" -PrivateLinkServiceConnectionStateActionsRequired "TestActionsRequired" -PrivateLinkServiceConnectionStateDescription "TestDescription" -PrivateLinkServiceConnectionStateStatus Approved -ProvisioningState Succeeded | Format-List
```

```output
GroupId                                          : {TestId}
Id                                               :
Name                                             :
PrivateEndpointId                                : TestPrivateEndpointId
PrivateLinkServiceConnectionStateActionsRequired : TestActionsRequired
PrivateLinkServiceConnectionStateDescription     : TestDescription
PrivateLinkServiceConnectionStateStatus          : Approved
ProvisioningState                                : Succeeded
ResourceGroupName                                :
Type                                             :
```

Create an in-memory object for PrivateEndpointConnection.

## PARAMETERS

### -GroupId
GroupIds from the private link service resource.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateEndpointId
The ARM identifier for Private Endpoint.

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

### -PrivateLinkServiceConnectionStateActionsRequired
Actions required (if any).

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

### -PrivateLinkServiceConnectionStateDescription
Description of the connection state.

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

### -PrivateLinkServiceConnectionStateStatus
Status of the connection.

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

### -ProvisioningState
Provisioning state of the Private Endpoint Connection.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.PrivateEndpointConnection

## NOTES

## RELATED LINKS

