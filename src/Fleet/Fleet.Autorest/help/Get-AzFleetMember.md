---
external help file:
Module Name: Az.Fleet
online version: https://learn.microsoft.com/powershell/module/az.fleet/get-azfleetmember
schema: 2.0.0
---

# Get-AzFleetMember

## SYNOPSIS
Get a FleetMember

## SYNTAX

### List (Default)
```
Get-AzFleetMember -FleetName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzFleetMember -FleetName <String> -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFleetMember -InputObject <IFleetIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityFleet
```
Get-AzFleetMember -FleetInputObject <IFleetIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a FleetMember

## EXAMPLES

### Example 1: Get specific fleet member with specified name
```powershell
Get-AzFleetMember -FleetName testfleet01 -ResourceGroupName K8sFleet-Test -Name testmember
```

```output
ClusterResourceId            : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/microsoft.containerservice/managedClusters/TestCluster01
ETag                         : "6205a537-0000-0100-0000-655430760000"
Group                        : 
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01/members/testmember
Name                         : testmember
ProvisioningState            : Succeeded
ResourceGroupName            : K8sFleet-Test
SystemDataCreatedAt          : 11/15/2023 2:43:32 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/15/2023 2:43:32 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.ContainerService/fleets/members
```

This command gets specific fleet member with specified name.

### Example 2: Get a list of fleet member with specified fleet
```powershell
Get-AzFleetMember -FleetName testfleet01 -ResourceGroupName K8sFleet-Test
```

```output
Name        SystemDataCreatedAt   SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ETag                                   Resource 
                                                                                                                                                                                                      GroupNam 
                                                                                                                                                                                                      e        
----        -------------------   -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----                                   -------- 
testmember  11/21/2023 3:13:50 AM user1@example.com     User                    11/21/2023 3:13:50 AM    user1@example.com        User                         "bc061fb4-0000-0100-0000-655c208e0000" K8sFlee… 
testmember2 11/21/2023 4:11:24 AM user1@example.com     User                    11/21/2023 4:11:24 AM    user1@example.com        User                         "be067cf2-0000-0100-0000-655c2e280000" K8sFlee… 
```

This command gets a list of fleet member with specified fleet.

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

### -FleetInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
Parameter Sets: GetViaIdentityFleet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FleetName
The name of the Fleet resource.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Fleet member resource.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityFleet
Aliases: FleetMemberName

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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetMember

## NOTES

## RELATED LINKS

