---
external help file:
Module Name: Az.Fleet
online version: https://learn.microsoft.com/powershell/module/az.fleet/update-azfleet
schema: 2.0.0
---

# Update-AzFleet

## SYNOPSIS
Update a Fleet.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFleet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-IfMatch <String>]
 [-IfNoneMatch <String>] [-EnableSystemAssignedIdentity <Boolean?>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFleet -InputObject <IFleetIdentity> [-IfMatch <String>] [-IfNoneMatch <String>]
 [-EnableSystemAssignedIdentity <Boolean?>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a Fleet.

## EXAMPLES

### Example 1: Update tag of specified fleet
```powershell
Update-AzFleet -Name testfleet01 -ResourceGroupName K8sFleet-Test -Tag @{"123"="abc"}
```

```output
ETag                         : "cb06f006-0000-0100-0000-655c7e120000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : 
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : testfleet01
ProvisioningState            : Succeeded
ResourceGroupName            : K8sFleet-Test
SystemDataCreatedAt          : 11/15/2023 2:19:28 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/21/2023 9:53:21 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "123": "abc"
                               }
Type                         : Microsoft.ContainerService/fleets
```

This command updates tag of a fleet.

### Example 2: disable system assigned identity of specified fleet
```powershell
Update-AzFleet -ResourceGroupName joyer-test -Name testfleet03 -EnableSystemAssignedIdentity 0
```

```output
ETag                         : "0a00e5cc-0000-0100-0000-661cea3b0000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.ContainerService/fleets/testflee 
                               t02
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : testfleet02
ProvisioningState            : Succeeded
ResourceGroupName            : joyer-test
SystemDataCreatedAt          : 4/15/2024 7:19:15 AM
SystemDataCreatedBy          : v-jiaji@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/15/2024 8:50:01 AM
SystemDataLastModifiedBy     : v-jiaji@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "456": "asd"
                               }
Type                         : Microsoft.ContainerService/fleets
```

This command updates EnableSystemAssignedIdentity of a fleet.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
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

### -EnableSystemAssignedIdentity
Decides if enable a system assigned identity for the resource.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
The request should only proceed if an entity matches this string.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfNoneMatch
The request should only proceed if no entity matches this string.

```yaml
Type: System.String
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Fleet resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: FleetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

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

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleet

## NOTES

## RELATED LINKS

