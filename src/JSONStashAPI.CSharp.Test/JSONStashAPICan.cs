using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSONStashAPI.CSharp.Test
{
    [TestClass]
    public class JSONStashAPICan
    {
        private readonly string _key;
        private readonly string _stashId;

        public JSONStashAPICan()
        {
            _key = Guid.NewGuid().ToString();
            _stashId = Guid.NewGuid().ToString();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException() => new JSONStash("");

        [TestMethod]
        [ExpectedException(typeof(UriFormatException))]
        public void ThrowUriFormatException() => new JSONStash("badurl");

        [TestMethod]
        public async Task DoesNotThrowUriFormatExceptionAsync()
        {
            try
            {
                new JSONStash("example.com");
                new JSONStash("example.com", 8080);
                new JSONStash("example.com/path");
                new JSONStash("127.0.0.1");
                new JSONStash("127.0.0.1", 8080);
                new JSONStash("127.0.0.1/path", 8080);
                new JSONStash("http://127.0.0.1", 8080);
                new JSONStash("https://127.0.0.1", 8080);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ThrowArgumentNullExceptionForGetStashDataAsync()
        {
            JSONStash api = new JSONStash("example.com");
            await api.GetStashDataAsync("", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ThrowArgumentNullExceptionForUpdateStashDataAsync()
        {
            JSONStash api = new JSONStash("example.com");
            await api.UpdateStashDataAsync("", "", "");
        }
    }
}
