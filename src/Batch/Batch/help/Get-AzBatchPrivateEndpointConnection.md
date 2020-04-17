---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Batch.dll-Help.xml
Module Name: Az.Batch
online version: https://docs.microsoft.com/en-us/powershell/module/az.batch/get-azbatchprivateendpointconnection
schema: 2.0.0
---

# Get-AzBatchPrivateEndpointConnection

## SYNOPSIS
Gets the private endpoint connections for a Batch account.

## SYNTAX

### AccountAndResourceGroup (Default)
```
Get-AzBatchPrivateEndpointConnection [-AccountName] <String> [-ResourceGroupName] <String> [-MaxCount <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AccountResourceGroupAndName
```
Get-AzBatchPrivateEndpointConnection [-AccountName] <String> [-ResourceGroupName] <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### Id
```
Get-AzBatchPrivateEndpointConnection [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzBatchPrivateEndpointConnection** cmdlet gets private endpoint connections.
Specify an account using the *ResourceGroupName* and *AccountName* parameters.
To get a single private endpoint connection, specify either the *Name* or the *ResourceId* parameter.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzBatchPrivateEndpointConnection -ResourceGroupName "myrg" -AccountName "myaccount" -Name "myprivateendpoint"
Id                                : /subscriptions/subid/resourceGroups/myrg/providers/Microsoft.Batch/batchAccounts/myaccount/privateEndpointConnections/myprivateendpoint
Name                              : myprivateendpoint
ProvisioningState                 : Succeeded
PrivateEndpoint                   : Microsoft.Azure.Commands.Batch.Models.PSPrivateEndpoint
PrivateLinkServiceConnectionState : Microsoft.Azure.Commands.Batch.Models.PSPrivateLinkServiceConnectionState
```

Get a specific PrivateEndpointConnection using `ResourceGroupName`, `AccountName`, and `Name`.

### Example 2
```powershell
PS C:\> Get-AzBatchPrivateEndpointConnection -ResourceId "/subscriptions/subid/resourceGroups/myrg/providers/Microsoft.Batch/batchAccounts/myaccount/privateEndpointConnections/myprivateendpoint"
Id                                : /subscriptions/subid/resourceGroups/myrg/providers/Microsoft.Batch/batchAccounts/myaccount/privateEndpointConnections/myprivateendpoint
Name                              : myprivateendpoint
ProvisioningState                 : Succeeded
PrivateEndpoint                   : Microsoft.Azure.Commands.Batch.Models.PSPrivateEndpoint
PrivateLinkServiceConnectionState : Microsoft.Azure.Commands.Batch.Models.PSPrivateLinkServiceConnectionState
```

Get a specific PrivateEndpointConnection using `ResourceId`.

### Example 3
```powershell
PS C:\> Get-AzBatchPrivateEndpointConnection -ResourceGroupName "myrg" -AccountName "myaccount"
Id                                : /subscriptions/subid/resourceGroups/myrg/providers/Microsoft.Batch/batchAccounts/myaccount/privateEndpointConnections/myprivateendpoint1
Name                              : myprivateendpoint1
ProvisioningState                 : Succeeded
PrivateEndpoint                   : Microsoft.Azure.Commands.Batch.Models.PSPrivateEndpoint
PrivateLinkServiceConnectionState : Microsoft.Azure.Commands.Batch.Models.PSPrivateLinkServiceConnectionState

Id                                : /subscriptions/subid/resourceGroups/myrg/providers/Microsoft.Batch/batchAccounts/myaccount/privateEndpointConnections/myprivateendpoint2
Name                              : myprivateendpoint2
ProvisioningState                 : Succeeded
PrivateEndpoint                   : Microsoft.Azure.Commands.Batch.Models.PSPrivateEndpoint
PrivateLinkServiceConnectionState : Microsoft.Azure.Commands.Batch.Models.PSPrivateLinkServiceConnectionState
```

Get all PrivateEndpointConnection's in the account.

## PARAMETERS

### -AccountName
Specifies the name of the Batch account.

```yaml
Type: System.String
Parameter Sets: AccountAndResourceGroup, AccountResourceGroupAndName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -MaxCount
The maximum number of results to return.

```yaml
Type: System.Int32
Parameter Sets: AccountAndResourceGroup
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the private endpoint connection to get.

```yaml
Type: System.String
Parameter Sets: AccountResourceGroupAndName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that contains the Batch account.

```yaml
Type: System.String
Parameter Sets: AccountAndResourceGroup, AccountResourceGroupAndName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource id of the Private Endpoint Connection.

```yaml
Type: System.String
Parameter Sets: Id
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Batch.Models.PSPrivateEndpointConnection

## NOTES

## RELATED LINKS

[Set-AzBatchPrivateEndpointConnection](./Set-AzBatchPrivateEndpointConnection.md)

[Get-AzBatchPrivateLinkResource](./Get-AzBatchPrivateLinkResource.md)