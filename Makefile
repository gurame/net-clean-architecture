build:
	dotnet build GymManagement.sln

tests_unit:
	dotnet test tests/GymManagement.Domain.Tests.Unit/GymManagement.Domain.Tests.Unit.csproj
	dotnet test tests/GymManagement.Application.Tests.Unit/GymManagement.Application.Tests.Unit.csproj

tests_subcutaneous:
	dotnet test tests/GymManagement.Application.Tests.Subcutaneous/GymManagement.Application.Tests.Subcutaneous.csproj

run:
	dotnet run --project src/GymManagement.Api/GymManagement.Api.csproj

zero-migration:
	if [ -d src/GymManagement.Infrastructure/Migrations ]; then rm -rf src/GymManagement.Infrastructure/Migrations; fi
	dotnet ef migrations add InitialCreate -p src/GymManagement.Infrastructure -s src/GymManagement.Api

run-migrations:
	if [ -f src/GymManagement.Api/GymManagement.db ]; then rm src/GymManagement.Api/GymManagement.db; fi
	dotnet ef database update -p src/GymManagement.Infrastructure -s src/GymManagement.Api