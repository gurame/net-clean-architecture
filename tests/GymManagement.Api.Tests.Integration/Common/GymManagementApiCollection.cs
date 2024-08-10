namespace GymManagement.Api.Tests.Integration.Common;

[CollectionDefinition(CollectionName)]
public class GymManagementApiFactoryCollection : ICollectionFixture<GymManagementApiFactory>
{
    public const string CollectionName = "GymManagementApiFactoryCollection";
}