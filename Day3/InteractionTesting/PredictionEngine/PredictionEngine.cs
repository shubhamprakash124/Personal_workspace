using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictionEngine
{
    public class PredictionEngine
    {
        private ILanguageModelAlgo languageModelAlgo;
        public PredictionEngine(ILanguageModelAlgo algo)
        {
            languageModelAlgo = algo;
        }

        public string Predict(string phrase)
        {
            String lastword = lastWord(phrase);
            if(phrase.EndsWith(" "))
            {
                return this.languageModelAlgo.predictUsingBigram(phrase);
            }
            else 
            {
                return this.languageModelAlgo.predictUsingMonogram(lastword);
            }
        }

        private string lastWord(string phrase)
        {
            String[] words = phrase.Trim().Split(' ');
            return words[words.Length - 1];
        }
    }
}
