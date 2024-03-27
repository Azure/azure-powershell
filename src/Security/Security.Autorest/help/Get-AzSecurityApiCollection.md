---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/get-azsecurityapicollection
schema: 2.0.0
---

# Get-AzSecurityApiCollection

## SYNOPSIS
Gets an Azure API Management API if it has been onboarded to Microsoft Defender for APIs.
If an Azure API Management API is onboarded to Microsoft Defender for APIs, the system will monitor the operations within the Azure API Management API for intrusive behaviors and provide alerts for attacks that have been detected.

## SYNTAX

### List (Default)
```
Get-AzSecurityApiCollection [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSecurityApiCollection -ApiId <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSecurityApiCollection -InputObject <ISecurityIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzSecurityApiCollection -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzSecurityApiCollection -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets an Azure API Management API if it has been onboarded to Microsoft Defender for APIs.
If an Azure API Management API is onboarded to Microsoft Defender for APIs, the system will monitor the operations within the Azure API Management API for intrusive behaviors and provide alerts for attacks that have been detected.

## EXAMPLES

### Example 1: Get a specific onboarded api collection resource
```powershell
Get-AzSecurityApiCollection -ResourceGroupName apicollectionstests -ServiceName "demoapimservice2" -ApiId "echo-api"
```

```output
BaseUrl                                      : https://demoapimservice2.azure-api.net/echo
DiscoveredVia                                : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/apicollectionstests/providers/Microsoft.ApiManagement/service/demoapim
                                               service2
DisplayName                                  : Echo API
Id                                           : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/apicollectionstests/providers/Microsoft.ApiManagement/service/demoapim
                                               service2/providers/Microsoft.Security/apiCollections/echo-api
Name                                         : echo-api
NumberOfApiEndpoint                          : 6
NumberOfApiEndpointsWithSensitiveDataExposed : 0
NumberOfExternalApiEndpoint                  : 0
NumberOfInactiveApiEndpoint                  : 6
NumberOfUnauthenticatedApiEndpoint           : 0
ProvisioningState                            : Succeeded
ResourceGroupName                            : apicollectionstests
SensitivityLabel                             :
Type                                         : microsoft.security/apicollections
```



### Example 2: List onboarded api collections by service name
```powershell
Get-AzSecurityApiCollection -ResourceGroupName "apicollectionstests" -ServiceName "demoapimservice2"
```

```output
Name       ResourceGroupName
----       -----------------
echo-api   apicollectionstests
echo-api-2 apicollectionstests
```



### Example 3: List onboarded api collections by subscription
```powershell
Get-AzSecurityApiCollection
```

```output
Name       ResourceGroupName
----       -----------------
echo-api   apicollectionstests
echo-api-2 apicollectionstests
```



## PARAMETERS

### -ApiId
API revision identifier.
Must be unique in the API Management service instance.
Non-current revision has ;rev=n as a suffix where n is the revision number.

```yaml
Type: System.String
Parameter Sets: Get
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityIdentity
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
Parameter Sets: Get, List1, List2
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
Parameter Sets: Get, List2
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
Parameter Sets: Get, List, List1, List2
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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IApiCollection

## NOTES

## RELATED LINKS

