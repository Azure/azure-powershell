---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/get-azsqlservertrustgroup
schema: 2.0.0
---

# Get-AzSqlServerTrustGroup

## SYNOPSIS
Gets information about Server Trust Group.

## SYNTAX

### ListByLocationSet (Default)
```
Get-AzSqlServerTrustGroup [-ResourceGroupName] <String> [-Location] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByName
```
Get-AzSqlServerTrustGroup [-ResourceGroupName] <String> [-Location] <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ListByInstanceSet
```
Get-AzSqlServerTrustGroup [-ResourceGroupName] <String> [-InstanceName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdSet
```
Get-AzSqlServerTrustGroup [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSqlServerTrustGroup** cmdlet get information about Server Trust Group and its members for current subscription. Based on parameter set this cmdlet can retrieve specified Server Trust Group, all Server Trust Groups in a specified location or Server Trust Groups that have specified AzureSQL Managed Instance as a member.

## EXAMPLES

### Example 1
```powershell
Get-AzSqlServerTrustGroup -ResourceGroupName "ResourceGroup01" -Location "West Europe" -Name "ServerTrustGroup01"
```

Gets information about Server Trust Group named ServerTrustGroup01 in resource group ResourceGroup01 in location West Europe.

### Example 2
```powershell
Get-AzSqlServerTrustGroup -ResourceGroupName "ResourceGroup01" -Location "West Europe"
```

Gets information about all Server Trust Groups in location West Europe in resource group ResourceGroup01.

### Example 3
```powershell
Get-AzSqlServerTrustGroup -ResourceGroupName "ResourceGroup01" -InstanceName "ManagedInstance01"
```

Gets information about all Server Trust Groups that have managed instance ManagedInstance01 as a member.

### Example 4
```powershell
Get-AzSqlServerTrustGroup -ResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/locations/WestEurope/serverTrustGroups/ServerTrustGroup01"
```

Gets information about Server Trust Group specified by its id.

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

### -InstanceName
The name of the managed instance that is member of Server Trust Groups to retrieve.

```yaml
Type: System.String
Parameter Sets: ListByInstanceSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the Server Trust Group to retrieve.

```yaml
Type: System.String
Parameter Sets: ListByLocationSet, GetByName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Server Trust Group to retrieve.

```yaml
Type: System.String
Parameter Sets: GetByName
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
Parameter Sets: ListByLocationSet, GetByName, ListByInstanceSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of instance to use

```yaml
Type: System.String
Parameter Sets: ResourceIdSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ServerTrustGroup.Model.AzureSqlServerTrustGroupModel

## NOTES

## RELATED LINKS
