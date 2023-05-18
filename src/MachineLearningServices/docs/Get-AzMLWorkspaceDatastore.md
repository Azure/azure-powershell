---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/get-azmlworkspacedatastore
schema: 2.0.0
---

# Get-AzMLWorkspaceDatastore

## SYNOPSIS
Get datastore.

## SYNTAX

### List (Default)
```
Get-AzMLWorkspaceDatastore -ResourceGroupName <String> -WorkspaceName <String> [-SubscriptionId <String[]>]
 [-Count <Int32>] [-IsDefault] [-OrderBy <String>] [-OrderByAsc] [-SearchName <String[]>]
 [-SearchText <String>] [-Skip <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMLWorkspaceDatastore -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMLWorkspaceDatastore -InputObject <IMachineLearningServicesIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get datastore.

## EXAMPLES

### Example 1: Lists all datastore under a workspace
```powershell
Get-AzMLWorkspaceDatastore  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01
```

```output
Name                      SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
----                      ------------------- -------------------                  ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
workspaceartifactstore    5/5/2022 1:27:41 AM 779301c0-18b2-4cdc-801b-a0a3368fee0a Application             5/5/2022 1:27:42 AM      779301c0-18b2-4cdc-801b-a0a3368fee0a Application                  ml-rg-test
workspaceworkingdirectory 5/5/2022 1:27:41 AM 779301c0-18b2-4cdc-801b-a0a3368fee0a Application             5/5/2022 1:27:42 AM      779301c0-18b2-4cdc-801b-a0a3368fee0a Application                  ml-rg-test
workspaceblobstore        5/5/2022 1:27:41 AM 779301c0-18b2-4cdc-801b-a0a3368fee0a Application             5/5/2022 1:27:42 AM      779301c0-18b2-4cdc-801b-a0a3368fee0a Application                  ml-rg-test
workspacefilestore        5/5/2022 1:27:41 AM 779301c0-18b2-4cdc-801b-a0a3368fee0a Application             5/5/2022 1:27:42 AM      779301c0-18b2-4cdc-801b-a0a3368fee0a Application                  ml-rg-test
```

Lists all datastore under a workspace

### Example 2: Get a datastore by name
```powershell
Get-AzMLWorkspaceDatastore  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name workspaceartifactstore
```

```output
Name                   SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
----                   ------------------- -------------------                  ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
workspaceartifactstore 5/5/2022 1:27:41 AM 779301c0-18b2-4cdc-801b-a0a3368fee0a Application             5/5/2022 1:27:42 AM      779301c0-18b2-4cdc-801b-a0a3368fee0a Application                  ml-rg-test
```

Get a datastore by name

## PARAMETERS

### -Count
Maximum number of results to return.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -IsDefault
Filter down to the workspace default datastore.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Datastore name.

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

### -OrderBy
Order by property (createdtime | modifiedtime | name).

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

### -OrderByAsc
Order by property in ascending order.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SearchName
Names of datastores to return.

```yaml
Type: System.String[]
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SearchText
Text to search for in the datastore names.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDatastore

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

