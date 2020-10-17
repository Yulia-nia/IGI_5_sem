﻿using ICourses.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICourses.Data.Interfaces
{
    public interface IVideo
    {
        void AddVideo(Video video);
        IEnumerable<Video> GetAllVideos();
        void DeleteVideo(Video video);
        void DeleteVideoById(int id);
        Video GetVideo(int id);
        void UpdateVideo(Video video);

    }
}