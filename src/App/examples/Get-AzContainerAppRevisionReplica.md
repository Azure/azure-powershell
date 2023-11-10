### Example 1: List replica for a Container App Revision.
```powershell
Get-AzContainerAppRevisionReplica -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -RevisionName azps-containerapp-1--xdmhk31
```

```output
Name                                        ResourceGroupName
----                                        -----------------
azps-containerapp-1--xdmhk31-7fdbf895c6-rh65t azps_test_group_app
```

List replica for a Container App Revision.

### Example 2: Get a replica for a Container App Revision.
```powershell
Get-AzContainerAppRevisionReplica -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -RevisionName azps-containerapp-1--xdmhk31 -Name azps
```

```output
Name                                        ResourceGroupName
----                                        -----------------
azps-containerapp-1--xdmhk31-7fdbf895c6-rh65t azps_test_group_app
```

Get a replica for a Container App Revision.

### Example 3: Get a replica for a Container App Revision.
```powershell
$obj = Get-AzContainerAppRevision -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app

Get-AzContainerAppRevisionReplica -RevisionInputObject $obj -Name azps-containerapp-1--xdmhk31-7fdbf895c6-rh65t
```

```output
Name                                        ResourceGroupName
----                                        -----------------
azps-containerapp-1--xdmhk31-7fdbf895c6-rh65t azps_test_group_app
```

Get a replica for a Container App Revision.

### Example 4: Get a replica for a Container App Revision.
```powershell
$obj = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-1

Get-AzContainerAppRevisionReplica -ContainerAppInputObject $obj -RevisionName azps-containerapp-1--xdmhk31 -Name azps-containerapp-1--xdmhk31-7fdbf895c6-rh65t
```

```output
Name                                        ResourceGroupName
----                                        -----------------
azps-containerapp-1--xdmhk31-7fdbf895c6-rh65t azps_test_group_app
```

Get a replica for a Container App Revision.