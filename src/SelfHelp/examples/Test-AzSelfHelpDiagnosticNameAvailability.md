### Example 1: Example when the diagnostic resource name is available

```powershell
Test-AzSelfHelpDiagnosticNameAvailability -Name test-diagnostics-resource -Type microsoft.help/diagnostics -Scope "subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba"
```

```output
Message NameAvailable Reason
------- ------------- ------
        True

```

Example when the diagnostic resource name is available

### Example 2: Example when the diagnostic resource name is available

```powershell
Test-AzSelfHelpDiagnosticNameAvailability -Name test-diagnostics-resource -Type microsoft.help/diagnostics -Scope "subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba"
```

```output
Message                            NameAvailable   Reason
-------                            -------------   ------
Resource name is currently in use. False           Resource name already exisits/unavailable
```

Example when the diagnostic resource name is not available
