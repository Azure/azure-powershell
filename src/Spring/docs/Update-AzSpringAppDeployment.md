---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/az.spring/update-azspringappdeployment
schema: 2.0.0
---

# Update-AzSpringAppDeployment

## SYNOPSIS
Operation to update an exiting Deployment.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSpringAppDeployment -AppName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> [-SubscriptionId <String>] [-Active] [-AddonConfig <Hashtable>]
 [-EnvironmentVariable <Hashtable>] [-ResourceRequestCpu <String>] [-ResourceRequestMemory <String>]
 [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>] [-Source <IUserSourceInfo>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityApp
```
Update-AzSpringAppDeployment -AppInputObject <ISpringIdentity> -Name <String>
 -DeploymentResource <IDeploymentResource> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityAppExpanded
```
Update-AzSpringAppDeployment -AppInputObject <ISpringIdentity> -Name <String> [-Active]
 [-AddonConfig <Hashtable>] [-EnvironmentVariable <Hashtable>] [-ResourceRequestCpu <String>]
 [-ResourceRequestMemory <String>] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>]
 [-Source <IUserSourceInfo>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSpringAppDeployment -InputObject <ISpringIdentity> [-Active] [-AddonConfig <Hashtable>]
 [-EnvironmentVariable <Hashtable>] [-ResourceRequestCpu <String>] [-ResourceRequestMemory <String>]
 [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>] [-Source <IUserSourceInfo>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentitySpring
```
Update-AzSpringAppDeployment -AppName <String> -Name <String> -SpringInputObject <ISpringIdentity>
 -DeploymentResource <IDeploymentResource> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentitySpringExpanded
```
Update-AzSpringAppDeployment -AppName <String> -Name <String> -SpringInputObject <ISpringIdentity> [-Active]
 [-AddonConfig <Hashtable>] [-EnvironmentVariable <Hashtable>] [-ResourceRequestCpu <String>]
 [-ResourceRequestMemory <String>] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>]
 [-Source <IUserSourceInfo>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzSpringAppDeployment -AppName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzSpringAppDeployment -AppName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Operation to update an exiting Deployment.

## EXAMPLES

### Example 1: Operation to update an exiting Deployment
```powershell
Update-AzSpringAppDeployment -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -AppName tools -Name default
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/1 3:41:45    *********@microsoft.com User                    2022/7/1 3:49:11         **********@microso…
```

Operation to update an exiting Deployment.

### Example 2: Operation to update an exiting Deployment by pipeline
```powershell
Get-AzSpringAppDeployment -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -AppName tools -Name default | Update-AzSpringAppDeployment
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/1 3:41:45    *********@microsoft.com User                    2022/7/1 3:49:11         **********@microso…
```

Operation to update an exiting Deployment by pipeline.

## PARAMETERS

### -Active
Indicates whether the Deployment is active

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddonConfig
Collection of addons

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppInputObject
Identity Parameter
To construct, see NOTES section for APPINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity
Parameter Sets: UpdateViaIdentityApp, UpdateViaIdentityAppExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AppName
The name of the App resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentitySpring, UpdateViaIdentitySpringExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
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

### -DeploymentResource
Deployment resource payload
To construct, see NOTES section for DEPLOYMENTRESOURCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.IDeploymentResource
Parameter Sets: UpdateViaIdentityApp, UpdateViaIdentitySpring
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EnvironmentVariable
Collection of environment variables

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Deployment resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityApp, UpdateViaIdentityAppExpanded, UpdateViaIdentitySpring, UpdateViaIdentitySpringExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: DeploymentName

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

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceRequestCpu
Required CPU.
1 core can be represented by 1 or 1000m.
This should be 500m or 1 for Basic tier, and {500m, 1, 2, 3, 4} for Standard tier.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceRequestMemory
Required memory.
1 GB can be represented by 1Gi or 1024Mi.
This should be {512Mi, 1Gi, 2Gi} for Basic tier, and {512Mi, 1Gi, 2Gi, ..., 8Gi} for Standard tier.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The name of the Service resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
Current capacity of the target resource

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the Sku

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
Tier of the Sku

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Source
Uploaded source information of the deployment.
To construct, see NOTES section for SOURCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.IUserSourceInfo
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpringInputObject
Identity Parameter
To construct, see NOTES section for SPRINGINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity
Parameter Sets: UpdateViaIdentitySpring, UpdateViaIdentitySpringExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.IDeploymentResource

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.IDeploymentResource

## NOTES

## RELATED LINKS

