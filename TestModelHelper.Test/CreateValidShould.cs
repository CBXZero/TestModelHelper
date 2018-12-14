using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues;
using TestModelHelper;

namespace TestModelHelper.Test
{
    [TestClass]
    public class CreateValidShould
    {
        private TestModelHelper<TestModel> _sut;
        private TestModel _validModel;

        [TestInitialize]
        public void Setup()
        {
            _validModel = new TestModel
            {
                TestString = RandomValue.String(),
                TestInt = RandomValue.Int(),
                TestBool = RandomValue.Bool(),
                TestGuid = RandomValue.Guid(),
                TestDate = RandomValue.DateTime()
            };
            _sut = new TestModelHelper<TestModel>(_validModel);
        }

        [TestMethod]
        public void ReturnMatchingData()
        {
            var result = _sut.CreateOriginalTestData();

            Assert.AreEqual(_validModel.TestInt, result.TestInt);
            Assert.AreEqual(_validModel.TestString, result.TestString);
            Assert.AreEqual(_validModel.TestBool, result.TestBool);
            Assert.AreEqual(_validModel.TestGuid, result.TestGuid);
            Assert.AreEqual(_validModel.TestDate, result.TestDate);
        }

        [TestMethod]
        public void ReturnACopyOfTheObject()
        {
            var result = _sut.CreateOriginalTestData();

            Assert.AreNotEqual(_validModel, result);
        }

        [TestMethod]
        public void ReturnACopyOfTheObjectEachCall()
        {
            var result1 = _sut.CreateOriginalTestData();
            var result2 = _sut.CreateOriginalTestData();

            Assert.AreNotEqual(result1, result2);
        }
    }
}
