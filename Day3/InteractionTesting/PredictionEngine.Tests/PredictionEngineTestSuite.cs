using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace PredictionEngine
{
    [TestFixture]
    public class PredictionEngineTests
    {
        [TestCase("Hello ho", "ho")]
        [TestCase("Hello how are you", "you")]
        [TestCase("Hello how are you doing", "doing")]
        public void WhenInputIsAPArtialWordMonogramMustBeCalled(string phrase, string lastWord)
        {
            //Arrange
            var mockILanguageAlgo = new Mock<ILanguageModelAlgo>();
            PredictionEngine predictionEngine = new PredictionEngine(mockILanguageAlgo.Object);
            //Act
            string predictionResult = predictionEngine.Predict(phrase);
            //Assert
            mockILanguageAlgo.Verify(p => p.predictUsingMonogram(lastWord), Times.Once);
        }

        [TestCase("Hello ", "Hello")]
        [TestCase("Hello how are you ", "you")]
        [TestCase(" ", "")]
        public void WhenInputIsAPArtialWordBigramMustBeCalled(string phrase, string lastWord)
        {
            //Arrange
            var mockILanguageAlgo = new Mock<ILanguageModelAlgo>();
            PredictionEngine predictionEngine = new PredictionEngine(mockILanguageAlgo.Object);
            //Act
            string predictionResult = predictionEngine.Predict(phrase);
            //Assert
            mockILanguageAlgo.Verify(p => p.predictUsingBigram(phrase), Times.Once);
        }

    }
}
