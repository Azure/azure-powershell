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
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.FunctionalTests
{
    public class OutputFormatValidator
    {
        public static void ValidateOutputFormat(string actualFileName, string expectedFileName)
        {
            string actualFormat = GetMaskedData(actualFileName);
            Console.WriteLine(actualFormat);
            string expectedFormat = GetMaskedData(expectedFileName);
            Assert.AreEqual(expectedFormat, actualFormat, "Format of output object didn't match");
        }

        private static string GetMaskedData(string fileName)
        {
            string mask = "xxxxxxxxxx";
            // The code expects the first line of the file contains the list of dynamic data (such as servername#operation id) separated by #.
            // These dynamic data will be replaced with xxxxxxxxxx.
            string dynamicContentLine = File.ReadAllLines(fileName)[0];
            string[] dynamicContents = dynamicContentLine.Split('#');
            string data = FileUtilities.DataStore.ReadFileAsText(fileName);

            foreach (string dynamicContent in dynamicContents)
            {
                data = data.Replace(dynamicContent, mask);
            }
            return data;
        }
    }
}
