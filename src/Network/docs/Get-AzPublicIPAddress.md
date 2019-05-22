---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/get-azpublicipaddress
schema: 2.0.0
---

# Get-AzPublicIPAddress

## SYNOPSIS
Gets the specified public IP address in a specified resource group.

## SYNTAX

### List (Default)
```
Get-AzPublicIPAddress -SubscriptionId <String[]> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPublicIPAddress -Name <String> -ResourceGroupName <String> -SubscriptionId <String[]> [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzPublicIPAddress -ResourceGroupName <String> -SubscriptionId <String[]> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPublicIPAddress -InputObject <INetworkIdentity> [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the specified public IP address in a specified resource group.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Expand
Expands referenced resources.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the subnet.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PublicIPAddressName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/get-azpublicipaddress](https://docs.microsoft.com/en-us/powershell/module/az.network/get-azpublicipaddress)

