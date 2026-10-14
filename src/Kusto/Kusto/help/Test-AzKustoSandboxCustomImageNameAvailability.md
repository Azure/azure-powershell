---
external help file: Az.Kusto-help.xml
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/test-azkustosandboxcustomimagenameavailability
schema: 2.0.0
---

# Test-AzKustoSandboxCustomImageNameAvailability

## SYNOPSIS
Checks that the sandbox custom image resource name is valid and is not already in use.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzKustoSandboxCustomImageNameAvailability -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Name <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaJsonString
```
Test-AzKustoSandboxCustomImageNameAvailability -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaJsonFilePath
```
Test-AzKustoSandboxCustomImageNameAvailability -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzKustoSandboxCustomImageNameAvailability -InputObject <IKustoIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Checks that the sandbox custom image resource name is valid and is not already in use.

## EXAMPLES

### Example 1: Check the availability of a sandbox custom image name in a cluster
```powershell
Test-AzKustoSandboxCustomImageNameAvailability -ClusterName "myCluster" -ResourceGroupName "myResourceGroup" -Name "myImage"
```

```output
Message Name      NameAvailable Reason
------- ----      ------------- ------
        testimage True
```

The above command returns whether or not a sandbox custom image named "myImage" exists in the cluster named "myCluster".

## PARAMETERS

### -ClusterName
The name of the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaJsonString, CheckViaJsonFilePath
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
Parameter Sets: CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Sandbox custom image resource name.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
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
Parameter Sets: CheckExpanded, CheckViaJsonString, CheckViaJsonFilePath
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
Parameter Sets: CheckExpanded, CheckViaJsonString, CheckViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.ICheckNameResult

## NOTES

## RELATED LINKS
