### Example 1: List all revisions of a container group profile present in a resource group in the current subscription
```powershell
Get-AzContainerInstanceContainerGroupProfileRevision -ContainerGroupProfileName test-cgp -ResourceGroupName test-rg
```

```output
Location Name    Zone ResourceGroupName Revision
-------- ----    ---- ----------------- --------
eastus   test-cgp      test-rg          1  
eastus   test-cgp      test-rg          2
```

This command gets all revisions of `test-cgp` container group profile present in `test-rg` in the current subscription.