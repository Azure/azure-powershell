---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudvirtualmachine
schema: 2.0.0
---

# Get-AzNetworkCloudVirtualMachine

## SYNOPSIS
Get properties of the provided virtual machine.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudVirtualMachine [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudVirtualMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzNetworkCloudVirtualMachine -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudVirtualMachine -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get properties of the provided virtual machine.

## EXAMPLES

### Example 1: List virtual machines by subscription
```powershell
Get-AzNetworkCloudVirtualMachine -SubscriptionId subscriptionId
```

```output
Location Name       SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType  SystemDataLastModifiedAt  SystemDataLastModifiedBy SystemDataLastModifiedByType AzureAsyncOperation
--------        ----                   -------------------                  -------------------                    -----------------------                       ------------------------                        ------------------------             -
eastus      testVM123       07/07/2023 16:50:12    <user>                                  User                                             07/08/2023 03:19:08                  <Identity>                           A
```

This command gets all virtual machines under a subscription.

### Example 2: Get virtual machine
```powershell
Get-AzNetworkCloudVirtualMachine -Name vmName -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location Name       SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType  SystemDataLastModifiedAt  SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------        ----                   -------------------                  -------------------                    -----------------------                       ------------------------                        ------------------------                       ---------------------------------------------  ------------------------
eastus      <VM name>    07/07/2023 16:50:12    <user>                                  User                                             07/08/2023 03:19:08                  <Identity>                                       Application                                          <RG>
```

This command gets a virtual machine by name.

### Example 2: List virtual machines by resource group
```powershell
Get-AzNetworkCloudVirtualMachine -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location Name       SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType  SystemDataLastModifiedAt  SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------        ----                   -------------------                  -------------------                    -----------------------                       ------------------------                        ------------------------                       ---------------------------------------------  ------------------------
eastus      <VM name>    07/07/2023 16:50:12    <user>                                  User                                             07/08/2023 03:19:08                  <Identity>                                       Application                                          <RG>
eastus      <VM name>    07/07/2023 16:50:12    <user>                                  User                                             07/08/2023 03:19:08                  <Identity>                                       Application                                          <RG>
eastus      <VM name>    07/07/2023 16:50:12    <user>                                  User                                             07/08/2023 03:19:08                  <Identity>                                       Application                                          <RG>
```

This command lists all virtual machines in a resource group.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: VirtualMachineName

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
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IVirtualMachine

## NOTES

## RELATED LINKS
