build:
	dotnet build GymManagement.sln

run:
	dotnet run --project src/GymManagement.Api/GymManagement.Api.csproj

set-zero-migration:
	dotnet ef migrations add InitialCreate -p src/GymManagement.Infrastructure -s src/GymManagement.Api

run-migrations:
	dotnet ef database update -p src/GymManagement.Infrastructure -s src/GymManagement.Api