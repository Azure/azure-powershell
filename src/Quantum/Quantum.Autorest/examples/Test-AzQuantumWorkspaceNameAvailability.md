### Example 1: Check the availability of the resource name.
```powershell
Test-AzQuantumWorkspaceNameAvailability -LocationName eastus -Name sample-workspace-name -Type "Microsoft.Quantum/Workspaces"
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Check the availability of the resource name.