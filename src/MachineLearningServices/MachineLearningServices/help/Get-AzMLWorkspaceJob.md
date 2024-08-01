---
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/get-azmlworkspacejob
schema: 2.0.0
---

# Get-AzMLWorkspaceJob

## SYNOPSIS
Gets a Job by name/id.

## SYNTAX

### List (Default)
```
Get-AzMLWorkspaceJob -ResourceGroupName <String> [-SubscriptionId <String[]>] -WorkspaceName <String>
 [-Job <String>] [-JobType <String>] [-ListViewType <ListViewType>] [-Skip <String>] [-Tag <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMLWorkspaceJob -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMLWorkspaceJob -InputObject <IMachineLearningServicesIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a Job by name/id.

## EXAMPLES

### Example 1: Lists all jobs under a workspace
```powershell
Get-AzMLWorkspaceJob  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01
```

```output
Name                       SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                       -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
willing_vinegar_mwjs1dyft0 5/31/2022 7:58:38 AM UserName (Example)         User                                                                                                   ml-rg-test
ivory_beard_fsbkdw8n77     5/18/2022 8:03:36 AM UserName (Example)         User                                                                                                   ml-rg-test
plucky_collar_5x0ds0fgb3   5/18/2022 7:44:55 AM UserName (Example)         User                                                                                                   ml-rg-test
heroic_quince_0vqqqpq7mt   5/18/2022 7:10:35 AM UserName (Example)         User                                                                                                   ml-rg-test
amiable_hominy_g700h46sb5  5/18/2022 6:42:32 AM UserName (Example)         User                                                                                                   ml-rg-test
```

Lists all jobs under a workspace

### Example 2: Gets a Job by name
```powershell
Get-AzMLWorkspaceJob  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name willing_vinegar_mwjs1dyft0
```

```output
Name                       SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                       -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
willing_vinegar_mwjs1dyft0 5/31/2022 7:58:38 AM UserName (Example)         User                                                                                                   ml-rg-test
```

Gets a Job by name

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

### -Job
Comma-separated list of user property names (and optionally values).
Example: prop1,prop2=value2

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

### -JobType
Type of job to be returned.

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
The name and identifier for the Job.
This is case-sensitive.

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

### -Tag
Jobs returned will have this tag key.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBase

## NOTES

## RELATED LINKS
