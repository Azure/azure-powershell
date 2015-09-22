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

Import-Module azure
.".\Emulator.ps1"
$global:totalCount = 0;
$global:passedCount = 0;

function Run-TestProtected
{
   param([ScriptBlock]$script, [string] $testName)
   try 
   {
     Write-Host  -ForegroundColor Green =====================================
	 Write-Host  -ForegroundColor Green "Running test $testName"
     Write-Host  -ForegroundColor Green =====================================
	 Write-Host
     &$script
	 $global:passedCount = $global:passedCount + 1
	 Write-Host
     Write-Host  -ForegroundColor Green =====================================
	 Write-Host -ForegroundColor Green "Test Passed"
     Write-Host  -ForegroundColor Green =====================================
	 Write-Host
   }
   catch
   {
     Out-String -InputObject $_.Exception | Write-Host -ForegroundColor Red
	 Write-Host
     Write-Host  -ForegroundColor Red =====================================
	 Write-Host -ForegroundColor Red "Test Failed"
     Write-Host  -ForegroundColor Red =====================================
	 Write-Host
   }
   finally
   {
      $global:totalCount = $global:totalCount + 1
   }
}
Run-TestProtected {Run-Test {Test-PHPServiceCreation} ".\emtest002.log"} "Emulator PHP Hello World Scenario"
Run-TestProtected {Run-Test {Test-PHPHelloInEmulator}} "Emulator PHP Hello World Scenario"
Write-Host
Write-Host -ForegroundColor Green "$global:passedCount / $global:totalCount Emulator Tests Pass"
Write-Host

