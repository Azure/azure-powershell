### Example 1: Get diagnostic by resource id and diagnostic name

```powershell
 Get-AzSelfHelpDiagnostic -Scope "subscriptions/6bded6d5-a6df-44e1-96d3-bf71f6f5f8ba/resourceGroups/test-rgName/providers/Microsoft.KeyVault/vaults/testKeyVault" -SResourceName ab-test-983
```

```output
Name
----
ab-test-983
```

Get diagnostic by resource id and diagnostic name
