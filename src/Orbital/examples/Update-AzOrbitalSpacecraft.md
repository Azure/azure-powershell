### Example 1: Updates the specified spacecraft tags.
```powershell
Update-AzOrbitalSpacecraft -ResourceGroupName azpstest_gp -SpacecraftName azps-orbitalspacecraft -Tag @{"123"="abc"}
```

```output
Name                   Location NoradId TitleLine   ResourceGroupName
----                   -------- ------- ---------   -----------------
azps-orbitalspacecraft eastus   12345   ISS (ZARYA) azpstest_gp
```

Updates the specified spacecraft tags.

### Example 2: Updates the specified spacecraft tags.
```powershell
$spacecraftObject = Get-AzOrbitalSpacecraft -ResourceGroupName azpstest_gp -Name azps-orbitalspacecraft
Update-AzOrbitalSpacecraft -InputObject $spacecraftObject -Tag @{"123"="abc"}
```

```output
Name                   Location NoradId TitleLine   ResourceGroupName
----                   -------- ------- ---------   -----------------
azps-orbitalspacecraft eastus   12345   ISS (ZARYA) azpstest_gp
```

Updates the specified spacecraft tags.