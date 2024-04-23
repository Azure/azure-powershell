---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricroutepolicy
schema: 2.0.0
---

# Get-AzNetworkFabricRoutePolicy

## SYNOPSIS
Implements Route Policy GET method.

## SYNTAX

### List1 (Default)
```
Get-AzNetworkFabricRoutePolicy [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricRoutePolicy -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List
```
Get-AzNetworkFabricRoutePolicy -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricRoutePolicy -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Implements Route Policy GET method.

## EXAMPLES

### Example 1: List Route Policies by Subscription
```powershell
Get-AzNetworkFabricRoutePolicy -SubscriptionId $subscriptionId
```

```output
Location    Name                                                                 SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------    ----                                                                 ------------------- -------------------    ----------------------- ------------------------ ---------
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v4-intnw-2603-imp-policy           07/14/2023 15:34:26 <identity>             Application             09/05/2023 10:18:21      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v4-intnw-2603-exp-policy           07/14/2023 15:36:34 <identity>             Application             09/05/2023 10:18:22      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v4-intnw-2604-imp-policy           07/14/2023 15:38:32 <identity>             Application             09/05/2023 10:18:22      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v4-intnw-2604-exp-policy           07/14/2023 15:40:26 <identity>             Application             09/05/2023 10:18:22      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v4-extoptionA-imp-policy-2603-2604 07/14/2023 15:41:50 <identity>             Application             09/05/2023 10:18:22      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v4-extoptionA-exp-policy-2603-2604 07/14/2023 15:42:56 <identity>             Application             09/05/2023 10:18:23      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v4-intnw-2609-imp-policy           07/14/2023 17:01:58 <identity>             Application             07/19/2023 14:29:17      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v4-intnw-2609-exp-policy           07/14/2023 17:04:04 <identity>             Application             07/19/2023 14:29:17      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v4-intnw-2610-imp-policy           07/14/2023 17:06:02 <identity>             Application             07/19/2023 14:29:17      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v4-intnw-2610-exp-policy           07/14/2023 17:07:59 <identity>             Application             07/19/2023 14:29:17      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v4-extoptionB-imp-policy-2609-2610 07/14/2023 17:09:21 <identity>             Application             07/19/2023 14:29:18      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v4-extoptionB-exp-policy-2609-2610 07/14/2023 17:10:28 <identity>             Application             07/19/2023 14:29:18      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v6-connsubnet-ext-policy-2605-2606 07/20/2023 10:13:20 <identity>             User                    07/27/2023 10:17:59      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v6-connsubnet-ext-policy-2613-2614 07/24/2023 15:26:21 <identity>             User                    08/01/2023 13:18:05      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v4-intnw-2613-imp-policy           07/24/2023 15:33:14 <identity>             User                    08/01/2023 13:18:05      <identity>
eastus2euap rcf-pipeline-GA-nf071423-l3domain-v4-intnw-2613-exp-policy           07/25/2023 06:56:46 <identity>             User                    08/01/2023 13:18:05      <identity>
eastus2euap nfa-tool-ts-GA-routePolicy081023                                     08/18/2023 14:24:05 <identity>             User                    08/25/2023 16:10:25      <identity>
eastus2euap rcf-pipeline-nf082823-l3domain-v6-connsubnet-ext-policy-2605-2606    09/15/2023 17:50:37 <identity>             User                    09/25/2023 11:44:14      <identity>
eastus2euap rcf-nni-v4-ingress-patch                                             09/22/2023 06:34:25 <identity>             User                    09/22/2023 11:00:14      <identity>
eastus2euap rcf-nni-v6-egress-patch                                              09/22/2023 07:03:22 <identity>             User                    09/22/2023 08:31:34      <identity>
eastus2euap rcf-nni-v6-ingress-patch                                             09/22/2023 10:28:56 <identity>             User                    09/22/2023 10:46:07      <identity>
eastus2euap rcf-nni-v6-ingress2-patch                                            09/22/2023 10:49:04 <identity>             User                    09/22/2023 11:00:14      <identity>
eastus2euap rcf-nni-v4-egress                                                    09/21/2023 10:42:13 <identity>             Application             09/21/2023 10:58:53      <identity>
eastus2euap rcf-nni-v6-egress                                                    09/21/2023 10:42:55 <identity>             Application             09/22/2023 05:45:36      <identity>
eastus2euap rcf-nni-v4-ingress                                                   09/21/2023 10:43:36 <identity>             Application             09/21/2023 10:58:53      <identity>
eastus2euap rcf-nni-v6-ingress                                                   09/21/2023 10:44:18 <identity>             Application             09/21/2023 10:58:53      <identity>
eastus      RoutePolicyName                                                      09/22/2023 07:32:56 <identity>             User                    09/25/2023 04:58:00      <identity>
```

This command lists all the Route Policies under the given Subscription.

### Example 2: List Route Policies by Resource Group
```powershell
Get-AzNetworkFabricRoutePolicy -ResourceGroupName $resourceGroupName
```

```output
AddressFamilyType AdministrativeState Annotation ConfigurationState DefaultAction Id
----------------- ------------------- ---------- ------------------ ------------- --
IPv4                                                                Permit        /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/provide…
```

This command lists all the Route Policies under the given Resource Group.

### Example 3: Get Route Policy
```powershell
Get-AzNetworkFabricRoutePolicy -Name $name -ResourceGroupName $resourceGroupName
```

```output
AddressFamilyType AdministrativeState Annotation ConfigurationState DefaultAction Id
----------------- ------------------- ---------- ------------------ ------------- --
IPv4                                                                Permit        /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/provide…
```

This command gets details of the given Route Policy.

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
Name of the Route Policy.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RoutePolicyName

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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IRoutePolicy

## NOTES

## RELATED LINKS
