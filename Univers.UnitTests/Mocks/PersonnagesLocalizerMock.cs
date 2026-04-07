using Microsoft.Extensions.Localization;
using Moq;
using Univers.Application.Dtos.Resources;

namespace Univers.UnitTests.Mocks;
public class PersonnagesLocalizerMock : Mock<IStringLocalizer<Personnages>>
{
	public PersonnagesLocalizerMock() 
	{
		SetupGet(l => l["Nom"]).Returns(new LocalizedString("Nom", "Nom"));
		SetupGet(l => l["DateNaissance"]).Returns(new LocalizedString("DateNaissance", "Date de naissance"));
	}
}