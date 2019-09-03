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

<#
.SYNOPSIS
Tests the general sku name completer
#>
function Test-SkuNameCompleter {
    $skuNames = [Microsoft.Azure.Commands.Management.Compute.ArgumentCompleters.VmScaleSetSkuCompleterAttribute]::GetSkuNames()
    Assert-True { $skuNames.Count -gt 0 }
    Assert-True { $skuNames.Contains("Standard_A0") }
}


<#
.SYNOPSIS
Tests the vmss-specific sku name completer
#>
function Test-AvailableSkuNameCompleter {
    $skuNames = [Microsoft.Azure.Commands.Management.Compute.ArgumentCompleters.AvailableVmScaleSetSkuCompleterAttribute]::GetSkuNames("ForSkuTest", "VmssForSkuTest")
    Assert-True { $skuNames.Count -gt 0 }
    Assert-False { $skuNames.Contains("Standard_A0") }
    Assert-True { $skuNames.Contains("Standard_B1ls") }
}
