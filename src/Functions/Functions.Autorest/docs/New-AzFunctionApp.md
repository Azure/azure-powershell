---
external help file:
Module Name: Az.Functions
online version: https://learn.microsoft.com/powershell/module/az.functions/new-azfunctionapp
schema: 2.0.0
---

# New-AzFunctionApp

## SYNOPSIS
Creates a function app.

## SYNTAX

### Consumption (Default)
```
New-AzFunctionApp -Location <String> -Name <String> -ResourceGroupName <String> -Runtime <String>
 -StorageAccountName <String> [-ApplicationInsightsKey <String>] [-ApplicationInsightsName <String>]
 [-AppSetting <Hashtable>] [-DisableApplicationInsights] [-FunctionsVersion <String>] [-IdentityID <String[]>]
 [-IdentityType <ManagedServiceIdentityType>] [-OSType <String>] [-PassThru] [-RuntimeVersion <String>]
 [-SubscriptionId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ByAppServicePlan
```
New-AzFunctionApp -Name <String> -PlanName <String> -ResourceGroupName <String> -Runtime <String>
 -StorageAccountName <String> [-ApplicationInsightsKey <String>] [-ApplicationInsightsName <String>]
 [-AppSetting <Hashtable>] [-DisableApplicationInsights] [-FunctionsVersion <String>] [-IdentityID <String[]>]
 [-IdentityType <ManagedServiceIdentityType>] [-OSType <String>] [-PassThru] [-RuntimeVersion <String>]
 [-SubscriptionId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CustomDockerImage
```
New-AzFunctionApp -Image <String> -Name <String> -PlanName <String> -ResourceGroupName <String>
 -StorageAccountName <String> [-ApplicationInsightsKey <String>] [-ApplicationInsightsName <String>]
 [-AppSetting <Hashtable>] [-DisableApplicationInsights] [-IdentityID <String[]>]
 [-IdentityType <ManagedServiceIdentityType>] [-PassThru] [-RegistryCredential <PSCredential>]
 [-SubscriptionId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### EnvironmentForContainerApp
```
New-AzFunctionApp -Environment <String> -Name <String> -ResourceGroupName <String>
 -StorageAccountName <String> [-ApplicationInsightsKey <String>] [-ApplicationInsightsName <String>]
 [-AppSetting <Hashtable>] [-DisableApplicationInsights] [-IdentityID <String[]>]
 [-IdentityType <ManagedServiceIdentityType>] [-Image <String>] [-PassThru]
 [-RegistryCredential <PSCredential>] [-RegistryServer <String>] [-ResourceCpu <Double>]
 [-ResourceMemory <String>] [-ScaleMaxReplica <Int32>] [-ScaleMinReplica <Int32>] [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-WorkloadProfileName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a function app.

## EXAMPLES

### Example 1: Create a consumption PowerShell function app in Central US.
```powershell
New-AzFunctionApp -Name MyUniqueFunctionAppName `
                  -ResourceGroupName MyResourceGroupName `
                  -Location centralUS `
                  -StorageAccountName MyStorageAccountName `
                  -Runtime PowerShell
```

This command creates a consumption PowerShell function app in Central US.

### Example 2: Create a PowerShell function app which will be hosted in a service plan.
```powershell
New-AzFunctionApp -Name MyUniqueFunctionAppName `
                  -ResourceGroupName MyResourceGroupName `
                  -PlanName MyPlanName `
                  -StorageAccountName MyStorageAccountName `
                  -Runtime PowerShell
```

This command creates a PowerShell function app which will be hosted in a service plan.

### Example 3: Create a function app using a using a private ACR image.
```powershell
New-AzFunctionApp -Name MyUniqueFunctionAppName `
                  -ResourceGroupName MyResourceGroupName `
                  -PlanName MyPlanName `
                  -StorageAccountName MyStorageAccountName `
                  -DockerImageName myacr.azurecr.io/myimage:tag
```

This command creates a function app using a using a private ACR image.

### Example 4: Create a function app on container app.
```powershell
New-AzFunctionApp -Name MyUniqueFunctionAppName `
                  -ResourceGroupName MyResourceGroupName `
                  -StorageAccountName MyStorageAccountName `
                  -Environment MyEnvironment `
                  -WorkloadProfileName MyWorkloadProfileName
```

This command create a function app on container app using the default .Net image.

## PARAMETERS

### -ApplicationInsightsKey
Instrumentation key of App Insights to be added.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AppInsightsKey

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationInsightsName
Name of the existing App Insights project to be added to the function app.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AppInsightsName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppSetting
Function app settings.

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
Runs the cmdlet as a background job.

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

### -DisableApplicationInsights
Disable creating application insights resource during the function app creation.
No logs will be available.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: DisableAppInsights

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Environment
Name of the container app environment.

```yaml
Type: System.String
Parameter Sets: EnvironmentForContainerApp
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FunctionsVersion
The Functions version.

```yaml
Type: System.String
Parameter Sets: ByAppServicePlan, Consumption
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityID
Specifies the list of user identities associated with the function app.
            The user identity references will be ARM resource ids in the form:
            '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/identities/{identityName}'

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Specifies the type of identity used for the function app.
            The acceptable values for this parameter are:
            - SystemAssigned
            - UserAssigned

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Image
Container image name, e.g., publisher/image-name:tag.

```yaml
Type: System.String
Parameter Sets: CustomDockerImage, EnvironmentForContainerApp
Aliases: DockerImageName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location for the consumption plan.

```yaml
Type: System.String
Parameter Sets: Consumption
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the function app.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Starts the operation and returns immediately, before the operation is completed.
In order to determine if the operation has successfully been completed, use some other mechanism.

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

### -OSType
The OS to host the function app.

```yaml
Type: System.String
Parameter Sets: ByAppServicePlan, Consumption
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds.

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

### -PlanName
The name of the service plan.

```yaml
Type: System.String
Parameter Sets: ByAppServicePlan, CustomDockerImage
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryCredential
The container registry username and password.
Required for private registries.

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: CustomDockerImage, EnvironmentForContainerApp
Aliases: DockerRegistryCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryServer
The container registry server hostname, e.g.
myregistry.azurecr.io.

```yaml
Type: System.String
Parameter Sets: EnvironmentForContainerApp
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceCpu
The CPU in cores of the container app.
e.g., 0.75.

```yaml
Type: System.Double
Parameter Sets: EnvironmentForContainerApp
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceMemory
The memory size of the container app.
e.g., 1.0Gi.

```yaml
Type: System.String
Parameter Sets: EnvironmentForContainerApp
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Runtime
The function runtime.

```yaml
Type: System.String
Parameter Sets: ByAppServicePlan, Consumption
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuntimeVersion
The function runtime.

```yaml
Type: System.String
Parameter Sets: ByAppServicePlan, Consumption
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleMaxReplica
The maximum number of replicas when creating a function app on container app.

```yaml
Type: System.Int32
Parameter Sets: EnvironmentForContainerApp
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleMinReplica
The minimum number of replicas when create function app on container app.

```yaml
Type: System.Int32
Parameter Sets: EnvironmentForContainerApp
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountName
The name of the storage account.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

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

### -WorkloadProfileName
The workload profile name to run the container app on.

```yaml
Type: System.String
Parameter Sets: EnvironmentForContainerApp
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ISite

## NOTES

## RELATED LINKS

