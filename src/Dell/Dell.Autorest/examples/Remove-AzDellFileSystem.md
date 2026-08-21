### Example 1: Delete a Dell filesystem resource
```powershell
Remove-AzDellFileSystem -Name biswadeep-test-rss -ResourceGroupName biswadeep-test-rg -SubscriptionId fc35d936-3b89-41f8-8110-a24b56826c37
```

```output
No output
```

Deletes the specified Dell filesystem resource.

### Example 2: Delete a Dell filesystem resource with confirmation suppressed
```powershell
Remove-AzDellFileSystem -Name biswadeep-test-rss-2 -ResourceGroupName biswadeep-test-rg -SubscriptionId fc35d936-3b89-41f8-8110-a24b56826c37 -PassThru -Confirm:$false
```

```output
True
```

Deletes the Dell filesystem resource without prompting for confirmation and returns True on success.

