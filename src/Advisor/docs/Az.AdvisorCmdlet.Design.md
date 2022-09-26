#### Get-AzAdvisorConfiguration

#### SYNOPSIS
Retrieve Azure Advisor configurations and also retrieve configurations of contained resource groups.

#### SYNTAX

+ List (Default)
```powershell
Get-AzAdvisorConfiguration [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ List1
```powershell
Get-AzAdvisorConfiguration -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get Configuration by SubscriptionId
```powershell
Get-AzAdvisorConfiguration
```

```output
Name    Exclude LowCpuThreshold
----    ------- ---------------
default False   10
```

Get Configuration by SubscriptionId

+ Example 2: Get Configuration by ResourceGroupName
```powershell
Get-AzAdvisorConfiguration -ResourceGroupName lnxtest
```

```output
Name                                         Exclude LowCpuThreshold
----                                         ------- ---------------
9e223dbe-3399-4e19-88eb-0975f02ac87f-lnxtest False
```

Get Configuration by ResourceGroupName


#### Set-AzAdvisorConfiguration

#### SYNOPSIS


#### SYNTAX

+ CreateByLCT (Default)
```powershell
Set-AzAdvisorConfiguration [-SubscriptionId <String>] [-Exclude] [-LowCpuThreshold <CpuThreshold>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateByInputObject
```powershell
Set-AzAdvisorConfiguration -InputObject <IAdvisorIdentity> [-Exclude] [-LowCpuThreshold <CpuThreshold>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateByRG
```powershell
Set-AzAdvisorConfiguration -ResourceGroupName <String> [-SubscriptionId <String>] [-Exclude]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Set advisor configuration by subscription id
```powershell
Set-AzAdvisorConfiguration -Exclude -LowCpuThreshold 20
```

```output
Name    Exclude LowCpuThreshold
----    ------- ---------------
default True    20
```

Set advisor configuration by subscription id

+ Example 2:  Set advisor configuration by resource group name
```powershell
Set-AzAdvisorConfiguration -Exclude
```

```output
Name    Exclude LowCpuThreshold
----    ------- ---------------
default True
```

Set advisor configuration by resource group name


#### Disable-AzAdvisorRecommendation

#### SYNOPSIS


#### SYNTAX

+ IdParameterSet (Default)
```powershell
Disable-AzAdvisorRecommendation -ResourceId <String> [-Day <Object>] [<CommonParameters>]
```

+ InputObjectParameterSet
```powershell
Disable-AzAdvisorRecommendation -InputObject <IAdvisorIdentity> [-Day <Object>] [<CommonParameters>]
```

+ NameParameterSet
```powershell
Disable-AzAdvisorRecommendation -RecommendationName <String> [-Day <Object>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Disable recommendation by recommendation name
```powershell
Disable-AzAdvisorRecommendation -RecommendationName 42963553-61de-5334-2d2e-47f3a0099d41 -Day 1
```

```output
SuppressionId                        Name                     Resource Group   Ttl
-------------                        ----                     --------------   ---
5b931ff3-42a3-5f80-797f-8e018a6dfaf5 HardcodedSuppressionName automanagehcrprg 1.00:00:00
```

Disable recommendation by recommendation name

+ Example 2: Disable recommendation by recommendation resource id
```powershell
Disable-AzAdvisorRecommendation -ResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/automanagehcrprg/providers/microsoft.compute/virtualmachines/arcbox-capi-mgmt/providers/Microsoft.Advisor/recommendations/42963553-61de-5334-2d2e-47f3a0099d41 -Day 1
```

```output
SuppressionId                        Name                     Resource Group   Ttl
-------------                        ----                     --------------   ---
5b931ff3-42a3-5f80-797f-8e018a6dfaf5 HardcodedSuppressionName automanagehcrprg 1.00:00:00
```

Disable recommendation by recommendation resource id


#### Enable-AzAdvisorRecommendation

#### SYNOPSIS


#### SYNTAX

+ IdParameterSet (Default)
```powershell
Enable-AzAdvisorRecommendation -ResourceId <String> [<CommonParameters>]
```

+ InputObjectParameterSet
```powershell
Enable-AzAdvisorRecommendation -InputObject <IAdvisorIdentity> [<CommonParameters>]
```

+ NameParameterSet
```powershell
Enable-AzAdvisorRecommendation -RecommendationName <String> [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Enable recommendation by resource Id
```powershell
Enable-AzAdvisorRecommendation -ResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/automanagehcrprg/providers/microsoft.compute/virtualmachines/arcbox-capi-mgmt/providers/Microsoft.Advisor/recommendations/42963553-61de-5334-2d2e-47f3a0099d41
```

```output
Name                                 Category Resource Group   Impact ImpactedField
----                                 -------- --------------   ------ -------------
42963553-61de-5334-2d2e-47f3a0099d41 Security automanagehcrprg High   Microsoft.Compute/virtualMachines
```

Enable recommendation by resource Id

+ Example 2: Enable recommendation byrecommendation name
```powershell
Enable-AzAdvisorRecommendation -RecommendationName 42963553-61de-5334-2d2e-47f3a0099d41
```

```output
Name                                 Category Resource Group   Impact ImpactedField
----                                 -------- --------------   ------ -------------
42963553-61de-5334-2d2e-47f3a0099d41 Security automanagehcrprg High   Microsoft.Compute/virtualMachines
```

Enable recommendation byrecommendation name


#### Get-AzAdvisorRecommendation

#### SYNOPSIS


#### SYNTAX

+ ListByFilter (Default)
```powershell
Get-AzAdvisorRecommendation [-SubscriptionId <String[]>] [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetById
```powershell
Get-AzAdvisorRecommendation -Id <String> -ResourceUri <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentity1
```powershell
Get-AzAdvisorRecommendation -InputObject <IAdvisorIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ ListById
```powershell
Get-AzAdvisorRecommendation -ResourceId <String> [-Category <String>] [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ ListByName
```powershell
Get-AzAdvisorRecommendation -ResourceGroupName <String> [-Category <String>] [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List Recommendation by subscriptionId and resource group name
```powershell
 Get-AzAdvisorRecommendation -ResourceGroupName lnxtest -Category HighAvailability
```

```output
Name                                 Category         Resource Group Impact ImpactedValue ImpactedField
----                                 --------         -------------- ------ ------------- -------------
71411b72-e7de-9dc2-308b-5c60252e1456 HighAvailability lnxtest        Medium lnxtest-vnet  MICROSOFT.NETWORK/VIRTUALNETWORKS
bf8ebdfd-6caa-9f55-53ae-ffafefbf3a7c HighAvailability lnxtest        Medium advisortest   MICROSOFT.NETWORK/VIRTUALNETWORKS
339071fa-d66a-be4f-9cf8-22b67552b287 HighAvailability lnxtest        Medium advisor-test  MICROSOFT.NETWORK/VIRTUALNETWORKS
```

List Recommendation by subscriptionId

+ Example 2: List Recommendation by subscriptionId and filter
```powershell
Get-AzAdvisorRecommendation -filter "Category eq 'HighAvailability' and ResourceGroup eq 'lnxtest'"
```

```output
Name                                 Category         Resource Group Impact ImpactedValue ImpactedField
----                                 --------         -------------- ------ ------------- -------------
71411b72-e7de-9dc2-308b-5c60252e1456 HighAvailability lnxtest        Medium lnxtest-vnet  MICROSOFT.NETWORK/VIRTUALNETWORKS
bf8ebdfd-6caa-9f55-53ae-ffafefbf3a7c HighAvailability lnxtest        Medium advisortest   MICROSOFT.NETWORK/VIRTUALNETWORKS
339071fa-d66a-be4f-9cf8-22b67552b287 HighAvailability lnxtest        Medium advisor-test  MICROSOFT.NETWORK/VIRTUALNETWORKS
```

List Recommendation by subscriptionId and filter

+ Example 3: Get Recommendation by Id and resource Id
```powershell
Get-AzAdvisorRecommendation -Id 42963553-61de-5334-2d2e-47f3a0099d41 -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f
```

```output
Name                                 Category Resource Group   Impact ImpactedValue    ImpactedField
----                                 -------- --------------   ------ -------------    -------------
42963553-61de-5334-2d2e-47f3a0099d41 Security automanagehcrprg High   arcbox-capi-mgmt Microsoft.Compute/virtualMachines
```

Get Recommendation by Id and resource Id


