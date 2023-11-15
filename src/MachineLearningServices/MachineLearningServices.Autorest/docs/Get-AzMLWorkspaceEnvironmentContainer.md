---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/get-azmlworkspaceenvironmentcontainer
schema: 2.0.0
---

# Get-AzMLWorkspaceEnvironmentContainer

## SYNOPSIS
Get container.

## SYNTAX

### List (Default)
```
Get-AzMLWorkspaceEnvironmentContainer -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-ListViewType <ListViewType>] [-Skip <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzMLWorkspaceEnvironmentContainer -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMLWorkspaceEnvironmentContainer -InputObject <IMachineLearningServicesIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get container.

## EXAMPLES

### Example 1: List all environment containers under a workspace
```powershell
Get-AzMLWorkspaceEnvironmentContainer  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01
```

```output
Name                                                             SystemDataCreatedAt   SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
----                                                             -------------------   -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
pwshenv01                                                        5/11/2022 2:31:25 AM  Lucas Yao (Wicresoft North America) User                    5/11/2022 2:31:25 AM     Lucas Yao (Wicresoft North America) User                         ml-rg-test
lightgbm-environment                                             5/5/2022 2:25:41 AM   Lucas Yao (Wicresoft North America) User                    5/5/2022 2:25:41 AM      Lucas Yao (Wicresoft North America) User                         ml-rg-test
env04                                                            5/5/2022 2:13:02 AM   Lucas Yao (Wicresoft North America) User                    5/5/2022 2:13:02 AM      Lucas Yao (Wicresoft North America) User                         ml-rg-test
env03                                                            5/5/2022 2:11:34 AM   Lucas Yao (Wicresoft North America) User                    5/5/2022 2:11:34 AM      Lucas Yao (Wicresoft North America) User                         ml-rg-test
env02                                                            5/5/2022 2:11:08 AM   Lucas Yao (Wicresoft North America) User                    5/5/2022 2:11:08 AM      Lucas Yao (Wicresoft North America) User                         ml-rg-test
env01                                                            5/5/2022 2:10:35 AM   Lucas Yao (Wicresoft North America) User                    5/5/2022 2:10:35 AM      Lucas Yao (Wicresoft North America) User                         ml-rg-test
docker-image-example                                             5/5/2022 1:57:13 AM   Lucas Yao (Wicresoft North America) User                    5/5/2022 1:57:13 AM      Lucas Yao (Wicresoft North America) User                         ml-rg-test
test                                                             5/5/2022 1:51:43 AM   Lucas Yao                           User                    5/5/2022 1:51:43 AM      Lucas Yao                           User                         ml-rg-test
AzureML-responsibleai-0.18-ubuntu20.04-py38-cpu                  5/18/2022 11:07:16 PM Microsoft                           User                    5/18/2022 11:07:16 PM    Microsoft                           User                         ml-rg-test
```

List all environment containers under a workspace

### Example 2: Gets a environment container by name
```powershell
Get-AzMLWorkspaceEnvironmentContainer  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name pwshenv01
```

```output
Name      SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
----      -------------------  -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
pwshenv01 5/11/2022 2:31:25 AM Lucas Yao (Wicresoft North America) User                    5/11/2022 2:31:25 AM     Lucas Yao (Wicresoft North America) User                         ml-rg-test
```

Gets a environment container by name

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
Parameter Sets: Get, List
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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
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
Parameter Sets: Get, List
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEnvironmentContainer

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IMachineLearningServicesIdentity>`: Identity Parameter
  - `[ComputeName <String>]`: Name of the Azure Machine Learning compute.
  - `[ConnectionName <String>]`: Friendly name of the workspace connection
  - `[DeploymentName <String>]`: Inference deployment identifier.
  - `[EndpointName <String>]`: Inference Endpoint name.
  - `[Id <String>]`: The name and identifier for the Job. This is case-sensitive.
  - `[Id1 <String>]`: Resource identity path
  - `[Location <String>]`: The location for which resource usage is queried.
  - `[Name <String>]`: Container name. This is case-sensitive.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection associated with the workspace
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[Version <String>]`: Version identifier. This is case-sensitive.
  - `[WorkspaceName <String>]`: Name of Azure Machine Learning workspace.

## RELATED LINKS

