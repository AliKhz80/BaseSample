using Domain.Enums;

namespace Application.Features.SampleModel.ViewModels;

public class SampleModelViewModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public GenderEnum? Gender { get; set; }
    public string Address { get; set; } = string.Empty;
}
