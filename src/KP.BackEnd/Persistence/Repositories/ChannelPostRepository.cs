using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Persistence.Repositories
{
    public class ChannelPostRepository : IChannelPostRepository
    {
        private readonly ApplicationDbContext _context;

        public ChannelPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<ChannelPost> Find(Guid id)
        {
            return await _context.ChannelPosts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ChannelPost> Find(Guid userId, Guid id)
        {
            return await _context.ChannelPosts.FirstOrDefaultAsync(p => p.Id == id);
        }
        
        public async Task<IEnumerable<ChannelPost>> GetRange(Guid supervisorId, Guid schoolClassId, int page, int count)
        {
            return await _context.ChannelPosts
                .Include(x => x.SchoolClass)
                .Where(x=> x.SchoolClassId ==schoolClassId && x.SchoolClass.SupervisorId == supervisorId)
                .Skip(page * count)
                .Take(count)
                .ToListAsync();
        }

        public async Task Add(ChannelPost channelPost)
        {
            await _context.ChannelPosts.AddAsync(channelPost);
        }
        
        public void Remove(ChannelPost channelPost)
        {
            _context.ChannelPosts.Remove(channelPost);
        }
    }
}