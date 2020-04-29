# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Full Share Subscription CRUD cycle
#>
function Test-ShareSubscriptionCrud
{
    $resourceGroup = getAssetName

	try{
		$AccountName = getAssetName
		$ShareSubscriptionName = getAssetName
		$InvitationId = "80f618dc-2ca8-4f99-83ee-9d2889066c6d"
		$SourceShareLocation = "eastus2"
		$createdShareSubscription = New-AzDataShareSubscription -AccountName $AccountName -ResourceGroupName $resourceGroup -Name $ShareSubscriptionName -InvitationId $InvitationId -SourceShareLocation $SourceShareLocation

		Assert-NotNull $createdShareSubscription
		Assert-AreEqual $ShareSubscriptionName $createdShareSubscription.Name
		Assert-AreEqual "Active" $createdShareSubscription.ShareSubscriptionStatus
		Assert-AreEqual $InvitationId $createdShareSubscription.InvitationId
		Assert-AreEqual $SourceShareLocation $createdShareSubscription.SourceShareLocation
		Assert-AreEqual "Succeeded" $createdShareSubscription.ProvisioningState

		$retrievedShareSubscription = Get-AzDataShareSubscription -AccountName $AccountName -ResourceGroupName $resourceGroup -Name $ShareSubscriptionName

		Assert-NotNull $retrievedShareSubscription
		Assert-AreEqual $ShareSubscriptionName $retrievedShareSubscription.Name
		Assert-AreEqual "Succeeded" $retrievedShareSubscription.ProvisioningState
		Assert-AreEqual "Active" $retrievedShareSubscription.ShareSubscriptionStatus

		$removed = Remove-AzDataShareSubscription -AccountName $AccountName -ResourceGroupName $resourceGroup -Name $ShareSubscriptionName -PassThru

		Assert-True { $removed }
		Assert-ThrowsContains { Get-AzDataShareSubscription -AccountName $AccountName -ResourceGroupName $resourceGroup -Name $ShareSubscriptionName } "Resource 'pssharesub1' does not exist"
	}
    finally
	{
		Remove-AzResourceGroup -Name $resourceGroup -Force
	}
}
