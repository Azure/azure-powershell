# Import the private AzureRM cmdlets.
# Note: This is a temporary step, until the DTL cmdlets are formally integrated into Azure Powershell.
Import-Module C:\Repos\azure-powershell\src\Package\Debug\ResourceManager\AzureResourceManager\AzureResourceManager.psd1 -Verbose

# Login to Azure 
Login-AzureRmAccount

# Select the subscription + tenant to use.
# NOTE: Please replace the TenantId and SubscriptionId values.
Select-AzureRmSubscription -TenantId "REPLACE-WITH-YOUR-TENANT-ID" -SubscriptionId "REPLACE-WITH-YOUR-SUBSCRIPTION-ID"

#################################################
# 
# Cmdlets for "Labs"
#
#################################################

# 
# Get-AzureDTLLab
# 

# Example 1
# Lists all labs under current subscription.
Get-AzureDtlLab


#################################################
# 
# Cmdlets for "VM Templates"
#
#################################################

Get-AzureDtlVMTemplate

#################################################
# 
# Cmdlets for "Environments"
#
#################################################

Get-AzureDTLEnvironment

# 
# 
#


New-AzureDtlEnvironment -EnvironmentName HelloTuesday -UserName SomeAdmin -Password SomePassword! -ResourceGroupName HackathonLabRG -LabName HackathonLab -Location "East Asia" -VMTemplateName "TEMPLATE FOR DTL DEV VM" -VMSize Standard_A4 -Verbose