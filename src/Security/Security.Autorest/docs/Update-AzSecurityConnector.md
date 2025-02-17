---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/update-azsecurityconnector
schema: 2.0.0
---

# Update-AzSecurityConnector

## SYNOPSIS
Update a security connector

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSecurityConnector -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-EnvironmentData <ISecurityConnectorEnvironment>] [-EnvironmentName <String>] [-Etag <String>]
 [-HierarchyIdentifier <String>] [-Kind <String>] [-Location <String>] [-Offering <ICloudOffering[]>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSecurityConnector -InputObject <ISecurityIdentity> [-EnvironmentData <ISecurityConnectorEnvironment>]
 [-EnvironmentName <String>] [-Etag <String>] [-HierarchyIdentifier <String>] [-Kind <String>]
 [-Location <String>] [-Offering <ICloudOffering[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a security connector

## EXAMPLES

### Example 1: Update security connector
```powershell
Update-AzSecurityConnector -ResourceGroupName "securityConnectors-pwsh-tmp" -Name "ado-sdk-pwsh-test03" -Tag @{myTag="v1"}
```

```output
EnvironmentData                 : {
                                    "environmentType": "AzureDevOpsScope"
                                  }
EnvironmentName                 : AzureDevOps
Etag                            : 
HierarchyIdentifier             : 9dd01e19-8aaf-43a2-8dd4-1c5992f4df35
HierarchyIdentifierTrialEndDate : 
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourcegroups/securityconnectors-pwsh-tmp/providers/Microsoft.Security/securityConnectors/ado-sdk-pwsh-test03
Kind                            : 
Location                        : CentralUS
Name                            : ado-sdk-pwsh-test03
Offering                        : {{
                                    "offeringType": "CspmMonitorAzureDevOps"
                                  }}
ResourceGroupName               : securityconnectors-pwsh-tmp
SystemDataCreatedAt             : 2/24/2024 12:13:11 AM
SystemDataCreatedBy             : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataCreatedByType         : Application
SystemDataLastModifiedAt        : 2/24/2024 12:24:02 AM
SystemDataLastModifiedBy        : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataLastModifiedByType    : Application
Tag                             : {
                                    "myTag": "v1"
                                  }
Type                            : Microsoft.Security/securityconnectors
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

### -EnvironmentData
The security connector environment data.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityConnectorEnvironment
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentName
The multi cloud resource's cloud name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Etag
Entity tag is used for comparing two or more entities from the same requested resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HierarchyIdentifier
The multi cloud resource identifier (account id in case of AWS connector, project number in case of GCP connector).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kind
Kind of the resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location where the resource is stored

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The security connector name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: SecurityConnectorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Offering
A collection of offerings for the security connector.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ICloudOffering[]
Parameter Sets: (All)
Aliases:

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
Parameter Sets: UpdateExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
A list of key value pairs that describe the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityConnector

## NOTES

## RELATED LINKS

