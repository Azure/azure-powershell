---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabric
schema: 2.0.0
---

# Get-AzNetworkFabric

## SYNOPSIS
Get Network Fabric resource details.

## SYNTAX

### List1 (Default)
```
Get-AzNetworkFabric [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabric -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List
```
Get-AzNetworkFabric -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabric -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get Network Fabric resource details.

## EXAMPLES

### Example 1: List NetworkFabrics by Subscription
```powershell
Get-AzNetworkFabric -SubscriptionId $subscriptionId
```

```output
Location    Name                        SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy     SystemDataLastModifiedByType
--------    ----                        ------------------- -------------------      ----------------------- ------------------------ ------------------------     ------
eastus2euap pipeline-GA-nf071423        07/14/2023 10:58:25 <identity>               User                    09/05/2023 11:14:10      <identity>                   Appli…
eastus2euap pipeline-GA-nf080323-1      08/03/2023 13:49:42 <identity>               Application             08/03/2023 13:52:24      <identity>                   Appli…
eastus2euap nfa-automation-testing-nf-1 08/07/2023 13:18:40 <identity>               Application             08/07/2023 13:24:41      <identity>                   Appli…
eastus2euap nfa-automation-testing-nf-2 08/07/2023 15:36:56 <identity>               Application             08/07/2023 16:05:20      <identity>                   Appli…
eastus2euap nfa-tool-ts-GA-nf081123     08/11/2023 06:40:50 <identity>               User                    09/05/2023 09:42:59      <identity>                   Appli…
eastus2euap nfa-tool-ts-GA-nf081223     08/12/2023 14:01:45 <identity>               User                    09/20/2023 15:01:05      <identity>                   Appli…
eastus2euap nffab1-4-1-BF               09/24/2023 10:14:30 <identity>               Application             09/25/2023 07:22:46      <identity>                   Appli…
eastus2euap pipeline-nf082823           08/28/2023 07:24:46 <identity>               User                    09/22/2023 06:30:23      <identity>                   Appli…
eastus2euap nffab3-4-1-GF1              09/21/2023 10:38:54 <identity>               Application             09/25/2023 05:30:10      <identity>                   Appli…
eastus      fabricName                  09/21/2023 13:53:03 <identity>               User                    09/25/2023 05:53:50      <identity>                   Appli…
```

This command lists all the NetworkFabrics under the given Subscription.

### Example 2: List NetworkFabrics by Resource Group
```powershell
Get-AzNetworkFabric -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState ControllerId
------------------- ---------- ------------------ ------------
                               Provisioned        /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabri…
```

This command lists all the NetworkFabrics under the given Resource Group.

### Example 3: Get NetworkFabric
```powershell
Get-AzNetworkFabric -Name $name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState ControllerId
------------------- ---------- ------------------ ------------
                               Provisioned        /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabri…
```

This command gets details of the given NetworkFabric.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Network Fabric.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: NetworkFabricName

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
Parameter Sets: List1, Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkFabric

## NOTES

## RELATED LINKS
