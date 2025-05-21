using AutoMapper;
using Moq;
using Project.Model;
using Project.Model.DTO;
using Project.Repository.Common;
using Xunit;

namespace Project.Service.Tests;

public class VehicleModelServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly VehicleModelService _service;

    public VehicleModelServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _service = new VehicleModelService(_unitOfWorkMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsPagedList()
    {
        var models = new List<VehicleModel> { new VehicleModel { Id = 1, Name = "Test", Abrv = "T", VehicleMakeId = 1, VehicleEngineTypeId = 1 } };
        var paged = new PagedList<VehicleModel>(models, 1, 1, 10);

        _unitOfWorkMock.Setup(x => x.VehicleModels.GetFilteredPagedAsync(null, It.IsAny<Func<IQueryable<VehicleModel>, IOrderedQueryable<VehicleModel>>>(), 1, 10))
            .ReturnsAsync(paged);

        _mapperMock.Setup(m => m.Map<List<VehicleModelDTO>>(models))
            .Returns(new List<VehicleModelDTO> { new VehicleModelDTO { Id = 1, Name = "Test", Abrv = "T", VehicleMakeId = 1, VehicleEngineTypeId = 1 } });
        
        var result = await _service.GetAllAsync(1, 10);
        
        Assert.NotNull(result);
        Assert.Single(result.Items);
        Assert.Equal(1, result.TotalCount);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsDTO_WhenExists()
    {
        var model = new VehicleModel { Id = 1, Name = "Test", Abrv = "T", VehicleMakeId = 1, VehicleEngineTypeId = 1 };

        _unitOfWorkMock.Setup(x => x.VehicleModels.GetByIdAsync(1)).ReturnsAsync(model);
        _mapperMock.Setup(m => m.Map<VehicleModelDTO>(model))
            .Returns(new VehicleModelDTO { Id = 1, Name = "Test", Abrv = "T", VehicleMakeId = 1, VehicleEngineTypeId = 1 });

        var result = await _service.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("Test", result.Name);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsNull_WhenNotFound()
    {
        _unitOfWorkMock.Setup(x => x.VehicleModels.GetByIdAsync(99)).ReturnsAsync((VehicleModel)null!);

        var result = await _service.GetByIdAsync(99);

        Assert.Null(result);
    }

    [Fact]
    public async Task CreateAsync_ReturnsDTO_WithId()
    {
        var dto = new VehicleModelDTO { Name = "Test", Abrv = "T", VehicleMakeId = 1, VehicleEngineTypeId = 1 };
        var entity = new VehicleModel { Id = 1, Name = "Test", Abrv = "T", VehicleMakeId = 1, VehicleEngineTypeId = 1 };

        _mapperMock.Setup(m => m.Map<VehicleModel>(dto)).Returns(entity);
        _unitOfWorkMock.Setup(x => x.VehicleModels.InsertAsync(entity)).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(x => x.SaveAsync()).ReturnsAsync(1);

        var result = await _service.CreateAsync(dto);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }
    
    // ne znam jel trebam napisati testove jos za Update i Delete?
}
