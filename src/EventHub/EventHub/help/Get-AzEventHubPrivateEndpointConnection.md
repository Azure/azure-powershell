---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventHub.dll-Help.xml
Module Name: Az.EventHub
online version:
schema: 2.0.0
---

# Get-AzEventHubPrivateEndpointConnection

## SYNOPSIS
Gets or lists private endpoint connections in an EventHub namespace

## SYNTAX

### PrivateEndpointPropertiesSet (Default)
```
Get-AzEventHubPrivateEndpointConnection [-ResourceGroupName] <String> [-NamespaceName] <String>
 [[-Name] <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PrivateEndpointResourceIdParameterSet
```
Get-AzEventHubPrivateEndpointConnection [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Gets or lists private endpoint connections in an EventHub namespace

## EXAMPLES

### Example 1
```powershell
Get-AzEventHubPrivateEndpointConnection -ResourceGroupName myresourcegroup -NamespaceName mynamespace -Name 00000000000
```

Gets private endpoint connection `00000000000` on EventHub namespace `mynamespace`. 
Note that connection name is NOT the same as Private Endpoint Name.

### Example 2
```powershell
Get-AzEventHubPrivateEndpointConnection -ResourceGroupName myresourcegroup -NamespaceName mynamespace
```

Lists all private endpoints in namespace `mynamespace`.

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

### -Name
Private Endpoint Connection Name.

```yaml
Type: System.String
Parameter Sets: PrivateEndpointPropertiesSet
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NamespaceName
EventHub Namespace Name.

```yaml
Type: System.String
Parameter Sets: PrivateEndpointPropertiesSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: PrivateEndpointPropertiesSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Private Endpoint Connection ARM ID.

```yaml
Type: System.String
Parameter Sets: PrivateEndpointResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### Microsoft.Azure.Commands.EventHub.Models.PSEventHubPrivateEndpointConnectionAttributes

## NOTES

## RELATED LINKS
