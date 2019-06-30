using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nde.NdcOlso2019
{
    [TestClass]
    public class AzureStorageUnitTests
    {
        private const string AzureStorageEmulatorConnString = "UseDevelopmentStorage=true";

        [TestMethod]
        public async void CanStoreTableInStorageEmulator()
        {
            var storage = new Storage.AzureStorage(connectionString: AzureStorageEmulatorConnString);
            var topic = new Topic
            {
                Name = "Blazor",
                Url = "https://www.youtube.com/watch?v=0RfUPr0KrSM",
                Pros = "RIA in the browser, all code in C#, reuseable libraries, can also render as Xamarin or Electron app.",
                Cons = "Big download if running client-side as wasm.",
                UsefulForAcorda = "Great candidate for rewrite of www.acorda.ch"
            };
            bool success = await storage.InsertToTable<Topic>(topic, nameof(Topic));
            Assert.IsTrue(success);
        }
    }

    public class Topic
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
        public string UsefulForAcorda { get; set; }
    }
}
