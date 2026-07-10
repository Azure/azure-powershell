---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/get-azcdnedgeactionversion
schema: 2.0.0
---

# Get-AzCdnEdgeActionVersion

## SYNOPSIS
Get EdgeActionVersion resource

## SYNTAX

### List (Default)
```
Get-AzCdnEdgeActionVersion -EdgeActionName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzCdnEdgeActionVersion -EdgeActionName <String> -ResourceGroupName <String> -Version <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get EdgeActionVersion resource

## EXAMPLES

### Example 1: List all Edge Action Versions
```powershell
Get-AzCdnEdgeActionVersion -ResourceGroupName "testps-rg-da16jm" -EdgeActionName "edgeaction001"
```

```output
Name                      : v1
Id                        : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/versions/v1
Type                      : Microsoft.Cdn/edgeActions/versions
Location                  : global
ResourceGroupName         : testps-rg-da16jm
DeploymentType            : zip
IsDefaultVersion          : True
ProvisioningState         : Succeeded
ValidationStatus          : Succeeded
LastPackageUpdateTime     : 10/27/2025 10:30:45 AM

Name                      : v2
Id                        : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/versions/v2
Type                      : Microsoft.Cdn/edgeActions/versions
Location                  : global
ResourceGroupName         : testps-rg-da16jm
DeploymentType            : zip
IsDefaultVersion          : False
ProvisioningState         : Succeeded
ValidationStatus          : Succeeded
LastPackageUpdateTime     : 10/27/2025 11:15:30 AM
```

List all versions of the specified Edge Action

### Example 2: Get a specific Edge Action Version by name
```powershell
Get-AzCdnEdgeActionVersion -ResourceGroupName "testps-rg-da16jm" -EdgeActionName "edgeaction001" -Version "v1"
```

```output
Name                      : v1
Id                        : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/versions/v1
Type                      : Microsoft.Cdn/edgeActions/versions
Location                  : global
ResourceGroupName         : testps-rg-da16jm
DeploymentType            : zip
IsDefaultVersion          : True
ProvisioningState         : Succeeded
ValidationStatus          : Succeeded
LastPackageUpdateTime     : 10/27/2025 10:30:45 AM
```

Get a specific Edge Action Version by name

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

### -EdgeActionName
The name of the Edge Action

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
The name of the Edge Action version

```yaml
Type: System.String
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IEdgeActionVersion

## NOTES

## RELATED LINKS

