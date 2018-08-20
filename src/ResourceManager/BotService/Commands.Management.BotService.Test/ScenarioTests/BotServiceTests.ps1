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
Test NewAzureRmBot
#>
function Test-NewAzureRmBot
{
    # Setup
    $rgname = Get-BotServiceTestResourceName;

    try
    {
		$rgname = 'psbottestname'
        # Test
        $skuname = 'F0';
		
        New-AzureRmResourceGroup -Name $rgname -Location "West US";
		$appId = New-Guid
		$appIdString = $appId.tostring()
        $bot = New-AzureRmBot -ResourceGroupName $rgname -Name $rgname -DisplayName "Test bot" -Description "Bot Description" -Endpoint "https://testbot.net" -MsaAppId $appIdString -SkuName $skuname $loc -Force;
        Assert-NotNull $bot;
        
        Retry-IfException { Remove-AzureRmBot-ResourceGroupName $rgname -Name $rgname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test GetAzureRmBot
#>
function Test-GetAzureRmBot
{
    # Setup
    $rgname = Get-BotServiceTestResourceName;

    try
    {
		$rgname = 'psbottestname'
        # Test
        $skuname = 'F0';
        New-AzureRmResourceGroup -Name $rgname -Location "West US";
		$appId = New-Guid
		$appIdString = $appId.tostring()
        $bot = New-AzureRmBot -ResourceGroupName $rgname -Name $rgname -DisplayName "Test bot" -Description "Bot Description" -Endpoint "https://testbot.net" -MsaAppId $appIdString -SkuName $skuname $loc -Force;
        Assert-NotNull $bot;
        
		$retrievedbot = Get-AzureRmBot -ResourceGroupName $rgname -Name $rgname

		Assert-AreEqual $bot.Name $retrievedbot.Name
		Assert-AreEqual $bot.Id $retrievedbot.Id

        Retry-IfException { Remove-AzureRmBot-ResourceGroupName $rgname -Name $rgname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test GetAzureRmBotNonExistingBotExistingResourceGroup
#>
function Test-GetAzureRmBotNonExistingBotExistingResourceGroup
{
    # Setup
    $rgname = Get-BotServiceTestResourceName;

    try
    {
		$rgname = 'psbottestname'
        New-AzureRmResourceGroup -Name $rgname -Location "West US";
		$retrievedbot = Get-AzureRmBot -ResourceGroupName $rgname -Name $rgname -ErrorAction SilentlyContinue

		Assert-Null $retrievedbot        
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test RemoveAzureRmBot
#>
function Test-RemoveAzureRmBot
{
    # Setup
    $rgname = Get-BotServiceTestResourceName;

    try
    {
		$rgname = 'psbottestname'
        # Test
        $skuname = 'F0';

        New-AzureRmResourceGroup -Name $rgname -Location "West US";
		$appId = New-Guid
		$appIdString = $appId.tostring()
        $bot = New-AzureRmBot -ResourceGroupName $rgname -Name $rgname -DisplayName "Test bot" -Description "Bot Description" -Endpoint "https://testbot.net" -MsaAppId $appIdString -SkuName $skuname $loc -Force;
        Assert-NotNull $bot;
        
		Remove-AzureRmBot -ResourceGroupName $rgname -Name $rgname

		# Verify bot was deleted
		$retrievedbot = Get-AzureRmBot -ResourceGroupName $rgname -Name $rgname -ErrorAction SilentlyContinue
		Assert-Null $retrievedbot

        Retry-IfException { Remove-AzureRmBot-ResourceGroupName $rgname -Name $rgname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
