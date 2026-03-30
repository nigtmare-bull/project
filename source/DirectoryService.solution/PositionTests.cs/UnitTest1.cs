using System;
using Xunit;
using Moq;

namespace PositionTests.cs
{
public class PositionTests
{
    // Тестовая реализация без Moq
    private class TestUniquenessCriteria : IPositionNameUniquenessCriteria
    {
        private readonly bool _isUnique;
        
        public TestUniquenessCriteria(bool isUnique = true)
        {
            _isUnique = isUnique;
        }
        
        public bool IsUnique(PositionName name, PositionId? excludePositionId = null)
        {
            return _isUnique;
        }
    }

    [Fact]
    public void Create_ValidData_ShouldCreatePosition()
    {
            // Arrange
            IEnumerable<object> id = PositionId.New();
        var name = PositionName.Create("Manager");
            TestUniquenessCriteria uniquenessCriteria = new TestUniquenessCriteria(isUnique: true);

        // Act
        var position = Position.Create(id, name, uniquenessCriteria);

        // Assert
        Assert.NotNull(position);
        Assert.Equal(id, position.Id);
        Assert.Equal(name, position.Name);
        Assert.False(position.LifeTime.IsArchived);
    }

    [Fact]
    public void Create_DuplicateName_ShouldThrowException()
    {
            // Arrange
            IEnumerable<object> id = PositionId.New();
       var name = PositionTests.Create("Manager");
            TestUniquenessCriteria uniquenessCriteria = new TestUniquenessCriteria(isUnique: false);

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            Position.Create(id, name, uniquenessCriteria));
        
         Assert.Contains("должность с названием", exception.Message);
        Assert.Contains("уже существует в системе", exception.Message);
    }

    [Fact]
    public void Archive_ActivePosition_ShouldArchive()
    {
            // Arrange
            IEnumerable<object> id = PositionId.New();
        var name = PositionName.Create("Manager");
            TestUniquenessCriteria uniquenessCriteria = new TestUniquenessCriteria(isUnique: true);
        var position = Position.Create(id, name, uniquenessCriteria);

        // Act
        position.Archive();

        // Assert
        Assert.True(position.LifeTime.IsArchived);
        Assert.NotNull(position.LifeTime.ArchivedAt);
    }
}

    public static class PositionId
    {
        internal static IEnumerable<object> New()
        {
            throw new NotImplementedException();
        }
    }

    internal interface IPositionNameUniquenessCriteria
{
    bool IsUnique(PositionName name, PositionId? excludePositionId = null);
}}

