---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/new-azsecurityautomationactionobject
schema: 2.0.0
---

# New-AzSecurityAutomationActionObject

## SYNOPSIS
Creates new security automation action object

## SYNTAX

### SecurityAutomationActionLogicApp (Default)
```
New-AzSecurityAutomationActionObject -LogicAppResourceId <String> -Uri <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### SecurityAutomationActionEventHub
```
New-AzSecurityAutomationActionObject -EventHubResourceId <String> -ConnectionString <String>
 [-SasPolicyName <String>] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### SecurityAutomationActionWorkspace
```
New-AzSecurityAutomationActionObject -WorkspaceResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Creates new security automation action object

## EXAMPLES

### Example 1
```powershell
New-AzSecurityAutomationActionObject -WorkspaceResourceId '/subscriptions/64ac75e7-15ff-4963-8c07-a16016505e0f/resourceGroups/sampleResourceGroup/providers/Microsoft.OperationalInsights/workspaces/surashed-test'
```

Creates new security automation action with workspace type

### Example 2
```powershell
New-AzSecurityAutomationActionObject -LogicAppResourceId '/subscriptions/03b601f1-7eca-4496-8f8d-355219eee254/resourceGroups/sampleResourceGroup/providers/Microsoft.Logic/workflows/LA' -Uri 'https://dummy.com/'
```

Creates new security automation action with logicApp type

### Example 3
```powershell
New-AzSecurityAutomationActionObject -EventHubResourceId 'subscriptions/03b601f1-7eca-4496-8f8d-355219eee254/resourceGroups/sampleResourceGroup/providers/Microsoft.EventHub/namespaces/cus-wsp-fake-assessment/eventhubs/cus-wsp-fake-assessment' -ConnectionString 'Endpoint=sb://dummy/;SharedAccessKeyName=dummy;SharedAccessKey=dummy;EntityPath=dummy'
```

Creates new security automation action with even-hub type

## PARAMETERS

### -ConnectionString
The target Event Hub connection string

```yaml
Type: System.String
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
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
Type: System.String
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
Type: System.String
Parameter Sets: SecurityAutomationActionLogicApp
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SasPolicyName
The target Event Hub SAS policy name

```yaml
Type: System.String
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
Type: System.String
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
Type: System.String
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
