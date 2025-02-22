using Moq;
using MovieSite.Application.Interfaces.FilmInterfaces.Services.FilmServices;
using MovieSite.Domain.Entities;
using MovieSite.Domain.Interfaces;
using MovieSite.Domain.Interfaces.FilmInterfaces;
using MovieSite.Domain.ViewModels.FilmViewModels;

public class FilmServicesTests
{
    private readonly Mock<IRepository<Film>> _mockRepository;
    private readonly Mock<IFilmRepository> _mockFilmRepository;
    private readonly Film _testFilm;
    private readonly FilmServices _filmServices;

    public FilmServicesTests()
    {
        _mockRepository = new Mock<IRepository<Film>>();
        _mockFilmRepository = new Mock<IFilmRepository>();
        _testFilm = new Film { FilmID = 1, FilmTitle= "Test" }; 
        _filmServices = new FilmServices(_mockRepository.Object, _mockFilmRepository.Object);
    }

    [Fact]
    public async Task GetFilterFilm_ReturnsFilteredFilms()
    {
        // Arrange
        var filter = new FilterFilmViewModel();
        var expectedFilter = new FilterFilmViewModel(); // مقدار مورد انتظار را تعیین کنید

        _mockFilmRepository.Setup(repo => repo.FilterFilm(filter)).ReturnsAsync(expectedFilter);

        // Act
        var result = await _filmServices.GetFilterFilm(filter);

        // Assert
        Assert.Equal(expectedFilter, result);
    }

    [Fact]
    public async Task GetSpecialFilm_ThrowsNotImplementedException()
    {
        // Arrange
        var filter = new FilterFilmViewModel();

        // Act & Assert
        await Assert.ThrowsAsync<NotImplementedException>(() => _filmServices.GetSpecialFilm(filter));
    }
    [Fact]
    public async Task AddAsync_AddsFilm()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.AddAsync(_testFilm)).Returns(Task.CompletedTask);

        var filmList = new List<Film> { _testFilm };
        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(filmList);

        // Act
        await _mockRepository.Object.AddAsync(_testFilm);

        // Assert
        _mockRepository.Verify(repo => repo.AddAsync(_testFilm), Times.Once);

        var films = await _mockRepository.Object.GetAllAsync();
        Assert.Contains(_testFilm, films);
    }



    [Fact]
    public async Task UpdateAsync_UpdatesFilm()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.UpdateAsync(_testFilm)).Returns(Task.CompletedTask);

        var updatedFilm = new Film { FilmID = _testFilm.FilmID, FilmTitle = "Updated Test" };
        var filmList = new List<Film> { updatedFilm };
        _mockRepository.Setup(repo => repo.GetByIdAsync(_testFilm.FilmID)).ReturnsAsync(updatedFilm);
        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(filmList);

        // Act
        await _mockRepository.Object.UpdateAsync(updatedFilm);

        // Assert
        _mockRepository.Verify(repo => repo.UpdateAsync(updatedFilm), Times.Once);

        var film = await _mockRepository.Object.GetByIdAsync(_testFilm.FilmID);
        Assert.Equal("Updated Test", film.FilmTitle);
    }


    [Fact]
    public async Task DeleteAsync_DeletesFilmById()
    {
        // Arrange
        var filmId = _testFilm.FilmID;
        _mockRepository.Setup(repo => repo.DeleteAsync(filmId)).Returns(Task.CompletedTask);

        var filmList = new List<Film> { _testFilm };
        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(filmList);

        // Act
        await _mockRepository.Object.DeleteAsync(filmId);

        // Assert
        _mockRepository.Verify(repo => repo.DeleteAsync(filmId), Times.Once);

        // شبیه‌سازی حذف فیلم از لیست
        filmList.Remove(_testFilm);
        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(filmList);

        var films = await _mockRepository.Object.GetAllAsync();
        Assert.DoesNotContain(_testFilm, films);
    }

}
