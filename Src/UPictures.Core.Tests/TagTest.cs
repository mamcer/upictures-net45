using Xunit;

namespace UPictures.Core.Test
{
    public class TagTest
    {
        public void ConstructorShouldSetName()
        {
            // Arrange
            Tag tag;
            var tagName = "tag 01";

            // Act
            tag = new Tag(tagName);

            // Assert
            Assert.Equal(tagName, tag.Name);
        }

        [Fact]
        public void EqualsShouldCompareByNameToLower()
        {
            // Arrange
            var tag01 = new Tag("tag 01");
            var tag02 = new Tag("TaG 01");
            bool areEqual;

            // Act
            areEqual = tag01.Equals(tag02);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void EqualsWithNullShouldReturnFalse()
        {
            // Arrange
            var tag01 = new Tag("tag 01");
            Tag tag02 = null;
            bool areEqual;

            // Act
            areEqual = tag01.Equals(tag02);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void EqualsWithDifferentNamesShouldReturnFalse()
        {
            // Arrange
            var tag01 = new Tag("tag 01");
            var tag02 = new Tag("tax 01");
            bool areEqual;

            // Act
            areEqual = tag01.Equals(tag02);

            // Assert
            Assert.False(areEqual);
        }
    }
}