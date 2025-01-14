---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-AzNetworkCloudEndpointDependencyObject
schema: 2.0.0
---

# New-AzNetworkCloudEndpointDependencyObject

## SYNOPSIS
Create an in-memory object for EndpointDependency.

## SYNTAX

```
New-AzNetworkCloudEndpointDependencyObject -DomainName <String> [-Port <Int64>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for EndpointDependency.

## EXAMPLES

### Example 1: Create an in-memory object for EndpointDependency.
```powershell
New-AzNetworkCloudEndpointDependencyObject -DomainName domainName -Port 1234
```

```output
DomainName Port
---------- ----
domainName 1234
```

Create an in-memory object for EndpointDependency.

## PARAMETERS

### -DomainName
The domain name of the dependency.

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

### -Port
The port of this endpoint.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.EndpointDependency

## NOTES

## RELATED LINKS
