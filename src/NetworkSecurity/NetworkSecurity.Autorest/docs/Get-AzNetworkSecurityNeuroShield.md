---
external help file:
Module Name: Az.NetworkSecurity
online version: https://learn.microsoft.com/powershell/module/az.networksecurity/get-aznetworksecurityneuroshield
schema: 2.0.0
---

# Get-AzNetworkSecurityNeuroShield

## SYNOPSIS
Gets a NeuroShield resource.

## SYNTAX

### List (Default)
```
Get-AzNetworkSecurityNeuroShield [-SubscriptionId <String[]>] [-SkipToken <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkSecurityNeuroShield -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkSecurityNeuroShield -InputObject <INetworkSecurityIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzNetworkSecurityNeuroShield -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-SkipToken <String>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a NeuroShield resource.

## EXAMPLES

### Example 1: Get a NeuroShield
```powershell
Get-AzNetworkSecurityNeuroShield -ResourceGroupName 'myResourceGroup' -Name 'myNeuroShield'
```

Gets the specified NeuroShield in the current subscription.

### Example 2: List NeuroShields in a resource group
```powershell
Get-AzNetworkSecurityNeuroShield -ResourceGroupName 'myResourceGroup'
```

Lists NeuroShields in the resource group.

### Example 3: List NeuroShields in the current subscription
```powershell
Get-AzNetworkSecurityNeuroShield
```

Lists NeuroShields across resource groups in the current subscription.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INetworkSecurityIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the NeuroShield resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: NeuroShieldName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SkipToken
The continuation token used to retrieve the next page.

```yaml
Type: System.String
Parameter Sets: List, List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The maximum number of items to return.

```yaml
Type: System.Int32
Parameter Sets: List, List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INetworkSecurityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INeuroShieldResource

## NOTES

## RELATED LINKS
