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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.TSql
{
    internal sealed class MockSettings
    {
        /// <summary>
        /// Gets or sets the id for the mock
        /// </summary>
        private string mockId;

        /// <summary>
        /// Whether we are in recording mode or not
        /// </summary>
        private bool recordingMode;

        ///// <summary>
        ///// The sql connection string being used
        ///// </summary>
        //private string sqlConnectionString;

        /// <summary>
        /// Where to save the recordings
        /// </summary>
        private string outputPath;

        /// <summary>
        /// Whether to use isolated queries
        /// </summary>
        private bool isolatedQueries;

        /// <summary>
        /// Delegate to be called when initializing a sql connection
        /// </summary>
        private SetupMethodDelegate initializeMethod;

        /// <summary>
        /// Called when closing a sql connection
        /// </summary>
        private SetupMethodDelegate cleanupMethod;

        /// <summary>
        /// Called to do test setup
        /// </summary>
        /// <param name="connection"></param>
        public delegate void SetupMethodDelegate(SqlConnection connection);

        /// <summary>
        /// Constructor
        /// </summary>
        private MockSettings()
        {
        }

        /// <summary>
        /// Gets the mock id
        /// </summary>
        public string MockId
        {
            get { return this.mockId; }
        }

        /// <summary>
        /// Gets the current recording mode
        /// </summary>
        public bool RecordingMode
        {
            get { return this.recordingMode; }
        }

        /// <summary>
        /// Gets the output path for the test recordings
        /// </summary>
        public string OutputPath
        {
            get { return this.outputPath; }
        }

        /// <summary>
        /// Gets whether or not isolated queries are used
        /// </summary>
        public bool IsolatedQueries
        {
            get { return this.isolatedQueries; }
        }

        /// <summary>
        /// Gets the initialize delegate
        /// </summary>
        public SetupMethodDelegate InitializeMethod
        {
            get { return this.initializeMethod; }
        }

        /// <summary>
        /// Gets the cleanup delegate
        /// </summary>
        public SetupMethodDelegate CleanupMethod
        {
            get { return this.cleanupMethod; }
        }

        /// <summary>
        /// Gets all the settings for the mock session
        /// </summary>
        /// <returns></returns>
        public static MockSettings RetrieveSettings()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame[] stackFrames = stackTrace.GetFrames();

            var testMethodFrames = (
                from StackFrame frame in stackFrames
                where (frame.GetMethod().GetCustomAttribute<TestMethodAttribute>() != null) ||
                      (frame.GetMethod().GetCustomAttribute<TestInitializeAttribute>() != null) ||
                      (frame.GetMethod().GetCustomAttribute<TestCleanupAttribute>() != null) ||
                      (frame.GetMethod().GetCustomAttribute<ClassInitializeAttribute>() != null) ||
                      (frame.GetMethod().GetCustomAttribute<ClassCleanupAttribute>() != null)
                select frame).ToArray();

            StackFrame testMethodFrame = testMethodFrames.FirstOrDefault();
            MockSettings settings = new MockSettings();

            if (testMethodFrame != null)
            {
                settings.mockId = GetMockId(testMethodFrame);

                RecordMockDataResultsAttribute recordAttr = FindRecordMockDataResultsAttribute(testMethodFrame);
                if (recordAttr != null)
                {
                    settings.recordingMode = true;
                    settings.outputPath = recordAttr.OutputPath;
                    settings.isolatedQueries = recordAttr.IsolatedQueries;
                }
            }
            else
            {
                // Leave the rest of settings as defaults (nulls and false)
            }

            return settings;
        }

        private static RecordMockDataResultsAttribute FindRecordMockDataResultsAttribute(StackFrame testMethodFrame)
        {
            MethodBase testMethod = testMethodFrame.GetMethod();

            // Try to find RecordMockDataResultsAttribute.
            // 1) On the method:
            RecordMockDataResultsAttribute recordAttr = testMethod.GetCustomAttribute<RecordMockDataResultsAttribute>();

            // 2) On nearest of the enclosing types.
            if (recordAttr == null)
            {
                for (Type currentType = testMethod.DeclaringType; currentType != null; currentType = currentType.DeclaringType)
                {
                    recordAttr = currentType.GetCustomAttribute<RecordMockDataResultsAttribute>();

                    if (recordAttr != null)
                        break;
                }
            }

            // 3) On the test assembly
            if (recordAttr == null)
            {
                recordAttr = testMethod.DeclaringType.Assembly.GetCustomAttribute<RecordMockDataResultsAttribute>();
            }

            // 4) On the executing assembly
            if (recordAttr == null)
            {
                recordAttr = Assembly.GetExecutingAssembly().GetCustomAttribute<RecordMockDataResultsAttribute>();
            }

            return recordAttr;
        }

        private static string GetMockId(StackFrame testMethodFrame)
        {
            List<string> parts = new List<string>();

            parts.Insert(0, testMethodFrame.GetMethod().Name);
            for (Type type = testMethodFrame.GetMethod().DeclaringType; type != null; type = type.DeclaringType)
            {
                parts.Insert(0, type.Name);
            }
            
            return String.Join(".", parts.ToArray());
        }
    }
}
