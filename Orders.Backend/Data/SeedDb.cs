
using Orders.Shared.Entities;

namespace Orders.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        public SeedDb(DataContext context) 
        { 
            _context= context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Tecnologia" });
                _context.Categories.Add(new Category { Name = "Mascotas" });
                _context.Categories.Add(new Category { Name = "Hogar" });
                _context.Categories.Add(new Category { Name = "Cosmeticos" });
                _context.Categories.Add(new Category { Name = "Licores" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountriesAsync()
        {
            if(!_context.Categories.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States =
                    [
                        new State()
                        {
                            Name = "Antioquia",
                            Cities =
                            [
                                new() { Name = "Medellin" },
                                new() { Name = "Itagul" },
                                new() { Name = "Envigado" },
                                new() { Name = "Bello" },
                                new() { Name = "Rionegro" },
                            ]
                        },
                        new State()
                        {
                            Name = "Bogota",
                            Cities =
                            [
                                new() { Name = "Usaquen" },
                                new() { Name = "Champinero" },
                                new() { Name = "Santa fe" },
                                new() { Name = "Useme" },
                                new() { Name = "Bosa" },
                            ]
                        },
                    ]
                });
                _context.Countries.Add(new Country
                {
                    Name = "Esados Unidos",
                    States =
                    [
                        new State()
                        {
                            Name = "Florida",
                            Cities =
                            [
                                new () { Name = "Orlando" },
                                new () { Name = "Miami" },
                                new () { Name = "Tampa" },
                                new () { Name = "Fort Lauderdale" },
                                new () { Name = "Key West" },
                            ]
                        },
                        new State()
                        {
                            Name = "Texas",
                            Cities =
                            [
                                new () { Name = "Houston" },
                                new () { Name = "San Antonio" },
                                new () { Name = "Dallas" },
                                new () { Name = "Austin" },
                                new () { Name = "El Paso" },
                            ]
                        },
                    ]
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
