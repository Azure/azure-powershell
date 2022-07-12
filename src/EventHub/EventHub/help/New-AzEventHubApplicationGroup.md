---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventHub.dll-Help.xml
Module Name: Az.EventHub
online version:
schema: 2.0.0
---

# New-AzEventHubApplicationGroup

## SYNOPSIS
Creates a new application group within an eventhub namespace

## SYNTAX

```
New-AzEventHubApplicationGroup [-ResourceGroupName] <String> [-NamespaceName] <String> [-Name] <String>
 [-ClientAppGroupIdentifier] <String> [-IsEnabled]
 -ThrottlingPolicyConfig <PSEventHubThrottlingPolicyConfigAttributes[]>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new application group within an eventhub namespace with throttling policies enabled.

## EXAMPLES

### Example 1
```powershell
$policy1 = New-AzEventHubThrottlingPolicyConfig -Name policy1 -MetricId IncomingBytes -RateLimitThreshold 12345

$policy2 = New-AzEventHubThrottlingPolicyConfig -Name policy2 -MetricId IncomingMessages -RateLimitThreshold 23416

New-AzEventHubApplicationGroup -ResourceGroupName myresourcegroup -NamespaceName mynamespace -Name myappgroup `
-ClientAppGroupIdentifier SASKeyName=myauthkey -ThrottlingPolicyConfig $policy1, $policy2
```

Creates an application group with two throttling policies.

## PARAMETERS

### -ClientAppGroupIdentifier
The Unique identifier for application group.Supports SAS(SASKeyName=KeyName) or AAD(AADAppID=Guid)

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsEnabled
Determines if Application Group is allowed to create connection with namespace or not.
Once the isEnabled is set to false, all the existing connections of application group gets dropped and no new connections will be allowed

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Application Group Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NamespaceName
Namespace Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ThrottlingPolicyConfig
List of Throttling Policy Objects

```yaml
Type: Microsoft.Azure.Commands.EventHub.Models.PSEventHubThrottlingPolicyConfigAttributes[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String

### System.Management.Automation.SwitchParameter

### Microsoft.Azure.Commands.EventHub.Models.PSEventHubThrottlingPolicyConfigAttributes[]

## OUTPUTS

### Microsoft.Azure.Commands.EventHub.Models.PSEventHubApplicationGroupAttributes

## NOTES

## RELATED LINKS
