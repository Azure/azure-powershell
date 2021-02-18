---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/get-azprivateendpointconnection
=======
online version: https://docs.microsoft.com/powershell/module/az.network/get-azprivateendpointconnection
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Get-AzPrivateEndpointConnection

## SYNOPSIS
Gets a private endpoint connection resource.

## SYNTAX

### ByResourceId (Default)
```
<<<<<<< HEAD
Get-AzPrivateEndpointConnection -ResourceId <String> [-Description <String>]
=======
Get-AzPrivateEndpointConnection [-Description <String>] -ResourceId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByPrivateLinkResourceId
```
Get-AzPrivateEndpointConnection -PrivateLinkResourceId <String> [-Description <String>]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResource
```
<<<<<<< HEAD
Get-AzPrivateEndpointConnection -Name <String> -ServiceName <String> -ResourceGroupName <String>
 [-Description <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
=======
Get-AzPrivateEndpointConnection [-Description <String>] [-Name <String>] -ResourceGroupName <String>
 -ServiceName <String> [-DefaultProfile <IAzureContextContainer>] [-PrivateLinkResourceType <String>]
 [<CommonParameters>]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```

## DESCRIPTION
The **Get-AzPrivateEndpointConnection** cmdlet retrieves a private endpoint connection resource.

## EXAMPLES

### Example 1
```
<<<<<<< HEAD
Get-AzPrivateEndpointConnection -Name MyPrivateEndpointConnection1 -ResourceGroupName TestResourceGroup -ServiceName MyPrivateLinkServiceName
```

This example get a private endpoint connection named MyPrivateEndpointConnection1
=======
Get-AzPrivateEndpointConnection -PrivateLinkResourceId '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestResourceGroup/providers/Microsoft.Sql/servers/mySql'
```

This example return a list of all private endpoint connections belongs to sql server named Mysql.

### Example 2
```
Get-AzPrivateEndpointConnection -Name MyPrivateEndpointConnection1 -ResourceGroupName TestResourceGroup -ServiceName MyPrivateLinkService -PrivateLinkResourceType 'Microsoft.Network/privateLinkServices'
```

This example get a private endpoint connection named MyPrivateEndpointConnection1 belongs to private link service named MyPrivateLinkService
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
The reason of action.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the private endpoint connection.

```yaml
Type: System.String
Parameter Sets: ByResource
Aliases: ResourceName

<<<<<<< HEAD
=======
Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PrivateLinkResourceId
The Azure resource manager id of the private link resource that private endpoint connection belongs to.

```yaml
Type: System.String
Parameter Sets: ByPrivateLinkResourceId
Aliases:

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

<<<<<<< HEAD
=======
### -PrivateLinkResourceType
The private link resource type.

```yaml
Type: System.String
Parameter Sets: ByResource
Aliases:
Accepted values: 

Required: False
Position: Named
Default value: 'Microsoft.Network/privateLinkServices'
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
### -ResourceGroupName
The resource group name of the private endpoint connection.

```yaml
Type: System.String
Parameter Sets: ByResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The Azure resource manager id of the private endpoint connection.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceName
<<<<<<< HEAD
The name of the private link service that has the private endpoint connection.
=======
The name of service that the private endpoint connection belong to.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: ByResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

<<<<<<< HEAD
=======
[Approve-AzPrivateEndpointConnection](./Approve-AzPrivateEndpointConnection.md)

[Deny-AzPrivateEndpointConnection](./Deny-AzPrivateEndpointConnection.md)

[Remove-AzPrivateEndpointConnection](./Remove-AzPrivateEndpointConnection.md)

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
[Set-AzPrivateEndpointConnection](./Set-AzPrivateEndpointConnection.md)
