---
external help file:
Module Name: Az.HealthDataAIServices
online version: https://learn.microsoft.com/powershell/module/az.healthdataaiservices/update-azdeidservice
schema: 2.0.0
---

# Update-AzDeidService

## SYNOPSIS
update a DeidService

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDeidService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-EnableSystemAssignedIdentity <Boolean?>] [-PublicNetworkAccess <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDeidService -InputObject <IHealthDataAiServicesIdentity> [-EnableSystemAssignedIdentity <Boolean?>]
 [-PublicNetworkAccess <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
update a DeidService

## EXAMPLES

### Example 1: Update a De-identification service to create a System Assigned Managed Identity
```powershell
Update-AzDeidService -Name myHealthDeidService -ResourceGroupName azpwsh-test-rg -EnableSystemAssignedIdentity $true
```

```output
Id                           : /subscriptions/a49b70b4-60ee-4422-a7e2-3a5223f5fae4/resourceGroups/azpwsh-test-rg/providers/Microsoft.HealthDataAIServices/deidServices/myHealthDeidService
IdentityPrincipalId          : efab95dd-6969-4c43-bd96-4126dc372bfa
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus2
Name                         : myHealthDeidService
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          : Disabled
ResourceGroupName            : azpwsh-test-rg
ServiceUrl                   : https://h8bxaqamerbxd9a7.api.eus2001.deid.azure.com
SystemDataCreatedAt          : 10/21/2024 5:26:15 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/21/2024 6:56:12 PM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.healthdataaiservices/deidservices
```

Updates an existing De-identification service to create a System Assigned Managed Identity.

### Example 2: Update the public network access and tags of a De-identification service
```powershell
Update-AzDeidService -Name azpwshDeidService2 -ResourceGroupName azpwsh-test-rg -EnableSystemAssignedIdentity $false -PublicNetworkAccess "Enabled" -Tag @{ AzPwshTestKey = "AzPwshTestValue" }
```

```output
Id                           : /subscriptions/a49b70b4-60ee-4422-a7e2-3a5223f5fae4/resourceGroups/azpwsh-test-rg/providers/Microsoft.HealthDataAIServices/DeidServices/azpwshDeidService2
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus2
Name                         : azpwshDeidService2
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          : Enabled
ResourceGroupName            : azpwsh-test-rg
ServiceUrl                   : https://f4cag7feawaubgbv.api.eus2001.deid.azure.com
SystemDataCreatedAt          : 10/21/2024 12:01:06 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/21/2024 5:43:35 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "AzPwshTestKey": "AzPwshTestValue"
                               }
Type                         : microsoft.healthdataaiservices/deidservices
```

Update a De-identification Service by enabling public network access, removing the System Assigned Managed Identity and adding tags.

## PARAMETERS

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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthDataAIServices.Models.IHealthDataAiServicesIdentity
Parameter Sets: UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded
Aliases: DeidServiceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -PublicNetworkAccess
Gets or sets allow or disallow public network access to resource

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

### -ResourceGroupName
The name of the resource group.
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
The ID of the target subscription.
The value must be an UUID.

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
Resource tags.

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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.HealthDataAIServices.Models.IHealthDataAiServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HealthDataAIServices.Models.IDeidService

## NOTES

## RELATED LINKS

