---
external help file:
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/az.connectedmachine/get-azconnectedlicenseprofile
schema: 2.0.0
---

# Get-AzConnectedLicenseProfile

## SYNOPSIS
Retrieves information about the view of a license profile.

## SYNTAX

### Get (Default)
```
Get-AzConnectedLicenseProfile -MachineName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzConnectedLicenseProfile -MachineName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Retrieves information about the view of a license profile.

## EXAMPLES

### Example 1: Get ESU license profile for a machine
```powershell
Get-AzConnectedLicenseProfile -MachineName WIN-IAH3TLSP7A8 -ResourceGroupName PayGo_cmdlet
```

```output
AdditionalInfo                       :
Code                                 :
Detail                               :
EsuProfileAssignedLicense            :
EsuProfileAssignedLicenseImmutableId :
EsuProfileEsuEligibility             : Ineligible
EsuProfileEsuKey                     : {}
EsuProfileEsuKeyState                : Inactive
EsuProfileServerType                 : Datacenter
Id                                   : /subscriptions/b24cc8ee-df4f-48ac-94cf-46edf36b0fae/resourceGroups/PayGo_c
                                       mdlet/providers/Microsoft.HybridCompute/machines/WIN-IAH3TLSP7A8/licensePr
                                       ofiles/default
Location                             : eastus
Message                              :
Name                                 : default
ProductProfileBillingEndDate         :
ProductProfileBillingStartDate       : 11/15/2024 1:53:34 AM
ProductProfileDisenrollmentDate      :
ProductProfileEnrollmentDate         : 11/8/2024 1:53:34 AM
ProductProfileProductFeature         : {{
                                         "name": "WindowsServerAzureArcMgmt",
                                         "subscriptionStatus": "Enabled",
                                         "enrollmentDate": "2024-11-08T01:58:37.6099656Z",
                                         "billingStartDate": "2024-11-08T01:58:37.6096833Z"
                                       }, {
                                         "name": "Hotpatch",
                                         "subscriptionStatus": "Enabled",
                                         "enrollmentDate": "2024-11-08T01:58:37.6095044Z",
                                         "billingStartDate": "2025-02-01T00:00:00.0000000"
                                       }}
ProductProfileProductType            : WindowsServer
ProductProfileSubscriptionStatus     : Enabled
ProvisioningState                    : Succeeded
ResourceGroupName                    : PayGo_cmdlet
SoftwareAssuranceCustomer            :
SystemDataCreatedAt                  :
SystemDataCreatedBy                  :
SystemDataCreatedByType              :
SystemDataLastModifiedAt             :
SystemDataLastModifiedBy             :
SystemDataLastModifiedByType         :
Tags                                 : {
                                       }
Target                               :
Type                                 : Microsoft.HybridCompute/machines/licenseProfiles
```

Get ESU license profile for a machine

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

### -MachineName
The name of the hybrid machine.

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

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.ILicenseProfile

## NOTES

## RELATED LINKS

