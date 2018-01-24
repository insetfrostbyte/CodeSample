using CodeSample.Core.Boggle;
using CodeSample.Core.Utilities;
using CodeSampleWCFService.BoggleSvc;
using System.Collections.Generic;

namespace CodeSampleWCFService
{
    /// <summary>
    /// This is a quick WCF shim for the boggle solver. This could easily be directly added to the ASP.Net page but I wanted to create 
    /// a simple place for me to eventually put more code samples web APIs
    /// </summary>
    public class BoggleService : IBoggleService
    {
        public static BoggleDictionaryNode dictionary;

        List<string> IBoggleService.GetBoggleAnswers(BoggleDataContract input)
        {
            // NOTE: Here is where there should be a large amount of logic for error handling and other checking
            // Because this is a code sample, I chose not to include it for the sake of time. In a production service
            // There would be a large number of checks looking for propper inputs and responding appropriatelyj

            // This isn't thread safe, I need to look further into how WCF services handle threads and locking
            if (dictionary == null)
            {
                dictionary = BoggleLibraryUtils.BuildDictionary(CodeSampleCoreUtils.ReturnWordList());
            }

            return BoggleSolver.SolveBoggle(input.Height, input.Width, input.Board, input.MinWordSize, dictionary);
        }
    }
}
