---
external help file:
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.springcloud/new-azspringcloudtestkey
schema: 2.0.0
---

# New-AzSpringCloudTestKey

## SYNOPSIS
Regenerate a test key for a Service.

## SYNTAX

### RegenerateExpanded (Default)
```
New-AzSpringCloudTestKey -Name <String> -ResourceGroupName <String> -KeyType <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegenerateViaIdentityExpanded
```
New-AzSpringCloudTestKey -InputObject <ISpringCloudIdentity> -KeyType <String> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegenerateViaJsonFilePath
```
New-AzSpringCloudTestKey -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegenerateViaJsonString
```
New-AzSpringCloudTestKey -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Regenerate a test key for a Service.

## EXAMPLES

### Example 1: Regenerate a test key for a Service
```powershell
New-AzSpringCloudTestKey -ResourceGroupName SpringCloud-gp-junxi -Name springcloud-service -KeyType Primary
```

```output
Enabled PrimaryKey                                                       PrimaryTestEndpoint
------- ----------                                                       -------------------
True    **************************************************************** https://primary:***********************…
```

Regenerate a test key for a Service.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity
Parameter Sets: RegenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Regenerate operation

```yaml
Type: System.String
Parameter Sets: RegenerateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Regenerate operation

```yaml
Type: System.String
Parameter Sets: RegenerateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyType
Type of the test key

```yaml
Type: System.String
Parameter Sets: RegenerateExpanded, RegenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Service resource.

```yaml
Type: System.String
Parameter Sets: RegenerateExpanded, RegenerateViaJsonFilePath, RegenerateViaJsonString
Aliases:

Required: True
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
Parameter Sets: RegenerateExpanded, RegenerateViaJsonFilePath, RegenerateViaJsonString
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
Parameter Sets: RegenerateExpanded, RegenerateViaJsonFilePath, RegenerateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ITestKeys

## NOTES

## RELATED LINKS

