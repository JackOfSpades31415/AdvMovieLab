﻿using NLog;
string path = Directory.GetCurrentDirectory() + "\\nlog.config";
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Start!");

Console.WriteLine("Enter 1 to add movie.");
Console.WriteLine("Enter 2 to list movies.");
Console.WriteLine("Enter anything else to quit.");

String prompt = Console.ReadLine();
if (prompt == "1"){

    StreamWriter sw = new StreamWriter("movies.csv", true);
    Console.WriteLine("movie ID?");
    int movieID = 0;
    if (!int.TryParse(Console.ReadLine(), out movieID)){
        throw new Exception("Input Invalid.");
    }
    Console.WriteLine("Name of movie?");
    String movieName = Console.ReadLine();
    bool genreAsk = true;
    List<String> genres = new List<String>();
    char moreGenre;
    while(genreAsk){
        Console.WriteLine("What genre?");
        genres.Add(Console.ReadLine());
        Console.WriteLine("Another Genre? Y/N");
        if (!Char.TryParse(Console.ReadLine(), out moreGenre)){
        throw new Exception("Input Invalid.");
    }
            if(moreGenre == 'n'){
                genreAsk = false;
            }
            else if(moreGenre != 'y' || moreGenre != 'n'){
                logger.Error("Invalid input.");
            }
    }
    Console.WriteLine("Whose the Director?");
    String movieDirector = Console.ReadLine();
    Console.WriteLine("Enter the runtime (h:m:s)");
    String movieTime = Console.ReadLine();
    sw.WriteLine($"{movieID},{movieName},{movieDirector},{movieTime},{string.Join("|", genres)}"); 
    sw.Close();
}
else if(prompt == "2"){
         if(System.IO.File.Exists("movies.csv")){
        StreamReader sr = new StreamReader("movies.csv");
        while(!sr.EndOfStream){
            Console.WriteLine(sr.ReadLine());
        }
         }

}

string scrubbedFile = FileScrubber.ScrubMovies("movies.csv");
logger.Info(scrubbedFile);
MovieFile movieFile = new MovieFile(scrubbedFile);


logger.Info("End!");
