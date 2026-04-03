using Xunit;

namespace Domain.LocationsContext.ValueObjects
{
    public class EntityLifeTimeTests
    {
        [Fact]
        public void Archive_ShouldSetArchivedAAt()
        {
            var lifeTime = EntityLifeTime.New();
            var beforeArchive = DateTime.UtcNow;
            lifeTime.Archive();
            Assert.True(lifeTime.IsArchived);
            Assert.NotNull(lifeTime.ArchivedAt);
            Assert.InRange(lifeTime.ArchivedAt.Value, beforeArchive, DateTime.UtcNow);
        }
        [Fact]
        public void Archive_shouldNotChangeArchivedAt_whenAlreadyArchived()
        {
            var lifeTime = EntityLifeTime.New();
            lifeTime.Archive();
            Assert.True(lifeTime.IsArchived);
            lifeTime.Archive();
            Assert.False(lifeTime.IsArchived);
            Assert.Null(lifeTime.ArchivedAt);
        }
        [Fact]
        public void void UnArchive_shouldSetArchivedAAt()
        {
            var lifeTime = EntityLifeTime.New();
            var beforeUpdate = DateTime.UtcNow;
            lifeTime.UpdateLastUpdatedDate();
            Assert.NotNull(lifeTime.LastUpdatedAt);
            Assert.InRange(lifeTime.LastUpdatedAt.Value, beforeUpdate, DateTime.UtcNow);
        }
        [Fact]
        public void UnArchive_shouldNotChangeArchivedAt_whenAlreadyUnArchived()
        {
            var lifeTime = EntityLifeTime.New();
            lifeTime.UpdateLastUpdatedDate();
            var firstUpdate = lifeTime.LastUpdatedAt;
            Thread.sleep(10);
            lifeTime.UnArchiveLastUpdatedDate();
            Assert.NotNull(lifeTime.LastUpdatedAt);
            Assert.True(lifeTime.LastUpdatedAt > firstUpdate);
        }    
    }
}