namespace GymManagement.Application.Tests.Subcutaneous.Common;

[CollectionDefinition(CollectionName)]
public class MediatorFactoryCollection : ICollectionFixture<MediatorFactory>
{
    public const string CollectionName = "MediatorFactoryCollection";
}