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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.Common;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Common
{
    /// <summary>
    /// unit test for NameUtil
    /// </summary>
    [TestClass]
    public class NameUtilTest : StorageTestBase
    {
        [TestMethod]
        public void IsValidContainerNameTest()
        {
            string[] positives = { "$root", "$logs", "abc", "abc987", "abc2de", "4abc", "abc-def", new String('a', 63) };
            NameValidateHelper(positives, true, NameUtil.IsValidContainerName);

            string[] negatives =
                {
                    String.Empty, //can not empty
                    "$ROOT", //can not use upper case
                    "a", //too short
                    "ab", //too short
                    "Aabc", //start with a-z0-9
                    "abcAde", //can not contain upper case
                    "-abc", //start with a-z0-9
                    "a--bc", //can not contain consecutive dash
                    "abc-", //dash can not be the last character
                    "$abc", //$ is invalid
                    "abd*677", //* is invalid
                    "abc?", //? is invalid
                };
            NameValidateHelper(negatives, false, NameUtil.IsValidContainerName);
        }

        [TestMethod]
        public void IsValidContainerPrefixTest()
        {
            string[] positives = { "$", "$ro", "$l", "$root", "a", "ab", "abc", "$logs", "abc", "abc987", "abc2de", "4abc", "abc-def", "a-c", "ac-", new String('a', 63) };
            NameValidateHelper(positives, true, NameUtil.IsValidContainerPrefix);

            string[] negatives =
                {
                    String.Empty, //can not empty
                    "$re", //$re is not the prefix of "$root" or "$logs"
                    "$$", //$$ is not the prefix of "$root" or "$logs"
                    "Aabc", //start with a-z0-9
                    "abcAde", //can not contain upper case
                    "-abc", //start with a-z0-9
                    "a--bc", //can not contain consecutive dash
                    "$abc", //$ is invalid
                    "abd*677", //* is invalid
                    "abc?", //? is invalid
                    "$root-", //$ is invalid
                };
            NameValidateHelper(negatives, false, NameUtil.IsValidContainerPrefix);
        }

        [TestMethod]
        public void IsValidBlobNameTest()
        {
            string[] positives = { "$", "$ro", "$l", "$root", "a", "*&(&^$^*", "ab", "abc", "$logs", "abc", "abc987", "abc2de", "4abc", "abc-def", "a-c", "ac-", new String('a', 1024)};
            NameValidateHelper(positives, true, NameUtil.IsValidBlobName);

            string[] negatives =
                {
                    String.Empty, //can not empty
                    new String('a', 1025)
                };
            NameValidateHelper(negatives, false, NameUtil.IsValidBlobName);
        }

        [TestMethod]
        public void IsValidBlobPrefixTest()
        {
            string[] positives = { "$", "$ro", "$l", "$root", "a", "*&(&^$^*", "ab", "abc", "$logs", "abc", "abc987", "abc2de", "4abc", "abc-def", "a-c", "ac-", new String('a', 1024) };
            NameValidateHelper(positives, true, NameUtil.IsValidBlobPrefix);

            string[] negatives =
                {
                    String.Empty, //can not empty
                    new String('a', 1025)
                };
            NameValidateHelper(negatives, false, NameUtil.IsValidBlobPrefix);
        }


        [TestMethod]
        public void IsValidTableNameTest()
        {
            string[] positives = { "Abc", "abc", "a99", new String('a', 63) };
            NameValidateHelper(positives, true, NameUtil.IsValidTableName);

            string[] negatives =
                {
                    String.Empty, //can not empty
                    "9a", //only start with A-Za-z
                    "a", //too short
                    "a?", //? is invalid
                    "af*", //* is invalid
                    "abc+", //+ is invalid
                    new String('a', 64), //too long
                    new String('a', 256) //too long
                };
            NameValidateHelper(negatives, false, NameUtil.IsValidTableName);
        }

        [TestMethod]
        public void ValidMetricsTableTest()
        {
            string[] metricsTables = {"$MetricsTransactionsBlob", "$MetricsTransactionsTable",
                                          "$MetricsTransactionsQueue",  "$MetricsCapacityBlob"};
            NameValidateHelper(metricsTables, true, NameUtil.IsValidTableName);
        }

        [TestMethod]
        public void IsValidTablePrefixTest()
        {
            string[] positives = {"a", "A", "Ab", "ab", "a99", new String('a', 63) };
            NameValidateHelper(positives, true, NameUtil.IsValidTablePrefix);

            string[] negatives =
                {
                    String.Empty, //can not empty
                    "9", //only start with a-zA-Z
                    "9a", //only start with A-Za-z
                    "a?", //? is invalid
                    "af*", //* is invalid
                    "abc+", //+ is invalid
                    new String('a', 64), //too long
                    new String('a', 256) //too long
                };
            NameValidateHelper(negatives, false, NameUtil.IsValidTablePrefix);
        }

        [TestMethod]
        public void IsValidQueueNameTest()
        {
            string[] positives = {"abc", "abc987", "abc2de", "4abc", "abc-def", new String('a', 63) };
            NameValidateHelper(positives, true, NameUtil.IsValidQueueName);

            string[] negatives =
                {
                    String.Empty, //can not empty
                    "$ROOT", //can not use upper case
                    "a", //too short
                    "ab", //too short
                    "Aabc", //start with a-z0-9
                    "abcAde", //can not contain upper case
                    "-abc", //start with a-z0-9
                    "a--bc", //can not contain consecutive dash
                    "abc-", //dash can not be the last character
                    "$abc", //$ is invalid
                    "abd*677", //* is invalid
                    "abc?", //? is invalid
                    new String('a', 64), //too long
                    new String('a', 256) //too long
                };
            NameValidateHelper(negatives, false, NameUtil.IsValidQueueName);
        }

        [TestMethod]
        public void IsValidQueuePrefixTest()
        {
            string[] positives = {"a", "ab", "abc", "abc", "abc987", "abc2de", "4abc", "abc-def", "a-c", "ac-", new String('a', 63) };
            NameValidateHelper(positives, true, NameUtil.IsValidQueuePrefix);

            string[] negatives =
                {
                    String.Empty, //can not empty
                    "Aabc", //start with a-z0-9
                    "abcAde", //can not contain upper case
                    "-abc", //start with a-z0-9
                    "a--bc", //can not contain consecutive dash
                    "$abc", //$ is invalid
                    "abd*677", //* is invalid
                    "abc?", //? is invalid
                    new String('a', 64), //too long
                    new String('a', 256) //too long
                };
            NameValidateHelper(negatives, false, NameUtil.IsValidQueuePrefix);
        }

        [TestMethod]
        public void IsValidFileNameTest()
        {
            string[] positives = { "a", "ab", "abc", "Aabc", "abc987", "abc2de", "4abc", "abc-def", "a-c", "ac-", new String('a', 63) };
            NameValidateHelper(positives, true, NameUtil.IsValidFileName);

            string[] negatives =
                {
                    String.Empty, //can not empty
                    "abc/e", //$ is invalid
                    "COM1", //forbidden file name
                    "abd*677", //* is invalid
                    "abc?", //? is invalid
                    new String('a', 512), //too long
                    new String('a', 1024) //too long
                };
            NameValidateHelper(negatives, false, NameUtil.IsValidFileName);
        }

        /// <summary>
        /// validate names
        /// </summary>
        /// <param name="names">names which need to be checked</param>
        /// <param name="isValid">the names is valid or not</param>
        /// <param name="validator">Validate method</param>
        private void NameValidateHelper(string[] names, bool isValid, Func<string, bool> validator)
        {
            foreach (string name in names)
            {
                string message = String.Format("'{0}' {1} should be {2}", name, validator.Method.Name, isValid);
                Assert.AreEqual(isValid, validator(name), message);
            }
        }
    }
}
