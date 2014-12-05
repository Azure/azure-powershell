//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Commands.StorSimple.Test.ScenarioTests
//{
//    public sealed class StorSimplerController
//    {

//        private CSMTestEnvironmentFactory csmTestFactory;
//        private EnvironmentSetupHelper helper;
//        protected const string TenantIdKey = "TenantId";
//        protected const string DomainKey = "Domain";
//        public GraphRbacManagementClient GraphClient { get; private set; }
//        public ResourceManagementClient ResourceManagementClient { get; private set; }
//        public SubscriptionClient SubscriptionClient { get; private set; }
//        public GalleryClient GalleryClient { get; private set; }
//        public EventsClient EventsClient { get; private set; }
//        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }
//        public string UserDomain { get; private set; }
//        public static ResourcesController NewInstance
//        {
//            get
//            {
//                return new ResourcesController();
//            }
//        }
//        public StorSimplerController()
//        {
//            helper = new EnvironmentSetupHelper();
//        }
//        public void RunPsTest(params string[] scripts)
//        {
//        var callingClassType = TestUtilities.GetCallingClass(2);
//        var mockName = TestUtilities.GetCurrentMethodName(2);
//        RunPsTestWorkflow(
//        () => scripts,
//        // no cutom initializer
//        null,
//        // no custom cleanup
//        null,
//        callingClassType,
//        mockName);
//        }
//        public void RunPsTestWorkflow(
//        Func<string[]> scriptBuilder,
//        Action<CSMTestEnvironmentFactory> initialize,
//        Action cleanup,
//        string callingClassType,
//        string mockName)
//        {
//        using (UndoContext context = UndoContext.Current)
//        {
//        context.Start(callingClassType, mockName);
//        this.csmTestFactory = new CSMTestEnvironmentFactory();
//        if(initialize != null)
//        {
//        initialize(this.csmTestFactory);
//        }
//        SetupManagementClients();
//        helper.SetupEnvironment(AzureModule.AzureResourceManager);
//        var callingClassName = callingClassType
//        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
//        .Last();
//        helper.SetupModules(
//        AzureModule.AzureResourceManager,
//        "ScenarioTests\\Common.ps1",
//        "ScenarioTests\\" + callingClassName + ".ps1");
//        try
//        {
//        if (scriptBuilder != null)
//        {
//        var psScripts = scriptBuilder();
//        if (psScripts != null)
//        {
//        helper.RunPowerShellTest(psScripts);
//        }
//        }
//        }
//        finally
//        {
//        if(cleanup !=null)
//        {
//        cleanup();
//        }
//        }
//        }
//        }
//private void SetupManagementClients()
//{
//ResourceManagementClient = GetResourceManagementClient();
//SubscriptionClient = GetSubscriptionClient();
//GalleryClient = GetGalleryClient();
//EventsClient = GetEventsClient();
//AuthorizationManagementClient = GetAuthorizationManagementClient();
//GraphClient = GetGraphClient();
//helper.SetupManagementClients(ResourceManagementClient,
//SubscriptionClient,
//GalleryClient,
//EventsClient,
//AuthorizationManagementClient,
//GraphClient);
//}
//private GraphRbacManagementClient GetGraphClient()
//{
//var environment = this.csmTestFactory.GetTestEnvironment();
//string tenantId = null;
//if (HttpMockServer.Mode == HttpRecorderMode.Record)
//{
//tenantId = environment.AuthorizationContext.TenatId;
//UserDomain = environment.AuthorizationContext.UserDomain;
//HttpMockServer.Variables[TenantIdKey] = tenantId;
//HttpMockServer.Variables[DomainKey] = UserDomain;
//}
//else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
//{
//if (HttpMockServer.Variables.ContainsKey(TenantIdKey))
//{
//tenantId = HttpMockServer.Variables[TenantIdKey];
//}
//if (HttpMockServer.Variables.ContainsKey(DomainKey))
//{
//UserDomain = HttpMockServer.Variables[DomainKey];
//}
//}
//return TestBase.GetGraphServiceClient<GraphRbacManagementClient>(this.csmTestFactory, tenantId);
//}
//private AuthorizationManagementClient GetAuthorizationManagementClient()
//{
//return TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
//}
//private ResourceManagementClient GetResourceManagementClient()
//{
//return TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
//}
//private SubscriptionClient GetSubscriptionClient()
//{
//return TestBase.GetServiceClient<SubscriptionClient>(this.csmTestFactory);
//}
//private GalleryClient GetGalleryClient()
//{
//return TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);
//}
//private EventsClient GetEventsClient()
//{
//return TestBase.GetServiceClient<EventsClient>(this.csmTestFactory);
//}

//    }
//}
