
$global:SkippedTests = @(
    'TestInfraRoleInstancePowerOn',
    'TestInfraRoleInstancePowerOnAll',
    'TestInfrastructureRoleInstanceShutdown',
    'TestInfrastructureRoleInstancePowerOff',
    'TestInfrastructureRoleInstanceReboot',
    'TestCreateIpPool',
    'TestPowerOnScaleUnitNode',
    'TestPowerOffScaleUnitNode'
)

$global:Location = "local"
$global:TenantVMName = "502828aa-de3a-4ba9-a66c-5ae6d49589d7"
$global:Provider = "Microsoft.Fabric.Admin"
$global:ResourceGroupName = "System.local"

if (-not $global:RunRaw) {
    $scriptBlock = {
        Get-MockClient -ClassName 'FabricAdminClient' -TestName $global:TestName -Verbose
    }
    Mock New-ServiceClient $scriptBlock -ModuleName $global:ModuleName
}

if (Test-Path "$PSScriptRoot\Override.ps1") {
    . $PSScriptRoot\Override.ps1
}
