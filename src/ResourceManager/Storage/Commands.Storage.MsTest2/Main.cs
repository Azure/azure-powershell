// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;

namespace MS.Test.Common.MsTestLib
{
    class Program
    {
        static int Main(string[] args)
        {

            //parse the commandline
            
            Dictionary<string, string> argsGroup = new Dictionary<string, string>();
            List<string> switchGroup = new List<string>();
            foreach (string arg in args)
            {
                Regex rp = new Regex("(?<=^/).*?(?=:|$)");
                Match pMatch = rp.Match(arg);
                if (pMatch.Success)
                {
                    string paramName = pMatch.Value;
                    Regex rv = new Regex("(?<=(^/.*?:)).*$");
                    Match vMatch = rv.Match(arg);
                    if (vMatch.Success)
                    {
                        string paramValue = vMatch.Value;
                        if (!argsGroup.ContainsKey(paramName))
                        {
                            argsGroup.Add(paramName, paramValue);
                        }
                    }
                    else
                    {
                        if (!switchGroup.Contains(paramName))
                        {
                            switchGroup.Add(paramName);
                        }
                    }

                }

            }
            
            //for -args value -switches type
            string preArg = string.Empty;
            foreach (string arg in args)
            {
                if (arg.StartsWith("-"))
                {
                    string argTrimmed = arg.TrimStart(new char[] { '-' });
                    if (preArg == string.Empty)
                    {
                        if (!switchGroup.Contains(argTrimmed))
                        {
                            switchGroup.Add(argTrimmed);
                            
                        }
                        
                    }
                    preArg = argTrimmed;
                    
                }
                else
                {
                    if (preArg != string.Empty)
                    {
                        if (!argsGroup.ContainsKey(preArg))
                        {
                            argsGroup.Add(preArg, arg);
                            preArg = string.Empty;
                        }
                    }
                    
                }

            }


            string testDllName = string.Empty;
            if (argsGroup.ContainsKey("lib"))
            {
                testDllName = argsGroup["lib"];
            }
            
            string testMethodName = string.Empty;
            List<string> testMethodNames = null;

            if (argsGroup.ContainsKey("case"))
            {
                testMethodName = argsGroup["case"];
                testMethodNames = new List<string>(testMethodName.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }

            string testClassName = string.Empty;
            List<string> testClassNames = null; 
            if (argsGroup.ContainsKey("group"))
            {
                testClassName = argsGroup["group"];
                testClassNames = new List<string>(testClassName.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }

            string testCategory = string.Empty;
            List<string> testCategories = null;
            if (argsGroup.ContainsKey("tag"))
            {
                testCategory = argsGroup["tag"];
                testCategories = new List<string>(testCategory.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }

            string testDataFile = string.Empty;
            if (argsGroup.ContainsKey("config"))
            {
                testDataFile = argsGroup["config"];
                Test.TestDataFile = testDataFile;
            }

            int testCaseReRunCount = 0;
            if (argsGroup.ContainsKey("rerun"))
            {
                testCaseReRunCount = int.Parse(argsGroup["rerun"]);
            }
            

            if (argsGroup.Count ==0 || string.IsNullOrEmpty(testDllName))
            {
                PrintHelp();
                return -9009;
            }
            
            Assembly testAssembly = Assembly.LoadFrom(testDllName);
            
            TestClassUnit[] testClasses = TestClassUnit.GetTestGroupUnits(testAssembly);
            
            //filter the test cases 
            
            if (string.IsNullOrEmpty(testClassName) && string.IsNullOrEmpty(testMethodName) && string.IsNullOrEmpty(testCategory))
            {
                // no fileter
            }
            else
            {
                foreach (TestClassUnit testClass in testClasses)
                {

                    if (testClassNames == null)
                    {
                    }
                    else
                    {

                        if (testClassNames.Contains(testClass.Name))
                        {
                        }
                        else
                        {
                            testClass.Enable = false;
                            continue;
                        }
                    }

                    foreach (TestMethodUnit testMethod in testClass.TestCaseUnits)
                    {
                        if (testMethodNames == null)
                        {
                        }
                        else
                        {
                            if (testMethodNames.Contains(testMethod.Name))
                            {
                            }
                            else
                            {
                                testMethod.Enable = false;
                                continue;
                            }
                        }

                        if (testCategories != null)
                        {

                            if (testMethod.Tag != null && testCategories.Intersect<string>(testMethod.Tag).Count<string>() > 0)
                            {
                            }
                            else
                            {
                                testMethod.Enable = false;
                            }
                        }

                    }

                    //count the active test cases
                    foreach (TestMethodUnit testMethod in testClass.TestCaseUnits)
                    {
                        if (testMethod.Enable == true)
                        {
                            testClass.ActiveCases++;
                        }
                    }

                }
                
            }


            //if 'list' is specified, only list the enabled test cases
            if (switchGroup.Contains("list"))
            {

                foreach (TestClassUnit testClass in testClasses)
                {
                    if (testClass.AssemblyInitMethod != null)
                    {
                        Console.WriteLine("[Test Init] : {0}", testClass.AssemblyInitMethod.Name);
                    }
                }

                int totalCases = 0;
                foreach (TestClassUnit testClass in testClasses)
                {
                    Console.WriteLine("[Test Class] : {0}", testClass.Name);

                    foreach (TestMethodUnit testMethod in testClass.TestCaseUnits)
                    {
                        Console.WriteLine("      [Test Method] {0} {1}", testMethod.Name, testMethod.Enable ? "Enabled" : "Disabled");
                    }

                    Console.WriteLine("[Active Cases] : {0}", testClass.ActiveCases);
                    totalCases += testClass.ActiveCases;
                }
                
                foreach (TestClassUnit testClass in testClasses)
                {
                    if (testClass.AssemblyCleanupMethod != null)
                    {
                        Console.WriteLine("[Test Cleanup] : {0}" , testClass.AssemblyCleanupMethod.Name);
                    }
                }

                Console.WriteLine("[Test Total] : {0}", totalCases);

                return 0;
                
            }
            

            //execute assembly init
            foreach (TestClassUnit testClass in testClasses)
            {
                if (testClass.AssemblyInitMethod != null)
                {
                    try
                    {
                        testClass.AssemblyInitMethod.Invoke(null, new object[] { new TestContext2() });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception in AssemblyInit : {0}", e.ToString());
                        return -1;
                    }
                    // overwrite the delegate for AssertFail
                    Test.AssertFail= new AssertFailDelegate ((string a)=>{});
                }
            }

            

            //execute test classes and test methods

            foreach (TestClassUnit testClass in testClasses)
            {
                //init the class
                if (!testClass.Enable || testClass.ActiveCases == 0)
                {
                    continue;
                }

                
                TestContext2 testContext = new TestContext2 ();
                testContext.fullyQualifiedTestClassName= testClass.TestGroupClass.FullName;


                bool classInitOK = true;
                if (testClass.ClassInitMethod != null)
                {
                    try
                    {

                        testClass.ClassInitMethod.Invoke(null, new object[] { testContext });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Class {0} init exception : {1}", testClass.Name, e.ToString());
                        classInitOK = false; // this means to skip the method execution but still do the cleanup
                    }
                }

                if (classInitOK)
                {

                    object testObject = Activator.CreateInstance(testClass.TestGroupClass);
                    PropertyInfo pInfo = testClass.TestGroupClass.GetProperty("TestContext");
                    if (pInfo != null)
                    {
                        pInfo.SetValue(testObject, testContext, null);
                    }

                    foreach (TestMethodUnit testMethod in testClass.TestCaseUnits)
                    {

                        if (!testMethod.Enable)
                        {
                            continue;
                        }

                        //init the test method
                        testContext.testName = testMethod.TestCase.Name;
                        if (pInfo != null)
                        {
                            pInfo.SetValue(testObject, testContext, null);
                        }

                        // rerun the case if rerunCount > 0

                        for (int cr = 0; cr <= testCaseReRunCount; cr++)
                        {

                            bool testInitOK = true;

                            if (testClass.TestInitMethod != null)
                            {
                                try
                                {
                                    testClass.TestInitMethod.Invoke(testObject, new object[] { });
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Method {0} init exception : {1}", testMethod.Name, e.ToString());
                                    testInitOK = false;
                                }
                            }

                            if (testInitOK)
                            {
                                // deal with timeout


                                TestThreadArgs threadArgs = new TestThreadArgs();
                                threadArgs.InnerException = null;
                                threadArgs.TestExecutionDone = new AutoResetEvent(false);
                                threadArgs.TestObject = testObject;
                                threadArgs.Method = testMethod.TestCase;


                                Thread testThread = new Thread(threadArgs.TestCase);

                                testThread.SetApartmentState(System.Threading.ApartmentState.STA);
                                testThread.Start();

                                bool executionResult = false;
                                if (testMethod.Timeout <= 0)
                                {
                                    executionResult = threadArgs.TestExecutionDone.WaitOne(Timeout.Infinite, false);
                                }
                                else
                                {
                                    executionResult = threadArgs.TestExecutionDone.WaitOne(testMethod.Timeout, false);
                                }

                                if (!executionResult)
                                {
                                    testThread.Abort();
                                    Console.WriteLine("Test Case execution is too long, timeout happens and testing aborted, expected runtime: " + testMethod.Timeout + " milliseconds");
                                    Test.Error("Test {0} timeout after {1} ms.", testMethod.Name, testMethod.Timeout);
                                }
                                else
                                {
                                    if (threadArgs.InnerException != null)
                                    {
                                        Console.WriteLine("Test Case execution throws exception {0}", threadArgs.InnerException.ToString());
                                        Test.Error("Test Case execution throws exception {0}", threadArgs.InnerException.ToString());

                                        if (threadArgs.InnerException is TestPauseException)
                                        {
                                            // if test pause exception is thrown, pause the test run to wait for investigation
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.Write("Test run is paused for TestPauseException is thrown in the case. Press ESC to continue the run after investigation.");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                            ConsoleKeyInfo ki;
                                            do
                                            {
                                                ki = Console.ReadKey(true);

                                            } while (ki.Key != ConsoleKey.Escape);

                                        }
                                    }
                                }

                            }

                            //cleanup the test method
                            if (testClass.TestCleanupMethod != null)
                            {
                                try
                                {
                                    testClass.TestCleanupMethod.Invoke(testObject, new object[] { });
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Method {0} cleanup exception : {1}", testMethod.Name, e.ToString());
                                }
                            }

                        }
                        // case rerun

                    }

                }

                //cleanup the class

                if (testClass.ClassCleanupMethod != null)
                {
                    try
                    {
                        testClass.ClassCleanupMethod.Invoke(null, new object[] { });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Class {0} cleanup exception : {1}", testClass.Name, e.ToString());
                        
                    }
                }

            }


            //execute assembly cleanup

            foreach (TestClassUnit testClass in testClasses)
            {
                if (testClass.AssemblyCleanupMethod != null)
                {
                    testClass.AssemblyCleanupMethod.Invoke(null, new object[] { });
                }
            }

            Console.WriteLine("===Result Summary===");
            Console.WriteLine("Total Run : {0}", Test.TestCount);
            Console.WriteLine("Pass : {0}", Test.TestCount - Test.FailCount);
            Console.WriteLine("Fail : {0}", Test.FailCount);
            if (Test.FailedCases.Count > 0)
            {
                Console.WriteLine("===Failed Cases===");
                foreach(var c in Test.FailedCases)
                {
                    Console.WriteLine("CaseName: {0}", c);
                }
                Console.WriteLine("==================");
            }
            return Test.FailCount;
        }

        static void PrintHelp()
        {
            Console.WriteLine("MSTest2.exe /lib:[testlib.dll] /group:[FullTestClassName] /case:[TestMethodName] /tag:[TestCategoryName] /config:[TestDataFile] /rerun:[CaseReRunCount] [/list]");
            Console.WriteLine("MSTest2.exe -lib [testlib.dll] -group [FullTestClassName] -case [TestMethodName] -tag [TestCategoryName] -config [TestDataFile] -rerun [CaseReRunCount] [-list]");
        }
    }


    public class TestThreadArgs
    {
        private Exception innerException;

        public Exception InnerException
        {
            get { return innerException; }
            set { innerException = value; }
        }

        private AutoResetEvent testExecutionDone;

        public AutoResetEvent TestExecutionDone
        {
            get { return testExecutionDone; }
            set { testExecutionDone = value; }
        }

        private MethodInfo method;

        public MethodInfo Method
        {
            get { return method; }
            set { method = value; }
        }

        private object testObject;

        public object TestObject
        {
            get { return testObject; }
            set { testObject = value; }
        }

        public void TestCase()
        {
            try
            {
                Method.Invoke(TestObject, new object[] { });
            }
            catch (Exception e)
            {
                InnerException = e.InnerException;
            }
            finally
            {
                TestExecutionDone.Set();
            }
        }
    }
   
    
}
