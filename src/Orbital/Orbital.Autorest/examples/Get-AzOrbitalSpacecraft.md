### Example 1: List the specified spacecraft.
```powershell
Get-AzOrbitalSpacecraft
```

```output
Name                     Location NoradId TitleLine   ResourceGroupName
----                     -------- ------- ---------   -----------------
azpstest-test-spacecraft westus2  12345   ISS (ZARYA) azpstest-gp
AQUA                     eastus   12345   ISS (ZARYA) azpstest-gp
```

List the specified spacecraft.

### Example 2: Gets the specified spacecraft in a specified resource group.
```powershell
Get-AzOrbitalSpacecraft -ResourceGroupName azpstest-gp
```

```output
Name Location NoradId TitleLine ResourceGroupName
---- -------- ------- --------- -----------------
AQUA westus2  27424   AQUA      azpstest-gp
```

Gets the specified spacecraft in a specified resource group.

### Example 3: Get the specified spacecraft in a specified Name.
```powershell
Get-AzOrbitalSpacecraft -ResourceGroupName azpstest-gp -Name AQUA
```

```output
Name Location NoradId TitleLine ResourceGroupName
---- -------- ------- --------- -----------------
AQUA westus2  27424   AQUA      azpstest-gp
```

Get the specified spacecraft in a specified Name.