namespace WASTecnologia.Musicas.AcessoDados.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WASTecnologia.Musicas.AcessoDados.EF.Context.MusicasDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WASTecnologia.Musicas.AcessoDados.EF.Context.MusicasDbContext context)
        {
            
        }
    }
}
