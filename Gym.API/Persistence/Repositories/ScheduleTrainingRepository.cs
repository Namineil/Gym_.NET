using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gym.API.Domain.Models;
using Gym.API.Domain.Repositories;
using Gym.API.Persistence.Contexts;

namespace Gym.API.Persistence.Repositories
{
    public class ScheduleTrainingRepository : BaseRepository, IScheduleTrainingRepository
    {
        public ScheduleTrainingRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(ScheduleTraining scheduleTraining)
        {
            await context.ScheduleTraining.AddAsync(scheduleTraining);
        }

        public async Task<ScheduleTraining> FindByIdAsync(int id)
        {
            return await context.ScheduleTraining.FindAsync(id);
        }

        public async Task<IEnumerable<ScheduleTraining>> ListAsync()
        {
            return await context.ScheduleTraining.ToListAsync();
        }

        public void Remove(ScheduleTraining scheduleTraining)
        {
            context.ScheduleTraining.Remove(scheduleTraining);
        }

        public void Update(ScheduleTraining scheduleTraining)
        {
            context.ScheduleTraining.Update(scheduleTraining);
        }
    }
}