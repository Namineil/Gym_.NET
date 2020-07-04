using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Gym.API.Domain.Models;
using Gym.API.Domain.Services;
using Gym.API.Resources;
using Gym.API.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Gym.API.Controllers
{
    [Authorize]
    [Route("/api/scheduleTraining")]
    public class ScheduleTrainingController : Controller
    {
        private readonly IScheduleTrainingService scheduleTrainingService;
        private readonly IMapper mapper;
        public ScheduleTrainingController(IScheduleTrainingService scheduleTrainingService, IMapper mapper)
        {
            this.scheduleTrainingService = scheduleTrainingService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ScheduleTrainingResource>> GetAllAsync() 
        {
            var scheduleTraining = await scheduleTrainingService.ListAsync();
            var resource = mapper.Map<IEnumerable<ScheduleTraining>,IEnumerable<ScheduleTrainingResource>>(scheduleTraining);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveScheduleTrainingResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var scheduleTraining = mapper.Map<SaveScheduleTrainingResource, ScheduleTraining>(resource);
            var result = await scheduleTrainingService.SaveAsync(scheduleTraining);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var scheduleTrainingResource = mapper.Map<ScheduleTraining, ScheduleTrainingResource>(result.ScheduleTraining);
            return Ok(scheduleTrainingResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveScheduleTrainingResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var scheduleTraining = mapper.Map<SaveScheduleTrainingResource, ScheduleTraining>(resource);
            var result = await scheduleTrainingService.UpdateAsync(id, scheduleTraining);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var scheduleTrainingResource = mapper.Map<ScheduleTraining, ScheduleTrainingResource>(result.ScheduleTraining);
            return Ok(scheduleTrainingResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await scheduleTrainingService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var scheduleTrainingResource = mapper.Map<ScheduleTraining, ScheduleTrainingResource>(result.ScheduleTraining);
            return Ok(scheduleTrainingResource);
        }
    }
}