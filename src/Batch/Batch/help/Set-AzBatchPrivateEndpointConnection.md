---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Batch.dll-Help.xml
Module Name: Az.Batch
online version: https://docs.microsoft.com/en-us/powershell/module/az.batch/set-azbatchprivateendpointconnection
schema: 2.0.0
---

# Set-AzBatchPrivateEndpointConnection

## SYNOPSIS
Updates settings for the specified private endpoint connection.

## SYNTAX

### AccountResourceGroupAndName (Default)
```
Set-AzBatchPrivateEndpointConnection [-AccountName] <String> [-ResourceGroupName] <String> [-Name <String>]
 -Status <PrivateLinkServiceConnectionStatus> [-Description <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Id
```
Set-AzBatchPrivateEndpointConnection [-ResourceId] <String> -Status <PrivateLinkServiceConnectionStatus>
 [-Description <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObject
```
Set-AzBatchPrivateEndpointConnection [-PrivateEndpointConnection] <PSPrivateEndpointConnection>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzBatchPrivateEndpointConnection** cmdlet modifies settings for the specified private endpoint connection.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-AzBatchPrivateEndpointConnection -ResourceGroupName "myrg" -AccountName "myaccount" -Name "myprivateendpoint" -Status "Approved"
```

Sets the status of the private link connection to approved.

## PARAMETERS

### -AccountName
Specifies the name of the Batch account.

```yaml
Type: System.String
Parameter Sets: AccountResourceGroupAndName
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

### -Description
The private link service connection description.

```yaml
Type: System.String
Parameter Sets: AccountResourceGroupAndName, Id
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the private endpoint connection.

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

### -PrivateEndpointConnection
The Private Endpoint.

```yaml
Type: Microsoft.Azure.Commands.Batch.Models.PSPrivateEndpointConnection
Parameter Sets: InputObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that contains the Batch account.

```yaml
Type: System.String
Parameter Sets: AccountResourceGroupAndName
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

### -Status
The private link service connection status

```yaml
Type: Microsoft.Azure.Management.Batch.Models.PrivateLinkServiceConnectionStatus
Parameter Sets: AccountResourceGroupAndName, Id
Aliases:
Accepted values: Approved, Pending, Rejected, Disconnected

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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Batch.Models.PSPrivateEndpointConnection

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS

[Get-AzBatchPrivateLinkResource](./Get-AzBatchPrivateLinkResource.md)

[Get-AzBatchPrivateEndpointConnection](./Get-AzBatchPrivateEndpointConnection.md)
