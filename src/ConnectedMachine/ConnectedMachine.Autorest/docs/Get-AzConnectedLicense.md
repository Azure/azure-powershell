---
external help file:
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/az.connectedmachine/get-azconnectedlicense
schema: 2.0.0
---

# Get-AzConnectedLicense

## SYNOPSIS
Retrieves information about the view of a license.

## SYNTAX

### List1 (Default)
```
Get-AzConnectedLicense [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzConnectedLicense -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzConnectedLicense -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Retrieves information about the view of a license.

## EXAMPLES

### Example 1: Get a list of ESU licenses
```powershell
Get-AzConnectedLicense -SubscriptionId ********-****-****-****-**********
```

```output
Location      Name         SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------      ----         ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
uksouth       testLicense2                                                                                                                                                dakirbytest
eastus2euap   myESULicense                                                                                                                                                ytongtest
centraluseuap testLicense                                                                                                                                                 dakirbytest
centraluseuap testLicense                                                                                                                                                 dakirbytest
centraluseuap testLicense3                                                                                                                                                dakirbytest
centraluseuap testLicense4                                                                                                                                                dakirbytest
centraluseuap testLicense5                                                                                                                                                dakirbytest
```

Get a list of ESU licenses

### Example 2: Get a specific ESU license
```powershell
Get-AzConnectedLicense -Name 'myESULicense' -ResourceGroupName 'ytongtest' -SubscriptionId ********-****-****-****-**********
```

```output
DetailAssignedLicense        : 8
DetailEdition                : Datacenter
DetailImmutableId            : ********-****-****-****-**********
DetailProcessor              : 16
DetailState                  : Activated
DetailTarget                 : Windows Server 2012
DetailType                   : pCore
DetailVolumeLicenseDetail    :
Id                           : /subscriptions/********-****-****-****-**********/resourceGroups/ytongtest/providers/Microsoft.HybridCompute/licenses/myESULicense
LicenseType                  : ESU
Location                     : eastus2euap
Name                         : myESULicense
ProvisioningState            :
ResourceGroupName            : ytongtest
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
TenantId                     : ********-****-****-****-**********
Type                         : Microsoft.HybridCompute/licenses

```

Get a specific ESU license

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

### -Name
The name of the license.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: LicenseName

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.ILicense

## NOTES

## RELATED LINKS

