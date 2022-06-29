---
external help file:
Module Name: Az.MachineLearningServices
online version: https://docs.microsoft.com/powershell/module/az.machinelearningservices/get-azmlworkspaceonlinedeploymentlog
schema: 2.0.0
---

# Get-AzMLWorkspaceOnlineDeploymentLog

## SYNOPSIS
Polls an Endpoint operation.

## SYNTAX

```
Get-AzMLWorkspaceOnlineDeploymentLog -EndpointName <String> -Name <String> -ResourceGroupName <String>
 -WorkspaceName <String> [-SubscriptionId <String[]>] [-ContainerType <ContainerType>] [-Tail <Int32>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Polls an Endpoint operation.

## EXAMPLES

### Example 1: Gets online deployment log
```powershell
Get-AzMLWorkspaceOnlineDeploymentLog -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName online-cli01 -Name blue
```

```output
Instance status:
SystemSetup: Succeeded
UserContainerImagePull: Succeeded
ModelDownload: Succeeded
UserContainerStart: Succeeded

Container events:
Kind: Pod, Name: Pulling, Type: Normal, Time: 20220519-03:11:59.750675, Message: Start pulling container image
Kind: Pod, Name: Pulling, Type: Normal, Time: 20220519-03:11:59.843068, Message: Start downloading models
Kind: Pod, Name: Pulled, Type: Normal, Time: 20220519-03:12:54.679466, Message: Container image is pulled successfully
Kind: Pod, Name: Downloaded, Type: Normal, Time: 20220519-03:12:54.679466, Message: Models are downloaded successfully or no model need to download
Kind: Pod, Name: Created, Type: Normal, Time: 20220519-03:12:54.798575, Message: Created container inference-server
Kind: Pod, Name: Started, Type: Normal, Time: 20220519-03:12:54.921722, Message: Started container inference-server
```

Gets online deployment log

## PARAMETERS

### -ContainerType
The type of container to retrieve logs from.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ContainerType
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

### -EndpointName
Inference endpoint name.

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

### -Name
The name and identifier for the endpoint.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tail
The maximum number of lines to tail.

```yaml
Type: System.Int32
Parameter Sets: (All)
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
Parameter Sets: (All)
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

## OUTPUTS

### System.String

## NOTES

ALIASES

## RELATED LINKS

