### Example 1: Create an in-memory object for EventSubscriptionFilter.
```powershell
$adviceObj = New-AzEventGridBoolEqualsAdvancedFilterObject -Key "testKey" -Value:$true
New-AzEventGridEventSubscriptionFilterObject -AdvancedFilter $adviceObj -EnableAdvancedFilteringOnArray:$true -IncludedEventType "test" -IsSubjectCaseSensitive:$true -SubjectBeginsWith "startTest" -SubjectEndsWith "endTest"
```

```output
EnableAdvancedFilteringOnArray IsSubjectCaseSensitive SubjectBeginsWith SubjectEndsWith
------------------------------ ---------------------- ----------------- ---------------
True                           True                   startTest         endTest
```

Create an in-memory object for EventSubscriptionFilter.