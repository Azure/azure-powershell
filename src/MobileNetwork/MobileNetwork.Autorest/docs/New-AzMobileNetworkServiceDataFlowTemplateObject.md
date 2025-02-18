---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.MobileNetwork/new-AzMobileNetworkServiceDataFlowTemplateObject
schema: 2.0.0
---

# New-AzMobileNetworkServiceDataFlowTemplateObject

## SYNOPSIS
Create an in-memory object for ServiceDataFlowTemplate.

## SYNTAX

```
New-AzMobileNetworkServiceDataFlowTemplateObject -Direction <SdfDirection> -Protocol <String[]>
 -RemoteIPList <String[]> -TemplateName <String> [-Port <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ServiceDataFlowTemplate.

## EXAMPLES

### Example 1: Create an in-memory object for ServiceDataFlowTemplate.
```powershell
New-AzMobileNetworkServiceDataFlowTemplateObject -Direction "Bidirectional" -Protocol "255" -RemoteIPList "any" -TemplateName azps-mn-flow-template
```

```output
Direction     Port Protocol RemoteIPList TemplateName
---------     ---- -------- ------------ ------------
Bidirectional      {255}    {any}        azps-mn-flow-template
```

Create an in-memory object for ServiceDataFlowTemplate.

## PARAMETERS

### -Direction
The direction of this flow.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.SdfDirection
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Port
The port(s) to which UEs will connect for this flow.
You can specify zero or more ports or port ranges.
If you specify one or more ports or port ranges then you must specify a value other than ip in the protocol field.
This is an optional setting.
If you do not specify it then connections will be allowed on all ports.
Port ranges must be specified as \<FirstPort\>-\<LastPort\>.
For example: [8080, 8082-8085].

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

### -Protocol
A list of the allowed protocol(s) for this flow.
If you want this flow to be able to use any protocol within the internet protocol suite, use the value ip.
If you only want to allow a selection of protocols, you must use the corresponding IANA Assigned Internet Protocol Number for each protocol, as described in https://www.iana.org/assignments/protocol-numbers/protocol-numbers.xhtml.
For example, for UDP, you must use 17.
If you use the value ip then you must leave the field port unspecified.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoteIPList
The remote IP address(es) to which UEs will connect for this flow.
If you want to allow connections on any IP address, use the value 'any'.
Otherwise, you must provide each of the remote IP addresses to which the packet core instance will connect for this flow.
You must provide each IP address in CIDR notation, including the netmask (for example, 192.0.2.54/24).

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateName
The name of the data flow template.
This must be unique within the parent data flow policy rule.
You must not use any of the following reserved strings - 'default', 'requested' or 'service'.

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.ServiceDataFlowTemplate

## NOTES

## RELATED LINKS

