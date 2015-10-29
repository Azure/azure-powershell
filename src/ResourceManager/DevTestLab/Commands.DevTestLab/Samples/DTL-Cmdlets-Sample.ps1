# Import the private AzureRM cmdlets.
# Note: This is a temporary step, until the DTL cmdlets are formally integrated into Azure Powershell.
# Note: Please ensure that this script is run from the "src\Package\{Debug|Release}\ResourceManager\AzureResourceManager\AzureRM.DevTestLab\Samples" folder
Import-Module $PSScriptRoot\..\..\AzureResourceManager.psd1 -Verbose

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
Get-AzureDtlLab -verbose


#################################################
# 
# Cmdlets for "VM Templates"
#
#################################################

Get-AzureDtlVMTemplate -verbose

#################################################
# 
# Cmdlets for "Environments"
#
#################################################

Get-AzureDTLEnvironment -verbose

# 
# 
#


New-AzureDtlEnvironment -EnvironmentName "REPLACE-WITH-YOUR-ENV-NAME" -UserName "REPLACE-WITH-YOUR-USERNAME" -Password "REPLACE-WITH-YOUR-PASSWORD" -ResourceGroupName "REPLACE-WITH-YOUR-LAB-RESOURCEGROUP" -LabName "REPLACE-WITH-YOUR-LAB-NAME" -Location "East Asia" -VMTemplateName "REPLACE-WITH-YOUR-VMTEMPLATE-NAME" -VMSize Standard_A4 -Verbose