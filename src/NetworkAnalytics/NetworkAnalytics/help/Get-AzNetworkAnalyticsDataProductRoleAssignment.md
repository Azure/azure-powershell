---
external help file: Az.NetworkAnalytics-help.xml
Module Name: Az.NetworkAnalytics
online version: https://learn.microsoft.com/powershell/module/az.networkanalytics/get-aznetworkanalyticsdataproductroleassignment
schema: 2.0.0
---

# Get-AzNetworkAnalyticsDataProductRoleAssignment

## SYNOPSIS
List user roles associated with the data product.

## SYNTAX

### ListExpanded (Default)
```
Get-AzNetworkAnalyticsDataProductRoleAssignment -DataProductName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### List
```
Get-AzNetworkAnalyticsDataProductRoleAssignment -DataProductName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -Body <IAny> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
List user roles associated with the data product.

## EXAMPLES

### Example 1: List user role associated with the data product.
```powershell
$UserRoles=Get-AzNetworkAnalyticsDataProductRoleAssignment -ResourceGroupName "ResourceGroupName" -DataProductName "pwshdp01"

 $UserRoles.RoleAssignmentResponse| select PrincipalId,PrincipalType,RoleId,Role
```

```output
PrincipalId            PrincipalType RoleId                                   Role
-----------            ------------- ------                                   ----
user1@microsoft.com    User          opinsightsdpqjydom/pwshdp01/confc9uee8dm Viewer
user2@microsoft.com    User          opinsightsdpqjydom/pwshdp01/confmq0f0zpu Viewer
```

List user role associated with the data product.

## PARAMETERS

### -Body
Any object

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Models.IAny
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DataProductName
The data product resource name

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Models.IAny

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Models.Api20231115.IListRoleAssignments

## NOTES

## RELATED LINKS
