# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Full Consumer Invitation CRUD cycle
#>

function Test-ConsumerInvitationCrud
{
	$InvitationId = "694e289a-8430-4d46-bd4a-2c61f467fe6f"
	$Location = "eastus2"

	$consumerInvitation = Get-AzDataShareReceivedInvitation -Location $Location -InvitationId $InvitationId

	Assert-NotNull $consumerInvitation
	Assert-AreEqual $InvitationId $consumerInvitation.InvitationId
	Assert-AreEqual $Location $consumerInvitation.Location
}