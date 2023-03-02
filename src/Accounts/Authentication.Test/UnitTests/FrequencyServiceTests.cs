using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Commands.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using Microsoft.Azure.Commands.TestFx.Recorder;
using System.Threading;
using Newtonsoft.Json;
using System.IO;

namespace Microsoft.Azure.Commands.Common.Authentication.Tests
{
    public class FrequencyServiceTests
    {
        private FrequencyService _frequencyService;

        public FrequencyServiceTests()
        {
            _frequencyService = new FrequencyService();
        }

        [Fact]
        public void TestAdd()
        {
            // Arrange
            string featureName = "TestFeature";
            TimeSpan frequency = new TimeSpan(0, 0, 5); // 5 seconds

            // Act
            _frequencyService.Add(featureName, frequency);

            // Assert
            var frequencyInfo = _frequencyService.GetFrequencyInfo(featureName);
            Assert.NotNull(frequencyInfo);
            Assert.Equal(frequency, frequencyInfo.Frequency);
        }

        [Fact]
        public void TestAddSession()
        {
            string featureName = "testFeature";
            _frequencyService.AddSession(featureName);

            Assert.True(_frequencyService.SessionLogic.ContainsKey(featureName));
            Assert.False(_frequencyService.SessionLogic[featureName]);
        }

        [Fact]
        public void TestCheck_SessionLogic()
        {
            string featureName = "testFeature";
            _frequencyService.AddSession(featureName);

            bool businessCheck = true;
            bool businessCalled = false;
            _frequencyService.Check(featureName, () => businessCheck, () => businessCalled = true);

            Assert.True(businessCalled);
            Assert.True(_frequencyService.SessionLogic[featureName]);
        }

        [Fact]
        public void TestCheck_Frequencies()
        {
            string featureName = "testFeature";
            TimeSpan frequency = new TimeSpan(0, 0, 1);
            _frequencyService.Add(featureName, frequency);

            bool businessCheck = true;
            bool businessCalled = false;
            _frequencyService.Check(featureName, () => businessCheck, () => businessCalled = true);

            Assert.True(businessCalled);
            Assert.Equal(DateTime.Now.Date, _frequencyService.GetFrequencyInfo(featureName).LastCheckTime.Date);
        }

        [Fact]
        public void AddFeature_AddsFeatureToFrequencyService()
        {
            // Arrange
            var frequencyService = new FrequencyService();
            var featureName = "MyFeature";
            var frequency = TimeSpan.FromMinutes(5);

            // Act
            frequencyService.Add(featureName, frequency);

            // Assert
            Assert.NotNull(frequencyService);
            Assert.NotNull(frequencyService.GetAllFeatureNames());
            Assert.Contains(featureName, frequencyService.GetAllFeatureNames());
        }

        [Fact]
        public void AddDuplicateFeature_DoesNotAddDuplicateToFrequencyService()
        {
            // Arrange
            var frequencyService = new FrequencyService();
            var featureName = "MyFeature1";
            var frequency = TimeSpan.FromMinutes(5);

            // Act
            frequencyService.Add(featureName, frequency);
            frequencyService.Add(featureName, frequency);

            // Assert
            Assert.Equal(1, frequencyService.GetAllFeatureNames().Count(n => n == featureName));
        }

        [Fact]
        public void AddSessionFeature_AddsSessionFeatureToFrequencyService()
        {
            // Arrange
            var frequencyService = new FrequencyService();
            var featureName = "MySessionFeature";

            // Act
            frequencyService.AddSession(featureName);

            // Assert
            Assert.Contains(featureName, frequencyService.GetAllFeatureNames());
        }

        [Fact]
        public void AddDuplicateSessionFeature_DoesNotAddDuplicateToFrequencyService()
        {
            // Arrange
            var frequencyService = new FrequencyService();
            var featureName = "MySessionFeature";

            // Act
            frequencyService.AddSession(featureName);
            frequencyService.AddSession(featureName);

            // Assert
            Assert.Equal(1, frequencyService.GetAllFeatureNames().Count(n => n == featureName));
        }

        [Fact]
        public void Check_FrequencyMet_ExecuteBusinessLogic()
        {
            // Arrange
            var frequencyService = new FrequencyService();
            var featureName = "MyFeature2";
            var frequency = TimeSpan.FromMinutes(5);
            var businessLogicExecuted = false;
            frequencyService.Add(featureName, frequency);

            // Act
            frequencyService.Check(featureName, () => true, () => businessLogicExecuted = true);

            // Assert
            Assert.True(businessLogicExecuted);
        }

        [Fact]
        public void Check_FrequencyNotMet_DoesNotExecuteBusinessLogic()
        {
            // Arrange
            var frequencyService = new FrequencyService();
            var featureName = "MyFeature3";
            var frequency = TimeSpan.FromMinutes(5);
            var businessLogicExecuted = false;
            frequencyService.Add(featureName, frequency);

            // Act
            frequencyService.Check(featureName, () => false, () => businessLogicExecuted = true);

            // Assert
            Assert.False(businessLogicExecuted);
        }

        [Fact]
        public void Check_SessionFeatureFirstTime_ExecuteBusinessLogic()
        {
            // Arrange
            var frequencyService = new FrequencyService();
            var featureName = "MySessionFeature";
            var businessLogicExecuted = false;
            frequencyService.AddSession(featureName);

            // Act
            frequencyService.Check(featureName, () => true, () => businessLogicExecuted = true);

            // Assert
            Assert.True(businessLogicExecuted);
        }

        [Fact]
        public void Check_SessionFeatureSecondTime_DoesNotExecuteBusinessLogic()
        {
            // Arrange
            var frequencyService = new FrequencyService();
            var featureName = "MySessionFeature";
            var businessLogicExecuted = false;
            frequencyService.AddSession(featureName);

            // Act
            frequencyService.Check(featureName, () => true, () => businessLogicExecuted = true);
            frequencyService.Check(featureName, () => true, () => businessLogicExecuted = false);

            // Assert
            Assert.True(businessLogicExecuted);
        }

        [Fact]
        public void Check_Frequency_Logic()
        {
            var frequencyService = new FrequencyService();
            var featureName = "MyFeature4";
            var frequency = TimeSpan.FromMilliseconds(1000);
            int businessLogic = 13;
            frequencyService.Add(featureName, frequency);
            
            frequencyService.Check(featureName, () => true, () => businessLogic = 100);
            Assert.Equal(100, businessLogic);
            // sleep 1 sec
            Thread.Sleep(2000);
            
            frequencyService.Check(featureName, () => true, () => businessLogic = -100);
            Assert.Equal(-100, businessLogic);
            frequencyService.Check(featureName, () => true, () => businessLogic = 16);
            Assert.Equal(-100, businessLogic);
            Thread.Sleep(2000);
            Assert.Equal(-100, businessLogic);
            frequencyService.Check(featureName, () => true, () => businessLogic = 17);
            Assert.Equal(17, businessLogic);
        }
    }
}