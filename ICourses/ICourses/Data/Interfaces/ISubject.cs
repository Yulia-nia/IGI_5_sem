﻿using ICourses.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICourses.Data.Interfaces
{
    public interface ISubject
    {
        void AddSubject(Subject subject);
        IEnumerable<Subject> GetAllSubject();
        void DeleteSubject(Subject subject);
        void DeleteSubjectById(int id);
        Subject GetSubject(int id);
        void UpdateSubject(Subject subject);
        IEnumerable<Course> GetCourses(Subject subject);
    }
}