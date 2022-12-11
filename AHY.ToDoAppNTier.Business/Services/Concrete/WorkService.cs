using AHY.ToDoAppNTier.Business.Extensions;
using AHY.ToDoAppNTier.Business.Services.Abstract;
using AHY.ToDoAppNTier.Common.ResponseObjects;
using AHY.ToDoAppNTier.DataAccess.UnitOfWork;
using AHY.ToDoAppNTier.Dtos.WorkDtos;
using AHY.ToDoAppNTier.Entities.Domains;
using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AHY.ToDoAppNTier.Business.Services.Concrete
{
    public class WorkService : IWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<WorkCreateDto> _createDtoValidator;
        private readonly IValidator<WorkUpdateDto> _updateDtoValidator;
        public WorkService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<WorkCreateDto> createDtoValidator, IValidator<WorkUpdateDto> updateDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto workCreateDTO)
        {
            var validationResult = _createDtoValidator.Validate(workCreateDTO);
            if (validationResult.IsValid)
            {
                await _unitOfWork.GetRepository<Work>().Create(_mapper.Map<Work>(workCreateDTO));
                await _unitOfWork.SaveChanges();
                return new Response<WorkCreateDto>(ResponseType.Success, workCreateDTO);
            }
            else
            {
                return new Response<WorkCreateDto>(ResponseType.ValidationError, workCreateDTO, validationResult.ConvertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<WorkListDto>>> GetAll()
        {
            var data = _mapper.Map<List<WorkListDto>>(await _unitOfWork.GetRepository<Work>().GetAll());
            return new Response<List<WorkListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _unitOfWork.GetRepository<Work>().Find(id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id}'ye ait data bulunamadı.");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _unitOfWork.GetRepository<Work>().GetByFilter(x => x.Id == id);
            if (removedEntity != null)
            {
                _unitOfWork.GetRepository<Work>().Remove(removedEntity);
                await _unitOfWork.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id}'ye ait data bulunamadı.");
        }

        public async Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);

            if (result.IsValid)
            {
                var unChangedEntity = await _unitOfWork.GetRepository<Work>().Find(dto.Id);
                if (unChangedEntity != null)
                {
                    _unitOfWork.GetRepository<Work>().Update(_mapper.Map<Work>(dto), unChangedEntity);
                    await _unitOfWork.SaveChanges();
                    return new Response<WorkUpdateDto>(ResponseType.Success, dto);
                }
                else
                {
                    return new Response<WorkUpdateDto>(ResponseType.NotFound, $"{dto.Id}'ye ait data bulunamadı.");
                }
            }
            else
            {

                return new Response<WorkUpdateDto>(ResponseType.ValidationError, dto, result.ConvertToCustomValidationError());
            }
        }
    }
}
