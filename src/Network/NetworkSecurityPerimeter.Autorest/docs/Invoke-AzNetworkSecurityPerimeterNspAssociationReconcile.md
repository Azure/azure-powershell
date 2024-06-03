---
external help file:
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/invoke-aznetworksecurityperimeternspassociationreconcile
schema: 2.0.0
---

# Invoke-AzNetworkSecurityPerimeterNspAssociationReconcile

## SYNOPSIS
Reconcile NSP association

## SYNTAX

### PostExpanded (Default)
```
Invoke-AzNetworkSecurityPerimeterNspAssociationReconcile -AssociationName <String>
 -NetworkSecurityPerimeterName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Post
```
Invoke-AzNetworkSecurityPerimeterNspAssociationReconcile -AssociationName <String>
 -NetworkSecurityPerimeterName <String> -ResourceGroupName <String> -Parameter <IAny>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PostViaIdentity
```
Invoke-AzNetworkSecurityPerimeterNspAssociationReconcile -InputObject <INetworkSecurityPerimeterIdentity>
 -Parameter <IAny> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PostViaIdentityExpanded
```
Invoke-AzNetworkSecurityPerimeterNspAssociationReconcile -InputObject <INetworkSecurityPerimeterIdentity>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PostViaIdentityNetworkSecurityPerimeter
```
Invoke-AzNetworkSecurityPerimeterNspAssociationReconcile -AssociationName <String>
 -NetworkSecurityPerimeterInputObject <INetworkSecurityPerimeterIdentity> -Parameter <IAny>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PostViaIdentityNetworkSecurityPerimeterExpanded
```
Invoke-AzNetworkSecurityPerimeterNspAssociationReconcile -AssociationName <String>
 -NetworkSecurityPerimeterInputObject <INetworkSecurityPerimeterIdentity> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PostViaJsonFilePath
```
Invoke-AzNetworkSecurityPerimeterNspAssociationReconcile -AssociationName <String>
 -NetworkSecurityPerimeterName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PostViaJsonString
```
Invoke-AzNetworkSecurityPerimeterNspAssociationReconcile -AssociationName <String>
 -NetworkSecurityPerimeterName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Reconcile NSP association

## EXAMPLES

### Example 1: Reconcile NSP association
```powershell
Invoke-AzNetworkSecurityPerimeterNspAssociationReconcile -AssociationName association3 -NetworkSecurityPerimeterName nsp3 -ResourceGroupName ResourceGroup-1 
```

Reconcile NSP association

### Example 2: Reconcile NSP association by identity (using pipe)
```powershell
 $GETObj = Get-AzNetworkSecurityPerimeterAssociation -Name association3 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3
 Invoke-AzNetworkSecurityPerimeterNspAssociationReconcile -InputObject $GETObj
```

Reconcile NSP association by identity (using pipe)

## PARAMETERS

### -AssociationName
The name of the NSP association.

```yaml
Type: System.String
Parameter Sets: Post, PostExpanded, PostViaIdentityNetworkSecurityPerimeter, PostViaIdentityNetworkSecurityPerimeterExpanded, PostViaJsonFilePath, PostViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
Parameter Sets: PostViaIdentity, PostViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Post operation

```yaml
Type: System.String
Parameter Sets: PostViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Post operation

```yaml
Type: System.String
Parameter Sets: PostViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkSecurityPerimeterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
Parameter Sets: PostViaIdentityNetworkSecurityPerimeter, PostViaIdentityNetworkSecurityPerimeterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NetworkSecurityPerimeterName
The name of the network security perimeter.

```yaml
Type: System.String
Parameter Sets: Post, PostExpanded, PostViaJsonFilePath, PostViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Anything

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IAny
Parameter Sets: Post, PostViaIdentity, PostViaIdentityNetworkSecurityPerimeter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Post, PostExpanded, PostViaJsonFilePath, PostViaJsonString
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
Type: System.String
Parameter Sets: Post, PostExpanded, PostViaJsonFilePath, PostViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IAny

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IAny

## NOTES

## RELATED LINKS

