### Example 1: Update an AzureFrontDoor profile under the resource group
```powershell
$tags = @{
    Tag1 = 11
    Tag2  = 22
}
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -Tag $tags
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Update an AzureFrontDoor profile under the resource group


### Example 2: Update an AzureFrontDoor profile under the resource group via identity
```powershell
$tags = @{
    Tag1 = 11
    Tag2  = 22
}
Get-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 | Update-AzFrontDoorCdnProfile -Tag $tags
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Update an AzureFrontDoor profile under the resource group via identity


### Example 3: Enable managed identity using SystemAssigned type to an AzureFrontDoor profile
```powershell
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -IdentityType SystemAssigned
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Enable managed identity using SystemAssigned type to an AzureFrontDoor profile


### Example 4: Enable managed identity using UserAssigned type to an AzureFrontDoor profile
```powershell
$userId =  @{"/subscriptions/subId/resourceGroups/testps-rg-da16jm/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testcdnrpaadidentity" = @{}}
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -IdentityType UserAssigned -IdentityUserAssignedIdentity $userId
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Enable managed identity using UserAssigned type to an AzureFrontDoor profile


### Example 5: Enable the Profile Logscrub to an AzureFrontDoor profile, only contains one LogScrubbingRule
```powershell
$rule = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -State Enabled
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -LogScrubbingRule $rule -LogScrubbingState Enabled
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Enable the Profile Logscrub to an AzureFrontDoor profile, only contains one LogScrubbingRule


### Example 6: Enable the Profile Logscrub to an AzureFrontDoor profile, contains more than one LogScrubbingRule
```powershell
$rule1 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -State Enabled 
$rule2 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable QueryStringArgNames -State Enabled
$rules = New-AzFrontDoorCdnProfileLogScrubbingObject -ScrubbingRule @($rule1, $rule2) -State Enabled

Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -LogScrubbingRule $rules.ScrubbingRule -LogScrubbingState Enabled
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Enable the Profile Logscrub to an AzureFrontDoor profile, contains more than one LogScrubbingRule


### Example 7: Disable the Profile Logscrub to an AzureFrontDoor profile
```powershell
$rule = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -State Disabled
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -LogScrubbingRule $rule -LogScrubbingState Disabled
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Disable the Profile Logscrub to an AzureFrontDoor profile