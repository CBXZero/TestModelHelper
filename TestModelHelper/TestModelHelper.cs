using System;
using Newtonsoft.Json;

namespace TestModelHelper
{
    public class TestModelHelper<T>
    {
        private T _validModel;

        public TestModelHelper(T validModel)
        {
            _validModel = validModel;
        }

        public T CreateOriginalTestData()
        {
            return CloneValidObject();
        }

        public T CreateModifiedTestData(Action<T> action)
        {
            var clone = CloneValidObject();
            action.Invoke(clone);
            return clone;
        }

        private T CloneValidObject()
        {
            var stringClone = JsonConvert.SerializeObject(_validModel);
            var clone = JsonConvert.DeserializeObject<T>(stringClone);
            return clone;
        }
    }
}
