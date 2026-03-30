namespace Test;

public class UnitTest1
{
    [Fact]
    public void PositionNameTests()
    {  
        [Theory]
        
        [InlineData("Менеджер")]
        [InlineData("Старший разработчик")]
        [InlineData(" Директор ")]
        [InlineData("HR Specialist")]
        public void Create_ShouldSucceed_ForValidName(string validName)
        {
            var positionName = positionName.Create(validName);
            Assert.NotNull(positionName);
            Assert.Equal(validName.Trim(), positionName.Value);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Create_ShouldThrowArgumentException_ForInvalidName(string invalidName)
        {
            Assert.Throws<ArgumentException>(() => positionName.Create(invalidName));
        }
        [Fact]
        public void Create_ShouldThrowArgumentException_ForNameLongerThen100Characters()
        {
            var longName = new string('a', 101);
            Assert.Throws<ArgumentException>(() => positionName.Create(longName));      
        }
        
        [Fact]
        public void Create_ShouldThrowArgumentException_ForName()
        {
            var nameWithSpaces = "Менеджер";
           var posisionName = PositionName.Create(nameWithSpaces);
           Assert.Equal(" Менеджер ", posisionName.Value);        
        }
        [Theory]
        
        [InlineData("Менеджер","Менеджер")]
        [InlineData("Менеджер","Менеджер")]
        [InlineData("Менеджер"," Директор ")]
        public void Equals_SholdCompareCase_ForPositionNames(string name1, string name2)
        {
            var positionName1 = PositionName.Create(name1);
            var positionName2 = PositionName.Create(name2);
            var areEqual = positionName1.Equals(positionName2);
            Assert.Equal(expectedEquals, areEqual);
        }
        [Fact]
        public void GetHashCode_ShouldReturnSameValue_ForPositionNames()
        {
            var name1 = PositionName.Create("Менеджер");
            var name2 = PositionName.Create("Менеджер");
            Assert.Equal(name1.GetHashCode(), name2.GetHashCode());
            
        }
    )


    }
}
