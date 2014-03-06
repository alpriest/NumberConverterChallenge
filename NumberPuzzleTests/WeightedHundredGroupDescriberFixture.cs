using Moq;
using NUnit.Framework;
using NumberPuzzle;

namespace NumberPuzzleTests
{
	[TestFixture]
	public class WeightedHundredGroupDescriberFixture
	{
		[Test]
		public void DescribesAWeightedGroupWhenWeightingIsThousand()
		{
			// Arrange
			var describer = BuildDescriber("fifty", "thousand");

			// Act
			var result = describer.Describe(new WeightedHundredGroup(50, 1000));

			// Assert
			Assert.That(result, Is.EqualTo("fifty thousand"));
		}
		
		[Test]
		public void DescribesAWeightedGroupWhenWeightingIsMillion()
		{
			// Arrange
			var describer = BuildDescriber("fifty", "million");

			// Act
			var result = describer.Describe(new WeightedHundredGroup(50, 1000000));

			// Assert
			Assert.That(result, Is.EqualTo("fifty million"));
		}
		
		[Test]
		public void DoesNotAppendWeightingWhenThereIsNotOne()
		{
			// Arrange
			var describer = BuildDescriber("fifty", string.Empty);

			// Act
			var result = describer.Describe(new WeightedHundredGroup(50, 0));

			// Assert
			Assert.That(result, Is.EqualTo("fifty"));
		}

		private static WeightedHundredGroupDescriber BuildDescriber(string hundredsDescription, string weightingDescription)
		{
			var groupDescriber = new Mock<IHundredGroupDescriber>();
			groupDescriber.Setup(x => x.Describe(It.IsAny<HundredGroup>())).Returns(hundredsDescription);

			var groupDescriberFactory = new Mock<IDescriberFactory>();
			groupDescriberFactory.Setup(x => x.CreateHundredGroupDescriber(It.IsAny<INumberDescriber>()))
				.Returns(groupDescriber.Object);

			var numberDescriber = new Mock<INumberDescriber>();
			numberDescriber.Setup(x => x.LookupWeightedName(It.IsAny<int>()))
				.Returns(new LookupResult {Description = weightingDescription, Found = !string.IsNullOrEmpty(weightingDescription)});

			return new WeightedHundredGroupDescriber(numberDescriber.Object, groupDescriberFactory.Object);
		}
	}
}
