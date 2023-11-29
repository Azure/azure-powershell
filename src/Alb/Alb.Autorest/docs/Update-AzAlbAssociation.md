---
external help file:
Module Name: Az.Alb
online version: https://learn.microsoft.com/powershell/module/az.alb/update-azalbassociation
schema: 2.0.0
---

# Update-AzAlbAssociation

## SYNOPSIS
Update a Association

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAlbAssociation -AlbName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AssociationType <String>] [-SubnetId <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAlbAssociation -InputObject <IAlbIdentity> [-AssociationType <String>] [-SubnetId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityTrafficController
```
Update-AzAlbAssociation -Name <String> -TrafficControllerInputObject <IAlbIdentity>
 -Property <IAssociationUpdate> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityTrafficControllerExpanded
```
Update-AzAlbAssociation -Name <String> -TrafficControllerInputObject <IAlbIdentity>
 [-AssociationType <String>] [-SubnetId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzAlbAssociation -AlbName <String> -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzAlbAssociation -AlbName <String> -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a Association

## EXAMPLES

### Example 1: Update Application Gateway for Containers association resource with tag
```powershell
Update-AzAlbAssociation -Name test-association -AlbName test-alb -ResourceGroupName test-rg -Tag @{TestTag="Test tag value"}
```

This command updates tag values for an Application Gateway for Containers association resource.

## PARAMETERS

### -AlbName
traffic controller name for path

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssociationType
Association Type

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityTrafficControllerExpanded
Aliases:

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAlbIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Association

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityTrafficController, UpdateViaIdentityTrafficControllerExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Property
The type used for update operations of the Association.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAssociationUpdate
Parameter Sets: UpdateViaIdentityTrafficController
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetId
Association ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityTrafficControllerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityTrafficControllerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficControllerInputObject
Identity Parameter
To construct, see NOTES section for TRAFFICCONTROLLERINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAlbIdentity
Parameter Sets: UpdateViaIdentityTrafficController, UpdateViaIdentityTrafficControllerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAlbIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAssociationUpdate

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAssociation

## NOTES

## RELATED LINKS

