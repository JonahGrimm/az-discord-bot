using Xunit;
using AZDiscordBot.Storage;

namespace AZDiscordBot.xUnit.Tests
{
    public class UnityTests
    {
        [Fact]
        public void UnityResolveTwoObjectsTest()
        {
            //IDataStorage should be a singleton.  
            //Therefore resolving IDataStorage twice should just give you 
            //two variables to the same reference
            var storage1 = Unity.Resolve<IDataStorage>();
            var storage2 = Unity.Resolve<IDataStorage>();

            Assert.NotNull(storage1);
            Assert.NotNull(storage2);
            Assert.Same(storage1, storage2);           
        }
    }
}
