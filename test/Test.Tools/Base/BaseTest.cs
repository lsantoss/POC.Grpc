using NUnit.Framework;
using POC.Grpc.Test.Tools.Mocks;

namespace POC.Grpc.Test.Tools.Base
{
    [TestFixture]
    public class BaseTest : Startup
    {
        protected MocksTest MocksTest { get; set; }

        public BaseTest() : base() => MocksTest = new MocksTest();

        [OneTimeSetUp]
        protected virtual void OneTimeSetUp() => MocksTest = new MocksTest();

        [OneTimeTearDown]
        protected virtual void OneTimeTearDown() => MocksTest = null;

        [SetUp]
        protected virtual void SetUp() => MocksTest = new MocksTest();

        [TearDown]
        protected virtual void TearDown() => MocksTest = null;
    }
}