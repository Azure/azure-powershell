# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------


$global:SkippedTests = @(
    'TestInfraRoleInstancePowerOn'#,
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

$global:Client = $null

if (-not $global:RunRaw) {
    $scriptBlock = {
        if ($null -eq $global:Client) {
            $global:Client = Get-MockClient -ClassName 'FabricAdminClient' -TestName $global:TestName -Verbose
        }
        $global:Client
    }
    Mock New-ServiceClient $scriptBlock -ModuleName $global:ModuleName
}

if (Test-Path "$PSScriptRoot\Override.ps1") {
    . $PSScriptRoot\Override.ps1
}
