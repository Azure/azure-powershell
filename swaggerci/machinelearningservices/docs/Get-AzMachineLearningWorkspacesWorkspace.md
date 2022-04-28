---
external help file:
Module Name: Az.MachineLearningWorkspaces
online version: https://docs.microsoft.com/en-us/powershell/module/az.machinelearningworkspaces/get-azmachinelearningworkspacesworkspace
schema: 2.0.0
---

# Get-AzMachineLearningWorkspacesWorkspace

## SYNOPSIS
Gets the properties of the specified machine learning workspace.

## SYNTAX

### List1 (Default)
```
Get-AzMachineLearningWorkspacesWorkspace [-SubscriptionId <String[]>] [-Skip <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMachineLearningWorkspacesWorkspace -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMachineLearningWorkspacesWorkspace -InputObject <IMachineLearningWorkspacesIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzMachineLearningWorkspacesWorkspace -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Skip <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the properties of the specified machine learning workspace.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Models.IMachineLearningWorkspacesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of Azure Machine Learning workspace.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: WorkspaceName

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
Parameter Sets: List, List1
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
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Models.IMachineLearningWorkspacesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Models.Api20210701.IWorkspace

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IMachineLearningWorkspacesIdentity>: Identity Parameter
  - `[ComputeName <String>]`: Name of the Azure Machine Learning compute.
  - `[ConnectionName <String>]`: Friendly name of the workspace connection
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The location for which resource usage is queried.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection associated with the workspace
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[WorkspaceName <String>]`: Name of Azure Machine Learning workspace.

## RELATED LINKS

