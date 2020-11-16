﻿using ICourses.Data.Interfaces;
using ICourses.Data.Models;
using ICourses.Data.Repositories;
using ICourses.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICourses.Services
{
    public class SubjectService : ISubjectService
    {
        ISubject _subjectRepository;

        public SubjectService(ISubject subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task AddSubject(Subject subject)
        {

            await _subjectRepository.AddSubject(subject);
        }

        public async Task DeleteSubject(Subject subject)
        {
            await _subjectRepository.DeleteSubject(subject);
        }

        public async Task DeleteSubjectById(Guid id)
        {
            await _subjectRepository.DeleteSubjectById(id);
        }

        public async Task<IEnumerable<Subject>> GetAllSubject()
        {
            return await _subjectRepository.GetAllSubject();
        }

        public async Task<IEnumerable<Course>> GetCourses(Subject subject)
        {
            return await _subjectRepository.GetCourses(subject);
        }

        public async Task<Subject> GetSubject(Guid id)
        {
            var subject = await _subjectRepository.GetSubject(id);
            return subject;
        }
    }
}