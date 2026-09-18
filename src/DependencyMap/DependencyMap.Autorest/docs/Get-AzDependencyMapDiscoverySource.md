---
external help file:
Module Name: Az.DependencyMap
online version: https://learn.microsoft.com/powershell/module/az.dependencymap/get-azdependencymapdiscoverysource
schema: 2.0.0
---

# Get-AzDependencyMapDiscoverySource

## SYNOPSIS
Get a DiscoverySourceResource

## SYNTAX

### List (Default)
```
Get-AzDependencyMapDiscoverySource -MapName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDependencyMapDiscoverySource -MapName <String> -ResourceGroupName <String> -SourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDependencyMapDiscoverySource -InputObject <IDependencyMapIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityMap
```
Get-AzDependencyMapDiscoverySource -MapInputObject <IDependencyMapIdentity> -SourceName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a DiscoverySourceResource

## EXAMPLES

### Example 1: List all discovery sources under a dependency map.
```powershell
Get-AzDependencyMapDiscoverySource -ResourceGroupName dmTestGroup -MapName testMap
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/dmTestGroup/providers/Microsoft.DependencyMap/maps/testMap/discoverySources/dmSource
Location                     : eastus
Name                         : dmSource
Property                     : {
                                 "provisioningState": "Succeeded",
                                 "sourceType": "OffAzure",
                                 "sourceId": "testSourceId"
                               }
ResourceGroupName            : dmTestGroup
SystemDataCreatedAt          : 6/9/2025 6:20:14 AM
SystemDataCreatedBy          : test@abc.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 6/9/2025 6:20:14 AM
SystemDataLastModifiedBy     : test@abc.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.dependencymap/maps/discoverysources
```

This command lists all discovery sources under a dependency map.

### Example 2: Get a discovery source with name.
```powershell
Get-AzDependencyMapDiscoverySource -ResourceGroupName dmTestGroup -MapName testMap -SourceName dmSource
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/dmTestGroup/providers/Microsoft.DependencyMap/maps/testMap/discoverySources/dmSource
Location                     : eastus
Name                         : dmSource
Property                     : {
                                 "provisioningState": "Succeeded",
                                 "sourceType": "OffAzure",
                                 "sourceId": "testSourceId"
                               }
ResourceGroupName            : dmTestGroup
SystemDataCreatedAt          : 6/9/2025 6:20:14 AM
SystemDataCreatedBy          : test@abc.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 6/9/2025 6:20:14 AM
SystemDataLastModifiedBy     : test@abc.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.dependencymap/maps/discoverysources
```

This command gets a discovery source with name.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MapInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapIdentity
Parameter Sets: GetViaIdentityMap
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MapName
Maps resource name

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

### -SourceName
discovery source resource

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityMap
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResource

## NOTES

## RELATED LINKS

