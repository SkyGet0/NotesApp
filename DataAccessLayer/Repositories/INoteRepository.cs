using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetAllAsync();
        Task<Note?> GetByIdAsync(int id);
        Task<Note> AddAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteAsync(int id);
        Task<IEnumerable<Note>> SearchAsync(string query);
        Task<IEnumerable<Note>> FilterAsync(bool? isImportant, DateTime? startDate);
    }
}