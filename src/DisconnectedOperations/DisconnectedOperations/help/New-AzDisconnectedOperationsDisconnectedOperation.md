---
external help file: Az.DisconnectedOperations-help.xml
Module Name: Az.DisconnectedOperations
online version: https://learn.microsoft.com/powershell/module/az.disconnectedoperations/new-azdisconnectedoperationsdisconnectedoperation
schema: 2.0.0
---

# New-AzDisconnectedOperationsDisconnectedOperation

## SYNOPSIS
Create a DisconnectedOperation

## SYNTAX

### CreateExpanded (Default)
```
New-AzDisconnectedOperationsDisconnectedOperation -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Location <String> [-BenefitPlanAzureHybridWindowsServerBenefit <String>]
 [-BenefitPlanWindowsServerVMCount <Int32>] [-BillingConfigurationAutoRenew <String>]
 [-ConnectionIntent <String>] [-CurrentCore <Int32>] [-CurrentPricingModel <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDisconnectedOperationsDisconnectedOperation -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDisconnectedOperationsDisconnectedOperation -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a DisconnectedOperation

## EXAMPLES

### Example 1: Create a new DisconnectedOperation with expanded parameters
```powershell
New-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -ConnectionIntent "Disconnected" -BillingConfigurationAutoRenew "Disabled" -CurrentCore 8 -CurrentPricingModel "Annual" -BenefitPlanAzureHybridWindowsServerBenefit "Enabled" -BenefitPlanWindowsServerVMCount 10 -Location "eastus2euap" -Tag @{}
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
RegistrationStatus                         : Unregistered
ResourceGroupName                          : winfield-demo-rg-2
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt                        : 03/02/2026 10:07:05
SystemDataCreatedBy                        : user1@outlook.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 03/02/2026 10:07:05
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

This command creates a new DisconnectedOperation resource named "winfield-ps-test" in the resource group "winfield-demo-rg-2" located in "eastus2euap" with expanded parameters.

### Example 2: Create a DisconnectedOperation using a JSON file path
```powershell
New-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -JsonFilePath "path/to/jsonFiles/CreateDisconnectedOperations.json"
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
RegistrationStatus                         : Unregistered
ResourceGroupName                          : winfield-demo-rg-2
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt                        : 03/02/2026 10:07:05
SystemDataCreatedBy                        : user1@outlook.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 03/02/2026 10:07:05
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

This command creates a DisconnectedOperation resource using the configuration specified in the JSON file located at "path/to/jsonFiles/CreateDisconnectedOperations.json".

### Example 3: Create a DisconnectedOperation using a JSON string
```powershell
New-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test-2" -ResourceGroupName "winfield-demo-rg-2" -JsonString '{"properties":{"connectionIntent":"Disconnected","billingModel":"Capacity","billingConfiguration":{"autoRenew":"Disabled","current":{"cores":8,"pricingModel":"Annual"},"upcoming":{"cores":8,"pricingModel":"Annual"}},"benefitPlans":{"azureHybridWindowsServerBenefit":"Enabled","windowsServerVmCount":10}},"tags":{},"location":"eastus2euap"}'
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
Id                                         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test-2
Location                                   : eastus2euap
Name                                       : winfield-ps-test-2
ProvisioningState                          : Succeeded
RegistrationStatus                         : Unregistered
ResourceGroupName                          : winfield-demo-rg-2
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt                        : 03/02/2026 09:59:40
SystemDataCreatedBy                        : user1@outlook.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 03/02/2026 09:59:40
SystemDataLastModifiedBy                   : user1@outlook.com
SystemDataLastModifiedByType               : User
Tag                                        : {
                                             }
Type                                       : microsoft.edge/disconnectedoperations
UpcomingCore                               : 8
UpcomingEndDate                            : 03/01/2028 00:00:00
UpcomingPricingModel                       : Annual
UpcomingStartDate                          : 03/02/2027 00:00:00
```

This command creates a DisconnectedOperation resource using the configuration specified in the provided JSON string.

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

### -BenefitPlanAzureHybridWindowsServerBenefit
Azure Hybrid Windows Server Benefit plan

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

### -BenefitPlanWindowsServerVMCount
Number of Windows Server VMs to license under the Azure Hybrid Benefit plan

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Name of the resource

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

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation

## NOTES

## RELATED LINKS
