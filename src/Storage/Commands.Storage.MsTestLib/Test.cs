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

namespace MS.Test.Common.MsTestLib
{
    public static class Test
    {
        public static string TestDataFile;
        public static TestConfig Data;
        public static TestLogger Logger;
        public static int TestCount = 0;
        public static int FailCount = 0;

        public static string FullClassName = string.Empty;
        public static string MethodName = string.Empty;

        public static int ErrorCount = 0;

        public static List<String> FailedCases = null;

        public static void Init()
        {
            Data = new TestConfig(TestDataFile);
            Logger = new TestLogger(Data);
            FailedCases = new List<string>();
        }

        public static void Init(string testDataFile)
        {
            Data = new TestConfig(testDataFile);
            Logger = new TestLogger(Data);
            FailedCases = new List<string>();
        }

        public static void Close()
        {
            Logger.Close();
        }

        public static void Info(
            string msg,
            params object[] objToLog)
        {
            Logger.Info(msg, objToLog);
        }

        public static void Warn(
        string msg,
        params object[] objToLog)
        {
            Logger.Warning(msg, objToLog);
        }

        public static void Verbose(
        string msg,
        params object[] objToLog)
        {
            Logger.Verbose(msg, objToLog);
        }

        public static void Error(
        string msg,
        params object[] objToLog)
        {
            ErrorCount++;
            Logger.Error(msg, objToLog);
        }

        public static void Assert(bool condition,
            string msg,
            params object[] objToLog)
        {
            if (condition)
            {
                Verbose("[Assert Pass] " + msg, objToLog);
            }
            else
            {
                Error("[Assert Fail] " + msg, objToLog);
            }
        }

        public static void Start(string testClass, string testMethod)
        {
            TestCount++;
            ErrorCount = 0;
            Logger.StartTest(testClass + "." + testMethod);
            Test.FullClassName = testClass;
            Test.MethodName = testMethod;
        }

        public static void End(string testClass, string testMethod)
        {
            if (ErrorCount == 0)
            {
                Logger.EndTest(testClass + "." + testMethod, TestResult.PASS);
            }
            else
            {
                FailCount++;
                Logger.EndTest(testClass + "." + testMethod, TestResult.FAIL);
                AssertFail(string.Format("There " + (ErrorCount > 1 ? "are {0} errors" : "is {0} error") + " so the case fails. Please check the detailed case log.", ErrorCount));
                FailedCases.Add(String.Format("{0}.{1}", testClass, testMethod));
            }

        }

        public static AssertFailDelegate AssertFail;

    }

    public delegate void AssertFailDelegate(string msg);
}
