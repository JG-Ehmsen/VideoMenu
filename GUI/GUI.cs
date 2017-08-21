using BE;
using BLL;
using System;
using System.Collections.Generic;
using static System.Console;

namespace GUI
{
    class GUI
    {
        public BLLFacade BLLFacade = new BLLFacade();

        public GUI()
        {
            MainMenu();
        }

        private void MainMenu()
        {

            while (true)
            {
                WriteLine("What would you like to do?");
                WriteLine("----------------------------------------------------------------------------------------------");
                List<string> items = new List<string>();
                items.Add("Add videos.");
                items.Add("View videos.");
                items.Add("Edit vidos.");
                items.Add("Delete videos.");
                items.Add("Exit");

                int index = 1;
                foreach (var i in items)
                {
                    WriteLine(index + " : " + i);
                    index++;
                }
                switch (ReadLine())
                {
                    case "1":
                        AddMenu();
                        break;
                    case "2":
                        ViewMenu();
                        break;
                    case "3":
                        EditMenu();
                        break;
                    case "4":
                        DeleteMenu();
                        break;
                    case "5":
                        ExitMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Please write a valid option.");
                        break;
                }
            }

        }


        private void AddMenu()
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine("Welcome to the add menu.");
            WriteLine("Here you can add new videos.");
            WriteLine("----------------------------------------------------------------------------------------------");
            while (true)
            {
                WriteLine("Actions:");
                WriteLine("1 - Add new video | 2 - Go back");
                switch (ReadLine())
                {
                    case "1":
                        WriteLine("Enter video name:");
                        string name = ReadLine();
                        WriteLine("Enter video author:");
                        string author = ReadLine();
                        WriteLine("Enter genre:");
                        string genre = ReadLine();
                        WriteLine("Thank you! The new video has been added.");
                        Video tempVid = new Video(name);
                        tempVid.Author = author;
                        tempVid.Genre = genre;
                        BLLFacade.addVideo(tempVid);
                        ReadLine();
                        AddMenu();
                        break;
                    case "2":
                        Clear();
                        MainMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid input.");
                        break;
                }
            }
        }

        private void ViewMenu()
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine("Welcome to the view menu.");
            WriteLine("Here you can view all your videos.");
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine("Actions:");
            WriteLine("1 - Search | 2 - Exit");

            WriteLine("Current videos: ");
            foreach (var vid in BLLFacade.getVideos())
            {
                WriteLine(vid.ToString());
            }
            while (true)
            {
                switch (ReadLine())
                {
                    case "1":
                        SearchMenu();
                        break;
                    case "2":
                        Clear();
                        MainMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid input. Write 1 to search, or 2 to exit.");
                        break;
                }
            }
        }

        private void SearchMenu()
        {
            List<Video> filteredVideos = new List<Video>();
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine("You can now search for specific videos.");
            WriteLine("Enter a search parameter!");
            WriteLine("----------------------------------------------------------------------------------------------");
            string filter = ReadLine().ToLower();
            foreach (var i in BLLFacade.getVideos())
            {
                if (i.ToString().ToLower().Contains(filter))
                {
                    filteredVideos.Add(i);
                }
            }

            WriteLine("Results: ");
            WriteLine();

            foreach (var i in filteredVideos)
            {
                WriteLine(i.ToString());
            }
            WriteLine();
            while (true)
            {
                WriteLine("Actions:");
                WriteLine("1 - Search again | 2 - Go back");
                switch (ReadLine())
                {
                    case "1":
                        SearchMenu();
                        break;
                    case "2":
                        ViewMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid input.");
                        break;
                }
            }
        }

        private void EditMenu()
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine("Welcome to the edit menu.");
            WriteLine("Here you can edit all our videos. NOT IMPLEMENTED.");
            WriteLine("----------------------------------------------------------------------------------------------");
            while (true)
            {
                WriteLine("Actions:");
                WriteLine("1 - Edit video | 2 - Go back");
                WriteLine();
                WriteLine("Current Videos:");
                foreach (var vid in BLLFacade.getVideos())
                {
                    WriteLine(vid.ToString());
                }
                switch (ReadLine())
                {
                    case "1":
                        Edit();
                        break;

                    case "2":
                        Clear();
                        MainMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid input.");
                        break;
                }
            }
        }

        private void Edit()
        {
            if (BLLFacade.getVideos().Count == 0)
            {
                WriteLine("There are no videos to edit.");
                ReadLine();
                Clear();
                MainMenu();
            }
            while (true)
            {
                WriteLine("Enter ID of video to edit.");
                if (!int.TryParse(ReadLine(), out int ID))
                {
                    WriteLine("Invalid input. Whole numbers only.");
                }
                else
                {
                    bool match = false;
                    foreach (var i in BLLFacade.getVideos())
                    {
                        if (i.ID == ID)
                        {
                            match = true;
                            WriteLine("Editing " + i.ToString());
                            WriteLine("Enter title:");
                            i.Title = ReadLine();
                            WriteLine("Enter author:");
                            i.Author = ReadLine();
                            WriteLine("Enter genre:");
                            i.Genre = ReadLine();
                            WriteLine("Video has been edited!");
                            ReadLine();
                            EditMenu();
                        }

                    }
                    if (!match)
                    {
                        WriteLine("No match found.");
                        ReadLine();
                        EditMenu();
                    }
                }
            }
        }

        private void DeleteMenu()
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine("Welcome to the delete menu.");
            WriteLine("Here you can delete any of your videos.");
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine();

            while (true)
            {
                WriteLine("Actions:");
                WriteLine("1 - Delete a video | 2 - Go back");
                WriteLine();
                WriteLine("Current Videos:");
                foreach (var vid in BLLFacade.getVideos())
                {
                    WriteLine(vid.ToString());
                }
                switch (ReadLine())
                {
                    case "1":
                        Delete();
                        break;

                    case "2":
                        Clear();
                        MainMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid input.");
                        break;
                }
            }
        }

        private void Delete()
        {
            if (BLLFacade.getVideos().Count == 0)
            {
                WriteLine("There are no videos to delete.");
                ReadLine();
                Clear();
                MainMenu();
            }
            while (true)
            {
                WriteLine("Enter ID of video to delete.");
                int ID;
                bool valid = int.TryParse(ReadLine(), out ID);
                if (!valid)
                {
                    WriteLine("Invalid input. Whole numbers only.");
                }
                else
                {
                    bool match = false;
                    Video vid = null;
                    foreach (var i in BLLFacade.getVideos())
                    {
                        if (i.ID == ID)
                        {
                            match = true;
                            vid = i;
                        }

                    }
                    if (match)
                    {
                        WriteLine("Deleting " + vid.ToString());
                        BLLFacade.removeVideo(vid);
                        ReadLine();
                        DeleteMenu();
                    }
                    else
                    {
                        WriteLine("No match found.");
                    }
                }
            }
        }

        private void ExitMenu()
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine("Woops, you're about to exit the program. Is that right?");
            WriteLine("Actions:");
            WriteLine("Y | N");
            WriteLine("----------------------------------------------------------------------------------------------");
            while (true)
            {
                switch (ReadLine().ToLower())
                {
                    case "y":
                        Environment.Exit(0);
                        break;
                    case "n":
                        MainMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid input. Write Y to exit or N to cancel.");
                        break;
                }
            }

        }
    }
}