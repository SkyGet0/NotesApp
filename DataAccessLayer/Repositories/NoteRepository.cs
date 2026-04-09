using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer.Contexts;

namespace DataAccessLayer.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;

        public NoteRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Note>> GetAllAsync() =>
            await _context.Notes.ToListAsync();
        
        public async Task<Note?> GetByIdAsync(int id) =>
            await _context.Notes.FindAsync(id);

        public async Task<Note> AddAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task UpdateAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var note = await GetByIdAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Note>> SearchAsync(string query) =>
            await _context.Notes
                .Where(n => n.Title.Contains(query) || n.Content.Contains(query))
                .ToListAsync();
        
        public async Task<IEnumerable<Note>> FilterAsync(bool? isImportant, DateTime? startDate)
        {
            var query = _context.Notes.AsQueryable();

            if (isImportant.HasValue)
                query = query.Where(n => n.IsImportant == isImportant.Value);

            if (startDate.HasValue)
                query = query.Where(n => n.CreatedAt == startDate.Value);

            return await query.ToListAsync();
        }
    }
}