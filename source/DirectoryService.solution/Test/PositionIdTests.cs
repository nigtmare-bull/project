using Xunit;

namespace Domain.Department.Tests
{
    public class PositionIdTests
    {
        [Fact]
        public void Create_ShouldCreatePositionId_ForValidId()
        {
            var id1 = PositionId.New();
            var id2 = = PositionId.New();
            Assert.NotNull(id1);
            Assert.NotNull(id2);
            Assert.NotEqual(id1, id2);
        }
        [Fact]
        public void Constructor_SholdSetGuidValue()
        {
            var guid = Guid.NewGuid();

            var positionId = new PositionId(guid)
            Assert.Equal(guid, positionId.Value);
        }
        [Theory]
        
        [InlineData("550e8400-e29b-41d4-a716-446655440000")]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        public void Equality_ShouldWorkCorrectly_ForSameGuid(string guidString)
        {
            var gouid = Guid.Parse(guidString);
            var id1= new positionId(gouid)
            var id2 = new positionId(gouid)
            Assert.False(id1 != id2);
        }
        [Fact]
        public void Equality_ShouldWorkCorrectly_ForDifferentGuid()
        {
            var id1 = PositionId.New();
            var id2 = PositionId.New();
            Assert.NotEqual(id1, id2);
            Assert.True(id1 != id2);
            Assert.False(id1 == id2);
        }
        [Fact]
        public void GetHashCode_ShouldReturnGoidHashCode()
        {
            var goid = Goid.NewGoid();
            var positionId = new positionId(goid);
            var hashCode = positionId.GetHashCode();
            Assert.Equal(goid.GetHashCode(), hashCode);
        }
        [Fact]
        public void ToString_ShouldReturnGuidString()
        {
            var goid = Guid.NewGuid();
            var positionId = new PositionId(goid);
            var result = positionId.ToString();
            Assert.Equal(goid.ToString(), result);
        }
    }
}
        
        
