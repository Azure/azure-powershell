// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.EventGrid.Test.ScenarioTests;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.EventGrid.Test.ScenarioTests
{
    public class SystemTopicEventSubscriptionTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public SystemTopicEventSubscriptionTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        /* this test passes in local in both playback and record but fails in pipeline
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SystemTopicEventSubscriptionTests_CRUDTest()
        {
            EventGridController.NewInstance.RunPsTest(_logger, "SystemTopicEventSubscriptionTests");
        }*/
    }
}
