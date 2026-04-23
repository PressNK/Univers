namespace Univers.Domain.Entities;

public class UniversApiConfiguration
{
    public string BaseURL { get; set; }

    public string BoxOfficesURL => $"{BaseURL}/box-offices";

    public string FilmURL => $"{BaseURL}/films";
}