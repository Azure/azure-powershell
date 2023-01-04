# Best Practices for Test Framework

In this article, it describes the best practices when writing Azure PowerShell test cases that leverage the test framework. Currently, the test framework only supports SDK based cmdlets including AutoRest generated SDK modules.



## Use testcredentials.json over environment variable

The article [Using Test Framework](https://github.com/Azure/azure-powershell/blob/main/documentation/testing-docs/using-azure-test-framework.md) describes two ways to setup test environment. One is to use the testcredentials.json and the other is to use the environment variable. We recommend opting for the testcredentials.json as switching between test modes is very common. And it requires restarting Visual Studio to make the change take effect after updating the value of the connection string in the environment variable.



## Encourage writing PowerShell code for all test cases

In order to maximally stimulate the real scenarios, we highly recommand writing all test cases using PowerShell script. In addition, this can help expose as more issues as possible at the first time. Any C# code sending backend requests or running with the test script may result in hiding issues in Azure PowerShell cmdlets.



## Use getAssetName to generate random resource name over hard-coded name

If a resource has a hard-coded name in the test case, the next time when this test needs to record again, it usually will fail since either the pre-created resource has been removed or the resource with the same name already exists. Using **getAssetName** function to generate a random name for any resource can help avoid this kind of issue.



## Use Start-TestSleep instead of Start-Sleep

Sometimes when recording a test scenario, sleeping until all the resources to be ready is crucial. However, in playback mode, waiting for such period of time is meaningless. **Start-TestSleep** function was born to resolve this problem. In record mode, it will wait for specified time while in playback mode, no time will elapse for waiting. Invoke **Start-TestSleep** whenever you think **Start-Sleep** is necessary.



## Leverage assertions in Assert.ps1

Assert.ps1 in the test framework contains plenty of assertion functions. Use the functions defined there instead of writing your own assertion logic. If you see none of them can meet your requirement, please contact us.



## Use appropriate property. Skip V.S. LiveOnly

Although **Skip** property of **Fact** attribute and **LiveOnly** property of **Trait** attribute can make the same effect, they totally have different meaning for a test case. **Skip** indicates the test case is not fully ready and will be modified later so that skipping running the test for the time being. **LiveOnly** indicates the test case is ready but due to some reason, it does not support recording and playback so that skipping running the test. Otherwise, the CI will fail. Please choose the right property to reflect the real state of the test.



## Consider implememting WithInitAction, WithMockContextAction, WithCleanupAction in TestRunner for all test cases

As mentioned above, they don't recommand writing C# code in the test. If you must use C# code to perform common actions for all the test cases, you can consider implementing following delegate methods in the TestRunner.

- **WithInitAction**: Invoked before mock context is initialized

- **WIthMockContextAction**: Invoked just after mock context is initialized

- **WithCleanupAction**: Invoked after the test case is executed but before disposing the mock context



## Consider passing parameters setUp, contextAction, tearDown to RunTestScript method for individual test case

Except for above delegates that apply to all the test cases, test framework also provides fine granularity that only take effect on specified test case. You can consider passing following delegates as parameters to the method **RunTestScript**.

- **setUp**: Invoked before mock context is initialized (same as WithInitAction)

- **contextAction**: Invoked just before executing the test script

- **tearDown**: Invoked after the test case is executed but before disposing the mock context (same as WithCleanupAction)



## Consider using method WithManagementClients if you have special logic for service client

In most of the scenarios, a service client initialized with all default values is enough. If you have to customize the service client object with properties other than the default values, you can consider implementing the delegate method **WithManagementClients** in the TestRunner. The object initialized in this method won't be re-populated.



## After recording all test cases, change the test mode from Record to Playback and execute all tests again

All test cases run successfully in record mode does not mean they will also succeed in playback mode because it may have something wrong in the recorded json files. In addition, in the CI for Azure PowerShell repo, we only run tests in playback mode after submitting a new PR. So running the test cases again in playback mode is a good practice to confirm it would also pass in the CI.
