### Example 1: Get a worksapce by resource group and worksapce name
```powershell
Get-AzOperationalInsightsWorkspace -name {WS_Name} -ResourceGroupName {RG_Name}


Location Name             ETag
-------- ----             ----
eastus   WS_Name

```

### Example 2: List all worksapces for a given resource group name
```powershell
Get-AzOperationalInsightsWorkspace  -ResourceGroupName {RG_Name}


Location    Name                        ETag
--------    ----                        ----
eastus      WS_Name1
eastus      WS_Name2
eastus      WS_Name3

```