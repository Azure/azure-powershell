---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Blueprint.dll-Help.xml
Module Name: Az.Blueprint
online version: https://docs.microsoft.com/en-us/powershell/module/get-azblueprint
schema: 2.0.0
---

# Get-AzBlueprint

## SYNOPSIS
Get one or more blueprints.

## SYNTAX

### SubscriptionScope (Default)
```
Get-AzBlueprint [[-SubscriptionId] <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ManagementGroupScope
```
Get-AzBlueprint [-ManagementGroupName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### BySubscriptionAndName
```
Get-AzBlueprint [[-SubscriptionId] <String>] [-Name] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### BySubscriptionNameAndVersion
```
Get-AzBlueprint [[-SubscriptionId] <String>] [-Version] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### BySubscriptionNameAndLatestPublished
```
Get-AzBlueprint [[-SubscriptionId] <String>] [-Name] <String> [-LatestPublished]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByManagementGroupAndName
```
Get-AzBlueprint [-ManagementGroupName] <String> [-Name] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByManagementGroupNameAndVersion
```
Get-AzBlueprint [-ManagementGroupName] <String> [-Version] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByManagementGroupNameAndLatestPublished
```
Get-AzBlueprint [-ManagementGroupName] <String> [-Name] <String> [-LatestPublished]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get one or more blueprints. Blueprints can be queried at management group or subscription scope.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzBlueprint
```

Gets the Blueprints within the subscription in current context.

### Example 2
```
PS C:\> Get-AzBlueprint -ManagementGroupName "myManagementGroupId"
```

Gets the list of Blueprints within the specified management group.

### Example 3
```
PS C:\> Get-AzBlueprint -SubscriptionId "00000000-1111-0000-1111-000000000000"
```

Gets the list of Blueprints within the given subscription.

### Example 4
```
PS C:\> Get-AzBlueprint -SubscriptionId "00000000-1111-0000-1111-000000000000" -Name "myBlueprintName"
```

Gets the Blueprint with given name.

### Example 5
```
PS C:\> Get-AzBlueprint -ManagementGroupName "myManagementGroupId" -Name "myBlueprintName" -Version "myBlueprintVersion"
```

Gets the Blueprint with given version.

### Example 6
```
PS C:\> Get-AzBlueprint -ManagementGroupName "myManagementGroupId" -Name "myBlueprintName" -LatestPublished
```

Get the lastest published Blueprint.

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

### -LatestPublished
The latest published Blueprint flag.
When set, execution returns the latest published version of Blueprint.
Defaults to false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: BySubscriptionNameAndLatestPublished, ByManagementGroupNameAndLatestPublished
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ManagementGroupName
Management Group Id where Blueprint is located.

```yaml
Type: System.String
Parameter Sets: ManagementGroupScope, ByManagementGroupAndName, ByManagementGroupNameAndVersion, ByManagementGroupNameAndLatestPublished
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Blueprint definition name.

```yaml
Type: System.String
Parameter Sets: BySubscriptionAndName, BySubscriptionNameAndLatestPublished, ByManagementGroupAndName, ByManagementGroupNameAndLatestPublished
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionId
Subscription Id.

```yaml
Type: System.String
Parameter Sets: SubscriptionScope, BySubscriptionAndName, BySubscriptionNameAndVersion, BySubscriptionNameAndLatestPublished
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Version
Blueprint definition version.

```yaml
Type: System.String
Parameter Sets: BySubscriptionNameAndVersion, ByManagementGroupNameAndVersion
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS
