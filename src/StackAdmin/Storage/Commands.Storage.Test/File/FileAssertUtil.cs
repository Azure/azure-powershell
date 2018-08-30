﻿// ----------------------------------------------------------------------------------
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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.Storage.Test.Common;
using Microsoft.WindowsAzure.Storage.File;
using Xunit;
namespace Microsoft.WindowsAzure.Management.Storage.Test.File
{
    internal static class FileAssertUtil
    {
        public static void AssertSingleObject<T>(this IEnumerable<T> collection, Func<T, bool> assertAction)
        {
            var list = new List<T>(collection);
            Assert.Equal(1, list.Count);
            Assert.True(assertAction(list[0]));
        }

        public static void AssertMockupException(this IList<ErrorRecord> errors, string errorId)
        {
            Assert.Equal(1, errors.Count);
            Assert.True(errors[0].Exception is MockupException);
            var exception = errors[0].Exception as MockupException;
            Assert.Equal(errorId, exception.ErrorId);
        }

        public static void AssertListFileItems(this IEnumerable<object> result, IEnumerable<IListFileItem> items)
        {
            var strongTypeResults = new List<IListFileItem>(result.Cast<IListFileItem>());
            var assertItems = new List<IListFileItem>(items);
            Assert.Equal(assertItems.Count, strongTypeResults.Count);

            var directoryItems = assertItems.Where(x => x is CloudFileDirectory).Cast<CloudFileDirectory>().Select(x => x.Name).ToList();
            var fileItems = assertItems.Where(x => x is CloudFile).Cast<CloudFile>().Select(x => x.Name).ToList();
            foreach (var item in strongTypeResults)
            {
                string name;
                List<string> expectList;
                if (item is CloudFile)
                {
                    name = ((CloudFile)item).Name;
                    expectList = fileItems;
                }
                else if (item is CloudFileDirectory)
                {
                    name = ((CloudFileDirectory)item).Name;
                    expectList = directoryItems;
                }
                else
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Unexpected list item: {0}", item));
                }

                Assert.True(expectList.Remove(name), string.Format(CultureInfo.InvariantCulture, "Item {0} does not exist in the expected list.", item));
            }
        }

        public static void AssertNoObject<T>(this IEnumerable<T> collection)
        {
            Assert.Equal(0, collection.Count());
        }

        public static void AssertShares(this IEnumerable<object> result, IEnumerable<string> expectedShareNames)
        {
            List<string> expectedShareNameList = new List<string>(expectedShareNames);
            foreach (var share in result.Cast<CloudFileShare>())
            {
                Assert.True(expectedShareNameList.Remove(share.Name), string.Format(CultureInfo.InvariantCulture, "Share {0} was not expected.", share.Name));
            }

            Assert.Equal(0, expectedShareNameList.Count);
        }
    }
}
