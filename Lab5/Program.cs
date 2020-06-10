using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp1
{
    class Punctuation
    {
        List<string> listOfPunct;
        public Punctuation()
        {
            listOfPunct = new List<string>();
            listOfPunct.Add(",");
        }
        public List<string> GetCollectionOfPunct
        {
            get { return listOfPunct; }
        }
    }
    class Letter
    {
        private char letter;
        public Letter(char letter)
        {
            this.letter = letter;
        }

        public string GetLetter
        {
            get { return letter.ToString(); }
        }
    }
    class Word
    {
        private string word;
        private Letter[] arrayOfLetters;
        //Конструктор, в котором заполняется массив Letter, где каждый элемент массива - это объект типа Letter
        public Word(string word)
        {
            this.word = word;
            arrayOfLetters = new Letter[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                Letter letter = new Letter(word[i]);
                arrayOfLetters[i] = letter;
            }
        }
        public int GetLengthArrayOfLetters
        {
            get { return arrayOfLetters.Length; }
        }

        public Letter GetLetter(int k)
        {
            return arrayOfLetters[k];
        }
    }
    class Sentence
    {
        private string sentence;
        private Word[] arrayOfWords;
        //Конструктор, в котором заполняется массив Word, где каждый элемент массива - это объект, который хранит в себе массив объектов типа Letter
        public Sentence(string sentence)
        {
            this.sentence = sentence;
            string[] sentenceArrayOfWords = sentence.Replace(", ", ",+").Split(new char[] { ' ', '+' }, StringSplitOptions.RemoveEmptyEntries);
            arrayOfWords = new Word[sentenceArrayOfWords.Length];
            for (int i = 0; i < sentenceArrayOfWords.Length; i++)
            {
                Word word = new Word(sentenceArrayOfWords[i]);
                arrayOfWords[i] = word;
            }
        }
        public int GetLengthArrayOfWords
        {
            get { return arrayOfWords.Length; }
        }
        public Word GetWord(int j)
        {
            return arrayOfWords[j];
        }
    }
    class Text
    {
        private string text;
        private Sentence[] arrayOfSentences;
        //Это тот текст, который получается в результате работы программы(то есть тот текст, который надо получить по заданию третьей лабы)
        private string resultText = "";
        //Конструктор, в котором заполняется массив Sentence, где каждый элемент массива - это объект, который хранит в себе массив объектов типа Word
        public Text(string text)
        {
            this.text = text;
            string[] textArrayOfSentences = text.Split(new char[] { '!', '?', '.' }, StringSplitOptions.RemoveEmptyEntries);
            arrayOfSentences = new Sentence[textArrayOfSentences.Length];
            for (int i = 0; i < textArrayOfSentences.Length; i++)
            {
                Sentence sentence = new Sentence(textArrayOfSentences[i]);
                arrayOfSentences[i] = sentence;
            }
            CreateNewText();
        }
        //Это метод, который выполняет задание третьей лабораторной(16 варик если че), только работает с типами классов
        private void CreateNewText()
        {
            //для каждого ИТОГО предложения
            for (int i = 0; i < arrayOfSentences.Length; i++)
            {
                //взяли ИТОЕ предложение
                Sentence helpSentence = arrayOfSentences[i];
                //для каждого ДЖИТОГО слова в ИТОМ предложении
                for (int j = 0; j < helpSentence.GetLengthArrayOfWords; j++)
                {
                    //взяли ДЖИТОЕ слово
                    Word helpWord = helpSentence.GetWord(j);
                    //будущее редактированное слово
                    string futureWord = "";
                    string lastLetter = helpWord.GetLetter(helpWord.GetLengthArrayOfLetters - 1).GetLetter;
                    int punctIndex = -1;
                    Punctuation punctuation = new Punctuation();
                    //для каждой КАТОЙ буквы в ДЖИТОМ слове в ИТОМ предложении
                    for (int k = 0; k < helpWord.GetLengthArrayOfLetters; k++)
                    {
                        if (punctuation.GetCollectionOfPunct.Contains(lastLetter))
                        {
                            punctIndex = punctuation.GetCollectionOfPunct.IndexOf(lastLetter);
                            lastLetter = helpWord.GetLetter(helpWord.GetLengthArrayOfLetters - 2).GetLetter;
                        }
                        if (helpWord.GetLetter(k).GetLetter != lastLetter)
                        {
                            futureWord += helpWord.GetLetter(k).GetLetter;
                        }
                    }
                    //заполняем результирующую строку
                    if (punctIndex != -1)
                        resultText += futureWord.Replace(punctuation.GetCollectionOfPunct[punctIndex], "") + lastLetter + punctuation.GetCollectionOfPunct[punctIndex] + " ";
                    else
                        resultText += futureWord + lastLetter + " ";
                }
            }
        }
        //получаем результирующую строку
        public string GetResultText
        {
            get { return resultText; }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //Начальный текст
            string myText = "Cccggg cccggg, cccggg cccggg, ggcggcccc. Hhhjjj hhhooo, LgggHg. Uuuffff Piihgiii!";
            Console.WriteLine(myText);
            //Инстанцируем класс текст
            Text inst = new Text(myText);
            string final = inst.GetResultText;

            Console.WriteLine(final);
            Console.ReadKey();
        }
    }
}
