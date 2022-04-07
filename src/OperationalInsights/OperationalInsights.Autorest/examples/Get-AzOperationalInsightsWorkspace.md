### Example 1: Get a worksapce by resource group and worksapce name
```powershell
Get-AzOperationalInsightsWorkspace -Name WS_Name -ResourceGroupName RG_Name
```
```output

Location Name             ETag
-------- ----             ----
eastus   WS_Name

```
Get a Log-Analytics workspace

### Example 2: List all worksapces for a given resource group name
```powershell
Get-AzOperationalInsightsWorkspace  -ResourceGroupName RG_Name
```
```output

Location    Name                        ETag
--------    ----                        ----
eastus      WS_Name1
eastus      WS_Name2
eastus      WS_Name3

```
List al Log-Analytics workspaces for a given resource group name
