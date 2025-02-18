---
external help file:
Module Name: Az.HealthDataAIServices
online version: https://learn.microsoft.com/powershell/module/az.healthdataaiservices/new-azdeidservice
schema: 2.0.0
---

# New-AzDeidService

## SYNOPSIS
create a DeidService

## SYNTAX

### CreateExpanded (Default)
```
New-AzDeidService -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-EnableSystemAssignedIdentity] [-PublicNetworkAccess <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDeidService -Name <String> -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDeidService -Name <String> -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
create a DeidService

## EXAMPLES

### Example 1: Create a new De-identification Service resource
```powershell
New-AzDeidService -Name myHealthDeidService -ResourceGroupName azpwsh-test-rg -Location eastus2 -EnableSystemAssignedIdentity -PublicNetworkAccess "Disabled"
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
SystemDataLastModifiedAt     : 10/21/2024 5:26:15 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.healthdataaiservices/deidservices
```

Creates a new De-identification Service resource in the specified resource group and location.

### Example 2: Create a new De-identification Service resource from a JSON file
```powershell
New-AzDeidService -Name myHealthDeidService -ResourceGroupName azpwsh-test-rg -JsonFilePath path/to/json.json
```

```output
Id                           : /subscriptions/a49b70b4-60ee-4422-a7e2-3a5223f5fae4/resourceGroups/azpwsh-test-rg/providers/Microsoft.HealthDataAIServices/deidServices/myHealthDeidService
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
SystemDataLastModifiedAt     : 10/21/2024 5:26:15 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.healthdataaiservices/deidservices
```

Creates a new De-identification Service resource with location and properties specified in the JSON file.

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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the deid service

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HealthDataAIServices.Models.IDeidService

## NOTES

## RELATED LINKS

