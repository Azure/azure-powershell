---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version:
schema: 2.0.0
---

# New-AzSecurityAutomationActionObject

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### SecurityAutomationActionLogicApp (Default)
```
New-AzSecurityAutomationActionObject -LogicAppResourceId <String> -Uri <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SecurityAutomationActionEventHub
```
New-AzSecurityAutomationActionObject -EventHubResourceId <String> -ConnectionString <String>
 [-SasPolicyName <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SecurityAutomationActionWorkspace
```
New-AzSecurityAutomationActionObject -WorkspaceResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ConnectionString
The target Event Hub connection string

```yaml
Type: String
Parameter Sets: SecurityAutomationActionEventHub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventHubResourceId
The target Event Hub Azure Resource ID

```yaml
Type: String
Parameter Sets: SecurityAutomationActionEventHub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogicAppResourceId
The triggered Logic App Azure Resource ID.
This can also reside on other subscriptions, given that you have permissions to trigger the Logic App

```yaml
Type: String
Parameter Sets: SecurityAutomationActionLogicApp
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SasPolicyName
The target Event Hub SAS policy name

```yaml
Type: String
Parameter Sets: SecurityAutomationActionEventHub
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Uri
The Logic App trigger URI endpoint (it will not be included in any response)

```yaml
Type: String
Parameter Sets: SecurityAutomationActionLogicApp
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceResourceId
The fully qualified Log Analytics Workspace Azure Resource ID

```yaml
Type: String
Parameter Sets: SecurityAutomationActionWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Security.Models.Automations.PSSecurityAutomationAction

## NOTES

## RELATED LINKS
