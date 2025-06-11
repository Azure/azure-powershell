---
external help file:
Module Name: Az.DependencyMap
online version: https://learn.microsoft.com/powershell/module/az.dependencymap/get-azdependencymap
schema: 2.0.0
---

# Get-AzDependencyMap

## SYNOPSIS
Get a MapsResource

## SYNTAX

### List1 (Default)
```
Get-AzDependencyMap [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDependencyMap -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDependencyMap -InputObject <IDependencyMapIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDependencyMap -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a MapsResource

## EXAMPLES

### Example 1: Get a dependency map with name.
```powershell
Get-AzDependencyMap -ResourceGroupName dmTestGroup -Name testMap
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/dmTestGroup/providers/Microsoft.DependencyMap/maps/testMap
Location                     : eastus
Name                         : testMap
ProvisioningState            : Succeeded
ResourceGroupName            : dmTestGroup
SystemDataCreatedAt          : 6/9/2025 5:25:07 AM
SystemDataCreatedBy          : test@abc.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 6/9/2025 5:25:07 AM
SystemDataLastModifiedBy     : test@abc.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.dependencymap/maps
```

This command gets a dependency map in a resource group.

### Example 2: List all dependency maps in a subscription.
```powershell
Get-AzDependencyMap
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/dmTestGroup/providers/Microsoft.DependencyMap/maps/testMap
Location                     : eastus
Name                         : testMap
ProvisioningState            : Succeeded
ResourceGroupName            : dmTestGroup
SystemDataCreatedAt          : 6/9/2025 5:25:07 AM
SystemDataCreatedBy          : test@abc.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 6/9/2025 5:25:07 AM
SystemDataLastModifiedBy     : test@abc.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.dependencymap/maps
```

This command lists all dependency maps in a subscription.

### Example 3: List all dependency maps in a resource group.
```powershell
Get-AzDependencyMap -ResourceGroupName dmTestGroup
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/dmTestGroup/providers/Microsoft.DependencyMap/maps/testMap
Location                     : eastus
Name                         : testMap
ProvisioningState            : Succeeded
ResourceGroupName            : dmTestGroup
SystemDataCreatedAt          : 6/9/2025 5:25:07 AM
SystemDataCreatedBy          : test@abc.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 6/9/2025 5:25:07 AM
SystemDataLastModifiedBy     : test@abc.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.dependencymap/maps
```

This command lists all dependency maps in a resource group.

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

### -Name
Maps resource name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: MapName

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IMapsResource

## NOTES

## RELATED LINKS

