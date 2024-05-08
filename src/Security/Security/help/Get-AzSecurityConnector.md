---
external help file: Az.Security-help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/get-azsecurityconnector
schema: 2.0.0
---

# Get-AzSecurityConnector

## SYNOPSIS
Retrieves details of a specific security connector

## SYNTAX

### List (Default)
```
Get-AzSecurityConnector [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzSecurityConnector -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzSecurityConnector -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSecurityConnector -InputObject <ISecurityIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Retrieves details of a specific security connector

## EXAMPLES

### Example 1: Get Security Connector resource by name
```powershell
Get-AzSecurityConnector -ResourceGroupName "dfdtest-sdk" -Name "dfdsdktests-azdo-01"
```

```output
EnvironmentData                 : {
                                    "environmentType": "AzureDevOpsScope"
                                  }
EnvironmentName                 : AzureDevOps
Etag                            : 
HierarchyIdentifier             : 4a8eb7f1-f533-48c5-b102-9b09e90906b7
HierarchyIdentifierTrialEndDate : 
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourcegroups/dfdtest-sdk/providers/Microsoft.Security/securityConnectors/dfdsdktests-azdo-01
Kind                            : 
Location                        : centralus
Name                            : dfdsdktests-azdo-01
Offering                        : {{
                                    "offeringType": "CspmMonitorAzureDevOps"
                                  }}
ResourceGroupName               : dfdtest-sdk
SystemDataCreatedAt             : 12/7/2023 6:38:36 AM
SystemDataCreatedBy             : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataCreatedByType         : Application
SystemDataLastModifiedAt        : 2/14/2024 2:11:46 AM
SystemDataLastModifiedBy        : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataLastModifiedByType    : Application
Tag                             : {}
Type                            : Microsoft.Security/securityconnectors
```

### Example 2: List Security Connectors by subscription
```powershell
Get-AzSecurityConnector
```

```output
Name                ResourceGroupName        EnvironmentName Location  HierarchyIdentifier
----                -----------------        --------------- --------  -------------------
dfdsdktests-azdo-01 dfdtest-sdk              AzureDevOps     centralus 4a8eb7f1-f533-48c5-b102-9b09e90906b7
dfdsdktests-gl-01   dfdtest-sdk              GitLab          centralus 7a1f4efe-f8c6-48e7-b7ef-1b45994ed602
dfdsdktests-gh-01   dfdtest-sdk              Github          centralus bc12ba4d-b89c-486e-85e1-d803e7d80525
aws-sdktest01       securityconnectors-tests AWS             CentralUS 891376984375
gcp-sdktest01       securityconnectors-tests GCP             CentralUS 843025268399
```

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The security connector name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: SecurityConnectorName

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

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure subscription ID

```yaml
Type: System.String[]
Parameter Sets: List, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityConnector

## NOTES

## RELATED LINKS
