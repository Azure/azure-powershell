### Example 1: Create a new Column which is used for New-AzOperationalInsightsTable cmdlet
```powershell
PS C:\> New-AzOperationalInsightsTableColumnObject -Name 'SourceSystem' -Description 'Type of agent the data was collected from. Possible values are OpsManager (Windows agent) or Linux.' -Type 'string'

DataTypeHint Description                                                                                         DisplayName IsDefaultDisplay IsHidden Name
------------ -----------                                                                                         ----------- ---------------- -------- ----
             Type of agent the data was collected from. Possible values are OpsManager (Windows agent) or Linux.                                       SourceSystem

```
Creates a TableColumnObject(1 of 2 that are required) which is required to use "New-AzOperationalInsightsTable" cmdlet.

### Example 2: Create a new Column which is used for New-AzOperationalInsightsTable cmdlet
```powershell
PS C:\> New-AzOperationalInsightsTableColumnObject -Name 'TimeGenerated' -Description 'Date and time the record was created.' -Type 'datetime'

DataTypeHint Description                           DisplayName IsDefaultDisplay IsHidden Name
------------ -----------                           ----------- ---------------- -------- ----
             Date and time the record was created.                                       TimeGenerated

```
Creates a TableColumnObject(2 of 2 that are required) which is required to use "New-AzOperationalInsightsTable" cmdlet.