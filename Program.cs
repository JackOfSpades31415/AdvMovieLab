﻿using NLog;
string path = Directory.GetCurrentDirectory() + "\\nlog.config";
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Start!");

Movie movie = new Movie
{
    mediaId = 123,
    title = "Greatest Movie Ever, The (2023)",
     director = "Jeff Grissom",
    runningTime = new TimeSpan(2, 21, 23), //hours, minutes, seconds
    genres = { "Comedy", "Romance" }
};

Console.WriteLine(movie.Display());

Album album = new Album
{
    mediaId = 321,
    title = "Greatest Album Ever, The (2020)",
    artist = "Jeff's Awesome Band",
    recordLabel = "Universal Music Group",
    genres = { "Rock" }
};
Console.WriteLine(album.Display());

Book book = new Book
{
    mediaId = 111,
    title = "Super Cool Book",
    author = "Jeff Grissom",
    pageCount = 101,
    publisher = "",
    genres = { "Suspense", "Mystery" }
};
Console.WriteLine(book.Display());



logger.Info("End!");
