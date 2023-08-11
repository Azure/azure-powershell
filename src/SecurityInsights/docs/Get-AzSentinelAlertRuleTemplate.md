---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/get-azsentinelalertruletemplate
schema: 2.0.0
---

# Get-AzSentinelAlertRuleTemplate

## SYNOPSIS
Gets the alert rule template.

## SYNTAX

### List (Default)
```
Get-AzSentinelAlertRuleTemplate -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSentinelAlertRuleTemplate -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSentinelAlertRuleTemplate -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityWorkspace
```
Get-AzSentinelAlertRuleTemplate -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the alert rule template.

## EXAMPLES

### Example 1: List all Alert Rule Templates
```powershell
Get-AzSentinelAlertRuleTemplate -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws"
```

```output
Kind      Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLast 
                                                                                                                                                                 ModifiedByType 
----      ----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ -------------- 
Scheduled 46ac55ae-47b8-414a-8f94-89ccd1962178
Scheduled 155f40c6-610d-497d-85fc-3cf06ec13256
Scheduled 4d94d4a9-dc96-450a-9dea-4d4d4594199b
Scheduled 050b9b3d-53d0-4364-a3da-1b678b8211ec
Scheduled c094384d-7ea7-4091-83be-18706ecca981
Scheduled dc99e38c-f4e9-4837-94d7-353ac0b01a77
Scheduled 8955c0fb-3408-47b0-a3b9-a1faec41e427
Scheduled f041e01d-840d-43da-95c8-4188f6cef546
Scheduled 6e95aef3-a1e0-4063-8e74-cd59aa59f245
Scheduled 009b9bae-23dd-43c4-bcb9-11c4ba7c784a
Scheduled e4779bdc-397a-4b71-be28-59e6a1e1d16b
Scheduled 85aca4d1-5d15-4001-abd9-acb86ca1786a
Scheduled 572e75ef-5147-49d9-9d65-13f2ed1e3a86
Scheduled 194dd92e-d6e7-4249-85a5-273350a7f5ce
Scheduled c37711a4-5f44-4472-8afc-0679bc0ef966
Scheduled 6b652b4f-9810-4eec-9027-7aa88ce4db23
Scheduled f0be259a-34ac-4946-aa15-ca2b115d5feb
Scheduled 95a15f39-d9cc-4667-8cdd-58f3113691c9
Scheduled 5f171045-88ab-4634-baae-a7b6509f483b
Scheduled 7cb8f77d-c52f-4e46-b82f-3cf2e106224a
Scheduled 7b907bf7-77d4-41d0-a208-5643ff75bf9a
Scheduled d7feb859-f03e-4e8d-8b21-617be0213b13
Scheduled 15049017-527f-4d3b-b011-b0e99e68ef45
Scheduled 75ea5c39-93e5-489b-b1e1-68fa6c9d2d04

AlertRulesCreatedByTemplateCount : 0
CreatedDateUtc                   : 7/16/2019 12:00:00 AM
Description                      : Create incidents based on all alerts generated in Microsoft Defender for Cloud
DisplayName                      : Create incidents based on Microsoft Defender for Cloud
DisplayNamesExcludeFilter        : 
DisplayNamesFilter               : 
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/ 
                                   providers/Microsoft.SecurityInsights/AlertRuleTemplates/90586451-7ba8-4c1e-9904-7d1b7c3cc4d6
Kind                             : MicrosoftSecurityIncidentCreation
LastUpdatedDateUtc               : 7/25/2021 12:00:00 AM
Name                             : 90586451-7ba8-4c1e-9904-7d1b7c3cc4d6
ProductFilter                    : Azure Security Center
RequiredDataConnector            : {{
                                     "connectorId": "AzureSecurityCenter",
                                     "dataTypes": [ "SecurityAlert (ASC)" ]
                                   }}
SeveritiesFilter                 : {Low, Medium, High}
Status                           : Available
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
Type                             : Microsoft.SecurityInsights/AlertRuleTemplates

Scheduled 32555639-b639-4c2b-afda-c0ae0abefa55
Scheduled 066395ac-ef91-4993-8bf6-25c61ab0ca5a
Scheduled bfb1c90f-8006-4325-98be-c7fffbc254d6
Scheduled 0625fcce-6d52-491e-8c68-1d9b801d25b9
Scheduled 26a3b261-b997-4374-94ea-6c37f67f4f39
Scheduled a0907abe-6925-4d90-af2b-c7e89dc201a6
Scheduled acc4c247-aaf7-494b-b5da-17f18863878a
Scheduled 9122a9cb-916b-4d98-a199-1b7b0af8d598
Scheduled 22a320c2-e1e5-4c74-a35b-39fc9cdcf859
Scheduled d2bc08fa-030a-4eea-931a-762d27c6a042
Scheduled c2da1106-bfe4-4a63-bf14-5ab73130ccd5
Scheduled 50eb4cbd-188f-44f4-b964-bab84dcdec10
Scheduled feb0a2fb-ae75-4343-8cbc-ed545f1da289
Scheduled d9938c3b-16f9-444d-bc22-ea9a9110e0fd
Scheduled 01f64465-b1ef-41ea-a7f5-31553a11ad43
Scheduled 9fb57e58-3ed8-4b89-afcf-c8e786508b1c
Scheduled e2559891-383c-4caf-ae67-55a008b9f89e
Scheduled 2b701288-b428-4fb8-805e-e4372c574786
Scheduled c9b6d281-b96b-4763-b728-9a04b9fe1246
Scheduled 572f3951-5fa3-4e42-9640-fe194d859419
Scheduled 3a9d5ede-2b9d-43a2-acc4-d272321ff77c
Scheduled aa1eff90-29d4-49dc-a3ea-b65199f516db
Scheduled 3fbc20a4-04c4-464e-8fcb-6667f53e4987
Scheduled d82eb796-d1eb-43c8-a813-325ce3417cef
Scheduled 3fe3c520-04f1-44b8-8398-782ed21435f8
Scheduled af435ca1-fb70-4de1-92c1-7435c48482a9
Scheduled 3edb7215-250b-40c0-8b46-79093949242d
Scheduled d0aa8969-1bbe-4da3-9e76-09e5f67c9d85
Scheduled 5dd76a87-9f87-4576-bab3-268b0e2b338b
Scheduled 84cf1d59-f620-4fee-b569-68daf7008b7b
Scheduled 011c84d8-85f0-4370-b864-24c13455aa94
Scheduled 7ee72a9e-2e54-459c-bc8a-8c08a6532a63
Scheduled 30c8b802-ace1-4408-bc29-4c5c5afb49e1
Scheduled 97ad74c4-fdd9-4a3f-b6bf-5e28f4f71e06
Scheduled a04cf847-a832-4c60-b687-b0b6147da219
Scheduled 677da133-e487-4108-a150-5b926591a92b
Scheduled 643c2025-9604-47c5-833f-7b4b9378a1f5
Scheduled 84cccc86-5c11-4b3a-aca6-7c8f738ed0f7
Scheduled 90d3f6ec-80fb-48e0-9937-2c70c9df9bad
Scheduled 3bd33158-3f0b-47e3-a50f-7c20a1b88038
Scheduled 8dcf7238-a7d0-4cfd-8d0c-b230e3cd9182
Scheduled 8c2ef238-67a0-497d-b1dd-5c8a0f533e25
Scheduled 01e8ffff-dc0c-43fe-aa22-d459c4204553

AlertRulesCreatedByTemplateCount : 0
CreatedDateUtc                   : 7/16/2019 12:00:00 AM
Description                      : Create incidents based on all alerts generated in Microsoft Defender for Identity
DisplayName                      : Create incidents based on Microsoft Defender for Identity alerts
DisplayNamesExcludeFilter        : 
DisplayNamesFilter               : 
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/ 
                                   providers/Microsoft.SecurityInsights/AlertRuleTemplates/40ba9493-4183-4eee-974f-87fe39c8f267
Kind                             : MicrosoftSecurityIncidentCreation
LastUpdatedDateUtc               : 7/16/2019 12:00:00 AM
Name                             : 40ba9493-4183-4eee-974f-87fe39c8f267
ProductFilter                    : Azure Advanced Threat Protection
RequiredDataConnector            : {{
                                     "connectorId": "AzureAdvancedThreatProtection",
                                     "dataTypes": [ "SecurityAlert (AATP)" ]
                                   }}
SeveritiesFilter                 : 
Status                           : Available
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
Type                             : Microsoft.SecurityInsights/AlertRuleTemplates

Scheduled f6a51e2c-2d6a-4f92-a090-cfb002ca611f
Scheduled 56f3f35c-3aca-4437-a1fb-b7a84dc4af00
Scheduled 2fc5d810-c9cc-491a-b564-841427ae0e50
Scheduled 5239248b-abfb-4c6a-8177-b104ade5db56
Scheduled 0433c8a3-9aa6-4577-beef-2ea23be41137
Scheduled d3980830-dd9d-40a5-911f-76b44dfdce16
Scheduled a7b9df32-1367-402d-b385-882daf6e3020
Scheduled f2eb15bd-8a88-4b24-9281-e133edfba315
Scheduled a3c144f9-8051-47d4-ac29-ffb0c312c910
Scheduled 6dd2629c-534b-4275-8201-d7968b4fa77e
Scheduled 957cb240-f45d-4491-9ba5-93430a3c08be
Scheduled 44a555d8-ecee-4a25-95ce-055879b4b14b

AlertRulesCreatedByTemplateCount : 0
CreatedDateUtc                   : 7/16/2019 12:00:00 AM
Description                      : Create incidents based on all alerts generated in Microsoft Defender for Cloud Apps
DisplayName                      : Create incidents based on Microsoft Cloud App Security alerts
DisplayNamesExcludeFilter        : 
DisplayNamesFilter               : 
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/ 
                                   providers/Microsoft.SecurityInsights/AlertRuleTemplates/b3cfc7c0-092c-481c-a55b-34a3979758cb
Kind                             : MicrosoftSecurityIncidentCreation
LastUpdatedDateUtc               : 7/16/2019 12:00:00 AM
Name                             : b3cfc7c0-092c-481c-a55b-34a3979758cb
ProductFilter                    : Microsoft Cloud App Security
RequiredDataConnector            : {{
                                     "connectorId": "MicrosoftCloudAppSecurity",
                                     "dataTypes": [ "SecurityAlert (MCAS)" ]
                                   }}
SeveritiesFilter                 : 
Status                           : Available
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
Type                             : Microsoft.SecurityInsights/AlertRuleTemplates
```

This command lists all Alert Rule Templates under a Microsoft Sentinel workspace.

### Example 2: Get an Alert Rule Template
```powershell
Get-AzSentinelAlertRuleTemplate -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Id "532c1811-79ee-4d9f-8d4d-6304c840daa1"
```

```output
AlertRulesCreatedByTemplateCount : 0
CreatedDateUtc                   : 7/16/2019 12:00:00 AM
Description                      : Create incidents based on all alerts generated in Azure Active Directory Identity Protection
DisplayName                      : Create incidents based on Azure Active Directory Identity Protection alerts
DisplayNamesExcludeFilter        : 
DisplayNamesFilter               : 
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/ 
                                   providers/Microsoft.SecurityInsights/AlertRuleTemplates/532c1811-79ee-4d9f-8d4d-6304c840daa1
Kind                             : MicrosoftSecurityIncidentCreation
LastUpdatedDateUtc               : 7/16/2019 12:00:00 AM
Name                             : 532c1811-79ee-4d9f-8d4d-6304c840daa1
ProductFilter                    : Azure Active Directory Identity Protection
RequiredDataConnector            : {{
                                     "connectorId": "AzureActiveDirectoryIdentityProtection",
                                     "dataTypes": [ "SecurityAlert (IPC)" ]
                                   }}
SeveritiesFilter                 : 
Status                           : Available
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
Type                             : Microsoft.SecurityInsights/AlertRuleTemplates
```

This command gets an Alert Rule Template.

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

### -Id
Alert rule template ID

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityWorkspace
Aliases: AlertRuleTemplateId, TemplateId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter
To construct, see NOTES section for WORKSPACEINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: GetViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IAlertRuleTemplate

## NOTES

## RELATED LINKS

