---
external help file:
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworksecurityperimeterassociation
schema: 2.0.0
---

# New-AzNetworkSecurityPerimeterAssociation

## SYNOPSIS
Create a NSP resource association.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkSecurityPerimeterAssociation -Name <String> -ResourceGroupName <String>
 -SecurityPerimeterName <String> [-SubscriptionId <String>] [-AccessMode <String>] [-AssociationId <String>]
 [-Location <String>] [-PrivateLinkResourceId <String>] [-ProfileId <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzNetworkSecurityPerimeterAssociation -Name <String> -ResourceGroupName <String>
 -SecurityPerimeterName <String> -Parameter <INspAssociation> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzNetworkSecurityPerimeterAssociation -InputObject <INetworkSecurityPerimeterIdentity>
 [-AccessMode <String>] [-AssociationId <String>] [-Location <String>] [-PrivateLinkResourceId <String>]
 [-ProfileId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityNetworkSecurityPerimeter
```
New-AzNetworkSecurityPerimeterAssociation -Name <String>
 -NetworkSecurityPerimeterInputObject <INetworkSecurityPerimeterIdentity> -Parameter <INspAssociation>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityNetworkSecurityPerimeterExpanded
```
New-AzNetworkSecurityPerimeterAssociation -Name <String>
 -NetworkSecurityPerimeterInputObject <INetworkSecurityPerimeterIdentity> [-AccessMode <String>]
 [-AssociationId <String>] [-Location <String>] [-PrivateLinkResourceId <String>] [-ProfileId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkSecurityPerimeterAssociation -Name <String> -ResourceGroupName <String>
 -SecurityPerimeterName <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkSecurityPerimeterAssociation -Name <String> -ResourceGroupName <String>
 -SecurityPerimeterName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a NSP resource association.

## EXAMPLES

### Example 1: Creates a NetworkSecurityPerimeterAccessAssociation
```powershell

 $profileId = '/subscriptions/<SubscriptionId>/resourceGroups/ResourceGroup-1/providers/Microsoft.Network/networkSecurityPerimeters/nsp3/profiles/profile2'
 $privateLinkResourceId = '/subscriptions/<SubscriptionId>/resourceGroups/ResourceGroup-1/providers/Microsoft.KeyVault/vaults/rp4'
 New-AzNetworkSecurityPerimeterAssociation -Name association1 -SecurityPerimeterName nsp3 -ResourceGroupName ResourceGroup-1 -Location eastus2euap -AccessMode Learning -ProfileId $profileId -PrivateLinkResourceId $privateLinkResourceId

```

```output

Location Name
-------- ----
         association1


```

Creates a NetworkSecurityPerimeterAccessAssociation

## PARAMETERS

### -AccessMode
Access mode on the association.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssociationId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded
Aliases: Id

Required: False
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
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the NSP association.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaIdentityNetworkSecurityPerimeter, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: AssociationName

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
Parameter Sets: CreateViaIdentityNetworkSecurityPerimeter, CreateViaIdentityNetworkSecurityPerimeterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Parameter
The NSP resource association resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspAssociation
Parameter Sets: Create, CreateViaIdentityNetworkSecurityPerimeter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateLinkResourceId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityPerimeterName
The name of the network security perimeter.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: NetworkSecurityPerimeterName, NSPName

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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspAssociation

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspAssociation

## NOTES

## RELATED LINKS

