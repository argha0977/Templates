using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Moq.Protected;
using ReflectionMagic;
using DslConfig;
using ConsoleApp;

namespace ConsoleApp.Test {
    [TestFixture]
    public class MainLoopTest {
        private Mock<Configuration> configMock;

        [SetUp]
        public void SetUp() {
            configMock = new Mock<Configuration>();
            configMock.Setup(x => x.GetVariable<TimeSpan>("ThreadSleep"))
                      .Returns(new TimeSpan());
        }

        private MainLoop CreateMainLoop() {            
            Mock<MainLoop> mainLoop = new Mock<MainLoop>();
            mainLoop.CallBase = true;
            mainLoop.Object.Configuration = configMock.Object;
            mainLoop.Protected().Setup("ProcessWorkflow")
                                .Callback(() => {                                     
                                    //don't run in endless loop in main loop
                                    mainLoop.Object.AsDynamic()._runThread = false;                                     
                                })
                                .Verifiable();
            return mainLoop.Object;
        }

        [Test]
        public void ExecuteWorkerThread_Ok() {
            //Arrange
            var mainLoop = CreateMainLoop();
            dynamic dynMainLoop = mainLoop.AsDynamic();            
            //Act
            dynMainLoop.ExecuteWorkerThread();            
            //Assert
            Mock.Get(mainLoop).VerifyAll();
        }
    }
}
