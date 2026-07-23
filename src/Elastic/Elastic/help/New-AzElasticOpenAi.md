---
external help file: Az.Elastic-help.xml
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/new-azelasticopenai
schema: 2.0.0
---

# New-AzElasticOpenAi

## SYNOPSIS
Create an OpenAI integration rule for a given Elastic monitor resource, enabling advanced AI-driven observability and monitoring.

## SYNTAX

### CreateExpanded (Default)
```
New-AzElasticOpenAi -IntegrationName <String> -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Key <String>] [-OpenAiConnectorId <String>] [-OpenAiResourceEndpoint <String>]
 [-OpenAiResourceId <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzElasticOpenAi -IntegrationName <String> -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzElasticOpenAi -IntegrationName <String> -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityMonitorExpanded
```
New-AzElasticOpenAi -IntegrationName <String> -MonitorInputObject <IElasticIdentity> [-Key <String>]
 [-OpenAiConnectorId <String>] [-OpenAiResourceEndpoint <String>] [-OpenAiResourceId <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzElasticOpenAi -InputObject <IElasticIdentity> [-Key <String>] [-OpenAiConnectorId <String>]
 [-OpenAiResourceEndpoint <String>] [-OpenAiResourceId <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create an OpenAI integration rule for a given Elastic monitor resource, enabling advanced AI-driven observability and monitoring.

## EXAMPLES

### Example 1: Create or update a OpenAI integration rule for a given monitor resource.
```powershell
New-AzElasticOpenAi -IntegrationName default -ResourceGroupName elastic-rg-3eytki -MonitorName elastic-rhqz1v
```

```output
IntegrationName              Status            ResourceGroupName
------------------          ---------          -----------------
default                      Active            elastic-rg-3eytki
```

This command Creates or updates a OpenAI integration rule for a given monitor resource.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IntegrationName
OpenAI Integration name

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityMonitorExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Key
Value of API key for Open AI resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
Parameter Sets: CreateViaIdentityMonitorExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OpenAiConnectorId
The connector id of Open AI resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OpenAiResourceEndpoint
The API endpoint for Open AI resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OpenAiResourceId
The resource name of Open AI resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IOpenAiIntegrationRpmodel

## NOTES

## RELATED LINKS
