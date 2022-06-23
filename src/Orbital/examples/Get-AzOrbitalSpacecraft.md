### Example 1: List the specified spacecraft.
```powershell
Get-AzOrbitalSpacecraft
```

```output
Name                     Location NoradId TitleLine   ResourceGroupName
----                     -------- ------- ---------   -----------------
azpstest-test-spacecraft westus2  12345   ISS (ZARYA) azpstest_gp
azps-orbitalspacecraft   eastus   12345   ISS (ZARYA) azpstest_gp
```

List the specified spacecraft.

### Example 2: Gets the specified spacecraft in a specified resource group.
```powershell
Get-AzOrbitalSpacecraft -ResourceGroupName azpstest_gp
```

```output
Name                     Location NoradId TitleLine   ResourceGroupName
----                     -------- ------- ---------   -----------------
azpstest-test-spacecraft westus2  12345   ISS (ZARYA) azpstest_gp
azps-orbitalspacecraft   eastus   12345   ISS (ZARYA) azpstest_gp
```

Gets the specified spacecraft in a specified resource group.

### Example 3: Get the specified spacecraft in a specified Name.
```powershell
Get-AzOrbitalSpacecraft -ResourceGroupName azpstest_gp -Name azps-orbitalspacecraft
```

```output
Name                   Location NoradId TitleLine   ResourceGroupName
----                   -------- ------- ---------   -----------------
azps-orbitalspacecraft eastus   12345   ISS (ZARYA) azpstest_gp
```

Get the specified spacecraft in a specified Name.