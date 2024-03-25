---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/invoke-azsecurityapicollectionapimonboard
schema: 2.0.0
---

# Invoke-AzSecurityApiCollectionApimOnboard

## SYNOPSIS
Onboard an Azure API Management API to Microsoft Defender for APIs.
The system will start monitoring the operations within the Azure Management API for intrusive behaviors and provide alerts for attacks that have been detected.

## SYNTAX

### Azure (Default)
```
Invoke-AzSecurityApiCollectionApimOnboard -ApiId <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### AzureViaIdentity
```
Invoke-AzSecurityApiCollectionApimOnboard -InputObject <ISecurityIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Onboard an Azure API Management API to Microsoft Defender for APIs.
The system will start monitoring the operations within the Azure Management API for intrusive behaviors and provide alerts for attacks that have been detected.

## EXAMPLES

### Example 1: Onboard an Azure API Management API to Microsoft Defender for APIs.
```powershell
Invoke-AzSecurityApiCollectionApimOnboard -ResourceGroupName "apicollectionstests" -ServiceName "demoapimservice2" -ApiId "echo-api-2"
```

```output
BaseUrl                                      : https://demoapimservice2.azure-api.net
DiscoveredVia                                : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/apicollectionstests/providers/Microsoft.ApiManagement/service/demoapimservice2
DisplayName                                  : Echo API 2
Id                                           : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/apicollectionstests/providers/Microsoft.ApiManagement/service/demoapimservice2/providers/Microsoft.Security/apiCollections/ech 
                                               o-api-2
Name                                         : echo-api-2
NumberOfApiEndpoint                          : 0
NumberOfApiEndpointsWithSensitiveDataExposed : 0
NumberOfExternalApiEndpoint                  : 0
NumberOfInactiveApiEndpoint                  : 0
NumberOfUnauthenticatedApiEndpoint           : 0
ProvisioningState                            : Succeeded
ResourceGroupName                            : apicollectionstests
SensitivityLabel                             : 
Type                                         : microsoft.security/apicollections
```



## PARAMETERS

### -ApiId
API revision identifier.
Must be unique in the API Management service instance.
Non-current revision has ;rev=n as a suffix where n is the revision number.

```yaml
Type: System.String
Parameter Sets: Azure
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityIdentity
Parameter Sets: AzureViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Azure
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The name of the API Management service.

```yaml
Type: System.String
Parameter Sets: Azure
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
Parameter Sets: Azure
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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IApiCollection

## NOTES

## RELATED LINKS

