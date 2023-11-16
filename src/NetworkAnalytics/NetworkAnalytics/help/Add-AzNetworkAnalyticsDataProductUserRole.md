---
external help file:
Module Name: Az.NetworkAnalytics
online version: https://learn.microsoft.com/powershell/module/az.networkanalytics/add-aznetworkanalyticsdataproductuserrole
schema: 2.0.0
---

# Add-AzNetworkAnalyticsDataProductUserRole

## SYNOPSIS
Assign role to the data product.

## SYNTAX

### AddExpanded (Default)
```
Add-AzNetworkAnalyticsDataProductUserRole -DataProductName <String> -ResourceGroupName <String>
 -DataTypeScope <String[]> -PrincipalId <String> -PrincipalType <String> -Role <DataProductUserRole>
 -RoleId <String> -UserName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### AddViaIdentityExpanded
```
Add-AzNetworkAnalyticsDataProductUserRole -InputObject <INetworkAnalyticsIdentity> -DataTypeScope <String[]>
 -PrincipalId <String> -PrincipalType <String> -Role <DataProductUserRole> -RoleId <String> -UserName <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Assign role to the data product.

## EXAMPLES

### Example 1: Assign user role to the data product.
```powershell
 Add-AzNetworkAnalyticsDataProductUserRole -DataProductName "dataProductName" -ResourceGroupName "ResourceGroupName" -PrincipalId user@microsoft.com -Role Reader -RoleId " " -UserName "User Name" -PrincipalType user  -DataTypeScope "dataProductName"
```

```output
PrincipalId            PrincipalType Role   RoleAssignmentId RoleId UserName
-----------            ------------- ----   ---------------- ------ --------
user@microsoft.com     user          Reader confmq0f0zpu            User Name
```

Assign user role to the data product.

## PARAMETERS

### -DataProductName
The data product resource name

```yaml
Type: System.String
Parameter Sets: AddExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataTypeScope
Data Type Scope at which the role assignment is created.

```yaml
Type: System.String[]
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Models.INetworkAnalyticsIdentity
Parameter Sets: AddViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrincipalId
Object ID of the AAD principal or security-group.

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

### -PrincipalType
Type of the principal Id: User, Group or ServicePrincipal

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
Parameter Sets: AddExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Role
Data Product role to be assigned to a user.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Support.DataProductUserRole
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleId
Role Id of the Built-In Role

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
Type: System.String
Parameter Sets: AddExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserName
User name.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Models.INetworkAnalyticsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Models.Api20231115.IRoleAssignmentDetail

## NOTES

## RELATED LINKS

