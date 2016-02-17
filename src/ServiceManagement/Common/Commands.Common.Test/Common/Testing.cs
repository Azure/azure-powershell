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
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Resources;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Common
{
    /// <summary>
    /// Various utilities and helpers to facilitate testing.
    /// </summary>
    /// <remarks>
    /// The name is a compromise for something that pops up easily in
    /// intellisense when using MSTest.
    /// </remarks>
    public static class Testing
    {
        /// <summary>
        /// Ensure an action throws a specific type of Exception.
        /// </summary>
        /// <typeparam name="T">Expected exception type.</typeparam>
        /// <param name="action">
        /// The action that should throw when executed.
        /// </param>
        public static void AssertThrows<T>(Action action)
            where T : Exception
        {
            Debug.Assert(action != null);
            
            try
            {
                action();
                Assert.Fail("No exception was thrown!");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(T));
            }
        }

        /// <summary>
        /// Ensure an action throws a specific type of Exception.
        /// </summary>
        /// <typeparam name="T">Expected exception type.</typeparam>
        /// <param name="action">
        /// The action that should throw when executed.
        /// </param>
        /// <param name="expectedMessage">
        /// Expected exception message.
        /// </param>
        public static void AssertThrows<T>(Action action, string expectedMessage)
            where T : Exception
        {
            Debug.Assert(action != null);

            try
            {
                action();
                Assert.Fail("No exception was thrown!");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(T));
                Assert.AreEqual(expectedMessage, ex.Message, ex.ToString());
            }
        }
        
        /// <summary>
        /// Get the path to a file included in the test project as something to
        /// be copied on Deployment (see Local.testsettings > Deployment for
        /// examples).
        /// </summary>
        /// <param name="relativePath">Relative path to the resource.</param>
        /// <returns>Path to the resource.</returns>
        public static string GetAssemblyTestResourcePath<TResourceLocator>(string relativePath)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            try
            {
                EmbeddedFileWriter.WriteResourceToDisk<TResourceLocator>(relativePath, path);
            }
            catch
            {
                Console.WriteLine(path);
                throw;
            }
            Assert.IsTrue(File.Exists(path));
            return path;
        }

        /// <summary>
        /// Get the path to a file included in the test project as something to
        /// be copied on Deployment (see Local.testsettings > Deployment for
        /// examples).
        /// </summary>
        /// <param name="relativePath">Relative path to the resource.</param>
        /// <returns>Path to the resource.</returns>
        public static string GetTestResourcePath(string relativePath)
        {
            return GetAssemblyTestResourcePath<ResourceLocator>(relativePath);
        }

        /// <summary>
        /// Get the contents of a file included in the test project as something to
        /// be copied on Deployment (see Local.testsettings > Deployment for
        /// examples).
        /// </summary>
        /// <param name="relativePath">Relative path to the resource.</param>
        /// <returns>the resource contents.</returns>
        public static string GetTestResourceContents(string relativePath)
        {
            return File.ReadAllText(Testing.GetTestResourcePath(relativePath));
        }

        /// <summary>
        /// Asserts that given two directories and identical.
        /// </summary>
        /// <param name="expected">The expected directory</param>
        /// <param name="actual">The actual directory</param>
        public static void AssertDirectoryIdentical(string expected, string actual)
        {
            DirectoryInfo expectedDir = new DirectoryInfo(expected);
            DirectoryInfo actualDir = new DirectoryInfo(expected);
            DirectoryInfo[] ExpectedDirs = expectedDir.GetDirectories();
            DirectoryInfo[] ActualDirs = actualDir.GetDirectories();
            FileInfo[] expectedFiles = expectedDir.GetFiles();
            FileInfo[] actualFiles = actualDir.GetFiles();

            Assert.AreEqual<int>(expectedFiles.Length, actualFiles.Length);

            for (int i = 0; i < expectedFiles.Length; i++)
            {
                Assert.AreEqual<string>(expectedFiles[i].Name, actualFiles[i].Name);
            }

            foreach (DirectoryInfo subdir in ExpectedDirs)
            {
                string ActualSubDir = Path.Combine(actual, subdir.Name);
                AssertDirectoryIdentical(subdir.FullName, ActualSubDir);
            }
        }
    }
}
