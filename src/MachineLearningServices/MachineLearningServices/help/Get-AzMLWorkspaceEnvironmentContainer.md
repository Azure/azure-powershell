---
external help file: Az.MachineLearningServices-help.xml
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
Get-AzMLWorkspaceEnvironmentContainer -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-ListViewType <String>] [-Skip <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityWorkspace
```
Get-AzMLWorkspaceEnvironmentContainer -Name <String> -WorkspaceInputObject <IMachineLearningServicesIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMLWorkspaceEnvironmentContainer -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
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
Get-AzMLWorkspaceEnvironmentContainer -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2
```

```output
Name                                                SystemDataCreatedAt  SystemDataCreatedBy                     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----                                                -------------------  -------------------                     ----------------------- ------------------------ ------------------------          
DefaultNcdEnv-mlflow-ubuntu20-04-py38-cpu-inference 11/4/2025 9:30:32 AM 11111111-2222-3333-4444-123456789102    Application             11/4/2025 9:30:32 AM     11111111-2222-3333-4444-123456789102
commandjobenv1                                      11/4/2025 6:18:47 AM User Name (Example)                     User                    11/4/2025 6:18:47 AM     UserName (Example)
batchenv1                                           11/4/2025 6:18:41 AM User Name (Example)                     User                    11/4/2025 6:18:41 AM     UserName (Example)
openmpi4_1_0-ubuntu22_04                            11/4/2025 6:02:17 AM User Name (Example)                     User                    11/4/2025 6:02:17 AM     UserName (Example)
AzureML-ACPT-pytorch-1.13-py38-cuda11.7-gpu         1/24/2023 2:27:55 AM Microsoft                               User                    1/24/2023 2:27:55 AM     Microsoft
```

List all environment containers under a workspace

### Example 2: Gets a environment container by name
```powershell
Get-AzMLWorkspaceEnvironmentContainer -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name openmpi4_1_0-ubuntu22_04
```

```output
Description                  : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/environments/openmpi4_1_0-ubuntu22_04
IsArchived                   : False
LatestVersion                : 1
Name                         : openmpi4_1_0-ubuntu22_04
NextVersion                  : 2
ProvisioningState            : Succeeded
ResourceBaseProperty         : {
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/4/2025 6:02:17 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/4/2025 6:02:17 AM
SystemDataLastModifiedBy     : User Name (Example)
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.MachineLearningServices/workspaces/environments
XmsAsyncOperationTimeout     :
```

Gets a environment container by name

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
Type: System.String
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
Parameter Sets: GetViaIdentityWorkspace, Get
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

### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
Parameter Sets: GetViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IEnvironmentContainer

## NOTES

## RELATED LINKS
