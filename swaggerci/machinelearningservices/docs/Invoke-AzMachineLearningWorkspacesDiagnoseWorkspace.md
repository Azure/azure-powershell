---
external help file:
Module Name: Az.MachineLearningWorkspaces
online version: https://docs.microsoft.com/en-us/powershell/module/az.machinelearningworkspaces/invoke-azmachinelearningworkspacesdiagnoseworkspace
schema: 2.0.0
---

# Invoke-AzMachineLearningWorkspacesDiagnoseWorkspace

## SYNOPSIS
Diagnose workspace setup issue.

## SYNTAX

### DiagnoseExpanded (Default)
```
Invoke-AzMachineLearningWorkspacesDiagnoseWorkspace -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-ValueApplicationInsight <Hashtable>] [-ValueContainerRegistry <Hashtable>]
 [-ValueDnsResolution <Hashtable>] [-ValueKeyVault <Hashtable>] [-ValueNsg <Hashtable>]
 [-ValueOthers <Hashtable>] [-ValueResourceLock <Hashtable>] [-ValueStorageAccount <Hashtable>]
 [-ValueUdr <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Diagnose
```
Invoke-AzMachineLearningWorkspacesDiagnoseWorkspace -ResourceGroupName <String> -WorkspaceName <String>
 -Parameter <IDiagnoseWorkspaceParameters> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DiagnoseViaIdentity
```
Invoke-AzMachineLearningWorkspacesDiagnoseWorkspace -InputObject <IMachineLearningWorkspacesIdentity>
 -Parameter <IDiagnoseWorkspaceParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### DiagnoseViaIdentityExpanded
```
Invoke-AzMachineLearningWorkspacesDiagnoseWorkspace -InputObject <IMachineLearningWorkspacesIdentity>
 [-ValueApplicationInsight <Hashtable>] [-ValueContainerRegistry <Hashtable>]
 [-ValueDnsResolution <Hashtable>] [-ValueKeyVault <Hashtable>] [-ValueNsg <Hashtable>]
 [-ValueOthers <Hashtable>] [-ValueResourceLock <Hashtable>] [-ValueStorageAccount <Hashtable>]
 [-ValueUdr <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Diagnose workspace setup issue.

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

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Models.IMachineLearningWorkspacesIdentity
Parameter Sets: DiagnoseViaIdentity, DiagnoseViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Parameters to diagnose a workspace
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Models.Api20210701.IDiagnoseWorkspaceParameters
Parameter Sets: Diagnose, DiagnoseViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Diagnose, DiagnoseExpanded
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
Type: System.String
Parameter Sets: Diagnose, DiagnoseExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValueApplicationInsight
Setting for diagnosing dependent application insights

```yaml
Type: System.Collections.Hashtable
Parameter Sets: DiagnoseExpanded, DiagnoseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValueContainerRegistry
Setting for diagnosing dependent container registry

```yaml
Type: System.Collections.Hashtable
Parameter Sets: DiagnoseExpanded, DiagnoseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValueDnsResolution
Setting for diagnosing dns resolution

```yaml
Type: System.Collections.Hashtable
Parameter Sets: DiagnoseExpanded, DiagnoseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValueKeyVault
Setting for diagnosing dependent key vault

```yaml
Type: System.Collections.Hashtable
Parameter Sets: DiagnoseExpanded, DiagnoseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValueNsg
Setting for diagnosing network security group

```yaml
Type: System.Collections.Hashtable
Parameter Sets: DiagnoseExpanded, DiagnoseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValueOthers
Setting for diagnosing unclassified category of problems

```yaml
Type: System.Collections.Hashtable
Parameter Sets: DiagnoseExpanded, DiagnoseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValueResourceLock
Setting for diagnosing resource lock

```yaml
Type: System.Collections.Hashtable
Parameter Sets: DiagnoseExpanded, DiagnoseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValueStorageAccount
Setting for diagnosing dependent storage account

```yaml
Type: System.Collections.Hashtable
Parameter Sets: DiagnoseExpanded, DiagnoseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValueUdr
Setting for diagnosing user defined routing

```yaml
Type: System.Collections.Hashtable
Parameter Sets: DiagnoseExpanded, DiagnoseViaIdentityExpanded
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
Parameter Sets: Diagnose, DiagnoseExpanded
Aliases:

Required: True
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Models.Api20210701.IDiagnoseWorkspaceParameters

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Models.IMachineLearningWorkspacesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Models.Api20210701.IDiagnoseResponseResultValue

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

PARAMETER <IDiagnoseWorkspaceParameters>: Parameters to diagnose a workspace
  - `[ValueApplicationInsight <IDiagnoseRequestPropertiesApplicationInsights>]`: Setting for diagnosing dependent application insights
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ValueContainerRegistry <IDiagnoseRequestPropertiesContainerRegistry>]`: Setting for diagnosing dependent container registry
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ValueDnsResolution <IDiagnoseRequestPropertiesDnsResolution>]`: Setting for diagnosing dns resolution
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ValueKeyVault <IDiagnoseRequestPropertiesKeyVault>]`: Setting for diagnosing dependent key vault
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ValueNsg <IDiagnoseRequestPropertiesNsg>]`: Setting for diagnosing network security group
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ValueOthers <IDiagnoseRequestPropertiesOthers>]`: Setting for diagnosing unclassified category of problems
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ValueResourceLock <IDiagnoseRequestPropertiesResourceLock>]`: Setting for diagnosing resource lock
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ValueStorageAccount <IDiagnoseRequestPropertiesStorageAccount>]`: Setting for diagnosing dependent storage account
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ValueUdr <IDiagnoseRequestPropertiesUdr>]`: Setting for diagnosing user defined routing
    - `[(Any) <Object>]`: This indicates any property can be added to this object.

## RELATED LINKS

