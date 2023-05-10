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

# Automation account information
$resourceGroupName = "py3-RG"
$automationAccountName = "py3-aa123"
$py3PackageName = "py3-package"
$contentLinkUri = "https://files.pythonhosted.org/packages/7f/e2/85dfb9f7364cbd7a9213caea0e91fc948da3c912a2b222a3e43bc9cc6432/requires.io-0.2.6-py2.py3-none-any.whl"


function Test-E2EPython3Packages
{
    $expectedPython3Package = @{
        ResourceGroupName = $resourceGroupName
        AutomationAccountName = $automationAccountName
        Name = $py3PackageName
    }

    New-AzAutomationPython3Package -ResourceGroupName $resourceGroupName `
                                              -AutomationAccountName $automationAccountName  `
                                              -Name $py3PackageName   `
                                              -ContentLinkUri $contentLinkUri `
                                              -ErrorAction SilentlyContinue

    $py3Package = Get-AzAutomationPython3Package -ResourceGroupName $resourceGroupName `
                                                     -AutomationAccountName $automationAccountName  `
                                                     -Name $py3PackageName 

    Assert-AreEqual $py3Package.name $expectedPython3Package.Name

	# Remove the py3 package
	Remove-AzAutomationPython3Package -ResourceGroupName $resourceGroupName `
                                              -AutomationAccountName $automationAccountName  `
                                              -Name $py3PackageName -Force 
	
	# Make sure it was the py3 package was deleted
	$group = Get-AzAutomationPython3Package -ResourceGroupName $resourceGroupName `
                                              -AutomationAccountName $automationAccountName  `
                                              -Name $py3PackageName `
                                              -ErrorAction SilentlyContinue

    Assert-True {$group -eq $null} "Fail to remove Python 3 package '$py3PackageName'"
}

