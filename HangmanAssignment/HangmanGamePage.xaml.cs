using System;
using System.Collections.Generic;

namespace HangmanAssignment
{
    public partial class HangmanGamePage : ContentPage
    {
        
        List<string> words = new List<string>()
        {
            "hi",
            "my",
            "ace",
            "ran",
            "far",
            "ok"
        };

        string answer;
        string guessWord;
        int remainingAttempts;
        int amountOfErrors = 8;
        int currentImage=1; 
        private string hangmanImage;


        private string _spotlight;

        public string Spotlight
        {
            get { return _spotlight; }
            set { _spotlight = value;

                OnPropertyChanged();
            }
        }


        public string HangmanImage
        {
            get { return hangmanImage; }
            set
            {
                hangmanImage = value;
                OnPropertyChanged();
            }
        }

        public string GuessWord
        {
            get { return guessWord; }
            set
            {
                guessWord = value;
                OnPropertyChanged();

            }
        }

        public HangmanGamePage()
        {
            InitializeComponent();
            BindingContext = this;
            ResetGame(); 
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            char guess = Spotlight[0];
            Spotlight = ""; 

            bool isCorrect = false;

            char[] guessArr = guessWord.ToCharArray();

            for (int i = 0; i < answer.Length; i++)
            {
                if (guessWord[i] == '_' && answer[i] == guess)
                {
                    guessArr[i] = guess;
                    isCorrect = true;
                    break;
                }
            }
            GuessWord = new String(guessArr);

            if (!isCorrect)
            {
                amountOfErrors--;
                currentImage ++;
               
            }

            UpdatingUI();

            if (answer == guessWord) 
            { 
                DisplayAlert("Congratulations!", "You won!!!!!!", "HI");
                ResetGame();
            }
            else if (amountOfErrors > 8)
            {
                DisplayAlert("Sorry!", "You lost! The word was " + answer, "MY");
                ResetGame();
            }
        }


        private void UpdatingUI()
        {
           
            HangmanImage = "hang" + currentImage + ".png";


            turns.Text = (amountOfErrors > 0) ? "Turns remaining: " + amountOfErrors : "Game Over!";
        }


        private void ResetGame()
        {
            answer = words[new Random().Next(words.Count)]; 
            GuessWord = new string('_', answer.Length); 
            amountOfErrors = 8; 
            currentImage = 1; 
            UpdatingUI();
            remainingAttempts = amountOfErrors;
        }
    }
}