---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# New-AzNetworkWatcherConnectionMonitorEndpointObject

## SYNOPSIS
Create an endpoint object for connection monitor V2.

## SYNTAX

```
New-AzNetworkWatcherConnectionMonitorEndpointObject [-Name <String>] [-ResourceId <String>] [-Address <String>]
 [-FilterType <String>]
 [-FilterItem <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSConnectionMonitorEndpointFilterItem]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
New-AzNetworkWatcherConnectionMonitorEndpointObject cmdlet creates an endpoint object for connection monitor V2.

## EXAMPLES

### Example 1
```powershell
PS C:\>$MySrcResourceId1 = "/subscriptions/96e68903-0a56-4819-9987-8d08ad6a1f99/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachines/iraVmTestSrc1"
PS C:\>$SrcEndpointFilterItem1 =New-AzNetworkWatcherConnectionMonitorEndpointFilterItemObject -Type "AgentAddress" -Address "10.127.0.1"
PS C:\>$SourceEndpointObject1 = New-AzNetworkWatcherConnectionMonitorEndPointObject -ResourceId $MySrcResourceId1 -FilterType Include -FilterItem $SrcEndpointFilterItem1
```

Name       : iraVmTestSrc1(MyResourceGroup)
ResourceId : /subscriptions/96e68903-0a56-4819-9987-8d08ad6a1f99/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachines/iraVmTestSrc1
Address    :
Filter     : Microsoft.Azure.Commands.Network.Models.PSConnectionMonitorEndpointFilter
FilterText : {
               "Type": "Include",
               "Items": [
                 {
                   "Type": "AgentAddress",
                   "Address": "10.127.0.1"
                 }
               ]
             }

## PARAMETERS

### -Address
The Ip address of the endpoint.

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

### -FilterItem
The connection monitor filter addresses.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSConnectionMonitorEndpointFilterItem]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterType
The connection monitor filter type.

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

### -Name
The endpoint name.

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

### -ResourceId
The ID of the endpoint.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorEndpointObject

## NOTES

## RELATED LINKS
