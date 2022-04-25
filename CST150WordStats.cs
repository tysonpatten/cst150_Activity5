using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity5
{
    public partial class WordStats : Form
    {
        

        public WordStats()
        {
            InitializeComponent();
        }

        // when button1 is clicked, open a file and put the words into an array


        private void button1_Click(object sender, EventArgs e)
        {

            // opens a file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // reads the file
                string fileName = openFileDialog1.FileName;
                string[] words = System.IO.File.ReadAllLines(fileName);

                // put the words into an array
                string[] wordsArray = words;

                // make the words lowercase
                for (int i = 0; i < wordsArray.Length; i++)
                {
                    wordsArray[i] = wordsArray[i].ToLower();
                }

                // go through the array and find the longest word
                string longestWord = "";
                for (int i = 0; i < wordsArray.Length; i++)
                {
                    if (wordsArray[i].Length > longestWord.Length)
                    {
                        longestWord = wordsArray[i];
                    }
                }

                textBox1.Text = longestWord; //displays result
            

            // finds the word with the most vowels

            int mostVowels = 0; //counter
                string mostVowelsWord = "";
                for (int i = 0; i < wordsArray.Length; i++) //iterates through words
                {
                    int vowels = 0;
                    for (int j = 0; j < wordsArray[i].Length; j++) // iterates through letters
                    {
                        if (wordsArray[i][j] == 'a' || wordsArray[i][j] == 'e' || wordsArray[i][j] == 'i' || wordsArray[i][j] == 'o' || wordsArray[i][j] == 'u')
                        {
                            vowels++; // increments with each vowel
                        }
                    }
                    if (vowels > mostVowels)
                    {
                        mostVowels = vowels;
                        mostVowelsWord = wordsArray[i]; // compares to current most vowel word and replaces if needed
                    }
                }

                textBox2.Text = mostVowelsWord; //displays result


                // find the first word alphabetically

                string firstWord = "zzzzz"; // starter word to compare to
                for (int i = 0; i < wordsArray.Length; i++) // iterates through words
                {
                    if (wordsArray[i].CompareTo(firstWord) < 0) // if the current word is before
                    {
                        firstWord = wordsArray[i]; // then swap the firstWord
                    }
                }

                textBox3.Text = firstWord; // displays result

                // finds the last word alphabetically

                string lastWord = ""; // starter word
                for (int i = 0; i < wordsArray.Length; i++) // iterates through words
                {
                    if (wordsArray[i].CompareTo(lastWord) > 0) // opposite of the above
                    {
                        lastWord = wordsArray[i]; // swaps if needed
                    }
                }

                textBox4.Text = lastWord; // displays result

            }

            // write results to a new file "results.txt"

            System.IO.File.WriteAllText(@"results.txt", "longest word: " + textBox1.Text + "\n" + "most vowels: " 
                + textBox2.Text + "\n" + "first word alphabetically: " + textBox3.Text + "\n" + "last word alphabetically: " + textBox4.Text);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
