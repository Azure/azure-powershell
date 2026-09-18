---
external help file:
Module Name: Az.HealthDataAIServices
online version: https://learn.microsoft.com/powershell/module/az.healthdataaiservices/get-azdeidservice
schema: 2.0.0
---

# Get-AzDeidService

## SYNOPSIS
Get a DeidService

## SYNTAX

### List (Default)
```
Get-AzDeidService [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDeidService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDeidService -InputObject <IHealthDataAiServicesIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzDeidService -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a DeidService

## EXAMPLES

### Example 1: Get a De-identification Service resource by name
```powershell
Get-AzDeidService -Name azpwshDeidService1 -ResourceGroupName azpwsh-test-rg
```

```output
Id                           : /subscriptions/a49b70b4-60ee-4422-a7e2-3a5223f5fae4/resourceGroups/azpwsh-test-rg/providers/Microsoft.HealthDataAIServices/DeidServices/azpwshDeidService1
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus2
Name                         : azpwshDeidService1
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          : Enabled
ResourceGroupName            : azpwsh-test-rg
ServiceUrl                   : https://vebsefg7b9cackat.api.eus2001.deid.azure.com
SystemDataCreatedAt          : 10/21/2024 12:00:35 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/21/2024 12:00:35 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.healthdataaiservices/deidservices
```

Gets a De-identification Service by its name and the resource group it belongs to.

### Example 2: List all De-identification Service resources in a resource group
```powershell
Get-AzDeidService -ResourceGroupName azpwsh-test-rg
```

```output
Location Name               SystemDataCreatedAt    SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----               -------------------    -------------------     ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus2  azpwshDeidService1 10/21/2024 12:00:35 AM contoso@microsoft.com User                    10/21/2024 12:00:35 AM   contoso@microsoft.com  User                         azpwsh-test-rg
eastus2  azpwshDeidService2 10/21/2024 12:01:06 AM contoso@microsoft.com User                    10/21/2024 12:01:06 AM   contoso@microsoft.com  User                         azpwsh-test-rg
```

Lists all De-identification Service resources in the specified resource group.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthDataAIServices.Models.IHealthDataAiServicesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the deid service

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DeidServiceName

Required: True
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
Parameter Sets: Get, List1
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
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.HealthDataAIServices.Models.IHealthDataAiServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HealthDataAIServices.Models.IDeidService

## NOTES

## RELATED LINKS

