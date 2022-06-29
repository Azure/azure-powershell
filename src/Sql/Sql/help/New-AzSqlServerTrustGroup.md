---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/new-azsqlservertrustgroup
schema: 2.0.0
---

# New-AzSqlServerTrustGroup

## SYNOPSIS
Creates or updates a Server Trust Group.

## SYNTAX

### GroupMemberObjectSet (Default)
```
New-AzSqlServerTrustGroup [-ResourceGroupName] <String> [-Location] <String> [-Name] <String>
 [-GroupMember] <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel]>
 [-TrustScope <System.Collections.Generic.List`1[System.String]>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GroupMemberResourceIdSet
```
New-AzSqlServerTrustGroup [-ResourceGroupName] <String> [-Location] <String> [-Name] <String>
 [-GroupMemberResourceId] <System.Collections.Generic.List`1[System.String]>
 [-TrustScope <System.Collections.Generic.List`1[System.String]>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new Server Trust Group with specified location, members, trust scope, name and resource group.

## EXAMPLES

### Example 1
```powershell
$managedInstanceList = @()
$mi = Get-AzSqlInstance -Name "ManagedInstance01" -ResourceGroupName "ResourceGroup01"
$managedInstanceList += $mi
$mi = Get-AzSqlInstance -Name "ManagedInstance02" -ResourceGroupName "ResourceGroup02"
$managedInstanceList += $mi
New-AzSqlServerTrustGroup -ResourceGroupName "ResourceGroup03" -Location "West Europe" -Name "ServerTrustGroup01" -GroupMember $managedInstanceList -TrustScope "GlobalTransactions"
```

Creates a new Server Trust Group in location West Europe with name ServerTrustGroup01. Its members are AzureSQL Managed Instances ManagedInstance01 and ManagedInstance02. Its trust scope is GlobalTransactions and its resource group is ResourceGroup03.

### Example 2
```powershell
$mi1 = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01"
$mi2 = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup02/providers/Microsoft.Sql/managedInstances/ManagedInstance02"
New-AzSqlServerTrustGroup -ResourceGroupName "ResourceGroup03" -Location "West Europe" -Name "ServerTrustGroup01" -GroupMemberResourceId $mi1,$mi2 -TrustScope "GlobalTransactions"
```

Creates a new Server Trust Group in location West Europe with name ServerTrustGroup01. Its members are AzureSQL Managed Instances ManagedInstance01 and ManagedInstance02, given by its Resource ids. Its trust scope is GlobalTransactions and its resource group is ResourceGroup03.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupMember
Group members of the Server Trust Group to create.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel]
Parameter Sets: GroupMemberObjectSet
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupMemberResourceId
Group members of the Server Trust Group to create.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: GroupMemberResourceIdSet
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the Server Trust Group to create.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Server Trust Group to create.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrustScope
The trust scope of the Server Trust Group to create.

```yaml
Type: System.Collections.Generic.List`1[System.String]
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ServerTrustGroup.Model.AzureSqlServerTrustGroupModel

## NOTES

## RELATED LINKS
