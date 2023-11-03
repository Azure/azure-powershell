### Example 1: List AzureFrontDoor routes under the AzureFrontDoor profile
```powershell
Get-AzFrontDoorCdnRoute -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001
```

```output
Name     ResourceGroupName
----     -----------------
route001 testps-rg-da16jm
route002 testps-rg-da16jm
route003 testps-rg-da16jm
route004 testps-rg-da16jm
```

List AzureFrontDoor routes under the AzureFrontDoor profile

### Example 2: Get an AzureFrontDoor route under the AzureFrontDoor profile
```powershell
Get-AzFrontDoorCdnRoute -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 -Name route001
```

```output
Name     ResourceGroupName
----     -----------------
route001 testps-rg-da16jm
```

Get an AzureFrontDoor route under the AzureFrontDoor profile


### Example 3: Get an AzureFrontDoor route under the AzureFrontDoor profile via identity
```powershell
$originGroup = Get-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001
$ruleSet = Get-AzFrontDoorCdnRuleSet -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001
$customdomain = Get-AzFrontDoorCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -CustomDomainName domain001

$ruleSetResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $ruleSet.Id
$customdomainResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $customdomain.Id

New-AzFrontDoorCdnRoute -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 -Name route001 -OriginGroupId $originGroup.Id -RuleSet @($ruleSetResoure) -PatternsToMatch "/*" -LinkToDefaultDomain "Enabled" -EnabledState "Enabled" -CustomDomain @($customdomainResoure) | Get-AzFrontDoorCdnRoute
```

```output
Name     ResourceGroupName
----     -----------------
route001 testps-rg-da16jm
```

Get an AzureFrontDoor route under the AzureFrontDoor profile via identity