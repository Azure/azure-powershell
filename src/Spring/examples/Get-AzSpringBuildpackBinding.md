### Example 1: List all buildpack binding
```powershell
Get-AzSpringBuildpackBinding -ResourceGroupName Spring-gp-junxi -ServiceName Spring-01 -BuilderName default
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/13 3:26:33   *********@microsoft.com User                    2022/7/13 3:26:33        *********@microso…
```

List all buildpack binding.

### Example 2: Get a buildpack binding by name
```powershell
Get-AzSpringBuildpackBinding -ResourceGroupName Spring-gp-junxi -ServiceName Spring-01 -BuilderName default -Name default
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/13 3:26:33   *********@microsoft.com User                    2022/7/13 3:26:33        *********@microso…
```

Get a buildpack binding by name.

### Example 2: Get a buildpack binding by pipeline
```powershell
New-AzSpringBuildpackBinding -ResourceGroupName Springrg -ServiceName sspring-portal01 -BuilderName default -Name binging01 -BindingType 'AppDynamics' | Get-AzSpringBuildpackBinding
```

```output
Name      SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----      ------------------- -------------------     ----------------------- ------------------------ ------------------
binging01 2022/7/13 3:26:33   *********@microsoft.com User                    2022/7/13 3:26:33        *********@microso…
```

Get a buildpack binding by pipeline.