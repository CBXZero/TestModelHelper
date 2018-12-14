using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues;

namespace TestModelHelper.Test
{
    [TestClass]
    public class CreateModifiedShould
    {
        private TestModelHelper<TestModel> _sut;
        private TestModel _validModel;

        [TestInitialize]
        public void Setup()
        {
            _validModel = new TestModel
            {
                TestGuid = RandomValue.Guid(),
                TestBool = RandomValue.Bool(),
                TestDate = RandomValue.DateTime(),
                TestInt = RandomValue.Int(),
                TestString = RandomValue.String()
            };
            _sut = new TestModelHelper<TestModel>(_validModel);
        }

        [TestMethod]
        public void ShouldReturnCopyOfTheObject()
        {
            var result = _sut.CreateModifiedTestData(r => r.TestGuid = r.TestGuid);

            Assert.AreNotEqual(_validModel, result);
        }

        [TestMethod]
        public void ShouldModifyTestGuidFromLinqStatement()
        {
            var expected = RandomValue.Guid();

            var result = _sut.CreateModifiedTestData(r => r.TestGuid = expected);

            Assert.AreEqual(expected, result.TestGuid);
        }

        [TestMethod]
        public void ShouldModifyTestBoolFromLinqStatement()
        {
            var expected = _validModel.TestBool == false;

            var result = _sut.CreateModifiedTestData(r => r.TestBool = expected);

            Assert.AreEqual(expected, result.TestBool);
        }

        [TestMethod]
        public void ShouldModifyTestIntFromLinqStatement()
        {
            var expected = RandomValue.Int();

            var result = _sut.CreateModifiedTestData(r => r.TestInt = expected);

            Assert.AreEqual(expected, result.TestInt);
        }

        [TestMethod]
        public void ShouldModifyTestStringFromLinqStatement()
        {
            var expected = RandomValue.String();

            var result = _sut.CreateModifiedTestData(r => r.TestString = expected);

            Assert.AreEqual(expected, result.TestString);
        }

        [TestMethod]
        public void ShouldModifyTestDateFromLinqStatement()
        {
            var expected = RandomValue.DateTime();

            var result = _sut.CreateModifiedTestData(r => r.TestDate = expected);

            Assert.AreEqual(expected, result.TestDate);
        }
    }
}
