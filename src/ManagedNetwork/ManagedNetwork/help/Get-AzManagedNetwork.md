---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
schema: 2.0.0
---

# Get-AzManagedNetwork

## SYNOPSIS
Gets a managednetwork network in a resource group.

## SYNTAX

### NameParameterSet (Default)
```
Get-AzManagedNetwork -Name <String> -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ListParameterSet
```
Get-AzManagedNetwork [-Name <String>] [-ResourceGroupName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzManagedNetwork -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzManagedNetwork** cmdlet gets one or more managednewtorks in a resource group.

## EXAMPLES

### 1: Retrieve a managednetwork
```
Get-AzManagedNetwork -ResourceGroupName TestRG -Name TestMN

Scope        : Microsoft.Azure.Commands.ManagedNetwork.Models.PSScope
Connectivity : Microsoft.Azure.Commands.ManagedNetwork.Models.PSConnectivityCollection
Tags         : {}
Id           : subscriptions/{usersubscription}/resourceGroups/TestRG/providers/Microsoft.ManagedNetwo
               rk/managedNetworks/TestMN
Name         : TestMN
Type         : Microsoft.ManagedNetwork/managedNetworks
Location     : {user region}
```

### 2: Retrieve a managednetwork by resource id
```
Get-AzManagedNetwork -ResourceGroupid $resourceId

Scope        : Microsoft.Azure.Commands.ManagedNetwork.Models.PSScope
Connectivity : Microsoft.Azure.Commands.ManagedNetwork.Models.PSConnectivityCollection
Tags         : {}
Id           : subscriptions/{usersubscription}/resourceGroups/TestRG/providers/Microsoft.ManagedNetwo
               rk/managedNetworks/TestMN
Name         : TestMN
Type         : Microsoft.ManagedNetwork/managedNetworks
Location     : {user region}
```


## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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
The unique name of the Managed Network.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The create or use an existing resource group name.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The unique ARM id of an existing resource.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.ManagedNetwork.Models.PSManagedNetwork

## NOTES

## RELATED LINKS

[New-AzManagedNetwork](./New-AzManagedNetwork.md)

[Remove-AzManagedNetwork](./Remove-AzManagedNetwork.md)

[Update-AzManagedNetwork](./Update-AzManagedNetwork.md)


