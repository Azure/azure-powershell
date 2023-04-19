---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/invoke-azmlworkspacediagnose
schema: 2.0.0
---

# Invoke-AzMLWorkspaceDiagnose

## SYNOPSIS
Diagnose workspace setup issue.

## SYNTAX

### DiagnoseExpanded (Default)
```
Invoke-AzMLWorkspaceDiagnose -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ApplicationInsightId <Hashtable>] [-ContainerRegistryId <Hashtable>] [-DnsResolution <Hashtable>]
 [-KeyVaultId <Hashtable>] [-Nsg <Hashtable>] [-Other <Hashtable>] [-ResourceLock <Hashtable>]
 [-StorageAccount <Hashtable>] [-Udr <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### DiagnoseViaIdentityExpanded
```
Invoke-AzMLWorkspaceDiagnose -InputObject <IMachineLearningServicesIdentity>
 [-ApplicationInsightId <Hashtable>] [-ContainerRegistryId <Hashtable>] [-DnsResolution <Hashtable>]
 [-KeyVaultId <Hashtable>] [-Nsg <Hashtable>] [-Other <Hashtable>] [-ResourceLock <Hashtable>]
 [-StorageAccount <Hashtable>] [-Udr <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Diagnose workspace setup issue.

## EXAMPLES

### Example 1: Diagnose workspace setup issue
```powershell
Invoke-AzMLWorkspaceDiagnose -ResourceGroupName ml-rg-test -Name mlworkspace-cli01 -ApplicationInsightId @{'key1'="/subscriptions/xxxx-xxxxx-xxxxxxxxx-xxxx/resourceGroups/ml-rg-test/providers/Microsoft.insights/components/xxxxxxxxxxx"}
```

```output
ValueApplicationInsightsResult : {}
ValueContainerRegistryResult   :
ValueDnsResolutionResult       :
ValueKeyVaultResult            :
ValueNetworkSecurityRuleResult :
ValueOtherResult               :
ValueResourceLockResult        :
ValueStorageAccountResult      :
ValueUserDefinedRouteResult    :
```

Diagnose workspace setup issue

### Example 2: Diagnose workspace setup issue by workspace object
```powershell
$workspace = Get-AzMLWorkspace -ResourceGroupName ml-rg-test -Name mlworkspace-cli01
Invoke-AzMLWorkspaceDiagnose -InputObject $workspace -ApplicationInsightId @{'key1'="/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.insights/components/xxxxxxxxxxxx"}
```

```output
ValueApplicationInsightsResult : {}
ValueContainerRegistryResult   :
ValueDnsResolutionResult       :
ValueKeyVaultResult            :
ValueNetworkSecurityRuleResult :
ValueOtherResult               :
ValueResourceLockResult        :
ValueStorageAccountResult      :
ValueUserDefinedRouteResult    :
```

Diagnose workspace setup issue by workspace object

## PARAMETERS

### -ApplicationInsightId
Setting for diagnosing dependent application insights

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -ContainerRegistryId
Setting for diagnosing dependent container registry

```yaml
Type: System.Collections.Hashtable
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

### -DnsResolution
Setting for diagnosing dns resolution

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

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
Parameter Sets: DiagnoseViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyVaultId
Setting for diagnosing dependent key vault

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Azure Machine Learning workspace.

```yaml
Type: System.String
Parameter Sets: DiagnoseExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -Nsg
Setting for diagnosing network security group

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Other
Setting for diagnosing unclassified category of problems

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
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
Parameter Sets: DiagnoseExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceLock
Setting for diagnosing resource lock

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccount
Setting for diagnosing dependent storage account

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
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
Type: System.String
Parameter Sets: DiagnoseExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Udr
Setting for diagnosing user defined routing

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDiagnoseResponseResultValue

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

