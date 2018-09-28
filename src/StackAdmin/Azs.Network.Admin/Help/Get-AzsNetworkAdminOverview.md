---
external help file: Azs.Network.Admin-help.xml
Module Name: Azs.Network.Admin
online version: 
schema: 2.0.0
---

# Get-AzsNetworkAdminOverview

## SYNOPSIS
Get an overview of the state of the network resource provider.

## SYNTAX

```
Get-AzsNetworkAdminOverview [<CommonParameters>]
```

## DESCRIPTION
Get an overview of the state of the network resource provider. 
Individual properties provide detailed counts of resource usage and health by component.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsNetworkAdminOverview
```

Get network admin overview.

### -------------------------- EXAMPLE 2 --------------------------
```
(Get-AzsNetworkAdminOverview).PublicIpAddressUsage
```

Get public ip address usage.

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Network.Admin.Models.AdminOverview

## NOTES

## RELATED LINKS

