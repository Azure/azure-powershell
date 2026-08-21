---
external help file:
Module Name: Az.DisconnectedOperations
online version: https://learn.microsoft.com/powershell/module/az.disconnectedoperations/get-azdisconnectedoperationsdisconnectedoperation
schema: 2.0.0
---

# Get-AzDisconnectedOperationsDisconnectedOperation

## SYNOPSIS
Get a DisconnectedOperation

## SYNTAX

### List1 (Default)
```
Get-AzDisconnectedOperationsDisconnectedOperation [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDisconnectedOperationsDisconnectedOperation -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDisconnectedOperationsDisconnectedOperation -InputObject <IDisconnectedOperationsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDisconnectedOperationsDisconnectedOperation -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a DisconnectedOperation

## EXAMPLES

### Example 1: List all DisconnectedOperations resources in the current subscription
```powershell
Get-AzDisconnectedOperationsDisconnectedOperation
```

```output
Location    Name                    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
--------    ----                    ------------------- -------------------     ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus2euap "Resource-1"            07/16/2025 00:04:48 user1@outlook.com       User                    07/16/2025 00:04:48      user1@outlook.com                    User                         ResourceGroup-1
West US 3   "Resource-2"            05/19/2025 21:23:25 user1@outlook.com       User                    05/20/2025 06:09:56      user2@outlook.com9                   User                         ResourceGroup-2
westus3     "Resource-3"            07/22/2025 20:08:35 user2@outlook.com       User                    07/22/2025 20:08:35      user1@outlook.com                    User                         ResourceGroup-1
```

This command lists all the DisconnectedOperations resources in the current subscription.

### Example 2: Get a specific DisconnectedOperation by name and resource group
```powershell
Get-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2"
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

This command retrieves a specific DisconnectedOperation resource by its name and resource group.

### Example 3: GetViaIdentity for a specific DisconnectedOperation
```powershell
$disconnectedOperation = @{
  "ResourceGroupName" = "winfield-demo-rg-2";
  "Name" = "winfield-ps-test";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsDisconnectedOperation -InputObject $disconnectedOperation
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



### Example 4: List all DisconnectedOperations from a specific resource group
```powershell
Get-AzDisconnectedOperationsDisconnectedOperation -ResourceGroupName "ResourceGroup-1"
```

```output
Location    Name                    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
--------    ----                    ------------------- -------------------     ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus2euap "Resource-1"            07/16/2025 00:04:48 user1@outlook.com       User                    07/16/2025 00:04:48      user1@outlook.com                    User                         ResourceGroup-1
westus3     "Resource-3"            07/22/2025 20:08:35 user2@outlook.com       User                    07/22/2025 20:08:35      user1@outlook.com                    User                         ResourceGroup-1
```

This command lists all the DisconnectedOperations resources from the resource group `ResourceGroup-1`.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the resource

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

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation

## NOTES

## RELATED LINKS

