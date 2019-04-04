using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net.Http;

namespace Microsoft.Azure.Commands.DataLake.Test.ScenarioTests
{
    public class AdlMockContext : MockContext
    {
        public new static MockContext Start(
            string className,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName= "testframework_failed")
        {
            var context = new AdlMockContext();
            if (HttpMockServer.FileSystemUtilsObject == null)
            {
                HttpMockServer.FileSystemUtilsObject = new Microsoft.Azure.Test.HttpRecorder.FileSystemUtils();
            }
            HttpMockServer.Initialize(className, methodName);
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                context.disposed = false;
            }

            return context;
        }

        public DelegatingHandler[] GetDelegatingHAndlersForDataPlane(TestEnvironment currentEnvironment,
            params DelegatingHandler[] existingHandlers)
        {
            return base.AddHandlers(currentEnvironment, existingHandlers);
        }
    }
}
