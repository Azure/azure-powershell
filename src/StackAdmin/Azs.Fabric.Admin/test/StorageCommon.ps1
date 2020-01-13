$global:SkippedTests = @(
)

if ($global:TestMode -eq "Live") {
    $global:Location = (Get-AzLocation)[0].Name
    $global:ResourceGroupName = -join("System.",(Get-AzLocation)[0].Name)
}
else {
    $global:Location = "redmond"
    $global:ResourceGroupName = "System.redmond"
}