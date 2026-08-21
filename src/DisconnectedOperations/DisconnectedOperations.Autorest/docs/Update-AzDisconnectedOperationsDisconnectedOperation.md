---
external help file:
Module Name: Az.DisconnectedOperations
online version: https://learn.microsoft.com/powershell/module/az.disconnectedoperations/update-azdisconnectedoperationsdisconnectedoperation
schema: 2.0.0
---

# Update-AzDisconnectedOperationsDisconnectedOperation

## SYNOPSIS
Update a DisconnectedOperation

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDisconnectedOperationsDisconnectedOperation -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-BenefitPlanAzureHybridWindowsServerBenefit <String>]
 [-BenefitPlanWindowsServerVMCount <Int32>] [-BillingConfigurationAutoRenew <String>]
 [-ConnectionIntent <String>] [-CurrentCore <Int32>] [-CurrentPricingModel <String>] [-DeviceVersion <String>]
 [-RegistrationStatus <String>] [-Tag <Hashtable>] [-UpcomingCore <Int32>] [-UpcomingPricingModel <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDisconnectedOperationsDisconnectedOperation -InputObject <IDisconnectedOperationsIdentity>
 [-BenefitPlanAzureHybridWindowsServerBenefit <String>] [-BenefitPlanWindowsServerVMCount <Int32>]
 [-BillingConfigurationAutoRenew <String>] [-ConnectionIntent <String>] [-CurrentCore <Int32>]
 [-CurrentPricingModel <String>] [-DeviceVersion <String>] [-RegistrationStatus <String>] [-Tag <Hashtable>]
 [-UpcomingCore <Int32>] [-UpcomingPricingModel <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzDisconnectedOperationsDisconnectedOperation -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzDisconnectedOperationsDisconnectedOperation -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update a DisconnectedOperation

## EXAMPLES

### Example 1: Update a DisconnectedOperation by name and resource group
```powershell
Update-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -RegistrationStatus "Registered"
```

```output
BenefitPlanAzureHybridWindowsServerBenefit : Enabled
BenefitPlanWindowsServerVMCount            : 10
BillingConfigurationAutoRenew              : Disabled
BillingConfigurationBillingStatus          : Enabled
BillingModel                               : Capacity
ConnectionIntent                           : Disconnected
ConnectionStatus                           : Disconnected
CurrentCore                                : 8
CurrentEndDate                             : 03/01/2027 00:00:00
CurrentPricingModel                        : Annual
CurrentStartDate                           : 03/02/2026 00:00:00
DeviceVersion                              :
Id                                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test
Location                                   : eastus2euap
Name                                       : winfield-ps-test
ProvisioningState                          : Succeeded
RegistrationStatus                         : Registered
ResourceGroupName                          : winfield-demo-rg-2
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt                        : 03/02/2026 10:07:05
SystemDataCreatedBy                        : user1@outlook.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 03/03/2026 09:21:10
SystemDataLastModifiedBy                   : user1@outlook.com
SystemDataLastModifiedByType               : User
Tag                                        : {
                                             }
Type                                       : microsoft.edge/disconnectedoperations
UpcomingCore                               : 0
UpcomingEndDate                            :
UpcomingPricingModel                       :
UpcomingStartDate                          :
```

This command updates the DisconnectedOperation resource named `winfield-ps-test` in the resource group `winfield-demo-rg-2` to set the registration status to `Registered` using expanded parameters.

### Example 2: Update a DisconnectedOperation by json file path
```powershell
Update-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -JsonFilePath "path/to/jsonFiles/UpdateDisconnectedOperations.json"
```

```output
BenefitPlanAzureHybridWindowsServerBenefit : Enabled
BenefitPlanWindowsServerVMCount            : 10
BillingConfigurationAutoRenew              : Disabled
BillingConfigurationBillingStatus          : Enabled
BillingModel                               : Capacity
ConnectionIntent                           : Disconnected
ConnectionStatus                           : Disconnected
CurrentCore                                : 8
CurrentEndDate                             : 03/01/2027 00:00:00
CurrentPricingModel                        : Annual
CurrentStartDate                           : 03/02/2026 00:00:00
DeviceVersion                              :
Id                                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test
Location                                   : eastus2euap
Name                                       : winfield-ps-test
ProvisioningState                          : Succeeded
RegistrationStatus                         : Registered
ResourceGroupName                          : winfield-demo-rg-2
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt                        : 03/02/2026 10:07:05
SystemDataCreatedBy                        : user1@outlook.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 03/03/2026 09:21:10
SystemDataLastModifiedBy                   : user1@outlook.com
SystemDataLastModifiedByType               : User
Tag                                        : {
                                             }
Type                                       : microsoft.edge/disconnectedoperations
UpcomingCore                               : 0
UpcomingEndDate                            :
UpcomingPricingModel                       :
UpcomingStartDate                          :
```

This command updates the DisconnectedOperation resource named `winfield-ps-test` in the resource group `winfield-demo-rg-2` using the details provided in the specified JSON file.

### Example 3: Update a DisconnectedOperation by jsonString
```powershell
Update-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -JsonString '{"properties": {"registrationStatus": "Registered"}}'
```

```output
BenefitPlanAzureHybridWindowsServerBenefit : Enabled
BenefitPlanWindowsServerVMCount            : 10
BillingConfigurationAutoRenew              : Disabled
BillingConfigurationBillingStatus          : Enabled
BillingModel                               : Capacity
ConnectionIntent                           : Disconnected
ConnectionStatus                           : Disconnected
CurrentCore                                : 8
CurrentEndDate                             : 03/01/2027 00:00:00
CurrentPricingModel                        : Annual
CurrentStartDate                           : 03/02/2026 00:00:00
DeviceVersion                              :
Id                                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test
Location                                   : eastus2euap
Name                                       : winfield-ps-test
ProvisioningState                          : Succeeded
RegistrationStatus                         : Registered
ResourceGroupName                          : winfield-demo-rg-2
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt                        : 03/02/2026 10:07:05
SystemDataCreatedBy                        : user1@outlook.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 03/03/2026 09:21:10
SystemDataLastModifiedBy                   : user1@outlook.com
SystemDataLastModifiedByType               : User
Tag                                        : {
                                             }
Type                                       : microsoft.edge/disconnectedoperations
UpcomingCore                               : 0
UpcomingEndDate                            :
UpcomingPricingModel                       :
UpcomingStartDate                          :
```

This command updates the DisconnectedOperation resource named `winfield-ps-test` in the resource group `winfield-demo-rg-2` using the details provided in the specified JSON string.

### Example 4: Update a DisconnectedOperation by identity
```powershell
$disconnectedOperation = @{
  "ResourceGroupName" = "winfield-demo-rg-2";
  "DisconnectedOperationName" = "winfield-ps-test";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}

Update-AzDisconnectedOperationsDisconnectedOperation -InputObject $disconnectedOperation -RegistrationStatus "Registered"
```

```output
BenefitPlanAzureHybridWindowsServerBenefit : Enabled
BenefitPlanWindowsServerVMCount            : 10
BillingConfigurationAutoRenew              : Disabled
BillingConfigurationBillingStatus          : Enabled
BillingModel                               : Capacity
ConnectionIntent                           : Disconnected
ConnectionStatus                           : Disconnected
CurrentCore                                : 8
CurrentEndDate                             : 03/01/2027 00:00:00
CurrentPricingModel                        : Annual
CurrentStartDate                           : 03/02/2026 00:00:00
DeviceVersion                              :
Id                                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test
Location                                   : eastus2euap
Name                                       : winfield-ps-test
ProvisioningState                          : Succeeded
RegistrationStatus                         : Registered
ResourceGroupName                          : winfield-demo-rg-2
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt                        : 03/02/2026 10:07:05
SystemDataCreatedBy                        : user1@outlook.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 03/03/2026 09:21:10
SystemDataLastModifiedBy                   : user1@outlook.com
SystemDataLastModifiedByType               : User
Tag                                        : {
                                             }
Type                                       : microsoft.edge/disconnectedoperations
UpcomingCore                               : 0
UpcomingEndDate                            :
UpcomingPricingModel                       :
UpcomingStartDate                          :
```

This command updates the DisconnectedOperation resource identified by the provided identity to set the registration status to `Registered` using the InputObject and expanded parameters.

## PARAMETERS

### -BenefitPlanAzureHybridWindowsServerBenefit
Azure Hybrid Windows Server Benefit plan

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BenefitPlanWindowsServerVMCount
Number of Windows Server VMs to license under the Azure Hybrid Benefit plan

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BillingConfigurationAutoRenew
The auto renew setting

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionIntent
The connection intent

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CurrentCore
The number of cores

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CurrentPricingModel
The pricing model

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -DeviceVersion
The device version

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the resource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistrationStatus
The registration intent

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpcomingCore
The number of cores

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpcomingPricingModel
The pricing model

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation

## NOTES

## RELATED LINKS

