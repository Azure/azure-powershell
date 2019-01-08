using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Diagnostics;
using System.Threading;

namespace Microsoft.Azure.Commands.DevTestLabs.Test.ScenarioTests
{
    public class DevTestLabsTestFixture : RMTestBase, IDisposable
    {
        private string _resourceGroupName;
        private string _labName;
        private DevTestLabsController _controller;

        private SynchronizationContext _synchronizationContext;

        public DevTestLabsController Controller
        {
            get
            {
                Init();

                return _controller;
            }
        }

        public void Init()
        {
            if (_resourceGroupName != null)
            {
                return;
            }

            _synchronizationContext = SynchronizationContext.Current;

            _controller = DevTestLabsController.NewInstance;

            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _controller.RunPsTestWorkflow(
                () => new[] { "Setup-Test-ResourceGroup " + _resourceGroupName + " " + _labName },
                // custom initializer
                () =>
                {
                    _resourceGroupName = GenerateName();
                    _labName = GenerateName();
                },
                // no custom cleanup
                null,
                callingClassType,
                mockName);
        }

        public void RunTest(string testName)
        {
            var sf = new StackTrace().GetFrame(2);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            Init();
            var scripts = new[] { "Setup-Test-Vars " + _resourceGroupName + " " + _labName, testName };

            Controller.RunPsTestWorkflow(
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup
                null,
                callingClassType,
                mockName);
        }

        public void Dispose()
        {
            SynchronizationContext.SetSynchronizationContext(_synchronizationContext);
            _controller?.RunPsTest("Destroy-Test-ResourceGroup " + _resourceGroupName);
        }

        private static string GenerateName()
        {
            return Microsoft.Azure.Test.HttpRecorder.HttpMockServer.GetAssetName("DevTestLabsTests", "onesdk");
        }
    }
}