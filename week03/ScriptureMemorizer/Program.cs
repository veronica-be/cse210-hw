using System;
// My program will let the user type any scripture they want rather than just have the only option of one.
// Will let the user edit how many words wants to hide at the start of the program.
//Let the user remember any text.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        //At the beginning I thought to make a list of all the data of the csv to itarate it
        //But it will last too much so to make it quicker I will
        //make many list divided by the volumes rather one superlarge.

        //get lists of each book
        //LIST OF LISTS OF ALL DATA
        List<int> indexesToSave = [4, 5, 14, 15, 16]; // volume, book, chapther, verse number , text

        ReadCSV volumes = new ReadCSV("lds-scriptures.csv");
        volumes.GetAllLines(indexesToSave, 1);

        //DIVIDING DATA BY VOLUMES

        List<List<string>> booksInBookMormon = volumes.GetFilterListByValue(0, "Book of Mormon");
        List<List<string>> booksInOldTestament = volumes.GetFilterListByValue(0, "Old Testament");
        List<List<string>> booksInNewTestament = volumes.GetFilterListByValue(0, "New Testament");
        List<List<string>> booksInDoctrineCovenants = volumes.GetFilterListByValue(0, "Doctrine and Covenants");
        List<List<string>> booksInPearlGreatPrice = volumes.GetFilterListByValue(0, "Pearl of Great Price");


        // menu (actions principal)
        string response;
        Scripture scripture = null;
        Reference reference = null;
        int hidePerTime = 0;
        string book = "";

        do
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine(" 1. Remember a Scripture");
            Console.WriteLine(" 2. Remember my own text");
            Console.WriteLine(" 3. Quit");
            Console.WriteLine();

            do
            {
                Console.Write("What woud you like to do? ");
                response = Console.ReadLine();

                if (response == "1" || response == "2")
                {
                    while (true)
                    {
                        Console.WriteLine("How many words do you want to hide per time? ");
                        Console.Write("> ");

                        string input = Console.ReadLine();

                        TryParseInt parser = new TryParseInt(input);

                        if (parser.TryParse() && input != "0")
                        {
                            hidePerTime = parser.GetNumber();
                            if (hidePerTime > 0)
                            {
                                break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Sorry, it must be a number (greater than 0). Try again");
                            Console.WriteLine();
                        }
                    }
                }


                if (response.Trim() == "1") // Main menu option 1: remember a scripture
                {
                    Console.WriteLine("From which volume: ");
                    Console.WriteLine(" 1. Book of Mormon");
                    Console.WriteLine(" 2. Old Testament");
                    Console.WriteLine(" 3. New Testament");
                    Console.WriteLine(" 4. Doctrine and Covenants");
                    Console.WriteLine(" 5. Pearl of Great Price");
                    Console.WriteLine();

                    do
                    {
                        Console.Write("Answer : ");
                        string answer = Console.ReadLine().Trim();

                        if (answer == "1" || answer == "2" || answer == "3" || answer == "4" || answer == "5")
                        {
                            // I decided to not put more try code. Cause it will take me much longer.
                            if (answer != "4")
                            {
                                Console.Write("Book: ");
                                book = Console.ReadLine().Trim().ToLower();
                            }
                            else if (answer == "4")
                            {
                                book = "doctrine and covenants";
                            }
                            Console.Write("Chapter: ");
                            int chapter = int.Parse(Console.ReadLine().Trim());
                            Console.Write("Verse: ");
                            int verse = int.Parse(Console.ReadLine().Trim());
                            Console.WriteLine();
                            string yesOrNo;

                            do
                            {
                                Console.Write("Do you want to add an end verse? (y/n) : ");
                                yesOrNo = Console.ReadLine().Trim().ToLower();

                                if (yesOrNo == "y" || yesOrNo == "yes")
                                {
                                    Console.Write("End verse: ");
                                    int endVerse = int.Parse(Console.ReadLine());
                                    if (answer == "1")//book of mormon
                                    {
                                        reference = new Reference(book, 1, chapter, 2, 3, verse, endVerse, 4, booksInBookMormon);
                                        scripture = new Scripture(reference);
                                    }
                                    else if (answer == "2")// old testament
                                    {
                                        reference = new Reference(book, 1, chapter, 2, 3, verse, endVerse, 4, booksInOldTestament);
                                        scripture = new Scripture(reference);
                                    }
                                    else if (answer == "3")// new testament
                                    {
                                        reference = new Reference(book, 1, chapter, 2, 3, verse, endVerse, 4, booksInNewTestament);
                                        scripture = new Scripture(reference);
                                    }
                                    else if (answer == "4")// D C
                                    {
                                        reference = new Reference(book, 1, chapter, 2, 3, verse, endVerse, 4, booksInDoctrineCovenants);
                                        scripture = new Scripture(reference);
                                    }
                                    else if (answer == "5")// Pearl of great price
                                    {
                                        reference = new Reference(book, 1, chapter, 2, 3, verse, endVerse, 4, booksInPearlGreatPrice);
                                        scripture = new Scripture(reference);
                                    }
                                    break;

                                }
                                else if (yesOrNo == "n" || yesOrNo == "no")
                                {
                                    if (answer == "1")//book of mormon
                                    {
                                        reference = new Reference(book, 1, chapter, 2, 3, verse, 4, booksInBookMormon);
                                        scripture = new Scripture(reference);
                                    }
                                    else if (answer == "2")// old testament
                                    {
                                        reference = new Reference(book, 1, chapter, 2, 3, verse, 4, booksInOldTestament);
                                        scripture = new Scripture(reference);
                                    }
                                    else if (answer == "3")// new testament
                                    {
                                        reference = new Reference(book, 1, chapter, 2, 3, verse, 4, booksInNewTestament);
                                        scripture = new Scripture(reference);
                                    }
                                    else if (answer == "4")// D C
                                    {
                                        reference = new Reference(book, 1, chapter, 2, 3, verse, 4, booksInDoctrineCovenants);
                                        scripture = new Scripture(reference);
                                    }
                                    else if (answer == "5")// Pearl of great price
                                    {
                                        reference = new Reference(book, 1, chapter, 2, 3, verse, 4, booksInPearlGreatPrice);
                                        scripture = new Scripture(reference);
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Sorry that is not a valid answer. (Type either 'y', 'yes' or 'n','no')");
                                    Console.WriteLine();
                                }
                            } while (true);


                        }
                        else
                        {
                            Console.WriteLine("Sorry that is not a valid answer. (Type either 1, 2, 3, 4 or 5)");
                            Console.WriteLine();
                            continue;
                        }

                        Console.Clear();
                        while (scripture.IsCompletelyHidden() == false)
                        {
                            Console.Clear();
                            scripture.HideRandomWords(hidePerTime);
                            Console.WriteLine(reference.GetCodeOfReference());
                            Console.WriteLine(scripture.GetDisplayText());
                            Console.WriteLine();
                            Console.WriteLine("To continue just press ENTER. Or if you want to QUIT type 'quit'.");
                            Console.Write("> ");
                            string userInput = Console.ReadLine().Trim().ToLower();
                            if (userInput == "quit")
                            {
                                Console.Clear();
                                break;
                            }
                        }
                        Console.Clear();

                    } while (response != "1" && response != "2" && response != "3" && response != "4" && response != "5");
                }


                else if (response.Trim() == "2") // If user wants to type something
                {
                    Console.WriteLine("Type what you want to remember.");
                    Console.Write("> ");
                    string textByUser = Console.ReadLine().Trim();

                    scripture = new Scripture(textByUser);
                    Console.Clear();
                    while (scripture.IsCompletelyHidden() == false)
                    {
                        Console.Clear();
                        scripture.HideRandomWords(hidePerTime);
                        Console.WriteLine(scripture.GetDisplayText());
                        Console.WriteLine();
                        Console.WriteLine("To continue just press ENTER. Or if you want to QUIT type 'quit'.");
                        Console.Write("> ");
                        string userInput = Console.ReadLine().Trim().ToLower();
                        if (userInput == "quit")
                        {
                            Console.Clear();
                            break;
                        }
                    }
                    Console.Clear();
                }


                else if (response.Trim() == "3") // Quit
                {
                    break;
                }


                else
                {
                    Console.WriteLine("Sorry that is not a valid answer. (1, 2 or 3)");
                    Console.WriteLine();
                }
            } while (response != "1" && response != "2" && response != "3");


        } while (response != "3");


    }
}