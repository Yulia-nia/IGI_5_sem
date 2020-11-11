﻿using ICourses.Data.Interfaces;
using ICourses.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICourses.Data.Repositories
{
    public class ModuleRepository : IModule
    {
        private readonly CourseDbContext _appDbContext;

        public ModuleRepository(CourseDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task AddModule(Module module)
        {
            await _appDbContext.Modules.AddAsync(module);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteModule(Module module)
        {
            _appDbContext.Modules.Remove(module);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteModuleById(Guid id)
        {
            var module = await _appDbContext.Modules.Where(x => x.Id == id).FirstOrDefaultAsync();
            _appDbContext.Modules.Remove(module);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Module> GetModule(Guid id)
        {
            return await _appDbContext.Modules.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Module>> GetAllModules()
        {
            return await _appDbContext.Modules.ToListAsync();
        }

        public async Task UpdateModule(Module module)
        {
            _appDbContext.Modules.Update(module);
            await _appDbContext.SaveChangesAsync();
        }

        //public int GetCourseId(string name)
        //{
        //    _appDbContext.Modules.Where(_ => Equals(_.Course.Name, name));
        //    return id;
        //}

        public Guid GetCourseId(string name)
        {
            return _appDbContext.Modules.FirstOrDefault(_ => Equals(_.Course.Name, name)).Id;
        }


        public IEnumerable<TextMaterial> GetTextMaterials(Module module)
        {
            var text = _appDbContext.Modules.Where(c => c.Id == module.Id)?.SelectMany(c => c.TextMaterials).ToList();
            return text.AsReadOnly(); ;
        }
        public IEnumerable<Video> GetVideos(Module module)
        {
            var videos = _appDbContext.Modules.Where(c => c.Id == module.Id)?.SelectMany(c => c.Videos).ToList();
            return videos.AsReadOnly(); ;
        }
    



        //public IEnumerable<Comment> GetComments(Module module)
        //{
        //    var comment = _appDbContext.Modules.Where(c => c.Id == module.Id)?.SelectMany(c => c.Comments).ToList();
        //    return comment.AsReadOnly();
        //}

        /*public void AddComment(string userId, Comment comment)
        {
            var user = _appDbContext.Users.FirstOrDefault(c => c.Id.Equals(userId));
            
            _appDbContext.Comments.Add(comment);
            _appDbContext.SaveChanges();
           
        }*/
    }
}
