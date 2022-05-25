namespace FriendlyId.Net.Tests
{
    public class FriendlyIdTests
    {
        [Test]
        public void FriendlyIdToGuidValidation()
        {
            try
            {
                var guid = FriendlyId.ToGuid("5wbwf6yUxVBcr48AMbz9cb");
                if (guid != Guid.Parse("c3587ec5-0976-497f-8374-61e0c2ea3da5"))
                {
                    Assert.Fail("Friendly Id did not parse to correct GUID");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();

        }


        [Test]
        public void GuidToFriendlyIdValidation()
        {
            try
            {
                var friendlyId = FriendlyId.ToFriendlyId(Guid.Parse("c3587ec5-0976-497f-8374-61e0c2ea3da5"));
                if(friendlyId!= "5wbwf6yUxVBcr48AMbz9cb")
                {
                    Assert.Fail("GUID did not convert to correct friendly id string");
                }

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }


        [Test]
        public void FriendlyIdGeneration()
        {
            try
            {
                var friendlyId = FriendlyId.CreateFriendlyId();
               
            }
            catch (Exception ex)
            {
                Assert.Fail( ex.Message);
            }
            Assert.Pass();
        }
    }
}