---
external help file: Microsoft.Azure.Commands.OperationalInsights.dll-Help.xml
ms.assetid: 1F094EBA-E4AE-4B3E-BA20-858818C6FD12
online version: 
schema: 2.0.0
---

# Get-AzureRmOperationalInsightsDataSource

## SYNOPSIS
Get datasources under Azure Log Analytics workspace.

## SYNTAX

### ByWorkspaceName (Default)
```
Get-AzureRmOperationalInsightsDataSource [<CommonParameters>]
```

### ByWorkspaceObjectByName
```
Get-AzureRmOperationalInsightsDataSource [-Workspace] <PSWorkspace> [[-Name] <String>] [<CommonParameters>]
```

### ByWorkspaceObjectByKind
```
Get-AzureRmOperationalInsightsDataSource [[-Workspace] <PSWorkspace>] [[-Kind] <String>] [<CommonParameters>]
```

### ByWorkspaceNameByName
```
Get-AzureRmOperationalInsightsDataSource [-ResourceGroupName] <String> [-WorkspaceName] <String>
 [-Name] <String> [<CommonParameters>]
```

### ByWorkspaceNameByKind
```
Get-AzureRmOperationalInsightsDataSource [[-ResourceGroupName] <String>] [[-WorkspaceName] <String>]
 [-Kind] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmOperationalInsightsDataSource** cmdlet gets data sources.
You can specify a data source to get.
You can filter the results based on the kind of data source.

## EXAMPLES

### 1:
```

```

## PARAMETERS

### -Kind
Specifies the kind of data sources to get.
The acceptable values for this parameter are:

- AzureActivityLog 
- CustomLog 
- LinuxPerformanceObject 
- LinuxSyslog 
- WindowsEvent 
- WindowsPerformanceCounter

```yaml
Type: String
Parameter Sets: ByWorkspaceObjectByKind
Aliases: 
Accepted values: AzureAuditLog, AzureActivityLog, CustomLog, LinuxPerformanceObject, LinuxSyslog, WindowsEvent, WindowsPerformanceCounter

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ByWorkspaceNameByKind
Aliases: 
Accepted values: AzureAuditLog, AzureActivityLog, CustomLog, LinuxPerformanceObject, LinuxSyslog, WindowsEvent, WindowsPerformanceCounter

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of a data source to get.

```yaml
Type: String
Parameter Sets: ByWorkspaceObjectByName
Aliases: 

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ByWorkspaceNameByName
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of a resource group that contains data sources to get.

```yaml
Type: String
Parameter Sets: ByWorkspaceNameByName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ByWorkspaceNameByKind
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Workspace
Specifies a workspace in which this cmdlet operates.

```yaml
Type: PSWorkspace
Parameter Sets: ByWorkspaceObjectByName
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

```yaml
Type: PSWorkspace
Parameter Sets: ByWorkspaceObjectByKind
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
Specifies the name of a workspace in which this cmdlet operates.

```yaml
Type: String
Parameter Sets: ByWorkspaceNameByName
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ByWorkspaceNameByKind
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PSWorkspace

Parameter 'Workspace' accepts value of type 'PSWorkspace' from the pipeline

### PSWorkspace

Parameter 'Workspace' accepts value of type 'PSWorkspace' from the pipeline

## OUTPUTS

## NOTES
* Keywords: azure, azurerm, arm, resource, management, manager, operational, insights

## RELATED LINKS

[Remove-AzureRmOperationalInsightsDataSource](./Remove-AzureRmOperationalInsightsDataSource.md)

[Set-AzureRmOperationalInsightsDataSource](./Set-AzureRmOperationalInsightsDataSource.md)


