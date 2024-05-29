---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/test-azspringcontainerregistry
schema: 2.0.0
---

# Test-AzSpringContainerRegistry

## SYNOPSIS
Check if the container registry properties are valid.

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzSpringContainerRegistry -Name <String> -ResourceGroupName <String> -ServiceName <String>
 -Credentials <IContainerRegistryCredentials> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaJsonFilePath
```
Test-AzSpringContainerRegistry -Name <String> -ResourceGroupName <String> -ServiceName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateViaJsonString
```
Test-AzSpringContainerRegistry -Name <String> -ResourceGroupName <String> -ServiceName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Check if the container registry properties are valid.

## EXAMPLES

### Example 1: Check if the container registry properties are valid.
```powershell
$containerRegistryObj = New-AzSpringContainerRegistryCredentialObject -Password "ibOL0******887K" -Server azpsacr.azurecr.io -Username azpsacr
Test-AzSpringContainerRegistry -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name default -ContainerRegistryProperty $containerRegistryObj
```

```output
IsValid Message
------- -------
  False credential cannot be null.:
```

Check if the container registry properties are valid.

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

### -Credentials
The credentials of the container registry resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IContainerRegistryCredentials
Parameter Sets: ValidateExpanded
Aliases:

Required: True
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

### -JsonFilePath
Path of Json file supplied to the Validate operation

```yaml
Type: System.String
Parameter Sets: ValidateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Validate operation

```yaml
Type: System.String
Parameter Sets: ValidateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the container registry.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ContainerRegistryName

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The name of the Service resource.

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
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IContainerRegistryValidateResult

## NOTES

## RELATED LINKS

