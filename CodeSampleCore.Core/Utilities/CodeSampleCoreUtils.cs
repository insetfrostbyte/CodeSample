using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CodeSample.Core.Utilities
{
    public static class CodeSampleCoreUtils
    {
        /// <summary>
        /// This grags the dictionary word.list from within the embedded resources of the DLL
        /// and returns it as an array of strings.
        /// 
        /// word.list is from YAWL downloadable at:
        /// https://directory.fsf.org/wiki/Yawl
        /// </summary>
        /// <returns>The complete list of words</returns>
        public static string[] ReturnWordList()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "CodeSample.Core.ProjectFiles.word.list";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                try
                {
                    List<string> wordList = new List<string>();
                    string buffer = string.Empty;
                    while((buffer = reader.ReadLine()) != null)
                    {
                        wordList.Add(buffer);
                    }
                    return wordList.ToArray();
                }
                catch
                {
                    return null;
                }
                
            }
        }
    }
}
