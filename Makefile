run:
	dotnet run --project BlazorWeb/Server



watch:
	dotnet watch --no-hot-reload --project BlazorWeb/Server




build:
	dotnet build BlazorWeb/Server -c Release


dbmigrate:
	dotnet ef migrations add MyFirstMigration --project BlazorWeb.DAL
	


