---
external help file:
Module Name: Az.Confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/new-azconfluentaccessrolebinding
schema: 2.0.0
---

# New-AzConfluentAccessRoleBinding

## SYNOPSIS
Organization role bindings

## SYNTAX

### CreateExpanded (Default)
```
New-AzConfluentAccessRoleBinding -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-CrnPattern <String>] [-Principal <String>] [-RoleName <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzConfluentAccessRoleBinding -OrganizationName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzConfluentAccessRoleBinding -OrganizationName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Organization role bindings

## EXAMPLES

### Example 1: Create a role binding for a user
```powershell
New-AzConfluentAccessRoleBinding -ResourceGroupName azure-rg-test -OrganizationName confluentorg-01 -Principal "User:u-123456" -RoleName "EnvironmentAdmin" -CrnPattern "crn://confluent.cloud/organization=*/environment=env-123456"
```

```output
Id          Principal          RoleName           CrnPattern
--          ---------          --------           ----------
rb-abc123   User:u-123456      EnvironmentAdmin   crn://confluent.cloud/organization=*/environment=env-123456
```

This command creates a role binding granting EnvironmentAdmin role to a user for a specific environment.

### Example 2: Create a role binding for a service account
```powershell
New-AzConfluentAccessRoleBinding -ResourceGroupName azure-rg-test -OrganizationName confluentorg-01 -Principal "ServiceAccount:sa-789012" -RoleName "CloudClusterAdmin" -CrnPattern "crn://confluent.cloud/organization=*/environment=*/cloud-cluster=lkc-abc123"
```

```output
Id          Principal                  RoleName           CrnPattern
--          ---------                  --------           ----------
rb-def456   ServiceAccount:sa-789012   CloudClusterAdmin  crn://confluent.cloud/organization=*/environment=*/cloud-cluster=lkc-abc123
```

This command creates a role binding granting CloudClusterAdmin role to a service account for a specific cluster.

## PARAMETERS

### -CrnPattern
A CRN that specifies the scope and resource patterns necessary for the role to bind

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -OrganizationName
Organization resource name

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

### -Principal
The principal User or Group to bind the role to

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleName
The name of the role to bind to the principal

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IRoleBindingRecord

## NOTES

## RELATED LINKS

