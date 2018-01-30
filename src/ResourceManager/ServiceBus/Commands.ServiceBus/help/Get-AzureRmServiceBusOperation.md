---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
Module Name: AzureRM.ServiceBus
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.servicebus/get-azurermservicebusoperation
schema: 2.0.0
---

# Get-AzureRmServiceBusOperation

## SYNOPSIS
List supported ServiceBus Operations

## SYNTAX

```
Get-AzureRmServiceBusOperation [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmServiceBusOperation** cmdlet Lists the ServiceBus supported Operations.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmServiceBusOperation
```

Lists ServiceBus supported operations

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.ServiceBus.Models.PSOperationAttributes, Microsoft.Azure.Commands.ServiceBus, Version=0.4.2.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### System.Collections.Generic.List`1[Microsoft.Azure.Commands.ServiceBus.Models.OperationAttributes]

## NOTES

## RELATED LINKS

