using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressPCLTests.Utility;
using WordPressPCL;
using System.Threading.Tasks;
using WordPressPCL.Models;
using WordPressPCL.Utility;
using System.Net;
using System.Linq;
using Newtonsoft.Json;

namespace WordPressPCLTests
{
    [TestClass]
    public class Tag_Tests
    {
        private const int TAG_ID = 7;

        [TestMethod]
        public async Task List_Tags_Test()
        {
            // Initialize
            var client = new WordPressClient(ApiCredentials.WordPressUri);
            Assert.IsNotNull(client);
            // Posts
            var tags = await client.Tags.GetAll();
            Assert.IsNotNull(tags);
            Assert.AreNotEqual(tags.Count(), 0);
            CollectionAssert.AllItemsAreUnique(tags.Select(tag => tag.Id).ToList());
        }

        [TestMethod]
        public async Task Get_Tag_Test()
        {
            // Initialize
            var client = new WordPressClient(ApiCredentials.WordPressUri);
            Assert.IsNotNull(client);
            // Posts
            var tag = await client.Tags.GetByID(TAG_ID);

            //TODO this should use Assert.Inconclusive
            Assert.IsNotNull(tag);
            Assert.AreEqual(tag.Id, TAG_ID);
            Assert.AreNotEqual(tag.Name, string.Empty);
        }
    }

}