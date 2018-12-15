using Xunit;
using System;
using AZDiscordBot.Storage.Implementations;
using AZDiscordBot.Storage;

namespace AZDiscordBot.xUnit.Tests
{
    public class DataStorageTests
    {
        [Fact]
        public void StorageDefaultsToJson()
        {
            var storage = Unity.Resolve<IDataStorage>();
            
            Assert.Throws<InvalidCastException>(() => 
            {
                var ims = (InMemoryStorage)storage;
            });
            var s = (JsonStorage)storage;
        }

        [Fact]
        public void InMemoryStorageTest()
        {
            const string expected = "I'm a unit test!"; 
            const string expectedKey = "TEST"; 

            IDataStorage storage = new InMemoryStorage();

            storage.StoreObject("I'm different.", expectedKey);
            storage.StoreObject(expected, expectedKey);

            var actual = storage.RestoreObject<string>(expectedKey);

            Assert.Equal(expected, actual);

            Assert.Throws<ArgumentException>(() => storage.RestoreObject<object>("FAKE-KEY"));
        }
    }
}