using CodeSample.Core.Boggle;
using CodeSample.Web.CoreWCFService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeSample.Web
{
    public partial class Boggle : System.Web.UI.Page
    {
        public static BoggleDictionaryNode dictionaryNode;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_SolveBoggle_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new System.Web.UI.PageAsyncTask(CallAsyncBoggleSolver));
        }

        private async Task CallAsyncBoggleSolver()
        { 
            var boggleBoard = VerifyInputs();

            wordList.Text = string.Empty;

            if (boggleBoard != null)
            {
                var inputRequest = BuildBoggleContract(int.Parse(txtHeight.Text), int.Parse(txtWidth.Text), boggleBoard, int.Parse(txtMinWordSize.Text));

                var coreService = new BoggleServiceClient();
                
                var foundWords = await coreService.GetBoggleAnswersAsync(inputRequest);

                if (foundWords.Length > 0)
                {
                    int wordCount = 0;
                    foreach (var word in foundWords)
                    {
                        wordList.Text += word + ",";
                        if (wordCount % 10 == 0)
                        {
                            wordList.Text += "<br/>";
                        }
                        wordCount++;
                    }
                }
                else
                {
                    wordList.Text = "Sorry, no words were found that meet the criteria";
                }
            }
            else
            {
                wordList.Text = "There was an error with your input. Please check your inputs";
            }
        }


        /// <summary>
        /// Verifies the input of the board, making sure that the height and width supplied
        /// line up with the inputted board
        /// </summary>
        /// <returns></returns>
        private char[][] VerifyInputs()
        {
            var boardRawString = txtBoardInput.Text.ToLower();

            var multiString = boardRawString.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            if (multiString.Length == int.Parse(txtHeight.Text))
            {
                List<char[]> newBoard = new List<char[]>();

                bool valid = true;
                foreach (string line in multiString)
                {
                    if (line.Length != int.Parse(txtWidth.Text))
                    {
                        valid = false;
                        break;
                    }
                    else
                    {
                        newBoard.Add(line.ToCharArray());
                    }
                }
                if (valid)
                {
                    return newBoard.ToArray();
                }
            }

            wordList.Text = "The board size needs to match what was inputted";

            return null;
        }

        /// <summary>
        /// Builds the boggle wire data contract
        /// </summary>
        /// <param name="width">The width of the boggle board being solved</param>
        /// <param name="height">The width of the boggle board being solved</param>
        /// <param name="board">The boggle board to solve words in</param>
        /// <param name="minWordLength">The minimum length found words need to be</param>
        /// <returns></returns>
        private BoggleDataContract BuildBoggleContract(int width, int height, char[][] board, int minWordLength)
        {
            return new BoggleDataContract()
            {
                Board = board,
                Width = width,
                Height = height,
                MinWordSize = minWordLength
            };
        }
    }
}