### Example 1: Create a tag with absolute criteria 
```powershell
New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfDay
```

```output
ObjectType                  AbsoluteCriterion DaysOfTheWeek MonthsOfYear ScheduleTime WeeksOfTheMonth
----------                  ----------------- ------------- ------------ ------------ ---------------
ScheduleBasedBackupCriteria {FirstOfDay}
```

This command creates a criteria object with absolute criteria.

### Example 2: create a tag with weekly criteria
```powershell
New-AzDataProtectionPolicyTagCriteriaClientObject -DaysOfWeek @("Sunday", "Monday")
```

```output
ObjectType                  AbsoluteCriterion DaysOfTheWeek    MonthsOfYear ScheduleTime WeeksOfTheMonth
----------                  ----------------- -------------    ------------ ------------ ---------------
ScheduleBasedBackupCriteria                   {Sunday, Monday}
```

This command creates a critetia object with weekly criteria

