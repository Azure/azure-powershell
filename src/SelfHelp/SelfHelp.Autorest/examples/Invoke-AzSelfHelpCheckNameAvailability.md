### Example 1: Invoke-AzSelfHelpCheckNameAvailability
```powershell
$CHECKNAMEAVAILABILITYREQUEST = [ordered]@{ 
    "name" ="helloworld" 
    “type” = “solutions” 

} 
 Invoke-AzSelfHelpCheckNameAvailability -Scope "/subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba" -CheckNameAvailabilityRequest $CHECKNAMEAVAILABILITYREQUEST 
```

```output
Message NameAvailable Reason 

------- ------------- ------ 

        True 
```

Checks if resource name is avilabale/unique for the scope or not


