using System;
using Xunit;
namespace EntityLifeTimeTests.cs
{
    public class EntityLifeTime
{
    [Fact]
    public void New_ShouldCreateAtToCurrentUtcTime()
    {
        DateTime beforeCreate = DateTime.UtcNow;
       var LifeTime = EntityLifeTime.New();
        Assert.InRange(LifeTime.CreatedAt, beforeCreate, DateTime.UtcNow);
        Assert.False(LifeTime.IsArchived);
        Assert.Null(LifeTime.ArchivedAt);
        Assert.Null(LifeTime.LastUpdatedAt);
    }
    
    [Fact]
    public void Archive_ShouldSetArchivedAt()
    {
        DateTime beforeArchive = DateTime.UtcNow;
        var LifeTime = EntityLifeTime.New();
        LifeTime.Archive();
        Assert.InRange(LifeTime.ArchivedAt, beforeArchive, DateTime.UtcNow);
        Assert.True(LifeTime.IsArchived);
        Assert.NotNull(LifeTime.LastUpdatedAt);
    }
    
    [Fact]
    
    public void Archive_ShouldNotChangeArchivedAt_WhenAlreadyArchived()
    {
        DateTime beforeUpdate = DateTime.UtcNow;
        var LifeTime = EntityLifeTime.New();
        LifeTime.Update();
        var firstArchive = LifeTime.ArchivedAt;
        LifeTime.Archive();
        Assert.Equal( LifeTime.ArchivedAt);
        
    }
    [Fact]
    public void Archive_ShouldNotChangeArchivedAt()
    {
        DateTime beforeUpdate = DateTime.UtcNow;
        var LifeTime = EntityLifeTime.New();
        LifeTime.Update();
       Assert.True(LifeTime.IsArchived);
       LifeTime.Archive();
       Assert.False(LifeTime.IsArchived);
       Assert.Null(LifeTime.ArchivedAt);
    }
     [Fact]
        public void UpdateLastUpdatedDate_ShouldSetLastUpdatedAt()
    {
            var lifeTime = EntityLifeTime.New();
           DateTime beforeUpdate = DateTime.UtcNow;
            lifeTime.UpdateLastUpdatedDate();
            Assert.NotNull(lifeTime.LastUpdatedAt);
            Assert.InRange(lifeTime.LastUpdatedAt.Value, beforeUpdate, DateTime.UtcNow);
    }

        [Fact]
        public void UpdateLastUpdatedDate_ShouldUpdateToLaterTime()
    {

            var lifeTime = EntityLifeTime.New();
            lifeTime.UpdateLastUpdatedDate();
            var firstUpdate = lifeTime.LastUpdatedAt;
            Thread.Sleep(10);
            lifeTime.UpdateLastUpdatedDate();
            Assert.NotNull(lifeTime.LastUpdatedAt);
            Assert.True(lifeTime.LastUpdatedAt > firstUpdate);
    }
    }
} 
   