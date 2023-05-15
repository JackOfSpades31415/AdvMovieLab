﻿using NLog;
string path = Directory.GetCurrentDirectory() + "\\nlog.config";
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Start!");

Movie movie = new Movie
{
    mediaId = 123,
    title = "Greatest Movie Ever, The (2023)",
    genres = { "Comedy", "Romance" }
};

Console.WriteLine(movie.Display());

logger.Info("End!");
