using AHY.ToDoAppNTier.Common.ResponseObjects;
using AHY.ToDoAppNTier.Dtos.WorkDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AHY.ToDoAppNTier.Business.Services.Abstract
{
    public interface IWorkService
    {
        Task<IResponse<List<WorkListDto>>> GetAll();
        Task<IResponse<WorkCreateDto>> Create(WorkCreateDto workCreateDTO);
        public Task<IResponse<IDto>> GetById<IDto>(int id);
        public Task<IResponse> Remove(int id);
        Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto);

    }
}
