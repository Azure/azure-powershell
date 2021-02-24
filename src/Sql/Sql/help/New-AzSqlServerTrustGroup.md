---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/az.sql/new-azsqlservertrustgroup
schema: 2.0.0
---

# New-AzSqlServerTrustGroup

## SYNOPSIS
Creates a new Server Trust Group.

## SYNTAX

```
New-AzSqlServerTrustGroup [-Location] <String> [-Name] <String>
 [-GroupMembers] <System.Collections.Generic.List`1[System.String]>
 [[-TrustScope] <System.Collections.Generic.List`1[System.String]>] [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates a new Server Trust Group with specified location, members, trust scope, name and resource group.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzSqlServerTrustGroup -Location "West Europe" -Name "ServerTrustGroup01" -GroupMembers "ManagedInstance01","ManagedInstance02" -TrustScope "GlobalTransactions" -ResourceGroupName "ResourceGroup01" 
```

Creates a new Server Trust Group in location Wet Europe with name ServerTrustGroup01. Its members are AzureSQL Managed Instances ManagedInstance01 and ManagedInstance02. Its trust scope is GlobalTransactions and its resource group is ResourceGroup01.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupMembers
Group members of the Server Trust Group to create.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: Default
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
Type: String
Parameter Sets: Default
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
Type: String
Parameter Sets: Default
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
Type: String
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
Parameter Sets: Default
Aliases:

Required: False
Position: 4
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
