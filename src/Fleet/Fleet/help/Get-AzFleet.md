---
external help file: Az.Fleet-help.xml
Module Name: Az.Fleet
online version: https://learn.microsoft.com/powershell/module/az.fleet/get-azfleet
schema: 2.0.0
---

# Get-AzFleet

## SYNOPSIS
Gets a Fleet.

## SYNTAX

### List (Default)
```
Get-AzFleet [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get
```
Get-AzFleet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzFleet -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFleet -InputObject <IFleetIdentity> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a Fleet.

## EXAMPLES

### Example 1: Lists the Fleet resources in a subscription
```powershell
Get-AzFleet
```

```output
Location Name SystemDataCreatedAt   SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ETag                                   ResourceGroupName
-------- ---- -------------------   -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----                                   -----------------
eastus   sss  11/14/2023 8:05:54 AM user1@example.com     User                    11/14/2023 8:05:54 AM    user1@example.com        User                         "25052d24-0000-0100-0000-65532a620000" ps1-test
eastus   ttt  11/14/2023 9:55:13 AM user1@example.com     User                    11/14/2023 9:55:13 AM    user1@example.com        User                         "29054cbc-0000-0100-0000-655344020000" ps1-test
```

This command lists the Fleet resources in a subscription.

### Example 2: Get specific fleet with specified name
```powershell
Get-AzFleet -Name testfleet01 -ResourceGroupName K8sFleet-Test
```

```output
ETag                         : "61052549-0000-0100-0000-65542ab10000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : 
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : testfleet01
ProvisioningState            : Succeeded
ResourceGroupName            : K8sFleet-Test
SystemDataCreatedAt          : 11/15/2023 2:19:28 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/15/2023 2:19:28 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.ContainerService/fleets
```

This command gets specific fleet with specified name.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Fleet resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: FleetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

```yaml
Type: System.String[]
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleet

## NOTES

## RELATED LINKS
