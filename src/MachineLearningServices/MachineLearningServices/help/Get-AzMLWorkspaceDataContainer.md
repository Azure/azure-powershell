---
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/get-azmlworkspacedatacontainer
schema: 2.0.0
---

# Get-AzMLWorkspaceDataContainer

## SYNOPSIS
Get container.

## SYNTAX

### List (Default)
```
Get-AzMLWorkspaceDataContainer -ResourceGroupName <String> [-SubscriptionId <String[]>] -WorkspaceName <String>
 [-ListViewType <ListViewType>] [-Skip <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzMLWorkspaceDataContainer -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMLWorkspaceDataContainer -InputObject <IMachineLearningServicesIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get container.

## EXAMPLES

### Example 1: Lists all data containers under a workspace
```powershell
Get-AzMLWorkspaceDataContainer  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01
```

```output
Name       SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----       -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
iris-data  5/5/2022 2:58:50 AM  Lucas Yao (Wicresoft North America) User                    5/5/2022 2:58:50 AM                                                            ml-rg-test
pwshdata01 5/17/2022 7:11:05 AM Lucas Yao (Wicresoft North America) User                    5/17/2022 7:11:05 AM                                                           ml-rg-test
dtpwsh01   5/24/2022 6:12:06 AM Lucas Yao (Wicresoft North America) User                    5/24/2022 6:12:06 AM                                                           ml-rg-test
dtpwsh02   5/24/2022 6:21:34 AM Lucas Yao (Wicresoft North America) User                    5/24/2022 6:21:35 AM                                                           ml-rg-test
```

Lists all data containers under a workspace

### Example 2: Get a data container by name
```powershell
Get-AzMLWorkspaceDataContainer  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name iris-data
```

```output
Name      SystemDataCreatedAt SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----      ------------------- -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
iris-data 5/5/2022 2:58:50 AM Lucas Yao (Wicresoft North America) User                    5/5/2022 2:58:50 AM                                                            ml-rg-test
```

Get a data container by name

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ListViewType
View type for including/excluding (for example) archived entities.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ListViewType
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Container name.

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
Name of Azure Machine Learning workspace.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Continuation token for pagination.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDataContainer

## NOTES

## RELATED LINKS
